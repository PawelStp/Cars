using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class ZakupController : Controller
    {
        // GET: Zakup
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var zakupy = dbContext.Zakup.GetAll();
                return View(zakupy);
            }
        }

        // GET: Zakup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Zakup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zakup/Create
        [HttpPost]
        public ActionResult Create(Zakup zakup)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Zakup.Add(zakup);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zakup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Zakup/Edit/5
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

        // GET: Zakup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Zakup/Delete/5
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
