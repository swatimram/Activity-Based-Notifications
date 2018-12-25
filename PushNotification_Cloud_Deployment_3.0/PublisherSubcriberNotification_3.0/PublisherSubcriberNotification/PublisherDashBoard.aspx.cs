using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class PublisherDashBoard : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.ApplicationUserBLL objApplicationuserBLL = null;
        PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO = null;

        PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO = null;
        PublisherSubcriberNotification.BLL.PublishContentSubscribeBLL objPublishContentSubscribeBLL = null;



        protected void Page_Load(object sender, EventArgs e)
        {
            objApplicationuserBLL = new BLL.ApplicationUserBLL();
            objApplicationUserDTO = new DTO.ApplicationUserDTO();
            try
            {
                objApplicationUserDTO.EmailId = Session["EmailId"].ToString();
                string count = objApplicationuserBLL.GetTotalUser_Pub_Sub_Publisher(objApplicationUserDTO);
                lblTotalUsers.Text = count.Split('&')[0];
                lblPublisherCount.Text = count.Split('&')[1];
                lblOverallPublishContentCount.Text = count.Split('&')[2];
                lblTotalPublishContent.Text = count.Split('&')[3];

                objPublishContentSubscribeBLL = new BLL.PublishContentSubscribeBLL();
                objPublishContentSubscribeDTO = new DTO.PublishContentSubscribeDTO();
                objPublishContentSubscribeDTO.EmailID = Session["EmailId"].ToString();

                DataTable tab = new DataTable();
                tab = objPublishContentSubscribeBLL.GetPublishContent_Top_5(objPublishContentSubscribeDTO);
                rptImages.DataSource = tab;
                rptImages.DataBind();

                DataTable tab1 = new DataTable();
                tab1 = objPublishContentSubscribeBLL.GetPublishRating_Top_5(objPublishContentSubscribeDTO);
                rptrating.DataSource = tab1;
                rptrating.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
}