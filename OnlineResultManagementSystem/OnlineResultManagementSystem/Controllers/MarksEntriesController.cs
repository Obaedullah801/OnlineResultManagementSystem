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
    public class MarksEntriesController : Controller
    {
        private OnlineResultDBEntities db = new OnlineResultDBEntities();

        // GET: MarksEntries
        public ActionResult Index()
        {
            var tblMarksEntries = db.tblMarksEntries.Include(t => t.tblDegree).Include(t => t.tblDegree1).Include(t => t.tblDepartment).Include(t => t.tblStudentProfile).Include(t => t.tblSubject);
            return View(tblMarksEntries.ToList());
        }

        // GET: MarksEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMarksEntry tblMarksEntry = db.tblMarksEntries.Find(id);
            if (tblMarksEntry == null)
            {
                return HttpNotFound();
            }
            return View(tblMarksEntry);
        }

        // GET: MarksEntries/Create
        public ActionResult Create()
        {
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name");
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name");
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name");
            ViewBag.student_profile_id = new SelectList(db.tblStudentProfiles, "student_profile_id", "student_name");
            ViewBag.subject_id = new SelectList(db.tblSubjects, "subject_id", "subject_name");
            return View();
        }

        // POST: MarksEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marks_entry_id,student_profile_id,degree_id,department_id,semester_id,roll_no,reg_no,subject_id,full_marks,obtained_marks")] tblMarksEntry tblMarksEntry)
        {
            if (ModelState.IsValid)
            {
                db.tblMarksEntries.Add(tblMarksEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblMarksEntry.degree_id);
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblMarksEntry.degree_id);
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name", tblMarksEntry.department_id);
            ViewBag.student_profile_id = new SelectList(db.tblStudentProfiles, "student_profile_id", "student_name", tblMarksEntry.student_profile_id);
            ViewBag.subject_id = new SelectList(db.tblSubjects, "subject_id", "subject_name", tblMarksEntry.subject_id);
            return View(tblMarksEntry);
        }

        // GET: MarksEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMarksEntry tblMarksEntry = db.tblMarksEntries.Find(id);
            if (tblMarksEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblMarksEntry.degree_id);
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblMarksEntry.degree_id);
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name", tblMarksEntry.department_id);
            ViewBag.student_profile_id = new SelectList(db.tblStudentProfiles, "student_profile_id", "student_name", tblMarksEntry.student_profile_id);
            ViewBag.subject_id = new SelectList(db.tblSubjects, "subject_id", "subject_name", tblMarksEntry.subject_id);
            return View(tblMarksEntry);
        }

        // POST: MarksEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marks_entry_id,student_profile_id,degree_id,department_id,semester_id,roll_no,reg_no,subject_id,full_marks,obtained_marks")] tblMarksEntry tblMarksEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMarksEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblMarksEntry.degree_id);
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblMarksEntry.degree_id);
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name", tblMarksEntry.department_id);
            ViewBag.student_profile_id = new SelectList(db.tblStudentProfiles, "student_profile_id", "student_name", tblMarksEntry.student_profile_id);
            ViewBag.subject_id = new SelectList(db.tblSubjects, "subject_id", "subject_name", tblMarksEntry.subject_id);
            return View(tblMarksEntry);
        }

        // GET: MarksEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMarksEntry tblMarksEntry = db.tblMarksEntries.Find(id);
            if (tblMarksEntry == null)
            {
                return HttpNotFound();
            }
            return View(tblMarksEntry);
        }

        // POST: MarksEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMarksEntry tblMarksEntry = db.tblMarksEntries.Find(id);
            db.tblMarksEntries.Remove(tblMarksEntry);
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
