using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace NotificationClient
{
    class Db
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public Db()
        {
            con = new SqlConnection(Program.CStr);
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public DataTable Get(string email)
        {
            string sql = string.Format("select * from SubNotification where SubEmailid = '{0}' and Status = 'N' order by RatingPoints", email);
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            DataTable buffer = new DataTable();
            adap.Fill(buffer);
            return buffer;
        }

        public bool  UpdateStatus(string SubNotificationID)
        {
            string sql = string.Format("update SubNotification set status = 'Y' where SubNotificationID = {0}", SubNotificationID);
            cmd.CommandText = sql;                                                   
            return cmd.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool UpdateMachineStatus(string emailid , int val)
        {
            string sql = string.Format("UPDATE applicationuser set machinestatus = {0} where EmailId = '{1}'", val, emailid);
            cmd.CommandText = sql;
            return cmd.ExecuteNonQuery() > 0 ? true : false;
        }

        public bool IsValid(string emailid, string password)
        {
            bool status = false;
            string sql = string.Format("select * from ApplicationUser where Emailid = '{0}' and Password = '{1}'", emailid, password);
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            DataTable buffer = new DataTable();
            adap.Fill(buffer);
            if (buffer.Rows.Count > 0)
            {
                Program.DeviceId = buffer.Rows[0]["DeviceId"].ToString();
                status = true;
            }
            return status;
        }
    }
}
