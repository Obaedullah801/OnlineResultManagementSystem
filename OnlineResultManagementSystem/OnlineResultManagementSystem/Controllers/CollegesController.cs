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
    public class CollegesController : Controller
    {
        private OnlineResultDBEntities db = new OnlineResultDBEntities();

        // GET: Colleges
        public ActionResult Index()
        {
            return View(db.tblColleges.ToList());
        }

        // GET: Colleges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCollege tblCollege = db.tblColleges.Find(id);
            if (tblCollege == null)
            {
                return HttpNotFound();
            }
            return View(tblCollege);
        }

        // GET: Colleges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colleges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "college_id,college_name,college_code,college_logo,college_address")] tblCollege tblCollege)
        {
            if (ModelState.IsValid)
            {
                db.tblColleges.Add(tblCollege);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCollege);
        }

        // GET: Colleges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCollege tblCollege = db.tblColleges.Find(id);
            if (tblCollege == null)
            {
                return HttpNotFound();
            }
            return View(tblCollege);
        }

        // POST: Colleges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "college_id,college_name,college_code,college_logo,college_address")] tblCollege tblCollege)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCollege).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCollege);
        }

        // GET: Colleges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCollege tblCollege = db.tblColleges.Find(id);
            if (tblCollege == null)
            {
                return HttpNotFound();
            }
            return View(tblCollege);
        }

        // POST: Colleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCollege tblCollege = db.tblColleges.Find(id);
            db.tblColleges.Remove(tblCollege);
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
