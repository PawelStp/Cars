using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class DostawaController : Controller
    {
        // GET: Dostawa
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var dostawy = dbContext.Dostawy.GetAll();
                return View(dostawy);
            }
        }

        // GET: Dostawa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dostawa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dostawa/Create
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

        // GET: Dostawa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dostawa/Edit/5
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

        // GET: Dostawa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dostawa/Delete/5
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
