using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PublisherSubcriberNotification.DAL
{
    public class CategoryDAL
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
        /// Create Category
        /// </summary>
        /// <param name="objApplicationUser"></param>
        /// <returns></returns>
        public string CreateCategory(PublisherSubcriberNotification.DTO.CategoryDTO objCategory)
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CreateCategory";
                cmd.Parameters.Add("@CategoryName", objCategory.CategoryName);
                cmd.Parameters.Add("@Description", objCategory.CategoryDescription);
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
        /// Get Active Category Details
        /// </summary>
        /// <returns></returns>
        public DataTable GetCategory()
        {
            try
            {
                cmd = new SqlCommand();
                open_connection();
                SqlDataAdapter adp = null;
                DataTable loaddata = new DataTable();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetCategory";
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