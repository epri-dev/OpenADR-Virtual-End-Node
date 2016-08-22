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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oadr2b_ven.UserControls.OadrLists
{
    public partial class ucOadrList : UserControl
    {
        public event EventHandler OnAddItem;
        public event EventHandler OnRemoveItems;

        public string NewItem { get; set; }
        public List<string> RemovedItems { get; set; }

        public ucOadrList()
        {
            InitializeComponent();
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public string ListLabel
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }

        /**********************************************************/

        public void addItem(string item)
        {
            if (item == null || item == "")
                return;

            ListViewItem lvi = new ListViewItem(item);

            NewItem = item;
           
            lvItems.Items.Add(lvi);

            if (OnAddItem != null)
                OnAddItem(this, null);
        }

        /**********************************************************/

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text;

            txtItem.Text = "";

            addItem(item);
        }

        /**********************************************************/

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> removedItems = new List<string>();

            while (lvItems.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvItems.SelectedItems[0];
                string item = lvi.SubItems[0].Text;

                removedItems.Add(item);

                lvItems.Items.Remove(lvi);
            }

            RemovedItems = removedItems;

            if (OnRemoveItems != null)
                OnRemoveItems(this, null);
        }

        /**********************************************************/
    }
}
