using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RDFindAuto.Models;

namespace RDFindAuto.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "RDFindAuto";
            ViewBag.Marcas = db.Marcas.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Donde encontraras el vehiculo que andas buscando.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}