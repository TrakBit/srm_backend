using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRM.Models;

namespace SRM.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private SRMContext db = new SRMContext();
        public void Add(Module module)
        {
            db.Modules.Add(module);
            db.SaveChanges();
        }

        public Module Get(int id)
        {
            Module module = db.Modules.Find(id);
            return module;
        }

        public IEnumerable<Module> GetAll()
        {
            return db.Modules;
        }

        public Module Remove(int id)
        {
            Module module = db.Modules.Find(id);
            if (module != null)
            {
                db.Modules.Remove(module);
                db.SaveChanges();
                return module;
            }
            else
            {
                return null;
            }
        }

        public bool Update(Module module)
        {
            Module updateModule = db.Modules.Single(e => e.ModuleId == module.ModuleId);
            updateModule.Name = module.Name;
            return true;
        }
    }
}