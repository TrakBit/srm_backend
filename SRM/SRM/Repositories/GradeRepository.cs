using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRM.Models;

namespace SRM.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private SRMContext db = new SRMContext();
        public void Add(Grade grade)
        {
            db.Grades.Add(grade);
            db.SaveChanges();
        }

        public Grade Get(int id)
        {
            Grade grade = db.Grades.Find(id);
            return grade;
        }

        public IEnumerable<Grade> GetAll()
        {
            return db.Grades;
        }

        public Grade Remove(int id)
        {
            Grade grade = db.Grades.Find(id);
            if (grade != null)
            {
                db.Grades.Remove(grade);
                db.SaveChanges();
                return grade;
            }
            else
            {
                return null;
            }
        }

        public bool Update(Grade grade)
        {
            Grade updateGrade = db.Grades.Single(e => e.GradeId == grade.GradeId);
            updateGrade.Score = grade.Score;
            return true;
        }
    }
}