using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BITCollege_KS.Models;

namespace BITCollege_KS.Controllers
{
    public class NextRegistrationNumberController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /NextRegistrationNumber/

        public ActionResult Index()
        {
            return View(NextRegistrationNumber.getInstance());
        }

        //
        // GET: /NextRegistrationNumber/Details/5

        public ActionResult Details(int id = 0)
        {
            NextRegistrationNumber nextregistrationnumber = db.NextRegistrationNumbers.Find(id);
            if (nextregistrationnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextregistrationnumber);
        }

        //
        // GET: /NextRegistrationNumber/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NextRegistrationNumber/Create

        [HttpPost]
        public ActionResult Create(NextRegistrationNumber nextregistrationnumber)
        {
            if (ModelState.IsValid)
            {
                db.NextRegistrationNumbers.Add(nextregistrationnumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextregistrationnumber);
        }

        //
        // GET: /NextRegistrationNumber/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextRegistrationNumber nextregistrationnumber = db.NextRegistrationNumbers.Find(id);
            if (nextregistrationnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextregistrationnumber);
        }

        //
        // POST: /NextRegistrationNumber/Edit/5

        [HttpPost]
        public ActionResult Edit(NextRegistrationNumber nextregistrationnumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextregistrationnumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextregistrationnumber);
        }

        //
        // GET: /NextRegistrationNumber/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextRegistrationNumber nextregistrationnumber = db.NextRegistrationNumbers.Find(id);
            if (nextregistrationnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextregistrationnumber);
        }

        //
        // POST: /NextRegistrationNumber/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NextRegistrationNumber nextregistrationnumber = db.NextRegistrationNumbers.Find(id);
            db.NextRegistrationNumbers.Remove(nextregistrationnumber);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}