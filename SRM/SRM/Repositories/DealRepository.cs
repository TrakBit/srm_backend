using System.Collections.Generic;
using System.Linq;
using SRM.Models;

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

        public bool Update(Deal deal)
        {
            Deal updateDeal = db.Deals.Single(e => e.DealId == deal.DealId);

            var newContactList = deal.Contacts.ToList();
            var oldContactList = updateDeal.Contacts.ToList();

            foreach (var newContact in newContactList)
            {
                var oldContactInstance = db.Contacts.Single(c => c.ContactId == newContact.ContactId);
                if (oldContactList.Count > 0)
                {
                    foreach (var oldContact in oldContactList)
                    {
                        if (newContact.ContactId == oldContact.ContactId)
                        {
                            if (newContact.FirstName == null)
                            {
                                updateDeal.Contacts.Remove(oldContact);
                            }
                            else
                            {
                                updateDeal.Contacts.Add(oldContact);
                            }
                        }
                        else
                        {
                            if (newContact.FirstName != null)
                            {
                                updateDeal.Contacts.Add(oldContactInstance);
                            }
                        }

                    }
                }
                else
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