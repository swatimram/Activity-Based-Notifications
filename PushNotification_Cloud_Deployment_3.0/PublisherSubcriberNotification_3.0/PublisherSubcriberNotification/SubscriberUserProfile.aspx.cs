using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class SubscriberUserProfile : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.ApplicationUserBLL objApplicationUserBLL = null;
        PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    GetUserProfileDetails();
                    lblMsg.Text = "";
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void GetUserProfileDetails()
        {
            try
            {
                objApplicationUserBLL = new BLL.ApplicationUserBLL();
                objApplicationUserDTO = new DTO.ApplicationUserDTO();
                objApplicationUserDTO.EmailId = Session["EmailId"].ToString();
                objApplicationUserDTO.UserType = Session["UserType"].ToString();
                DataTable loaddata = new DataTable();
                loaddata = objApplicationUserBLL.GetUserProfile_Details(objApplicationUserDTO);
                if (loaddata.Rows.Count > 0)
                {
                    txtEmailID.Text = loaddata.Rows[0][0].ToString();
                    txtMobileNo.Text = loaddata.Rows[0][1].ToString();
                    txtAddress.Text = loaddata.Rows[0][2].ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objApplicationUserBLL = new BLL.ApplicationUserBLL();
                objApplicationUserDTO = new DTO.ApplicationUserDTO();
                objApplicationUserDTO.EmailId = txtEmailID.Text;
                objApplicationUserDTO.MobileNo = txtMobileNo.Text;
                objApplicationUserDTO.Address = txtAddress.Text;
                string Result = objApplicationUserBLL.UpdateUserProfile(objApplicationUserDTO);
                if (Result != "0")
                {
                    GetUserProfileDetails();
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Profile Updation Successfully";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Profile Updation Fail";
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}