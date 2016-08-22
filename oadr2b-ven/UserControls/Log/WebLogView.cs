//////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2014, Electric Power Research Institute (EPRI)
// All rights reserved.
//
// oadr2b-ven, oadrlib, and oadr-test ("this software") are licensed under the 
// BSD 3-Clause license.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice, this 
//     list of conditions and the following disclaimer.
//     
//   * Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//     
//   * Neither the name of EPRI nor the names of its contributors may 
//     be used to endorse or promote products derived from this software without 
//     specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oadr2b_ven.UserControls.Log
{
    public class WebLogView
    {
        private WebBrowser m_browser;

        private const string MESSAGE_LIST_ID = "message_list";

        private const int STATUS_INDEX = 0;
        private const int TIME_INDEX = 1;
        private const int MESSAGE_INDEX = 2;
        
        private string m_messageTemplate;

        public enum eWebLogMessageStatus
        {
            INFO,
            WARNING,
            ERROR            
        }

        private string[] STATUS_CLASS = { "info", "warning", "error" };

        int m_maxMessages = 1000;

        /******************************************************************************/

        public WebLogView(WebBrowser browser)
        {
            m_browser = browser;

            System.IO.Stream stream;

            stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("oadr2b_ven.UserControls.Log.MessageLog.html");

            m_browser.DocumentText = new StreamReader(stream).ReadToEnd();

            stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("oadr2b_ven.UserControls.Log.MessageTemplate.html");

            m_messageTemplate = new StreamReader(stream).ReadToEnd();
        }

        /******************************************************************************/

        public void logMessage(string message, eWebLogMessageStatus status)
        {
            HtmlElement messageList = m_browser.Document.GetElementById(MESSAGE_LIST_ID);

            HtmlElement htmlMessage = m_browser.Document.CreateElement("li");

            htmlMessage.InnerHtml = m_messageTemplate;

            htmlMessage.Document.GetElementsByTagName("div")[MESSAGE_INDEX].InnerText = message;
            htmlMessage.Document.GetElementsByTagName("div")[TIME_INDEX].InnerText = DateTime.Now.ToString("ddd MMM dd yyyy hh:mm:ss tt");

            htmlMessage.SetAttribute("title", message);
 
            htmlMessage.GetElementsByTagName("div")[STATUS_INDEX].SetAttribute("className", "status " + STATUS_CLASS[(int)status]);
            htmlMessage.GetElementsByTagName("div")[STATUS_INDEX].SetAttribute("title", STATUS_CLASS[(int)status].ToUpper());

            if (messageList.Children.Count == 0)
                messageList.AppendChild(htmlMessage);
            else
                messageList.Children[0].InsertAdjacentElement(HtmlElementInsertionOrientation.BeforeBegin, htmlMessage);


            if (messageList.Children.Count > m_maxMessages)
                messageList.Children[messageList.Children.Count - 1].OuterHtml = "";
        }

        /******************************************************************************/

        public void clear()
        {
            HtmlElement messageList = m_browser.Document.GetElementById(MESSAGE_LIST_ID);

            messageList.InnerHtml = "";
        }
    }
}
