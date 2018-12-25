using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;

namespace PublisherSubcriberNotification.BLL
{
    public class PublishContentBLL
    {
        PublisherSubcriberNotification.DAL.PublishContentDAL objPublishContentDAL = new DAL.PublishContentDAL();

        /// <summary>
        /// Publish New Content
        /// </summary>
        /// <param name="objCategoryDTO"></param>
        /// <returns></returns>
        public DataTable PublishNew_Content(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                return objPublishContentDAL.PublishNew_Content(objPublishContentDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Update Publish Content
        /// </summary>
        /// <param name="objCategoryDTO"></param>
        /// <returns></returns>
        public string Update_PublishContent(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                return objPublishContentDAL.Update_PublishContent(objPublishContentDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Update Device Status
        /// </summary>
        /// <param name="objCategoryDTO"></param>
        /// <returns></returns>
        public string DeviceStatusUpdate(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                return objPublishContentDAL.DeviceStatusUpdate(objPublishContentDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Deactive Publish Content
        /// </summary>
        /// <param name="objCategoryDTO"></param>
        /// <returns></returns>
        public string Deactive_PublishContent(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                return objPublishContentDAL.Deactive_PublishContent(objPublishContentDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Deactive Publish Content
        /// </summary>
        /// <param name="objCategoryDTO"></param>
        /// <returns></returns>
        public string Active_PublishContent(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                return objPublishContentDAL.Active_PublishContent(objPublishContentDTO);
            }
            catch (Exception ex)
            {
                return null;
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
                return objPublishContentDAL.GetPublishContent_User(objPublishContentDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        ///Get Deactive Publish Content Based on Category & User
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContent_Deactive(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                return objPublishContentDAL.GetPublishContent_Deactive(objPublishContentDTO);
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
        public DataTable GetPublishContent_ID(PublisherSubcriberNotification.DTO.PublishContentDTO objPublishContentDTO)
        {
            try
            {
                return objPublishContentDAL.GetPublishContentID(objPublishContentDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}