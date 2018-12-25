using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NotificationClient;

namespace PublisherSubcriberNotification
{
    public partial class PublishContent : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.CategoryBLL objCategoryBLL=null;
        PublisherSubcriberNotification.BLL.PublishContentBLL objPublishBLL = null;
        PublisherSubcriberNotification.DTO.PublishContentDTO objPublishDTO = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                   objCategoryBLL = new BLL.CategoryBLL();
                   ddlCategory.DataSource = objCategoryBLL.GetCategory();
                   ddlCategory.DataTextField = "CategoryName";
                   ddlCategory.DataValueField = "CategoryId";
                   ddlCategory.DataBind();
                   ddlCategory.Items.Insert(0, "--Select Category--");
                   lblMsg.Text = "";
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objPublishBLL = new BLL.PublishContentBLL();
                objPublishDTO = new DTO.PublishContentDTO();
                objPublishDTO.CategoryID = Int64.Parse(ddlCategory.SelectedItem.Value);
                objPublishDTO.Title = txtTitle.Text;
                objPublishDTO.SubTitle = txtSubTitle.Text;
                objPublishDTO.Description = txtDespcription.Value;
                objPublishDTO.EmailId = Session["EmailId"].ToString();
                DataTable tab = new DataTable();
                tab = objPublishBLL.PublishNew_Content(objPublishDTO);
                if (tab.Rows.Count > 0)
                {
                    //string Results = objPublishBLL.PublishNew_Content(objPublishDTO);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        string[] devices = tab.Rows[i]["DeviceId"].ToString().Split(',');

                        for (int j = 0; j < devices.Length; j++)
                            GCMAlert.Send("New content published-" + tab.Rows[i]["PublishContentId"].ToString(), devices[j]);

                        objPublishDTO.UserId = Int64.Parse(tab.Rows[i]["SubUserId"].ToString());
                        objPublishDTO.PublishContentID = Int64.Parse(tab.Rows[i]["PublishContentId"].ToString());
                        string result = objPublishBLL.DeviceStatusUpdate(objPublishDTO);

                    }

                }
                    txtTitle.Text = txtSubTitle.Text = txtDespcription.Value = "";
                    ddlCategory.SelectedIndex = 0;
                    lblMsg.Text = "Content Published Sucessfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
         //       }
         //       else
         //       {
         //           lblMsg.Text = "Content Publish Error";
         //           lblMsg.ForeColor = System.Drawing.Color.Red;
         //       }
            }
            catch (Exception ex)
            {
 
            }
        }
    }
}