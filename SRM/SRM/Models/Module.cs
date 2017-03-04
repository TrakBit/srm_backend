using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRM.Models
{
    public class Module
    {
        public long ModuleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}