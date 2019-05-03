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
    public class RegistrationController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /Registration/

        public ActionResult Index()
        {
            var registrations = db.Registrations.Include(r => r.Student).Include(r => r.Course);
            return View(registrations.ToList());
        }

        //
        // GET: /Registration/Details/5

        public ActionResult Details(int id = 0)
        {
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        //
        // GET: /Registration/Create

        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title");
            return View();
        }

        //
        // POST: /Registration/Create

        [HttpPost]
        public ActionResult Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                registration.setNextRegistrationNumber();
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", registration.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", registration.CourseId);
            return View(registration);
        }

        //
        // GET: /Registration/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", registration.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", registration.CourseId);
            return View(registration);
        }

        //
        // POST: /Registration/Edit/5

        [HttpPost]
        public ActionResult Edit(Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", registration.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", registration.CourseId);
            return View(registration);
        }

        //
        // GET: /Registration/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        //
        // POST: /Registration/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
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