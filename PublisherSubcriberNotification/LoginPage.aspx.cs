using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublisherSubcriberNotification
{
    public partial class LoginPage1 : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.ApplicationUserBLL objApplicationUserBLL = new BLL.ApplicationUserBLL();
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
            objApplicationUserDTO = new DTO.ApplicationUserDTO();
            try
            {
                objApplicationUserDTO.Name = txtUserName.Text;
                objApplicationUserDTO.Password = txtPassword.Text;
                objApplicationUserDTO.UserType = ddlUserType.SelectedItem.Text;
                objApplicationUserDTO.EmailId = txtEmailID.Text;
                objApplicationUserDTO.MobileNo = txtMobileNo.Text;
                objApplicationUserDTO.Address = txtAddress.Text;
                objApplicationUserDTO.DeviceId = txtDeviceId.Value;
                string result = objApplicationUserBLL.CreateApplicationUser(objApplicationUserDTO);
                if (result == "1")
                {
                    txtUserName.Text = txtPassword.Text = txtEmailID.Text = txtMobileNo.Text = txtAddress.Text = "";
                    ddlUserType.SelectedIndex = 0;
                }
                else
                {
 
                }
            }
            catch(Exception ex)
            {
 
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            objApplicationUserDTO = new DTO.ApplicationUserDTO();
            try
            {
                objApplicationUserDTO.EmailId = txtLoginEmail.Text;
                objApplicationUserDTO.UserType =ddlLoginUserType.SelectedItem.Text;
                objApplicationUserDTO.Password = txtLoginPassword.Text;
                Session["EmailId"] = txtLoginEmail.Text;
                Session["Password"] = txtLoginPassword.Text;
                Session["UserType"] = ddlLoginUserType.SelectedItem.Text;
                if (objApplicationUserBLL.GetAdminLogin(objApplicationUserDTO))
                {
                    switch (ddlLoginUserType.SelectedItem.Text)
                    {
                        case "Admin": 
                            Response.Redirect("DashBoard.aspx");
                            break;
                        case "Publisher":
                            Response.Redirect("PublisherDashBoard.aspx");
                            break;
                        case "Subscriber":
                            Response.Redirect("SubscriberDashBoard.aspx");
                            break;
                    }
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Invalid UserName/Password";
                }
            }
            catch (Exception ex)
            { 
            }
        }
    }
}