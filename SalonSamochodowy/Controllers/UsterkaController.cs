using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class UsterkaController : Controller
    {
        // GET: Usterka
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var usterki = dbContext.Usterki.GetAll();
                return View(usterki);
            }
        }

        // GET: Usterka/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usterka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usterka/Create
        [HttpPost]
        public ActionResult Create(Usterka collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usterka/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usterka/Edit/5
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

        // GET: Usterka/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usterka/Delete/5
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
