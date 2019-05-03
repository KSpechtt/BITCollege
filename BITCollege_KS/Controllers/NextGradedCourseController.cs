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
    public class NextGradedCourseController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /NextGradedCourse/

        public ActionResult Index()
        {
            return View(NextGradedCourse.getInstance());
        }

        //
        // GET: /NextGradedCourse/Details/5

        public ActionResult Details(int id = 0)
        {
            NextGradedCourse nextgradedcourse = db.NextGradedCourses.Find(id);
            if (nextgradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(nextgradedcourse);
        }

        //
        // GET: /NextGradedCourse/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NextGradedCourse/Create

        [HttpPost]
        public ActionResult Create(NextGradedCourse nextgradedcourse)
        {
            if (ModelState.IsValid)
            {
                db.NextGradedCourses.Add(nextgradedcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextgradedcourse);
        }

        //
        // GET: /NextGradedCourse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextGradedCourse nextgradedcourse = db.NextGradedCourses.Find(id);
            if (nextgradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(nextgradedcourse);
        }

        //
        // POST: /NextGradedCourse/Edit/5

        [HttpPost]
        public ActionResult Edit(NextGradedCourse nextgradedcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextgradedcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextgradedcourse);
        }

        //
        // GET: /NextGradedCourse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextGradedCourse nextgradedcourse = db.NextGradedCourses.Find(id);
            if (nextgradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(nextgradedcourse);
        }

        //
        // POST: /NextGradedCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NextGradedCourse nextgradedcourse = db.NextGradedCourses.Find(id);
            db.NextGradedCourses.Remove(nextgradedcourse);
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