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
    public class NextMasteryCourseController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /NextMasteryCourse/

        public ActionResult Index()
        {
            return View(NextMasteryCourse.getInstance());
        }

        //
        // GET: /NextMasteryCourse/Details/5

        public ActionResult Details(int id = 0)
        {
            NextMasteryCourse nextmasterycourse = db.NextMasteryCourses.Find(id);
            if (nextmasterycourse == null)
            {
                return HttpNotFound();
            }
            return View(nextmasterycourse);
        }

        //
        // GET: /NextMasteryCourse/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NextMasteryCourse/Create

        [HttpPost]
        public ActionResult Create(NextMasteryCourse nextmasterycourse)
        {
            if (ModelState.IsValid)
            {
                db.NextMasteryCourses.Add(nextmasterycourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextmasterycourse);
        }

        //
        // GET: /NextMasteryCourse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextMasteryCourse nextmasterycourse = db.NextMasteryCourses.Find(id);
            if (nextmasterycourse == null)
            {
                return HttpNotFound();
            }
            return View(nextmasterycourse);
        }

        //
        // POST: /NextMasteryCourse/Edit/5

        [HttpPost]
        public ActionResult Edit(NextMasteryCourse nextmasterycourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextmasterycourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextmasterycourse);
        }

        //
        // GET: /NextMasteryCourse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextMasteryCourse nextmasterycourse = db.NextMasteryCourses.Find(id);
            if (nextmasterycourse == null)
            {
                return HttpNotFound();
            }
            return View(nextmasterycourse);
        }

        //
        // POST: /NextMasteryCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NextMasteryCourse nextmasterycourse = db.NextMasteryCourses.Find(id);
            db.NextMasteryCourses.Remove(nextmasterycourse);
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