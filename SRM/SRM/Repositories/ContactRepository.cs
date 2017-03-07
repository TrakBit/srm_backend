﻿using SRM.Models;
using System.Collections.Generic;
using System.Linq;

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

            var newDealList = contact.Deals.ToList();
            var oldDealList = updateContact.Deals.ToList();

            foreach (var newDeal in newDealList)
            {
                var oldDealInstance = db.Deals.Single(d => d.DealId == newDeal.DealId);
                if (oldDealList.Count > 0)
                {
                    foreach (var oldDeal in oldDealList)
                    {
                        if (newDeal.DealId == oldDeal.DealId)
                        {
                            if (newDeal.Name == null)
                            {
                                updateContact.Deals.Remove(oldDeal);
                            }
                            else
                            {
                                updateContact.Deals.Add(oldDeal);
                            }
                        }
                        else
                        {
                            if (newDeal.Name != null)
                            {
                                updateContact.Deals.Add(oldDealInstance);
                            }
                        }
                    }
                }
                else {
                    updateContact.Deals.Add(oldDealInstance);
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