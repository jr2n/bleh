using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RDFindAuto.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace RDFindAuto.Controllers
{
    public class PublicacionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Publicaciones
        public ActionResult Index()
        {
            var publicaciones = db.Publicaciones.Include(p => p.color).Include(p => p.condicion).Include(p => p.marca).Include(p => p.modelo).Include(p => p.tipoCombustible).Include(p => p.tiposVehiculo);
            return View(publicaciones.ToList());
        }

        // GET: Publicaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Publicacion publicacion = db.Publicaciones.Find(id);
            Publicacion publicacion = db.Publicaciones.Include(s => s.Files).SingleOrDefault(s => s.IDPublicacion == id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        // GET: Publicaciones/Create
        public ActionResult Create()
        {
            ViewBag.IDColor = new SelectList(db.Colores, "IDColor", "colorDesc");
            ViewBag.IDCondicion = new SelectList(db.Condiciones, "IDCondicion", "condicionDesc");
            ViewBag.IDMarca = new SelectList(db.Marcas, "IDMarca", "marcaDesc");
            ViewBag.IDModelo = new SelectList(db.Modelos, "IDModelo", "modeloDesc");
            ViewBag.IDTipoCombustible = new SelectList(db.TipoCombustibles, "IDTipoCombustible", "tipoCombustibledesc");
            ViewBag.IDTipoVehiculo = new SelectList(db.TiposVehiculos, "IDTipoVehiculo", "tipoVehiculodesc");
            return View();
        }

        // POST: Publicaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPublicacion,IDMarca,IDModelo,Precio,IDColor,IDTipoCombustible,IDTipoVehiculo,IDCondicion,IDUser,WDate,Status")] Publicacion publicacion, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    publicacion.Files = new List<File> { avatar };
                }
                db.Publicaciones.Add(publicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDColor = new SelectList(db.Colores, "IDColor", "colorDesc", publicacion.IDColor);
            ViewBag.IDCondicion = new SelectList(db.Condiciones, "IDCondicion", "condicionDesc", publicacion.IDCondicion);
            ViewBag.IDMarca = new SelectList(db.Marcas, "IDMarca", "marcaDesc", publicacion.IDMarca);
            ViewBag.IDModelo = new SelectList(db.Modelos, "IDModelo", "modeloDesc", publicacion.IDModelo);
            ViewBag.IDTipoCombustible = new SelectList(db.TipoCombustibles, "IDTipoCombustible", "tipoCombustibledesc", publicacion.IDTipoCombustible);
            ViewBag.IDTipoVehiculo = new SelectList(db.TiposVehiculos, "IDTipoVehiculo", "tipoVehiculodesc", publicacion.IDTipoVehiculo);
            return View(publicacion);
        }

        // GET: Publicaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicaciones.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDColor = new SelectList(db.Colores, "IDColor", "colorDesc", publicacion.IDColor);
            ViewBag.IDCondicion = new SelectList(db.Condiciones, "IDCondicion", "condicionDesc", publicacion.IDCondicion);
            ViewBag.IDMarca = new SelectList(db.Marcas, "IDMarca", "marcaDesc", publicacion.IDMarca);
            ViewBag.IDModelo = new SelectList(db.Modelos, "IDModelo", "modeloDesc", publicacion.IDModelo);
            ViewBag.IDTipoCombustible = new SelectList(db.TipoCombustibles, "IDTipoCombustible", "tipoCombustibledesc", publicacion.IDTipoCombustible);
            ViewBag.IDTipoVehiculo = new SelectList(db.TiposVehiculos, "IDTipoVehiculo", "tipoVehiculodesc", publicacion.IDTipoVehiculo);
            return View(publicacion);
        }

        // POST: Publicaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPublicacion,IDMarca,IDModelo,Precio,IDColor,IDTipoCombustible,IDTipoVehiculo,IDCondicion,IDUser,WDate,Status")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDColor = new SelectList(db.Colores, "IDColor", "colorDesc", publicacion.IDColor);
            ViewBag.IDCondicion = new SelectList(db.Condiciones, "IDCondicion", "condicionDesc", publicacion.IDCondicion);
            ViewBag.IDMarca = new SelectList(db.Marcas, "IDMarca", "marcaDesc", publicacion.IDMarca);
            ViewBag.IDModelo = new SelectList(db.Modelos, "IDModelo", "modeloDesc", publicacion.IDModelo);
            ViewBag.IDTipoCombustible = new SelectList(db.TipoCombustibles, "IDTipoCombustible", "tipoCombustibledesc", publicacion.IDTipoCombustible);
            ViewBag.IDTipoVehiculo = new SelectList(db.TiposVehiculos, "IDTipoVehiculo", "tipoVehiculodesc", publicacion.IDTipoVehiculo);
            return View(publicacion);
        }

        // GET: Publicaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicaciones.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        // POST: Publicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicacion publicacion = db.Publicaciones.Find(id);
            db.Publicaciones.Remove(publicacion);
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
