using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class SubscriberViewPublishContent : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.CategoryBLL objCategoryBLL = null;
        PublisherSubcriberNotification.BLL.PublishContentBLL objPublishBLL = null;
        PublisherSubcriberNotification.DTO.PublishContentDTO objPublishDTO = null;

        PublisherSubcriberNotification.BLL.PublishContentSubscribeBLL objPublishSubscribeBLL = null;
        PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishSubscribeDTO = null;

        static Int64 PublishContentId;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable tab = new DataTable();
            objPublishBLL = new BLL.PublishContentBLL();
            objPublishDTO = new DTO.PublishContentDTO();
            PublishContentId = Int64.Parse(Request.QueryString["PublishContentId"]);
            objPublishDTO.PublishContentID = PublishContentId;
            tab = objPublishBLL.GetPublishContent_ID(objPublishDTO);
            Session["PublishContentTitle"] = tab.Rows[0]["Title"].ToString();
            Session["PublishContentSubTitle"] = tab.Rows[0]["SubTitle"].ToString();
            Session["PublishContentDescp"] = tab.Rows[0]["Description"].ToString();
        }

        protected void lnkSubscribe_Click(object sender, EventArgs e)
        {
            objPublishSubscribeDTO = new DTO.PublishContentSubscribeDTO();
            objPublishSubscribeBLL = new BLL.PublishContentSubscribeBLL();
            DataTable tabUserID = new DataTable();
            objPublishSubscribeDTO.PublishContentID = PublishContentId;
            tabUserID = objPublishSubscribeBLL.GetUserID_PublishID(objPublishSubscribeDTO);
            objPublishSubscribeDTO.UserID = int.Parse(tabUserID.Rows[0]["UserID"].ToString());
            Response.Redirect("SubscriberRatePublisher.aspx?PublisherUserID=" + objPublishSubscribeDTO.UserID);
        }
    }
}