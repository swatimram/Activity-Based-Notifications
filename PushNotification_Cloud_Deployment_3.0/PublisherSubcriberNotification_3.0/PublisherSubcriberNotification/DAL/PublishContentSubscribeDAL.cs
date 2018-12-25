using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PublisherSubcriberNotification.DAL
{
    public class PublishContentSubscribeDAL
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public string conn_string = ConfigurationManager.AppSettings["ConnectionString"].ToString();

        /// <summary>
        /// SQL connection open
        /// </summary>
        public void open_connection()
        {
            con = new SqlConnection(conn_string);
            con.Open();
        }

        /// <summary>
        /// Get Publish Content Count Based on Publisher
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContentCount_Publisher(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetPublishContentCount_Publisher";
                cmd.Parameters.Add("@CategoryID", objPublishContentSubscribeDTO.CategoryId);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(loaddata);
                con.Close();
                return loaddata;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Publish Content Based on PublisherID
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContent_PublisherID(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetPublishContent_UserID";
                cmd.Parameters.Add("@UserId", objPublishContentSubscribeDTO.UserID);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(loaddata);
                con.Close();
                return loaddata;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get Publish Content Based on UserId Top 5
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContent_Top_5(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetPublishContent_UserID_Top_5";
                cmd.Parameters.Add("@EmailID", objPublishContentSubscribeDTO.EmailID);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(loaddata);
                con.Close();
                return loaddata;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get Publish Content Based on UserId Top 5
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishRating_Top_5(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetPublisherrating_UserID_Top_5";
                cmd.Parameters.Add("@EmailID", objPublishContentSubscribeDTO.EmailID);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(loaddata);
                con.Close();
                return loaddata;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get Publish Rating 
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishRating_EmailId(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetSubscriberrating_UserID";
                cmd.Parameters.Add("@EmailID", objPublishContentSubscribeDTO.EmailID);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(loaddata);
                con.Close();
                return loaddata;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get Publish Rating 
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishRating_PublisherUserID_EmailId(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetSubscriberRatingPoint_PublisherUserID";
                cmd.Parameters.Add("@PublisherUserID", objPublishContentSubscribeDTO.PublisherID);
                cmd.Parameters.Add("@EmailID", objPublishContentSubscribeDTO.EmailID);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(loaddata);
                con.Close();
                return loaddata;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get UserID Based on PublishContentID
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserID_PublishID(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetUserID_PublishContentID";
                cmd.Parameters.Add("@PublishContentID", objPublishContentSubscribeDTO.PublishContentID);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(loaddata);
                con.Close();
                return loaddata;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Subscriber Rate Publisher Content/Publisher
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public string SubscriberRatePublisher(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_SubscriberRatePublisher";
                cmd.Parameters.Add("@PublisherID", objPublishContentSubscribeDTO.PublisherID);
                cmd.Parameters.Add("@EmailID", objPublishContentSubscribeDTO.EmailID);
                cmd.Parameters.Add("@Rating", objPublishContentSubscribeDTO.Rate);
                SqlDataReader sqlreader = cmd.ExecuteReader();
                string result = null;
                if (sqlreader.Read())
                {
                    result = sqlreader.GetValue(0).ToString();
                }
                sqlreader.Close();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// Update Subscriber Rate Publisher Content/Publisher
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public string UpdateSubscriberRatePublisher(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Update_SubscriberRatePublisher";
                cmd.Parameters.Add("@PublisherID", objPublishContentSubscribeDTO.PublisherID);
                cmd.Parameters.Add("@EmailID", objPublishContentSubscribeDTO.EmailID);
                cmd.Parameters.Add("@Rating", objPublishContentSubscribeDTO.Rate);
                SqlDataReader sqlreader = cmd.ExecuteReader();
                string result = null;
                if (sqlreader.Read())
                {
                    result = sqlreader.GetValue(0).ToString();
                }
                sqlreader.Close();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}