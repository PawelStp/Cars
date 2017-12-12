using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var car = dbContext.Samochody.GetAll();
                return View(car);
            }
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            using (var dbContext = new DbContext())
            {
                var dzialy = dbContext.Samochody.GetAll();
                return View(dzialy.Where(d => d.Id == id).FirstOrDefault());
            }
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Samochod collection)
        {
            try
            {
                // TODO: Add update logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Samochody.Update(collection);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Car/Delete/5
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
