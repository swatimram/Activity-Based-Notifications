using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;

namespace PublisherSubcriberNotification.BLL
{
    public class CategoryBLL
    {
        PublisherSubcriberNotification.DAL.CategoryDAL objCategoryDAL = new DAL.CategoryDAL();
        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="objCategoryDTO"></param>
        /// <returns></returns>
        public string CreateCategory(PublisherSubcriberNotification.DTO.CategoryDTO objCategoryDTO)
        {
            try
            {
                return objCategoryDAL.CreateCategory(objCategoryDTO);
            }
            catch (Exception ex)
            {
                return null;
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
                return objCategoryDAL.GetCategory();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}