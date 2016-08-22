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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using oadrlib.lib.oadr2a;
using oadrlib.lib.helper;
using System.Reflection;
using System.IO;
using oadr2b_ven.UserControls.Log;

namespace oadr2b_ven.UserControls
{
    public partial class ucLog : UserControl
    {
        private Dictionary<ListViewItem, OadrRequest> m_messages = new Dictionary<ListViewItem, OadrRequest>();

        private int m_maxEntries = 1000;

        private WebLogView m_webLogView;

        /******************************************************************************/

        public ucLog()
        {
            InitializeComponent();

            listView1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);

            m_webLogView = new WebLogView(webBrowser1);
        }

        /******************************************************************************/

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = listView1.SelectedItems[0];

            OadrRequest request = m_messages[lvi];

            txtRequestXML.Text = request.requestBody;
            txtResponseXML.Text = request.responseBody;
        }

        /******************************************************************************/

        public void addOadrMessage(OadrRequest request, bool autoScroll = true)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                lock (listView1)
                {
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString());

                    lvi.SubItems.Add(request.responseTime.ToString());

                    lvi.SubItems.Add(request.requestType);
                    lvi.SubItems.Add(request.responseType);

                    //lvi.SubItems.Add(request.distributeEvent.eiResponse.responseCode.ToString());
                    //lvi.SubItems.Add(request.distributeEvent.eiResponse.responseDescription);
                    lvi.SubItems.Add(request.eiResponseCode.ToString());
                    lvi.SubItems.Add(request.eiResponseDescription);

                    listView1.Items.Add(lvi);

                    m_messages.Add(lvi, request);

                    if (autoScroll)
                    {
                        lvi.Selected = true;
                        listView1.EnsureVisible(lvi.Index);
                    }

                    if (listView1.Items.Count > m_maxEntries)
                    {
                        lvi = listView1.Items[0];

                        m_messages.Remove(lvi);
                        listView1.Items.Remove(lvi);
                    }
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /******************************************************************************/

        public void clearMessages()
        {

            MethodInvoker mi = new MethodInvoker(delegate
            {
                lock (listView1)
                {
                    listView1.Items.Clear();
                    m_messages.Clear();

                    txtRequestXML.Text = "";
                    txtResponseXML.Text = "";                    
                }

                lock (m_webLogView)
                {
                    m_webLogView.clear();
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /******************************************************************************/

        public void addSystemMessage(string message, oadr2b_ven.UserControls.Log.WebLogView.eWebLogMessageStatus status)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                lock (m_webLogView)
                {
                    m_webLogView.logMessage(message, status);
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }
    }
}
