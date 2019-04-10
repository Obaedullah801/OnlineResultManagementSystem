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
    public class CgparulesController : Controller
    {
        private OnlineResultDBEntities db = new OnlineResultDBEntities();

        // GET: Cgparules
        public ActionResult Index()
        {
            return View(db.tblCgparules.ToList());
        }

        // GET: Cgparules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCgparule tblCgparule = db.tblCgparules.Find(id);
            if (tblCgparule == null)
            {
                return HttpNotFound();
            }
            return View(tblCgparule);
        }

        // GET: Cgparules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cgparules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cgpa_rules_id,minimum_marks,maximum_marks,grade_point,letter_grade,division_or_class")] tblCgparule tblCgparule)
        {
            if (ModelState.IsValid)
            {
                db.tblCgparules.Add(tblCgparule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCgparule);
        }

        // GET: Cgparules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCgparule tblCgparule = db.tblCgparules.Find(id);
            if (tblCgparule == null)
            {
                return HttpNotFound();
            }
            return View(tblCgparule);
        }

        // POST: Cgparules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cgpa_rules_id,minimum_marks,maximum_marks,grade_point,letter_grade,division_or_class")] tblCgparule tblCgparule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCgparule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCgparule);
        }

        // GET: Cgparules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCgparule tblCgparule = db.tblCgparules.Find(id);
            if (tblCgparule == null)
            {
                return HttpNotFound();
            }
            return View(tblCgparule);
        }

        // POST: Cgparules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCgparule tblCgparule = db.tblCgparules.Find(id);
            db.tblCgparules.Remove(tblCgparule);
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
