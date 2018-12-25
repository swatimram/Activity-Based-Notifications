using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublisherSubcriberNotification
{
    public partial class DashBoard : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.ApplicationUserBLL objApplicationuserBLL = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            objApplicationuserBLL = new BLL.ApplicationUserBLL();
            try
            {
                string count = objApplicationuserBLL.GetTotalUser_Pub_Sub();
                lblTotalUsers.Text = count.Split('&')[0];
                lblPublisherCount.Text = count.Split('&')[1];
                lblSubscriberCount.Text = count.Split('&')[2];
                lblTotalPublishContent.Text = count.Split('&')[3];
            }
            catch (Exception ex)
            {
 
            }
        }
    }
}