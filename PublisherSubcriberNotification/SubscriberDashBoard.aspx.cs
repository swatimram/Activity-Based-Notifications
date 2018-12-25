using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class SubscriberDashBoard : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.ApplicationUserBLL objApplicationuserBLL = null;
        PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            objApplicationuserBLL = new BLL.ApplicationUserBLL();
            objApplicationUserDTO = new DTO.ApplicationUserDTO();
            try
            {
                objApplicationUserDTO.EmailId = Session["EmailId"].ToString();
                string count = objApplicationuserBLL.GetTotalUser_Pub_Sub_Subscriber(objApplicationUserDTO);
                lblTotalUsers.Text = count.Split('&')[0];
                lblPublisherCount.Text = count.Split('&')[1];
                lblOverallPublishContentCount.Text = count.Split('&')[2];
                lblTotalSubscribe.Text = count.Split('&')[3];

                //objPublishContentSubscribeBLL = new BLL.PublishContentSubscribeBLL();
                //objPublishContentSubscribeDTO = new DTO.PublishContentSubscribeDTO();
                //objPublishContentSubscribeDTO.EmailID = Session["EmailId"].ToString();

                //DataTable tab = new DataTable();
                //tab = objPublishContentSubscribeBLL.GetPublishContent_Top_5(objPublishContentSubscribeDTO);
                //rptImages.DataSource = tab;
                //rptImages.DataBind();

                DataTable tab1 = new DataTable();
                tab1 = objApplicationuserBLL.GetSubscriberRating_Top_5(objApplicationUserDTO);
                rptrating.DataSource = tab1;
                rptrating.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
}