using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SRM.Models
{
    public class SRMContext: DbContext
    {
        public SRMContext() : base("name=SRMContext")
        {
        }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}