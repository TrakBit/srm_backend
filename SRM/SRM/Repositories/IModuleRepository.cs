using SRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRM.Repositories
{
    interface IModuleRepository
    {
        IEnumerable<Module> GetAll();
        Module Get(int id);
        void Add(Module module);
        Module Remove(int id);
        bool Update(Module module);
    }
}