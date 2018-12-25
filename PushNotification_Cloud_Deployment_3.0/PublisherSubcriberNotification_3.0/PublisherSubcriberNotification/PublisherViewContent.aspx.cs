using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class PublisherViewContent : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.CategoryBLL objCategoryBLL = null;
        PublisherSubcriberNotification.BLL.PublishContentBLL objPublishBLL = null;
        PublisherSubcriberNotification.DTO.PublishContentDTO objPublishDTO = null;

        
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
            objPublishBLL = new BLL.PublishContentBLL();
            objPublishDTO = new DTO.PublishContentDTO();
            objPublishDTO.CategoryID = Int64.Parse(ddlCategory.SelectedItem.Value);
            objPublishDTO.EmailId = Session["EmailId"].ToString();

            DataTable tab = new DataTable();
            tab = objPublishBLL.GetPublishContent_User(objPublishDTO);
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


                hc1.Text = "Title";
                hr.Cells.Add(hc1);
                hc2.Text = "Sub Title";
                hr.Cells.Add(hc2);
                hc3.Text = "Created Date";
                hr.Cells.Add(hc3);
                hc4.Text = "View";
                hr.Cells.Add(hc4);
                //hc5.Text = "Edit";
                //hr.Cells.Add(hc5);
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
                    row.Controls.Add(ViewCell);
                    //row.Controls.Add(EditCell);
                    //row.Controls.Add(Deletecell);
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
            objPublishDTO = new DTO.PublishContentDTO();
            LinkButton lnk = (LinkButton)sender;
            //lnk.Attributes.Add("data-toggle", "modal");
            //lnk.Attributes.Add("data-target", "#myModal");
            objPublishDTO.PublishContentID = int.Parse(lnk.CommandArgument.ToString());
            DataTable tab = new DataTable();
            tab = objPublishBLL.GetPublishContent_ID(objPublishDTO);
            Session["PublishContentTitle"] = tab.Rows[0]["Title"].ToString();
            Session["PublishContentSubTitle"] = tab.Rows[0]["SubTitle"].ToString();
            Session["PublishContentDescp"] = tab.Rows[0]["Description"].ToString();
            Response.Redirect("PublishContentDetailsView.aspx?PublishContentId=" + objPublishDTO.PublishContentID);
            //lblPublicContent.Text = Server.HtmlDecode((tab.Rows[0][0]).ToString());
        }
    }
}