using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class SubscriberViewAllPublisherDetails : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.CategoryBLL objCategoryBLL = null;

        PublisherSubcriberNotification.BLL.PublishContentSubscribeBLL objPublishSubscribeBLL = null;
        PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishSubscribeDTO = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    LoadCategory();
                    Table1.Visible = false;
                }

                LoadPublishContent();

            }
            catch (Exception ex)
            {

            }
        }
        private void LoadCategory()
        {
            objCategoryBLL = new BLL.CategoryBLL();
            ddlCategory.DataSource = objCategoryBLL.GetCategory();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, "--Select Category--");
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Table1.Visible = true;
                LoadPublishContent();

            }
            catch (Exception ex)
            {

            }
        }
        private void LoadPublishContent()
        {
            objPublishSubscribeBLL =new BLL.PublishContentSubscribeBLL();
            objPublishSubscribeDTO = new DTO.PublishContentSubscribeDTO();
            objPublishSubscribeDTO.CategoryId = int.Parse(ddlCategory.SelectedItem.Value);

            DataTable tab = new DataTable();
            tab = objPublishSubscribeBLL.GetPublishContentCount_Publisher(objPublishSubscribeDTO);
            Table1.Controls.Clear();
            lblMsg.Text = "";
            if (tab.Rows.Count > 0)
            {
                TableRow hr = new TableRow();
                TableHeaderCell hc1 = new TableHeaderCell();
                TableHeaderCell hc2 = new TableHeaderCell();
                TableHeaderCell hc3 = new TableHeaderCell();
                TableHeaderCell hc4 = new TableHeaderCell();
                //TableHeaderCell hc5 = new TableHeaderCell();
                //TableHeaderCell hc6 = new TableHeaderCell();


                hc1.Text = "Publisher Name";
                hr.Cells.Add(hc1);
                hc2.Text = "Publish Content Count";
                hr.Cells.Add(hc2);
                hc3.Text = "View";
                hr.Cells.Add(hc3);
                hc4.Text = "Subscribe";
                hr.Cells.Add(hc4);
                Table1.Rows.Add(hr);
                for (int i = 0; i < tab.Rows.Count; i++)
                {

                    TableRow row = new TableRow();
                    Label lblName = new Label();
                    //lblTitle.Width = 100;
                    lblName.Text = tab.Rows[i]["Name"].ToString();
                    TableCell Name = new TableCell();
                    Name.Controls.Add(lblName);


                    Label lblPublishCount = new Label();
                    //lblSubTitle.Width = 100;
                    lblPublishCount.Text = tab.Rows[i]["PublishCount"].ToString();
                    TableCell PublishCount = new TableCell();
                    PublishCount.Controls.Add(lblPublishCount);

                   

                    LinkButton View = new LinkButton();
                    View.Text = "View";
                    View.ID = "lnkView" + i.ToString();
                    View.CommandArgument = tab.Rows[i]["UserId"].ToString();
                    View.Click += new EventHandler(View_Click);

                    TableCell ViewCell = new TableCell();
                    ViewCell.Controls.Add(View);

                    LinkButton Subscribe = new LinkButton();
                    Subscribe.Text = "Subscribe";
                    Subscribe.ID = "lnkSubscribe" + i.ToString();
                    Subscribe.CommandArgument = tab.Rows[i]["UserId"].ToString();
                    Subscribe.Click += new EventHandler(Subscribe_Click);

                    TableCell SubscribeCell = new TableCell();
                    SubscribeCell.Controls.Add(Subscribe);

                    
                    row.Controls.Add(Name);
                    row.Controls.Add(PublishCount);
                    row.Controls.Add(ViewCell);
                    row.Controls.Add(SubscribeCell);
                    Table1.Controls.Add(row);

                }
            }
            else
            {
                lblMsg.Text = "No Record Found";
            }
        }

        void Subscribe_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            objPublishSubscribeDTO = new DTO.PublishContentSubscribeDTO();
            LinkButton lnk = (LinkButton)sender;
            objPublishSubscribeDTO.UserID = int.Parse(lnk.CommandArgument.ToString());
            Response.Redirect("SubscriberRatePublisher.aspx?PublisherUserID=" + objPublishSubscribeDTO.UserID);
        }

        void View_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            objPublishSubscribeDTO = new DTO.PublishContentSubscribeDTO();
            LinkButton lnk = (LinkButton)sender;
            objPublishSubscribeDTO.UserID = int.Parse(lnk.CommandArgument.ToString());
            Response.Redirect("SubscriberViewIndividualPublisheContent.aspx?UserID=" + objPublishSubscribeDTO.UserID);
        }
    }
}