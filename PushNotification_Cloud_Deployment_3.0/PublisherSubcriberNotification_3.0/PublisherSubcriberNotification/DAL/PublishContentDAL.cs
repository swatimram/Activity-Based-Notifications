using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PublisherSubcriberNotification.DAL
{
    public class PublishContentDAL
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
        /// Publish Content
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public DataTable PublishNew_Content(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_PublishContent";
                cmd.Parameters.Add("@CategoryID", objPublishContentDTO.CategoryID);
                cmd.Parameters.Add("@Title", objPublishContentDTO.Title);
                cmd.Parameters.Add("@SubTitle", objPublishContentDTO.SubTitle);
                cmd.Parameters.Add("@Description", objPublishContentDTO.Description);
                cmd.Parameters.Add("@EmailID", objPublishContentDTO.EmailId);
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
        /// Update Publish Content
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public string Update_PublishContent(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Update_PublishContent";
                cmd.Parameters.Add("@PublishContentID", objPublishContentDTO.PublishContentID);
                cmd.Parameters.Add("@CategoryID", objPublishContentDTO.CategoryID);
                cmd.Parameters.Add("@Title", objPublishContentDTO.Title);
                cmd.Parameters.Add("@SubTitle", objPublishContentDTO.SubTitle);
                cmd.Parameters.Add("@Description", objPublishContentDTO.Description);
                cmd.Parameters.Add("@EmailID", objPublishContentDTO.EmailId);
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
        /// Deactive Publish Content
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public string Deactive_PublishContent(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Deactive_PublishContent";
                cmd.Parameters.Add("@PublishContentID", objPublishContentDTO.PublishContentID);
                cmd.Parameters.Add("@EmailID", objPublishContentDTO.EmailId);
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
        /// Update Device Status
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public string DeviceStatusUpdate(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UpdateDeviceStatus";
                cmd.Parameters.Add("@PublishContentID", objPublishContentDTO.PublishContentID);
                cmd.Parameters.Add("@SubUserId", objPublishContentDTO.UserId);
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
        /// Active Publish Content
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public string Active_PublishContent(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Update_PublishContent_Deactive";
                cmd.Parameters.Add("@PublishContentID", objPublishContentDTO.PublishContentID);
                cmd.Parameters.Add("@EmailID", objPublishContentDTO.EmailId);
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
        /// Get Publish Content Based on Category & User
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContent_User(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetPublishContent_EmailID";
                cmd.Parameters.Add("@CategoryID", objPublishContentDTO.CategoryID);
                cmd.Parameters.Add("EmailID", objPublishContentDTO.EmailId);
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
        /// Get Deactive Publish Content Based on Category & User
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContent_Deactive(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetPublishContent_ID_Deactive";
                cmd.Parameters.Add("@CategoryID", objPublishContentDTO.CategoryID);
                cmd.Parameters.Add("EmailID", objPublishContentDTO.EmailId);
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
        /// Get Publish Content Based PublishContentID
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContentID(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetPublishContent_ID";
                cmd.Parameters.Add("@PublishContentID", objPublishContentDTO.PublishContentID);
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
    }
}