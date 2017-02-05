using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public bool Update( Deal deal)
        {
            Deal updateDeal = db.Deals.Single(e => e.DealId == deal.DealId);
            updateDeal.Name = deal.Name;
            updateDeal.Amount = deal.Amount;
            updateDeal.Stage = deal.Stage;
            db.SaveChanges();
            return true;       
        }
    }
}