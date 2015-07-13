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
    public class TipoCombustiblesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoCombustibles
        public ActionResult Index()
        {
            return View(db.TipoCombustibles.ToList());
        }

        // GET: TipoCombustibles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCombustible tipoCombustible = db.TipoCombustibles.Find(id);
            if (tipoCombustible == null)
            {
                return HttpNotFound();
            }
            return View(tipoCombustible);
        }

        // GET: TipoCombustibles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCombustibles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTipoCombustible,tipoCombustibledesc")] TipoCombustible tipoCombustible)
        {
            if (ModelState.IsValid)
            {
                db.TipoCombustibles.Add(tipoCombustible);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCombustible);
        }

        // GET: TipoCombustibles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCombustible tipoCombustible = db.TipoCombustibles.Find(id);
            if (tipoCombustible == null)
            {
                return HttpNotFound();
            }
            return View(tipoCombustible);
        }

        // POST: TipoCombustibles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTipoCombustible,tipoCombustibledesc")] TipoCombustible tipoCombustible)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCombustible).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCombustible);
        }

        // GET: TipoCombustibles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCombustible tipoCombustible = db.TipoCombustibles.Find(id);
            if (tipoCombustible == null)
            {
                return HttpNotFound();
            }
            return View(tipoCombustible);
        }

        // POST: TipoCombustibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCombustible tipoCombustible = db.TipoCombustibles.Find(id);
            db.TipoCombustibles.Remove(tipoCombustible);
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
