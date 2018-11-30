using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toyshops.Models
{
    public class EFshops : IshopsMock
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IQueryable<shop> shops { get { return db.shops; } }

        public void Delete(shop shop)
        {
            db.shops.Remove(shop);
            db.SaveChanges();
        }

        public shop Save(shop shop)
        {
            if (shop.id == "one")
            {
                db.shops.Add(shop);
            }
            else
            {
                db.Entry(shop).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return shop;
        }
    }
}