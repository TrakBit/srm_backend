using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRM.Models
{
    public class Course
    {
        public Course()
        {
            Grades = new List<Grade>();
        }
        public long CourseId { get; set; }
        public string Name { get; set;}
        public float Duration { get; set; }
        /*
         * 6-  Leaving Certifiate
         * 7-  Ordinary Bachelor Degree
         * 8-  Honours Bachelor Degree
         * 9-  Masters Degree
         * 10- Doctoral Degree
         */
        public int Level { get; set; }
        /*
         * 0- Part Time
         * 1- Full Time
         * 2- Part Time/Full Time
         */
        public int Delivery { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}