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
    public class RegularStateController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /RegularState/

        public ActionResult Index()
        {
            return View(RegularState.getInstance());
        }

        //
        // GET: /RegularState/Details/5

        public ActionResult Details(int id = 0)
        {
            RegularState regularstate = db.RegularStates.Find(id);
            if (regularstate == null)
            {
                return HttpNotFound();
            }
            return View(regularstate);
        }

        //
        // GET: /RegularState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RegularState/Create

        [HttpPost]
        public ActionResult Create(RegularState regularstate)
        {
            if (ModelState.IsValid)
            {
                db.GPAStates.Add(regularstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regularstate);
        }

        //
        // GET: /RegularState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RegularState regularstate = db.RegularStates.Find(id);
            if (regularstate == null)
            {
                return HttpNotFound();
            }
            return View(regularstate);
        }

        //
        // POST: /RegularState/Edit/5

        [HttpPost]
        public ActionResult Edit(RegularState regularstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regularstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regularstate);
        }

        //
        // GET: /RegularState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RegularState regularstate = db.RegularStates.Find(id);
            if (regularstate == null)
            {
                return HttpNotFound();
            }
            return View(regularstate);
        }

        //
        // POST: /RegularState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RegularState regularstate = db.RegularStates.Find(id);
            db.GPAStates.Remove(regularstate);
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