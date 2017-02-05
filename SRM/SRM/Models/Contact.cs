using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRM.Models
{
    public class Contact
    {
        public long ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        /*
         * 0- High school student
         * 1- Undergraduate student
         * 2- Postgreduate student
         * 3- Doctoral student
         * 4- Working professional
         */
        public long LifecycleStage { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
    }
}