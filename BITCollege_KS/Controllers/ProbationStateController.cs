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
    public class ProbationStateController : Controller
    {
        private BITCollege_KSContext db = new BITCollege_KSContext();

        //
        // GET: /ProbationState/

        public ActionResult Index()
        {
            return View(ProbationState.getInstance());
        }

        //
        // GET: /ProbationState/Details/5

        public ActionResult Details(int id = 0)
        {
            ProbationState probationstate = db.ProbationStates.Find(id);
            if (probationstate == null)
            {
                return HttpNotFound();
            }
            return View(probationstate);
        }

        //
        // GET: /ProbationState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProbationState/Create

        [HttpPost]
        public ActionResult Create(ProbationState probationstate)
        {
            if (ModelState.IsValid)
            {
                db.GPAStates.Add(probationstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(probationstate);
        }

        //
        // GET: /ProbationState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProbationState probationstate = db.ProbationStates.Find(id);
            if (probationstate == null)
            {
                return HttpNotFound();
            }
            return View(probationstate);
        }

        //
        // POST: /ProbationState/Edit/5

        [HttpPost]
        public ActionResult Edit(ProbationState probationstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(probationstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(probationstate);
        }

        //
        // GET: /ProbationState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProbationState probationstate = db.ProbationStates.Find(id);
            if (probationstate == null)
            {
                return HttpNotFound();
            }
            return View(probationstate);
        }

        //
        // POST: /ProbationState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProbationState probationstate = db.ProbationStates.Find(id);
            db.GPAStates.Remove(probationstate);
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