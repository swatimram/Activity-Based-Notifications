using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class PublishContentDetailsView : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.CategoryBLL objCategoryBLL = null;
        PublisherSubcriberNotification.BLL.PublishContentBLL objPublishBLL = null;
        PublisherSubcriberNotification.DTO.PublishContentDTO objPublishDTO = null;

        static Int64 PublishContentId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                objCategoryBLL = new BLL.CategoryBLL();
                ddlCategory.DataSource = objCategoryBLL.GetCategory();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "--Select Category--");

                DataTable tab = new DataTable();
                objPublishBLL = new BLL.PublishContentBLL();
                objPublishDTO = new DTO.PublishContentDTO();
                PublishContentId = Int64.Parse(Request.QueryString["PublishContentId"]);
                objPublishDTO.PublishContentID = PublishContentId;
                tab = objPublishBLL.GetPublishContent_ID(objPublishDTO);
                ddlCategory.SelectedValue = tab.Rows[0]["CategoryID"].ToString();
                txtTitle.Text = tab.Rows[0]["Title"].ToString();
                txtSubTitle.Text = tab.Rows[0]["SubTitle"].ToString();
                txtDespcription.Value = tab.Rows[0]["Description"].ToString();
            }
            //LoadContent();
        }

        //private void LoadContent()
        //{
            
        //}
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objPublishBLL = new BLL.PublishContentBLL();
            objPublishDTO = new DTO.PublishContentDTO();
            try
            {
                objPublishDTO.PublishContentID = PublishContentId;
                objPublishDTO.CategoryID = Int64.Parse(ddlCategory.SelectedItem.Value);
                objPublishDTO.Title = txtTitle.Text;
                objPublishDTO.SubTitle = txtSubTitle.Text;
                objPublishDTO.Description = txtDespcription.Value;
                objPublishDTO.EmailId = Session["EmailId"].ToString();
                string result = objPublishBLL.Update_PublishContent(objPublishDTO);
                if (result == "1")
                {
                    //Session["PublishContentTitle"] = txtTitle.Text;
                    //Session["PublishContentSubTitle"] = txtSubTitle.Text;
                    //Session["PublishContentDescp"] = txtDespcription.Value;
                    txtTitle.Text = txtSubTitle.Text = txtDespcription.Value = "";
                    ddlCategory.SelectedIndex = 0;
                    Response.Redirect("PublisherViewContent.aspx");

                   
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            objPublishBLL = new BLL.PublishContentBLL();
            objPublishDTO = new DTO.PublishContentDTO();
            try
            {
                objPublishDTO.PublishContentID = PublishContentId;
                objPublishDTO.EmailId = Session["EmailId"].ToString();
                string result = objPublishBLL.Deactive_PublishContent(objPublishDTO);
                if (result == "1")
                {
                    Response.Redirect("PublisherViewContent.aspx");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}