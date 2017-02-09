using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRM.Models
{
    public class Deal
    {
        public long DealId { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        /*
         * 0 - Appointment Scheduled
         * 1 - Qualified to Buy
         * 2 - Presentation Scheduled
         * 3 - Decision Maker Brought-In
         * 4 - Contract Sent
         * 5 - Closed Won 
         * 6 - Closed Lost
         * */
        public long Stage { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}