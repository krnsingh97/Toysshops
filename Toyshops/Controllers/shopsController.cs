using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Toyshops.Models;

namespace Toyshops.Controllers
{
    [Authorize]
    public class shopsController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();
        private IshopsMock db;

        public shopsController()
        {
            this.db = new EFshops();
        }

        // mock constructor
        public shopsController(IshopsMock mock)
        {
            this.db = mock;
        }


        // GET: shops
        public ActionResult Index()
        {
            var shops = db.shops.Include(b => b.id);
          //  return View("Index", shops.ToList());

            return View(db.shops.ToList());
        }

        //// GET: shops/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }
            // shop shop = db.shops.Find(id);
            shop shop = db.shops.SingleOrDefault(a => a.id == id);

            if (shop == null)
            {
                //  return HttpNotFound();
                return View("Error");

            }
            return View("Details",shop);
        }

        //// GET: shops/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.shops, "id", "Name");

            return View("Create");
        }

        //// POST: shops/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Toys,Categories")] shop shop)
        {
            if (ModelState.IsValid)
            {
                //db.shops.Add(shop);
                //db.SaveChanges();
                db.Save(shop);
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.shops, "id", "Name", shop.id);


            return View("Create",shop);
        }

        //// GET: shops/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }
            // shop shop = db.shops.Find(id);
            shop shop = db.shops.SingleOrDefault(a => a.id == id);

            if (shop == null)
            {
                // return HttpNotFound();
                return View("Error");

            }
            ViewBag.id = new SelectList(db.shops, "id", "Name", shop.id);

            return View("Edit",shop);
        }

        //// POST: shops/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Toys,Categories")] shop shop)
        {
            if (ModelState.IsValid)
            {
                if (Request != null)
                {
                    // upload image if any
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file.FileName != null && file.ContentLength > 0)
                        {
                            // save file path
                            string path = Server.MapPath("~/Content/Images/") + file.FileName;

                            // save actual file
                            file.SaveAs(path);

                        }
                    }
                }
                // db.Entry(shop).State = EntityState.Modified;
                db.Save(shop);
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.shops, "id", "Name", shop.id);

            return View("Edit",shop);
        }

        //// GET: shops/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }
            //shop shop = db.shops.Find(id);
            shop shop = db.shops.SingleOrDefault(a => a.id == id);

            if (shop == null)
            {
                //return HttpNotFound();
                return View("Error");

            }
            return View("Delete",shop);

        }

        //// POST: shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //  shop shop = db.shops.Find(id);
            // db.shops.Remove(shop);
            // db.SaveChanges();
            if (id == null)
            {
                return View("Error");
            }

               shop shop = db.shops.SingleOrDefault(a => a.id == id);

            if (shop == null)
            {
                return View("Error");
            }

            db.Delete(shop);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
