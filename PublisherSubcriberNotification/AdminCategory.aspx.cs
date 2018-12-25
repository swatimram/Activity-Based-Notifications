using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublisherSubcriberNotification
{
    public partial class AdminCategory : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.CategoryBLL objCategoryBLL = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PublisherSubcriberNotification.DTO.CategoryDTO objCatgeoryDTO = new DTO.CategoryDTO();
            objCategoryBLL = new BLL.CategoryBLL();
            try
            {
                objCatgeoryDTO.CategoryName = txtCategoryname.Text;
                objCatgeoryDTO.CategoryDescription = txtCategoryDescription.Text;
                string result = objCategoryBLL.CreateCategory(objCatgeoryDTO);
                if (result == "1")
                {
                    txtCategoryname.Text = txtCategoryDescription.Text = "";
                    lblMsg.Text = "Category Created Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Category Creation Fail";
                }
            }
            catch (Exception ex)
            {
 
            }
        }
    }
}