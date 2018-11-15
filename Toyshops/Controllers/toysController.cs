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
    public class toysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: toys
        public ActionResult Index()
        {
            return View(db.toys.ToList());
        }

        // GET: toys/Details/5
       
        public ActionResult Details(string id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            toy toy = db.toys.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }

        // GET: toys/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: toys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Toy1,age")] toy toy)
        {
            if (ModelState.IsValid)
            {
                db.toys.Add(toy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toy);
        }

        // GET: toys/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            toy toy = db.toys.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }

        // POST: toys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Toy1,age")] toy toy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toy);
        }

        // GET: toys/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            toy toy = db.toys.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }

        // POST: toys/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            toy toy = db.toys.Find(id);
            db.toys.Remove(toy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
