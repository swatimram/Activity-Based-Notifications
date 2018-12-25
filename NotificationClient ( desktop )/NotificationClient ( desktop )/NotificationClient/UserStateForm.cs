using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
namespace NotificationClient
{
    public partial class UserStateForm : Form
    {

        Thread th;
        public UserStateForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            int secs = (int)(GetIdle.GetIdleTime() / 1000);
            TxtIdle.Text = secs.ToString();
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            Program.obj.UpdateMachineStatus(Program.Email, 0);
            if (th != null)
                th.Abort();

            for (int findex = 0; findex < Application.OpenForms.Count; findex++)
                Application.OpenForms[findex].Close();

            timer1.Enabled = false;
            Application.ExitThread();
        }

        private void UserStateForm_Load(object sender, System.EventArgs e)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;
            lblUser.Text = Program.Email;
            th = new Thread(new ThreadStart(Send));
            th.Start();
        }

        private void ShowNotification(string message)
        {
            this.WindowState = FormWindowState.Minimized;
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipTitle = message;
            notifyIcon.BalloonTipText = "You have just minimized the application." +
                                        Environment.NewLine +
                                        "Right-click on the icon for more options.";

            notifyIcon.ShowBalloonTip(5000);
        }

        private void Send()
        {
            while (th.IsAlive)
            {
                DataTable recs = Program.obj.Get(Program.Email);
                if (recs.Rows.Count > 0)
                {
                    for (int r = 0; r < recs.Rows.Count; r++)
                    {
                        string pid = recs.Rows[r]["PublishContentId"].ToString();
                        string sid = recs.Rows[r]["SubNotificationId"].ToString();
                        if (int.Parse(TxtIdle.Text) < int.Parse(TxtThreshold.Text)) // notify on mac
                        {
                            ShowNotification("You have a new published data");
                            if( Program.PubList.Contains(pid) == false )
                                Program.PubList.Add(pid);  // maintain q to view all
                        }
                        else     // notify on mobile 
                        {
                            string[] devices = Program.DeviceId.Split(',');
                            for (int i = 0; i < devices.Length; i++)
                                GCMAlert.Send("New content published-" + pid, devices[i]);
                        }
                        Program.obj.UpdateStatus(sid);
                    }
                }
            }
        }

        private void UserStateForm_Resize(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void Notify(object sender, System.EventArgs e)
        {

        }

        private void activeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void closeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Program.obj.UpdateMachineStatus(Program.Email , 0);
            if (th != null)
                th.Abort();

            for (int findex = 0; findex < Application.OpenForms.Count; findex++)
                Application.OpenForms[findex].Close();

            timer1.Enabled = false;
            Application.ExitThread();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new ViewNotifications()).ShowDialog();
        }
    }
}
