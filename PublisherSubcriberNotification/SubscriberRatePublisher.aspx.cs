using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class SubscriberRatePublisher : System.Web.UI.Page
    {
        static Int64 PublisherUserID;
        PublisherSubcriberNotification.BLL.PublishContentSubscribeBLL objPublishSubscribeBLL = null;
        PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishSubscribeDTO = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["PublisherUserID"] != null)
                {
                    PublisherUserID = int.Parse(Request.QueryString["PublisherUserID"].ToString());
                    lblMsg.Text = "";
                    LoadData();
                }
            }
        }
        public void LoadData()
        {
            try
            {
                objPublishSubscribeBLL = new BLL.PublishContentSubscribeBLL();
                objPublishSubscribeDTO = new DTO.PublishContentSubscribeDTO();

                objPublishSubscribeDTO.PublisherID = PublisherUserID;
                objPublishSubscribeDTO.EmailID = Session["EmailId"].ToString();
                DataTable tab = new DataTable();
                tab = objPublishSubscribeBLL.GetPublishRating_PublisherUserID_EmailId(objPublishSubscribeDTO);
                txtRating.Text = tab.Rows[0]["Rating"].ToString();
                btnSubmit.Text = "Update";
            }
            catch
            { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string Result;
                objPublishSubscribeBLL = new BLL.PublishContentSubscribeBLL();
                objPublishSubscribeDTO = new DTO.PublishContentSubscribeDTO();

                objPublishSubscribeDTO.PublisherID = PublisherUserID;
                objPublishSubscribeDTO.EmailID = Session["EmailId"].ToString();
                objPublishSubscribeDTO.Rate = int.Parse(txtRating.Text);
                if (btnSubmit.Text == "Update")
                {
                    Result = objPublishSubscribeBLL.UpdateSubscriberRatePublisher(objPublishSubscribeDTO);
                    if (Result == "1")
                    {
                        txtRating.Text = "";
                        btnSubmit.Text = "Submit";
                        Response.Redirect("SubscriberDashBoard.aspx");
                    }
                    else if (Result == "0")
                    {
                        lblMsg.Text = "Publisher Rated Error";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    Result = objPublishSubscribeBLL.SubscriberRatePublisher(objPublishSubscribeDTO);
                    if (Result == "1")
                    {
                        txtRating.Text = "";
                        Response.Redirect("SubscriberDashBoard.aspx");
                    }
                    else if (Result == "2")
                    {
                        lblMsg.Text = "Publisher Rated Already";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }

            }
            catch
            {
 
            }
        }
    }
}