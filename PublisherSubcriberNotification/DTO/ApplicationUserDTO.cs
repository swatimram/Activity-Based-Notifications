using System;
using System.Collections.Generic;
// System.Linq;
using System.Web;

namespace PublisherSubcriberNotification.DTO
{
    public class ApplicationUserDTO
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string DeviceId { get; set; }
        public string Status { get; set; }
    }
}