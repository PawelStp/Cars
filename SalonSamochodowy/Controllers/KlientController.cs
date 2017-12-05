using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class KlientController : Controller
    {
        // GET: Klient
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var klienci = dbContext.Klienci.GetAll();
                return View(klienci);
            }
        }

        // GET: Klient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Klient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klient/Create
        [HttpPost]
        public ActionResult Create(Klient kleint)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Klienci.Add(kleint);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Klient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Klient/Edit/5
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

        // GET: Klient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Klient/Delete/5
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
