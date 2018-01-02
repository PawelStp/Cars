using NHibernate;
using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //using (var dbContext = new DbContext())
            //{
            //    dbContext.InitData();
            //    dbContext.SaveChanges();
            //}
            if (Request.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Login");
        }
    }
}