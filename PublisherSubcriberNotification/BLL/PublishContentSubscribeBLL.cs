using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;

namespace PublisherSubcriberNotification.BLL
{
    public class PublishContentSubscribeBLL
    {
        PublisherSubcriberNotification.DAL.PublishContentSubscribeDAL objPublishContentSubscribeDAL=null;
        
        /// <summary>
        ///  Get Publish Content Count Based on Publisher
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContentCount_Publisher(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                objPublishContentSubscribeDAL = new DAL.PublishContentSubscribeDAL();
                return objPublishContentSubscribeDAL.GetPublishContentCount_Publisher(objPublishContentSubscribeDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        ///  Get Publish Content Based on PublisherID
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContent_PublisherID(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                objPublishContentSubscribeDAL = new DAL.PublishContentSubscribeDAL();
                return objPublishContentSubscribeDAL.GetPublishContent_PublisherID(objPublishContentSubscribeDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///  Get Publish Content Based on UserId Top 5
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishContent_Top_5(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                objPublishContentSubscribeDAL = new DAL.PublishContentSubscribeDAL();
                return objPublishContentSubscribeDAL.GetPublishContent_Top_5(objPublishContentSubscribeDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///  Get Publish Content Based on UserId Top 5
        /// </summary>
        /// <returns></returns>
        public DataTable GetPublishRating_Top_5(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                objPublishContentSubscribeDAL = new DAL.PublishContentSubscribeDAL();
                return objPublishContentSubscribeDAL.GetPublishRating_Top_5(objPublishContentSubscribeDTO);
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
                objPublishContentSubscribeDAL = new DAL.PublishContentSubscribeDAL();
                return objPublishContentSubscribeDAL.GetPublishRating_EmailId(objPublishContentSubscribeDTO);
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
                objPublishContentSubscribeDAL = new DAL.PublishContentSubscribeDAL();
                return objPublishContentSubscribeDAL.GetPublishRating_PublisherUserID_EmailId(objPublishContentSubscribeDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///  Get UserID Based on PublishContentID
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserID_PublishID(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                objPublishContentSubscribeDAL = new DAL.PublishContentSubscribeDAL();
                return objPublishContentSubscribeDAL.GetUserID_PublishID(objPublishContentSubscribeDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Subscriber Rate Publisher Content/Publisher
        /// </summary>
        /// <param name="objPublishContentSubscribeDTO"></param>
        /// <returns></returns>
        public string SubscriberRatePublisher(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                objPublishContentSubscribeDAL = new DAL.PublishContentSubscribeDAL();
                return objPublishContentSubscribeDAL.SubscriberRatePublisher(objPublishContentSubscribeDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// update Subscriber Rate Publisher Content/Publisher
        /// </summary>
        /// <param name="objPublishContentSubscribeDTO"></param>
        /// <returns></returns>
        public string UpdateSubscriberRatePublisher(PublisherSubcriberNotification.DTO.PublishContentSubscribeDTO objPublishContentSubscribeDTO)
        {
            try
            {
                objPublishContentSubscribeDAL = new DAL.PublishContentSubscribeDAL();
                return objPublishContentSubscribeDAL.UpdateSubscriberRatePublisher(objPublishContentSubscribeDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}