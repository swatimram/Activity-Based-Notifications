using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NotificationClient
{
    public partial class ViewNotifications : Form
    {
        public ViewNotifications()
        {
            InitializeComponent();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstPubs.SelectedIndices.Count > 0)
            {
                string pid = lstPubs.GetItemText(lstPubs.SelectedItem);
                Program.PubList.Remove(pid);  // remove from data structure
                lstPubs.Items.RemoveAt(lstPubs.SelectedIndex);  // remove from user interface as well
            }
        }

        private void PubList_DoubleClick(object sender, EventArgs e)
        {
            if (lstPubs.SelectedIndices.Count > 0)
            {
                string pid = lstPubs.GetItemText(lstPubs.SelectedItem);
                System.Diagnostics.Process.Start("http://njsempire.com/psn/SubscriberViewPublishContent.aspx?PublishContentId=" + pid);
            }
        }

        private void ViewNotifications_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.PubList.Count; i++)
                lstPubs.Items.Add(Program.PubList[i]);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            lstPubs.Items.Clear();
            Program.PubList.Clear();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

      
    }
}
