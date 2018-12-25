using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace NotificationClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            bool res = Regex.IsMatch(TxtEmail.Text, @"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$");
            if (!res)
            {
                MessageBox.Show("Invalid mailid format", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Program.obj = new Db();
                if (Program.obj.IsValid(TxtEmail.Text, TxtPassword.Text))
                {
                    Program.obj.UpdateMachineStatus(TxtEmail.Text , 1);
                    Program.Email = TxtEmail.Text;
                    this.Hide();
                    UserStateForm frm = new UserStateForm();
                    frm.Show();
                }
                else
                    MessageBox.Show("Invalid authentication", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Please check internet connection or contact network administrator", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
