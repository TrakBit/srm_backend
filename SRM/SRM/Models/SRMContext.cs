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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deal>()
                        .HasMany(p => p.Contacts)
                        .WithMany(p => p.Deals)
                        .Map(m =>
                        {
                            m.MapLeftKey("DealId");
                            m.MapRightKey("ContactId");
                            m.ToTable("DealContact");
                        });
        }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
    }
}