using SRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRM.Repositories
{
    public class ContactRepository: IContactRepository
    {
        private SRMContext db = new SRMContext();

        public void Add(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public Contact Get(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return contact;
        }

        public IEnumerable<Contact> GetAll()
        {
            return db.Contacts;
        }

        public Contact Remove(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact != null)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return contact;
            }
            else
            {
                return null;
            }

        }

        public bool Update(int id, Contact contact)
        {
            Contact updateContact = db.Contacts.Single(e => e.ContactId == contact.ContactId);
            updateContact.FirstName = contact.FirstName;
            updateContact.LastName = contact.LastName;
            updateContact.Email = contact.Email;
            updateContact.Telephone = contact.Telephone;
            updateContact.LifecycleStage = contact.LifecycleStage;
            db.SaveChanges();
            return true;
        }
    }
}