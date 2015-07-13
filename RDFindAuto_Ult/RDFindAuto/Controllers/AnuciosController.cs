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
    public class AnuciosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Anucios
        public ActionResult Index()
        {
            return View(db.Anucios.ToList());
        }

        // GET: Anucios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anucio anucio = db.Anucios.Find(id);
            if (anucio == null)
            {
                return HttpNotFound();
            }
            return View(anucio);
        }

        // GET: Anucios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anucios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAnucio,anucioDesc,URL")] Anucio anucio)
        {
            if (ModelState.IsValid)
            {
                db.Anucios.Add(anucio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anucio);
        }

        // GET: Anucios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anucio anucio = db.Anucios.Find(id);
            if (anucio == null)
            {
                return HttpNotFound();
            }
            return View(anucio);
        }

        // POST: Anucios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAnucio,anucioDesc,URL")] Anucio anucio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anucio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anucio);
        }

        // GET: Anucios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anucio anucio = db.Anucios.Find(id);
            if (anucio == null)
            {
                return HttpNotFound();
            }
            return View(anucio);
        }

        // POST: Anucios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anucio anucio = db.Anucios.Find(id);
            db.Anucios.Remove(anucio);
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
