using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class ZamowienieController : Controller
    {
        // GET: Zamowienie
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var zamowenia = dbContext.Zamowienia.GetAll();
                return View(zamowenia);
            }
        }

        // GET: Zamowienie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Zamowienie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zamowienie/Create
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

        // GET: Zamowienie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Zamowienie/Edit/5
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

        // GET: Zamowienie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Zamowienie/Delete/5
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
