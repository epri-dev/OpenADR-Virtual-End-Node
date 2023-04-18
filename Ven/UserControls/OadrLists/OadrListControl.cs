using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.OadrLists
{
    public partial class OadrListControl : UserControl
    {
        public string NewItem { get; set; }

        public List<string> RemovedItems { get; set; }

        public event EventHandler OnAddItem;
        public event EventHandler OnRemoveItems;

        public OadrListControl()
        {
            InitializeComponent();
        }

        [ComVisible(true), Browsable(true)]
        public string ListLabel
        {
            get => groupBox1.Text;
            set => groupBox1.Text = value;
        }
        
        public void AddItem(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            var item = new ListViewItem(value);
            NewItem = value;
            lvItems.Items.Add(item);

            OnAddItem?.Invoke(this, null);
        }
        
        private void OnAddClick(object sender, EventArgs e)
        {
            var item = txtItem.Text;
            txtItem.Text = string.Empty;
            AddItem(item);
        }
        
        private void OnRemoveToolStripMenuItemClick(object sender, EventArgs e)
        {
            var removedItems = new List<string>();
            while (lvItems.SelectedItems.Count > 0)
            {
                var item = lvItems.SelectedItems[0];
                var subItem = item.SubItems[0].Text;
                removedItems.Add(subItem);
                lvItems.Items.Remove(item);
            }

            RemovedItems = removedItems;
            OnRemoveItems?.Invoke(this, null);
        }
    }
}
