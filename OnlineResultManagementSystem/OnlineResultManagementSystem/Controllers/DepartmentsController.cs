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
    public class DepartmentsController : Controller
    {
        private OnlineResultDBEntities db = new OnlineResultDBEntities();

        // GET: Departments
        public ActionResult Index()
        {
            return View(db.tblDepartments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            List<SelectListItem> departments = new List<SelectListItem>();
            departments.Add(new SelectListItem { Text = "Bangali", Value = "Bangali" });
            departments.Add(new SelectListItem { Text = "English", Value = "English" });
            departments.Add(new SelectListItem { Text = "Mathematics", Value = "Mathematics" });
            departments.Add(new SelectListItem { Text = "CSE", Value = "CSE" });
            departments.Add(new SelectListItem { Text = "BBA", Value = "BBA" });
            departments.Add(new SelectListItem { Text = "Accounting", Value = "Accounting" });
            departments.Add(new SelectListItem { Text = "Finance and Banking", Value = "Finance and Banking" });
            departments.Add(new SelectListItem { Text = "Marketing", Value = "Marketing" });


            ViewBag.department_name = departments;
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "department_id,department_name,dept_address")] tblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                db.tblDepartments.Add(tblDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDepartment);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "department_id,department_name,dept_address")] tblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDepartment);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            db.tblDepartments.Remove(tblDepartment);
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
