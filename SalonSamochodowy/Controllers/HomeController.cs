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
                var persons1 = session.Query<Klient>().ToList();
                var persons2 = session.Query<Fabryka>().ToList();
                var persons3 = session.Query<Samochod_fabryka>().ToList();
                var persons4 = session.Query<Zakup>().ToList();
                var persons5 = session.Query<Zamowienie>().ToList();
                var persons6 = session.Query<Pracownik>().ToList();
                //var persons7 = session.Query<Status_zamowienia>().ToList();
                //var persons8 = session.Query<Samochod>().ToList();
                return View();
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