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
    public class SemestersController : Controller
    {
        private OnlineResultDBEntities db = new OnlineResultDBEntities();

        // GET: Semesters
        public ActionResult Index()
        {
            var tblSemesters = db.tblSemesters.Include(t => t.tblDegree).Include(t => t.tblDepartment);
            return View(tblSemesters.ToList());
        }

        // GET: Semesters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSemester tblSemester = db.tblSemesters.Find(id);
            if (tblSemester == null)
            {
                return HttpNotFound();
            }
            return View(tblSemester);
        }

        // GET: Semesters/Create
        public ActionResult Create()
        {
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name");
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name");
            List<SelectListItem> semesters = new List<SelectListItem>();
            semesters.Add(new SelectListItem { Text = "1st Semester", Value = "1st Semester" });
            semesters.Add(new SelectListItem { Text = "2nd Semester", Value = "1st Semester" });
            semesters.Add(new SelectListItem { Text = "3rd Semester", Value = "1st Semester" });
            semesters.Add(new SelectListItem { Text = "4th Semester", Value = "1st Semester" });
            semesters.Add(new SelectListItem { Text = "5th Semester", Value = "1st Semester" });
            semesters.Add(new SelectListItem { Text = "6th Semester", Value = "1st Semester" });
            semesters.Add(new SelectListItem { Text = "7th Semester", Value = "1st Semester" });
            semesters.Add(new SelectListItem { Text = "8th Semester", Value = "1st Semester" });
            semesters.Add(new SelectListItem { Text = "1st Year", Value = "1st Year" });
            semesters.Add(new SelectListItem { Text = "2nd Year", Value = "2nd Year" });
            semesters.Add(new SelectListItem { Text = "3rd Year", Value = "3rd Year" });
            semesters.Add(new SelectListItem { Text = "4th Year", Value = "4th Year" });
            ViewBag.semester_name = semesters;

            return View();
        }

        // POST: Semesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "semester_id,semester_name,degree_id,department_id")] tblSemester tblSemester)
        {
            if (ModelState.IsValid)
            {
                db.tblSemesters.Add(tblSemester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblSemester.degree_id);
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name", tblSemester.department_id);
            return View(tblSemester);
        }

        // GET: Semesters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSemester tblSemester = db.tblSemesters.Find(id);
            if (tblSemester == null)
            {
                return HttpNotFound();
            }
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblSemester.degree_id);
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name", tblSemester.department_id);
            return View(tblSemester);
        }

        // POST: Semesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "semester_id,semester_name,degree_id,department_id")] tblSemester tblSemester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSemester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.degree_id = new SelectList(db.tblDegrees, "degree_id", "degree_name", tblSemester.degree_id);
            ViewBag.department_id = new SelectList(db.tblDepartments, "department_id", "department_name", tblSemester.department_id);
            return View(tblSemester);
        }

        // GET: Semesters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSemester tblSemester = db.tblSemesters.Find(id);
            if (tblSemester == null)
            {
                return HttpNotFound();
            }
            return View(tblSemester);
        }

        // POST: Semesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSemester tblSemester = db.tblSemesters.Find(id);
            db.tblSemesters.Remove(tblSemester);
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
