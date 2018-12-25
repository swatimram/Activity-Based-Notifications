using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

namespace PublisherSubcriberNotification.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string Status { get; set; }
    }
}