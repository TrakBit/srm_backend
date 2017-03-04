using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRM.Models
{
    public class Grade
    {
        public long? ContactId { get; set; }
        public long? CourseId { get; set; }
        public long? ModuleId { get; set; }
        public long GradeId { get; set; }
        public float Score { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Course Course { get; set; }
        public virtual Module Module { get; set; }
    }
}