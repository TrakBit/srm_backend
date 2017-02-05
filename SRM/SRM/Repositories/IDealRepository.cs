using SRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRM.Repositories
{
    interface IDealRepository
    {
        IEnumerable<Deal> GetAll();
        Deal Get(int id);
        void Add(Deal deal);
        Deal Remove(int id);
        bool Update(Deal deal);
    }
}