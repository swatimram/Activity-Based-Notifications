using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class ActivePublishContent : System.Web.UI.Page
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
            tab = objPublishBLL.GetPublishContent_Deactive(objPublishDTO);
            Table1.Controls.Clear();
            lblMsg.Text = "";
            if (tab.Rows.Count > 0)
            {
                TableRow hr = new TableRow();
                TableHeaderCell hc1 = new TableHeaderCell();
                TableHeaderCell hc2 = new TableHeaderCell();
                TableHeaderCell hc3 = new TableHeaderCell();
                TableHeaderCell hc4 = new TableHeaderCell();


                hc1.Text = "Title";
                hr.Cells.Add(hc1);
                hc2.Text = "Sub Title";
                hr.Cells.Add(hc2);
                hc3.Text = "Created Date";
                hr.Cells.Add(hc3);
                hc4.Text = "View";
                hr.Cells.Add(hc4);
                Table1.Rows.Add(hr);
                for (int i = 0; i < tab.Rows.Count; i++)
                {

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

                    LinkButton Active = new LinkButton();
                    Active.Text = "Active";
                    Active.ID = "lnkActive" + i.ToString();
                    Active.CommandArgument = tab.Rows[i]["PublishContentID"].ToString();
                    Active.Click += new EventHandler(Active_Click);

                    TableCell ActiveCell = new TableCell();
                    ActiveCell.Controls.Add(Active);

                   
                    row.Controls.Add(Title);
                    row.Controls.Add(SubTitle);
                    row.Controls.Add(date);
                    row.Controls.Add(ActiveCell);
                    Table1.Controls.Add(row);

                }
            }
            else
            {
                lblMsg.Text = "No Record Found";
            }
        }

        void Active_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            objPublishDTO = new DTO.PublishContentDTO();
            LinkButton lnk = (LinkButton)sender;
            objPublishDTO.PublishContentID = int.Parse(lnk.CommandArgument.ToString());
            objPublishDTO.EmailId = Session["EmailId"].ToString();
            string Result = objPublishBLL.Active_PublishContent(objPublishDTO);
            if (Result == "1")
            {
                Response.Redirect("PublisherViewContent.aspx");
            }
        }
    }
}