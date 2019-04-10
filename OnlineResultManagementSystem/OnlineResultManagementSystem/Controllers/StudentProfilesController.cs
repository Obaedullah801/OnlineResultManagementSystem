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
    public class StudentProfilesController : Controller
    {
        private OnlineResultDBEntities db = new OnlineResultDBEntities();

        // GET: StudentProfiles
        public ActionResult Index()
        {
            var tblStudentProfiles = db.tblStudentProfiles.Include(t => t.tblDegree).Include(t => t.tblDepartment).Include(t => t.tblSemester);
            return View(tblStudentProfiles.ToList());
        }

        // GET: StudentProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentProfile tblStudentProfile = db.tblStudentProfiles.Find(id);
            if (tblStudentProfile == null)
            {
                return HttpNotFound();
            }
            return View(tblStudentProfile);
        }

        // GET: StudentProfiles/Create
        public ActionResult Create()
        {
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name");
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name");
            ViewBag.semester_id = new SelectList(db.tblSemesters, "semester_id", "semester_name");
            return View();
        }

        // POST: StudentProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "student_profile_id,student_name,student_photo,fathers_name,mothers_name,roll_no,reg_no,degree_id,department_id,semester_id,phone_no,email_id")] tblStudentProfile tblStudentProfile)
        {
            if (ModelState.IsValid)
            {
                db.tblStudentProfiles.Add(tblStudentProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblStudentProfile.degree_id);
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name", tblStudentProfile.department_id);
            ViewBag.semester_id = new SelectList(db.tblSemesters, "semester_id", "semester_name", tblStudentProfile.semester_id);
            return View(tblStudentProfile);
        }

        // GET: StudentProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentProfile tblStudentProfile = db.tblStudentProfiles.Find(id);
            if (tblStudentProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblStudentProfile.degree_id);
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name", tblStudentProfile.department_id);
            ViewBag.semester_id = new SelectList(db.tblSemesters, "semester_id", "semester_name", tblStudentProfile.semester_id);
            return View(tblStudentProfile);
        }

        // POST: StudentProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "student_profile_id,student_name,student_photo,fathers_name,mothers_name,roll_no,reg_no,degree_id,department_id,semester_id,phone_no,email_id")] tblStudentProfile tblStudentProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStudentProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblStudentProfile.degree_id);
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name", tblStudentProfile.department_id);
            ViewBag.semester_id = new SelectList(db.tblSemesters, "semester_id", "semester_name", tblStudentProfile.semester_id);
            return View(tblStudentProfile);
        }

        // GET: StudentProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentProfile tblStudentProfile = db.tblStudentProfiles.Find(id);
            if (tblStudentProfile == null)
            {
                return HttpNotFound();
            }
            return View(tblStudentProfile);
        }

        // POST: StudentProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStudentProfile tblStudentProfile = db.tblStudentProfiles.Find(id);
            db.tblStudentProfiles.Remove(tblStudentProfile);
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
