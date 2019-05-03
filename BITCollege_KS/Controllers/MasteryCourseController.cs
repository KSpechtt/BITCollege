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
    public class MasteryCourseController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /MasteryCourse/

        public ActionResult Index()
        {
            var courses = db.MasteryCourses.Include(m => m.Program);
            return View(courses.ToList());
        }

        //
        // GET: /MasteryCourse/Details/5

        public ActionResult Details(int id = 0)
        {
            MasteryCourse masterycourse = db.MasteryCourses.Find(id);
            if (masterycourse == null)
            {
                return HttpNotFound();
            }
            return View(masterycourse);
        }

        //
        // GET: /MasteryCourse/Create

        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description");
            return View();
        }

        //
        // POST: /MasteryCourse/Create

        [HttpPost]
        public ActionResult Create(MasteryCourse masterycourse)
        {
            if (ModelState.IsValid)
            {
                masterycourse.setNextCourseNumber();
                db.Courses.Add(masterycourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description", masterycourse.ProgramId);
            return View(masterycourse);
        }

        //
        // GET: /MasteryCourse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MasteryCourse masterycourse = db.MasteryCourses.Find(id);
            if (masterycourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description", masterycourse.ProgramId);
            return View(masterycourse);
        }

        //
        // POST: /MasteryCourse/Edit/5

        [HttpPost]
        public ActionResult Edit(MasteryCourse masterycourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterycourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description", masterycourse.ProgramId);
            return View(masterycourse);
        }

        //
        // GET: /MasteryCourse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MasteryCourse masterycourse = db.MasteryCourses.Find(id);
            if (masterycourse == null)
            {
                return HttpNotFound();
            }
            return View(masterycourse);
        }

        //
        // POST: /MasteryCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MasteryCourse masterycourse = db.MasteryCourses.Find(id);
            db.Courses.Remove(masterycourse);
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