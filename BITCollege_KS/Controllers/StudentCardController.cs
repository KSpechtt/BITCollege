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
    public class StudentCardController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /StudentCard/

        public ActionResult Index()
        {
            var studentcards = db.StudentCards.Include(s => s.Student);
            return View(studentcards.ToList());
        }

        //
        // GET: /StudentCard/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentCard studentcard = db.StudentCards.Find(id);
            if (studentcard == null)
            {
                return HttpNotFound();
            }
            return View(studentcard);
        }

        //
        // GET: /StudentCard/Create

        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName");
            return View();
        }

        //
        // POST: /StudentCard/Create

        [HttpPost]
        public ActionResult Create(StudentCard studentcard)
        {
            if (ModelState.IsValid)
            {
                db.StudentCards.Add(studentcard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", studentcard.StudentId);
            return View(studentcard);
        }

        //
        // GET: /StudentCard/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentCard studentcard = db.StudentCards.Find(id);
            if (studentcard == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", studentcard.StudentId);
            return View(studentcard);
        }

        //
        // POST: /StudentCard/Edit/5

        [HttpPost]
        public ActionResult Edit(StudentCard studentcard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentcard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FullName", studentcard.StudentId);
            return View(studentcard);
        }

        //
        // GET: /StudentCard/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentCard studentcard = db.StudentCards.Find(id);
            if (studentcard == null)
            {
                return HttpNotFound();
            }
            return View(studentcard);
        }

        //
        // POST: /StudentCard/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCard studentcard = db.StudentCards.Find(id);
            db.StudentCards.Remove(studentcard);
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