using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PublisherSubcriberNotification
{
    public partial class UpdatePublisherRatings : System.Web.UI.Page
    {
        PublisherSubcriberNotification.BLL.PublishContentSubscribeBLL objPublishSubscribeBLL = null;
        PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishSubscribeDTO = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPublishRatings();
        }

        private void LoadPublishRatings()
        {
            try
            {
                objPublishSubscribeBLL = new BLL.PublishContentSubscribeBLL();
                objPublishSubscribeDTO = new DTO.PublishContentSubscribeDTO();
                DataTable tab = new DataTable();
                objPublishSubscribeDTO.EmailID = Session["EmailId"].ToString();
                tab = objPublishSubscribeBLL.GetPublishRating_EmailId(objPublishSubscribeDTO);
                Table1.Controls.Clear();
                lblMsg.Text = "";
                if (tab.Rows.Count > 0)
                {
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();

                    hc1.Text = "Publisher Name";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Rating Points";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Edit";
                    hr.Cells.Add(hc3);
                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {

                        TableRow row = new TableRow();
                        Label lblName = new Label();
                        //lblTitle.Width = 100;
                        lblName.Text = tab.Rows[i]["Name"].ToString();
                        TableCell Name = new TableCell();
                        Name.Controls.Add(lblName);


                        Label lblRating = new Label();
                        //lblSubTitle.Width = 100;
                        lblRating.Text = tab.Rows[i]["Rating"].ToString();
                        TableCell Rating = new TableCell();
                        Rating.Controls.Add(lblRating);



                        LinkButton Edit = new LinkButton();
                        Edit.Text = "Edit";
                        Edit.ID = "lnkEdit" + i.ToString();
                        Edit.CommandArgument = tab.Rows[i]["PublisherID"].ToString();
                        Edit.Click += new EventHandler(Edit_Click);

                        TableCell EditCell = new TableCell();
                        EditCell.Controls.Add(Edit);

                       

                        row.Controls.Add(Name);
                        row.Controls.Add(Rating);
                        row.Controls.Add(EditCell);
                        Table1.Controls.Add(row);

                    }
                }
                else
                {
                    lblMsg.Text = "No Record Found";
                }
            }
            catch
            {
 
            }
        }

        void Edit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            objPublishSubscribeDTO = new DTO.PublishContentSubscribeDTO();
            LinkButton lnk = (LinkButton)sender;
            objPublishSubscribeDTO.UserID = int.Parse(lnk.CommandArgument.ToString());
            Response.Redirect("SubscriberRatePublisher.aspx?PublisherUserID=" + objPublishSubscribeDTO.UserID);
        }
    }
}