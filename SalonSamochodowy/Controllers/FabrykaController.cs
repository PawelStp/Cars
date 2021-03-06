﻿using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class FabrykaController : Controller
    {
        // GET: Fabryka
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var fabryki = dbContext.Fabryki.GetAll();
                return View(fabryki);
            }
        }

        // GET: Fabryka/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fabryka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabryka/Create
        [HttpPost]
        public ActionResult Create(Fabryka fabryka)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Fabryki.Add(fabryka);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fabryka/Edit/5
        public ActionResult Edit(int id)
        {
            using (var dbContext = new DbContext())
            {
                var dzialy = dbContext.Fabryki.GetAll();
                return View(dzialy.Where(d => d.Id == id).FirstOrDefault());
            }
        }

        // POST: Fabryka/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Fabryka collection)
        {
            try
            {
                // TODO: Add update logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Fabryki.Update(collection);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fabryka/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fabryka/Delete/5
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
