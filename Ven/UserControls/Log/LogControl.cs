using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Oadr.Library;

namespace Oadr.Ven.UserControls.Log
{
    public partial class LogControl : UserControl
    {
        private const int MaxEntries = 1000;

        private readonly Dictionary<ListViewItem, OadrRequest> _messages = new Dictionary<ListViewItem, OadrRequest>();
        private readonly WebLogView _webLogView;

        public LogControl()
        {
            InitializeComponent();

            lvLogs.SelectedIndexChanged += OnLogsSelectedIndexChanged;
            _webLogView = new WebLogView(webBrowser1);
        }

        private void OnLogsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLogs.SelectedItems.Count == 0)
            {
                return;
            }

            var item = lvLogs.SelectedItems[0];
            var request = _messages[item];

            txtRequestXML.Text = request.RequestBody;
            txtResponseXML.Text = request.ResponseBody;
        }
        
        public void AddOadrMessage(OadrRequest request, bool autoScroll = true)
        {
            var mi = new MethodInvoker(delegate
            {
                lock (lvLogs)
                {
                    var item = new ListViewItem(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    item.SubItems.Add(request.ResponseTime.ToString(CultureInfo.InvariantCulture));
                    item.SubItems.Add(request.RequestType);
                    item.SubItems.Add(request.ResponseType);
                    item.SubItems.Add(request.EiResponseCode.ToString());
                    item.SubItems.Add(request.EiResponseDescription);
                    lvLogs.Items.Add(item);
                    _messages.Add(item, request);

                    if (autoScroll)
                    {
                        item.Selected = true;
                        lvLogs.EnsureVisible(item.Index);
                    }

                    if (lvLogs.Items.Count > MaxEntries)
                    {
                        item = lvLogs.Items[0];

                        _messages.Remove(item);
                        lvLogs.Items.Remove(item);
                    }
                }
            });

            Invoke(mi);
        }
        
        public void ClearMessages()
        {
            var mi = new MethodInvoker(delegate
            {
                lock (lvLogs)
                {
                    lvLogs.Items.Clear();
                    _messages.Clear();
                    txtRequestXML.Text = string.Empty;
                    txtResponseXML.Text = string.Empty;                    
                }
                lock (_webLogView)
                {
                    _webLogView.Clear();
                }
            });

            Invoke(mi);
        }
        
        public void AddSystemMessage(string message, LogMessageStatus status)
        {
            var mi = new MethodInvoker(delegate
            {
                lock (_webLogView)
                {
                    _webLogView.LogMessage(message, status);
                }
            });

            Invoke(mi);
        }

        private void Invoke(MethodInvoker mi)
        {
            // BeginInvoke only needs to be called if we're trying to update the UI from a thread that did not create it.
            if (InvokeRequired)
            {
                BeginInvoke(mi);
            }
            else
            {
                mi.Invoke();
            }
        }
    }
}
