using NHibernate;
using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonSamochodowy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ISession session = NHibernateSession.OpenSession();
            {
                var persons = session.Query<Dzial>().ToList();
                return View(persons);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}