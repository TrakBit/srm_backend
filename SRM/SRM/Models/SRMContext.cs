﻿using System;
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}