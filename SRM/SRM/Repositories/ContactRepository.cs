using SRM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using System;
using System.Diagnostics;

namespace SRM.Repositories
{
    public class ContactRepository : IContactRepository
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

        public bool Update(Contact contact)
        {
            Contact updateContact = db.Contacts.Single(e => e.ContactId == contact.ContactId);

            var newDeal = contact.Deals.ToList();
            var oldDeal = updateContact.Deals.ToList();

            SRM.Models.Deal newDealInstance = new Deal();
            SRM.Models.Deal oldDealInstance = new Deal();

            foreach (var item in newDeal)
            {
                newDealInstance = item;
                oldDealInstance = db.Deals.Single(e => e.DealId == newDealInstance.DealId);

                if (oldDeal.Count > 0)
                {
                    foreach (var oldItem in oldDeal)
                    {
                        if (newDealInstance.DealId == oldItem.DealId)
                        {
                            if (newDealInstance.Name == null)
                            {
                                foreach (var dealObj in updateContact.Deals.ToList())
                                {
                                    if (newDealInstance.DealId == dealObj.DealId)
                                    {
                                        updateContact.Deals.Remove(dealObj);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (oldDealInstance.Name != null)
                            {
                                updateContact.Deals.Add(oldDealInstance);
                            }
                        }
                    }
                }
                else
                {
                    if (oldDealInstance.Name != null)
                    {
                        updateContact.Deals.Add(oldDealInstance);
                    }
                }
            }

            


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