using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls
{
    public class WebLogView
    {
        private const string MessageListId = "message_list";
        private const int StatusIndex = 0;
        private const int TimeIndex = 1;
        private const int MessageIndex = 2;
        
        private readonly WebBrowser _browser;
        private readonly string _messageTemplate;
        private readonly string[] _statusClass = { "info", "warning", "error" };
        readonly int _maxMessages = 1000;

        public WebLogView(WebBrowser browser)
        {
            _browser = browser ?? throw new ArgumentNullException(nameof(browser));

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Oadr.Ven.UserControls.Log.MessageLog.html");
            if (stream != null)
            {
                _browser.DocumentText = new StreamReader(stream).ReadToEnd();
            }
            stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Oadr.Ven.UserControls.Log.MessageTemplate.html");
            if (stream != null)
            {
                _messageTemplate = new StreamReader(stream).ReadToEnd();
            }
        }

        public void LogMessage(string message, LogMessageStatus status)
        {
            if (_browser.Document == null)
            {
                throw new Exception("The MessageLog.html was not loaded correctly");
            }
            var messageList = _browser.Document.GetElementById(MessageListId);
            var htmlMessage = _browser.Document.CreateElement("li");
            htmlMessage.InnerHtml = _messageTemplate;
            htmlMessage.Document.GetElementsByTagName("div")[MessageIndex].InnerText = message;
            htmlMessage.Document.GetElementsByTagName("div")[TimeIndex].InnerText = DateTime.Now.ToString("ddd MMM dd yyyy hh:mm:ss tt");
            htmlMessage.SetAttribute("title", message);
            htmlMessage.GetElementsByTagName("div")[StatusIndex].SetAttribute("className", "status " + _statusClass[(int)status]);
            htmlMessage.GetElementsByTagName("div")[StatusIndex].SetAttribute("title", _statusClass[(int)status].ToUpper());

            if (messageList.Children.Count == 0)
            {
                messageList.AppendChild(htmlMessage);
            }
            else
            {
                messageList.Children[0].InsertAdjacentElement(HtmlElementInsertionOrientation.BeforeBegin, htmlMessage);
            }

            if (messageList.Children.Count > _maxMessages)
            {
                messageList.Children[messageList.Children.Count - 1].OuterHtml = string.Empty;
            }
        }
        
        public void Clear()
        {
            var messageList = _browser.Document.GetElementById(MessageListId);
            messageList.InnerHtml = string.Empty;
        }
    }
}
