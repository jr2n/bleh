using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RDFindAuto.Models;

namespace RDFindAuto.Controllers
{
    public class CondicionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Condicions
        public ActionResult Index()
        {
            return View(db.Condiciones.ToList());
        }

        // GET: Condicions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicion = db.Condiciones.Find(id);
            if (condicion == null)
            {
                return HttpNotFound();
            }
            return View(condicion);
        }

        // GET: Condicions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condicions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCondicion,condicionDesc")] Condicion condicion)
        {
            if (ModelState.IsValid)
            {
                db.Condiciones.Add(condicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicion);
        }

        // GET: Condicions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicion = db.Condiciones.Find(id);
            if (condicion == null)
            {
                return HttpNotFound();
            }
            return View(condicion);
        }

        // POST: Condicions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCondicion,condicionDesc")] Condicion condicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicion);
        }

        // GET: Condicions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicion = db.Condiciones.Find(id);
            if (condicion == null)
            {
                return HttpNotFound();
            }
            return View(condicion);
        }

        // POST: Condicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Condicion condicion = db.Condiciones.Find(id);
            db.Condiciones.Remove(condicion);
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
