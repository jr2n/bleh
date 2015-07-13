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
    public class ModelosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Modelos
        public ActionResult Index()
        {
            var modelos = db.Modelos.Include(m => m.marca);
            return View(modelos.ToList());
        }

        // GET: Modelos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // GET: Modelos/Create
        public ActionResult Create()
        {
            ViewBag.IDMarca = new SelectList(db.Marcas, "IDMarca", "marcaDesc");
            return View();
        }

        // POST: Modelos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDModelo,IDMarca,modeloDesc")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                db.Modelos.Add(modelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMarca = new SelectList(db.Marcas, "IDMarca", "marcaDesc", modelo.IDMarca);
            return View(modelo);
        }

        // GET: Modelos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMarca = new SelectList(db.Marcas, "IDMarca", "marcaDesc", modelo.IDMarca);
            return View(modelo);
        }

        // POST: Modelos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDModelo,IDMarca,modeloDesc")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMarca = new SelectList(db.Marcas, "IDMarca", "marcaDesc", modelo.IDMarca);
            return View(modelo);
        }

        // GET: Modelos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Modelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelo modelo = db.Modelos.Find(id);
            db.Modelos.Remove(modelo);
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
