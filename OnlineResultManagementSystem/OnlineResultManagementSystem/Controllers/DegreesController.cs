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
    public class DegreesController : Controller
    {
        private OnlineResultDBEntities db = new OnlineResultDBEntities();

        // GET: Degrees
        public ActionResult Index()
        {
            return View(db.tblDegrees.ToList());
        }

        // GET: Degrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDegree tblDegree = db.tblDegrees.Find(id);
            if (tblDegree == null)
            {
                return HttpNotFound();
            }
            return View(tblDegree);
        }

        // GET: Degrees/Create
        public ActionResult Create()
        {
            List<SelectListItem> degrees = new List<SelectListItem>();
            degrees.Add(new SelectListItem { Text = "Hons", Value = "Hons" });
            degrees.Add(new SelectListItem { Text = "Masters", Value = "Masters" });
            degrees.Add(new SelectListItem { Text = "HSC", Value = "HSC" });
            


            ViewBag.degree_name = degrees;
            return View();
        }
          

        // POST: Degrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "degree_id,degree_name")] tblDegree tblDegree)
        {
            if (ModelState.IsValid)
            {
                db.tblDegrees.Add(tblDegree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDegree);
        }

        // GET: Degrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDegree tblDegree = db.tblDegrees.Find(id);
            if (tblDegree == null)
            {
                return HttpNotFound();
            }
            return View(tblDegree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "degree_id,degree_name")] tblDegree tblDegree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDegree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDegree);
        }

        // GET: Degrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDegree tblDegree = db.tblDegrees.Find(id);
            if (tblDegree == null)
            {
                return HttpNotFound();
            }
            return View(tblDegree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDegree tblDegree = db.tblDegrees.Find(id);
            db.tblDegrees.Remove(tblDegree);
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
