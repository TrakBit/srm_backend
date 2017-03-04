using SRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRM.Repositories
{
    interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course Get(int id);
        void Add(Course course);
        Course Remove(int id);
        bool Update(Course course);
    }
}