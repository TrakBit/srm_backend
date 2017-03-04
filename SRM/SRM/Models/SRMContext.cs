using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SRM.Models
{
    public class SRMContext : DbContext
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

            modelBuilder.Entity<Grade>()
                        .HasRequired<Contact>(c => c.Contact)
                        .WithMany(g => g.Grades)
                        .HasForeignKey(c => c.ContactId);

            modelBuilder.Entity<Grade>()
                        .HasRequired<Course>(c => c.Course)
                        .WithMany(g => g.Grades)
                        .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Grade>()
                        .HasRequired<Module>(m => m.Module)
                        .WithMany(g => g.Grades)
                        .HasForeignKey(m => m.ModuleId);
        }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }

    }
}