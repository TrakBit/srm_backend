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
        public string Stage { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}