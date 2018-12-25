using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace PublisherSubcriberNotification.DAL
{
    public class ApplicationUserDAL
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
        /// Admin/User Login Autherization
        /// </summary>
        /// <param name="objApplicationuserDTO"></param>
        /// <returns></returns>
        public bool ApplicationLogin(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUser)
        {

            cmd = new SqlCommand();
            open_connection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_LoginVerification";
            cmd.Parameters.Add("@EmailID", objApplicationUser.EmailId);
            cmd.Parameters.Add("@Password", objApplicationUser.Password);
            cmd.Parameters.Add("@UserType", objApplicationUser.UserType);
            int result = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            if (result > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Create Application User
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public string CreateApplicationUser(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUser)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CreateApplicationUser";
                cmd.Parameters.Add("@Name", objApplicationUser.Name);
                cmd.Parameters.Add("@Password", objApplicationUser.Password);
                cmd.Parameters.Add("@UserType", objApplicationUser.UserType);
                cmd.Parameters.Add("@EmailID", objApplicationUser.EmailId);
                cmd.Parameters.Add("@MobileNo", objApplicationUser.MobileNo);
                cmd.Parameters.Add("@Address", objApplicationUser.Address);
                cmd.Parameters.Add("@DeviceId", objApplicationUser.DeviceId);
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
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// Update user Profile
        /// </summary>
        /// <param name="objApplicationUserDTO"></param>
        /// <returns></returns>
        public string UpdateUserProfile(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UpdateUserprofile";
                cmd.Parameters.Add("@EmailID", objApplicationUserDTO.EmailId);
                cmd.Parameters.Add("@MobileNo", objApplicationUserDTO.MobileNo);
                cmd.Parameters.Add("@Address", objApplicationUserDTO.Address);
                SqlDataReader sqlreader = cmd.ExecuteReader();
                string Result = null;
                if (sqlreader.Read())
                {
                    Result = sqlreader.GetValue(0).ToString();
                }
                sqlreader.Close();
                con.Close();
                return Result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="objApplicationUserDTO"></param>
        /// <returns></returns>
        public string ChangePassword(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ChangePassword";
                cmd.Parameters.Add("@EmailID", objApplicationUserDTO.EmailId);
                cmd.Parameters.Add("@Password", objApplicationUserDTO.Password);
                SqlDataReader sqlreader = cmd.ExecuteReader();
                string Result = null;
                if (sqlreader.Read())
                {
                    Result = sqlreader.GetValue(0).ToString();
                }
                sqlreader.Close();
                con.Close();
                return Result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// Get User Profile Details
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public DataTable GetUserprofile_Details(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUser)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetUserProfile_EmailID";
                cmd.Parameters.Add("@EmailID", objApplicationUser.EmailId);
                cmd.Parameters.Add("@UserType", objApplicationUser.UserType);
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
        /// Get User,Publisher,Subscriber Count
        /// </summary>
        /// <returns></returns>
        public string GetTotalUser_Pub_Sub()
        {
            try 
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetTotalUsers_Pub_Sub";
                SqlDataReader sqlreader = cmd.ExecuteReader();
                string Result = null;
                if (sqlreader.Read())
                {
                    Result = sqlreader.GetValue(0).ToString() + "&" + sqlreader.GetValue(1).ToString() + "&" + sqlreader.GetValue(2).ToString() + "&" + sqlreader.GetValue(3).ToString();
                }
                sqlreader.Close();
                con.Close();
                return Result;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get User,Publisher,Individual PublishContent & Overall PublishContent Count
        /// </summary>
        /// <returns></returns>
        public string GetTotalUser_Pub_Sub_Publisher(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetTotalUsers_Pub_Sub_Publisher";
                cmd.Parameters.Add("@EmailID", objApplicationUserDTO.EmailId);
                SqlDataReader sqlreader = cmd.ExecuteReader();
                string Result = null;
                if (sqlreader.Read())
                {
                    Result = sqlreader.GetValue(0).ToString() + "&" + sqlreader.GetValue(1).ToString() + "&" + sqlreader.GetValue(2).ToString() + "&" + sqlreader.GetValue(3).ToString();
                }
                sqlreader.Close();
                con.Close();
                return Result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get User,Publisher,Subscriber Rating Count & Overall PublishContent Count
        /// </summary>
        /// <returns></returns>
        public string GetTotalUser_Pub_Sub_Subscriber(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetTotalUsers_Pub_Sub_Subscriber";
                cmd.Parameters.Add("@EmailID", objApplicationUserDTO.EmailId);
                SqlDataReader sqlreader = cmd.ExecuteReader();
                string Result = null;
                if (sqlreader.Read())
                {
                    Result = sqlreader.GetValue(0).ToString() + "&" + sqlreader.GetValue(1).ToString() + "&" + sqlreader.GetValue(2).ToString() + "&" + sqlreader.GetValue(3).ToString();
                }
                sqlreader.Close();
                con.Close();
                return Result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Subscriber Rating Based on UserId Top 5
        /// </summary>
        /// <returns></returns>
        public DataTable GetSubscriberRating_Top_5(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetSubscriberrating_UserID_Top_5";
                cmd.Parameters.Add("@EmailID", objApplicationUserDTO.EmailId);
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