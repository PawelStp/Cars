using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class DzialController : Controller
    {
        // GET: Dzial
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var dzialy = dbContext.Dzialy.GetAll();
                return View(dzialy);
            }
        }

        // GET: Dzial/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dzial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dzial/Create
        [HttpPost]
        public ActionResult Create(Dzial collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Dzialy.Add(collection);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dzial/Edit/5
        public ActionResult Edit(int id)
        {
            using (var dbContext = new DbContext())
            {
                var dzialy = dbContext.Dzialy.GetAll();
                return View(dzialy.Where(d => d.Id == id).FirstOrDefault());
            }
        }

        // POST: Dzial/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Dzial collection)
        {
            try
            {
                // TODO: Add update logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Dzialy.Update(collection);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dzial/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dzial/Delete/5
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
