using SRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Repositories
{
    interface IGradeRepository
    {
        IEnumerable<Grade> GetAll();
        Grade Get(int id);
        void Add(Grade grade);
        Grade Remove(int id);
        bool Update(Grade deal);
    }
}
