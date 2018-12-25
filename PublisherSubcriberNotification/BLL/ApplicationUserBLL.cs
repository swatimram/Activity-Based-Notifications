using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;

namespace PublisherSubcriberNotification.BLL
{
    public class ApplicationUserBLL
    {
        PublisherSubcriberNotification.DAL.ApplicationUserDAL objApplicationUserDAL= new DAL.ApplicationUserDAL();
        /// <summary>
        /// Create New Application User
        /// </summary>
        /// <param name="objApplicationUserDTO"></param>
        /// <returns></returns>
        public string CreateApplicationUser(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO)
        {
            try
            {
                return objApplicationUserDAL.CreateApplicationUser(objApplicationUserDTO);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// User Profile Update
        /// </summary>
        /// <param name="ObjApplicationUserDTO"></param>
        /// <returns></returns>
        public string UpdateUserProfile(PublisherSubcriberNotification.DTO.ApplicationUserDTO ObjApplicationUserDTO)
        {
            try
            {
                return objApplicationUserDAL.UpdateUserProfile(ObjApplicationUserDTO);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="ObjApplicationUserDTO"></param>
        /// <returns></returns>
        public string ChangePassword(PublisherSubcriberNotification.DTO.ApplicationUserDTO ObjApplicationUserDTO)
        {
            try
            {
                return objApplicationUserDAL.ChangePassword(ObjApplicationUserDTO);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// Login verification
        /// </summary>
        /// <param name="objUserDTO"></param>
        /// <returns></returns>
        public bool GetAdminLogin(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO)
        {
            try
            {
                if (objApplicationUserDAL.ApplicationLogin(objApplicationUserDTO))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Get User Profile Details
        /// </summary>
        /// <param name="ObjApplicationUserDTO"></param>
        /// <returns></returns>
        public DataTable GetUserProfile_Details(PublisherSubcriberNotification.DTO.ApplicationUserDTO ObjApplicationUserDTO)
        {
            try
            {
                DataTable loaddata = new DataTable();
                return loaddata = objApplicationUserDAL.GetUserprofile_Details(ObjApplicationUserDTO);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Total Users,Publisher,Subscriber
        /// </summary>
        /// <returns></returns>
        public string GetTotalUser_Pub_Sub()
        {
            try
            {
                return objApplicationUserDAL.GetTotalUser_Pub_Sub();
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
                return objApplicationUserDAL.GetTotalUser_Pub_Sub_Publisher(objApplicationUserDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get User,Publisher,Subscriber Rating & Overall PublishContent Count
        /// </summary>
        /// <returns></returns>
        public string GetTotalUser_Pub_Sub_Subscriber(PublisherSubcriberNotification.DTO.ApplicationUserDTO objApplicationUserDTO)
        {
            try
            {
                return objApplicationUserDAL.GetTotalUser_Pub_Sub_Subscriber(objApplicationUserDTO);
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
                return objApplicationUserDAL.GetSubscriberRating_Top_5(objApplicationUserDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}