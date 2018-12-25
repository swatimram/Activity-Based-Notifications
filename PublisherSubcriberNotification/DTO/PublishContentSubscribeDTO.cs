using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

namespace PublisherSubcriberNotification.DTO
{
    public class PublishContentSubscribeDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int UserID { get; set; }
        public Int64 PublishContentID { get; set; }

        public Int64 PublisherID { get; set; }
        public Int64 SubscriberID { get; set; }
        public int Rate { get; set; }

        public string EmailID { get; set; }

    }
}