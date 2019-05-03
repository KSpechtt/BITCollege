﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BITCollege_KS.Models;

namespace BITCollege_KS.Controllers
{
    public class NextAuditCourseController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /NextAuditCourse/

        public ActionResult Index()
        {
            return View(NextAuditCourse.getInstance());
        }

        //
        // GET: /NextAuditCourse/Details/5

        public ActionResult Details(int id = 0)
        {
            NextAuditCourse nextauditcourse = db.NextAuditCourses.Find(id);
            if (nextauditcourse == null)
            {
                return HttpNotFound();
            }
            return View(nextauditcourse);
        }

        //
        // GET: /NextAuditCourse/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NextAuditCourse/Create

        [HttpPost]
        public ActionResult Create(NextAuditCourse nextauditcourse)
        {
            if (ModelState.IsValid)
            {
                db.NextAuditCourses.Add(nextauditcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextauditcourse);
        }

        //
        // GET: /NextAuditCourse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextAuditCourse nextauditcourse = db.NextAuditCourses.Find(id);
            if (nextauditcourse == null)
            {
                return HttpNotFound();
            }
            return View(nextauditcourse);
        }

        //
        // POST: /NextAuditCourse/Edit/5

        [HttpPost]
        public ActionResult Edit(NextAuditCourse nextauditcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextauditcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextauditcourse);
        }

        //
        // GET: /NextAuditCourse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextAuditCourse nextauditcourse = db.NextAuditCourses.Find(id);
            if (nextauditcourse == null)
            {
                return HttpNotFound();
            }
            return View(nextauditcourse);
        }

        //
        // POST: /NextAuditCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NextAuditCourse nextauditcourse = db.NextAuditCourses.Find(id);
            db.NextAuditCourses.Remove(nextauditcourse);
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