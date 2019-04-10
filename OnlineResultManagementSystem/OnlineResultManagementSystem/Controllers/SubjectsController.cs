using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineResultManagementSystem.Models;

namespace OnlineResultManagementSystem.Controllers
{
    public class SubjectsController : Controller
    {
        private OnlineResultDBEntities db = new OnlineResultDBEntities();

        // GET: Subjects
        public ActionResult Index()
        {
            return View(db.tblSubjects.ToList());
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubject tblSubject = db.tblSubjects.Find(id);
            if (tblSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblSubject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subject_id,subject_name,subject_code,full_marks,credit")] tblSubject tblSubject)
        {
            if (ModelState.IsValid)
            {
                db.tblSubjects.Add(tblSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSubject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubject tblSubject = db.tblSubjects.Find(id);
            if (tblSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblSubject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subject_id,subject_name,subject_code,full_marks,credit")] tblSubject tblSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSubject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubject tblSubject = db.tblSubjects.Find(id);
            if (tblSubject == null)
            {
                return HttpNotFound();
            }
            return View(tblSubject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSubject tblSubject = db.tblSubjects.Find(id);
            db.tblSubjects.Remove(tblSubject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
