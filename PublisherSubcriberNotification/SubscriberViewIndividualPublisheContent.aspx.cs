using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class SubscriberViewIndividualPublisheContent : System.Web.UI.Page
    {
        PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO = null;
        PublisherSubcriberNotification.BLL.PublishContentSubscribeBLL objPublishContentSubscribeBLL = null;

        static int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["UserID"] != null)
            {
                UserID = int.Parse(Request.QueryString["UserID"].ToString());
                LoadPublishContent();
            }
        }

        private void LoadPublishContent()
        {
            objPublishContentSubscribeBLL = new BLL.PublishContentSubscribeBLL();
            objPublishContentSubscribeDTO = new DTO.PublishContentSubscribeDTO();
            objPublishContentSubscribeDTO.UserID = UserID;

            DataTable tab = new DataTable();
            tab = objPublishContentSubscribeBLL.GetPublishContent_PublisherID(objPublishContentSubscribeDTO);
            Table1.Controls.Clear();
            lblMsg.Text = "";
            if (tab.Rows.Count > 0)
            {
                TableRow hr = new TableRow();
                TableHeaderCell hc1 = new TableHeaderCell();
                TableHeaderCell hc2 = new TableHeaderCell();
                TableHeaderCell hc3 = new TableHeaderCell();
                TableHeaderCell hc4 = new TableHeaderCell();
                TableHeaderCell hc5 = new TableHeaderCell();
                //TableHeaderCell hc6 = new TableHeaderCell();


                hc1.Text = "Title";
                hr.Cells.Add(hc1);
                hc2.Text = "Sub Title";
                hr.Cells.Add(hc2);
                hc3.Text = "Created Date";
                hr.Cells.Add(hc3);
                hc4.Text = "Category Name";
                hr.Cells.Add(hc4);
                hc5.Text = "View";
                hr.Cells.Add(hc5);
                //hc6.Text = "Delete";
                //hr.Cells.Add(hc6);
                Table1.Rows.Add(hr);
                for (int i = 0; i < tab.Rows.Count; i++)
                {

                    //Table1.BorderWidth = 4;
                    //Table1.GridLines = GridLines.Both;
                    ////Table1.BackColor = System.Drawing.Color.White;
                    //Table1.BorderColor = System.Drawing.Color.Black;
                    //Table1.ForeColor = System.Drawing.Color.Black;

                    TableRow row = new TableRow();

                    Label lblTitle = new Label();
                    //lblTitle.Width = 100;
                    lblTitle.Text = tab.Rows[i]["Title"].ToString();
                    TableCell Title = new TableCell();
                    Title.Controls.Add(lblTitle);


                    Label lblSubTitle = new Label();
                    //lblSubTitle.Width = 100;
                    lblSubTitle.Text = tab.Rows[i]["SubTitle"].ToString();
                    TableCell SubTitle = new TableCell();
                    SubTitle.Controls.Add(lblSubTitle);

                    Label lblDate = new Label();
                    //lblDate.Width = 50;
                    lblDate.Text = tab.Rows[i]["CreateDate"].ToString();
                    TableCell date = new TableCell();
                    date.Controls.Add(lblDate);

                    Label lblCategory = new Label();
                    //lblDate.Width = 50;
                    lblCategory.Text = tab.Rows[i]["CategoryName"].ToString();
                    TableCell Category = new TableCell();
                    Category.Controls.Add(lblCategory);

                    LinkButton View = new LinkButton();
                    View.Text = "View";
                    View.ID = "lnkView" + i.ToString();
                    //View.Attributes.Add("data-toggle", "modal");
                    //View.Attributes.Add("data-target", "#myModal");
                    View.CommandArgument = tab.Rows[i]["PublishContentID"].ToString();
                    View.Click += new EventHandler(View_Click);

                    TableCell ViewCell = new TableCell();
                    ViewCell.Controls.Add(View);

                    


                    //row.Controls.Add(courseid);
                    row.Controls.Add(Title);
                    row.Controls.Add(SubTitle);
                    row.Controls.Add(date);
                    row.Controls.Add(Category);
                    row.Controls.Add(ViewCell);
                    Table1.Controls.Add(row);

                }
            }
            else
            {
                lblMsg.Text = "No Record Found";
            }
        }

        void View_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            objPublishContentSubscribeDTO = new DTO.PublishContentSubscribeDTO();
            LinkButton lnk = (LinkButton)sender;
            objPublishContentSubscribeDTO.PublishContentID = int.Parse(lnk.CommandArgument.ToString());
            Response.Redirect("SubscriberViewPublishContent.aspx?PublishContentId=" + objPublishContentSubscribeDTO.PublishContentID);
        }
    }
}