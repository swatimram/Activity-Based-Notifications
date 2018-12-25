using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublisherSubcriberNotification
{
    public partial class AdminChangePassword : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.ApplicationUserBLL objApplicationUserBLL = null;
        PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                { 
                    lblMsg.Text = "";
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objApplicationUserBLL = new BLL.ApplicationUserBLL();
                objApplicationUserDTO = new DTO.ApplicationUserDTO();
                objApplicationUserDTO.EmailId = Session["EmailId"].ToString();
                objApplicationUserDTO.Password = txtNewPassword.Text;
                string Result = objApplicationUserBLL.ChangePassword(objApplicationUserDTO);
                if (Result == "True")
                {
                    txtPassword.Text = txtNewPassword.Text = txtConPassword.Text = "";
                    lblMsg.Text = "Password Reset Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Password Reset Fail";
                }
            }
            catch (Exception ex)
            {
 
            }

        }
    }
}