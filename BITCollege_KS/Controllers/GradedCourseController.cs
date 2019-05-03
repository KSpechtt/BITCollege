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
    public class GradedCourseController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /GradedCourse/

        public ActionResult Index()
        {
            var courses = db.GradedCourses.Include(g => g.Program);
            return View(courses.ToList());
        }

        //
        // GET: /GradedCourse/Details/5

        public ActionResult Details(int id = 0)
        {
            GradedCourse gradedcourse = db.GradedCourses.Find(id);
            if (gradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedcourse);
        }

        //
        // GET: /GradedCourse/Create

        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description");
            return View();
        }

        //
        // POST: /GradedCourse/Create

        [HttpPost]
        public ActionResult Create(GradedCourse gradedcourse)
        {
            if (ModelState.IsValid)
            {
                gradedcourse.setNextCourseNumber();
                db.Courses.Add(gradedcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description", gradedcourse.ProgramId);
            return View(gradedcourse);
        }

        //
        // GET: /GradedCourse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GradedCourse gradedcourse = db.GradedCourses.Find(id);
            if (gradedcourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description", gradedcourse.ProgramId);
            return View(gradedcourse);
        }

        //
        // POST: /GradedCourse/Edit/5

        [HttpPost]
        public ActionResult Edit(GradedCourse gradedcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradedcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Description", gradedcourse.ProgramId);
            return View(gradedcourse);
        }

        //
        // GET: /GradedCourse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GradedCourse gradedcourse = db.GradedCourses.Find(id);
            if (gradedcourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedcourse);
        }

        //
        // POST: /GradedCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GradedCourse gradedcourse = db.GradedCourses.Find(id);
            db.Courses.Remove(gradedcourse);
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