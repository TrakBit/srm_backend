using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRM.Models;
using System.Data.Entity;

namespace SRM.Repositories
{
    public class DealRepository : IDealRepository
    {
        private SRMContext db = new SRMContext();
        public void Add(Deal deal)
        {
            db.Deals.Add(deal);
            db.SaveChanges();
        }

        public Deal Get(int id)
        {
            Deal deal = db.Deals.Find(id);
            return deal;
        }

        public IEnumerable<Deal> GetAll()
        {
            return db.Deals;
        }

        public Deal Remove(int id)
        {
            Deal deal = db.Deals.Find(id);
            if (deal != null)
            {
                db.Deals.Remove(deal);
                db.SaveChanges();
                return deal;
            }
            else
            {
                return null;
            }
        }

        public bool Update( Deal deal)
        {
            Deal updateDeal = db.Deals.Single(e => e.DealId == deal.DealId);

            var newContact = deal.Contacts.ToList();
            var oldContact = updateDeal.Contacts.ToList();

            SRM.Models.Contact newContactInstance = new Contact();

            foreach (var item in newContact)
            {
                newContactInstance = item;
            }

            SRM.Models.Contact oldContactInstance = db.Contacts.Single(e => e.ContactId == newContactInstance.ContactId);


            if (oldContact.Count > 0)
            {
                foreach (var item in oldContact)
                {
                    if (newContactInstance.ContactId == item.ContactId)
                    {
                        if (newContactInstance.FirstName == null)
                        {
                            foreach (var dealObj in updateDeal.Contacts.ToList())
                            {
                                if (newContactInstance.ContactId == dealObj.ContactId)
                                {
                                    updateDeal.Contacts.Remove(dealObj);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (oldContactInstance.FirstName != null)
                        {
                            updateDeal.Contacts.Add(oldContactInstance);
                        }
                    }
                }
            }
            else
            {
                if (oldContactInstance.FirstName != null)
                {
                    updateDeal.Contacts.Add(oldContactInstance);
                }
            }

            updateDeal.Name = deal.Name;
            updateDeal.Amount = deal.Amount;
            updateDeal.Stage = deal.Stage;
            db.SaveChanges();
            return true;       
        }
    }
}