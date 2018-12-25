using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

namespace PublisherSubcriberNotification.DTO
{
    public class PublishContentDTO
    {
        public Int64 CategoryID { get; set; }
        public Int64 PublishContentID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string EmailId { get; set; }
        public string Status { get; set; }
        public Int64 UserId { get; set; }
    }
}