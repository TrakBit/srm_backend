using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRM.Models;

namespace SRM.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private SRMContext db = new SRMContext();
        public void Add(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public Course Get(int id)
        {
            Course course = db.Courses.Find(id);
            return course;
        }

        public IEnumerable<Course> GetAll()
        {
            return db.Courses;
        }

        public Course Remove(int id)
        {
            Course course = db.Courses.Find(id);
            if (course != null)
            {
                db.Courses.Remove(course);
                db.SaveChanges();
                return course;
            }
            else
            {
                return null;
            }
        }

        public bool Update(Course course)
        {
            Course updateCourse = db.Courses.Single(e => e.CourseId == course.CourseId);
            updateCourse.Name = course.Name;
            updateCourse.Duration = course.Duration;
            updateCourse.Level = course.Level;
            updateCourse.Delivery = course.Delivery;
            db.SaveChanges();
            return true;
        }
    }
}