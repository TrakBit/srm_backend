using SRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Repositories
{
    interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        Contact Get(int id);
        void Add(Contact contact);
        Contact Remove(int id);
        bool Update(int id, Contact contact);
    }
}
