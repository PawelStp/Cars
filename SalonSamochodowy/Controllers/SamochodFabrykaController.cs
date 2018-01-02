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
    public class SamochodFabrykaController : Controller
    {
        // GET: SamochodFabryka
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var samochodyFabryczne = dbContext.Samochody_fabryczne.GetAll();
                return View(samochodyFabryczne);
            }
        }

        // GET: SamochodFabryka/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SamochodFabryka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SamochodFabryka/Create
        [HttpPost]
        public ActionResult Create(Samochod_fabryka samochod)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Samochody_fabryczne.Add(samochod);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SamochodFabryka/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SamochodFabryka/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SamochodFabryka/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SamochodFabryka/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
