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

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Search(Klient klient)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    var list = dbContext.Klienci.GetAll().Where(k=>k.Imie==klient.Imie && k.Nazwisko == klient.Nazwisko).ToList();
                    return View("Index", list);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Klient/Details/5
        public ActionResult Details(int id)
        {
            using (var dbContext = new DbContext())
            {
                var cars = dbContext.Samochody.GetAll().Where(c => c.Status == "Sprzedany").ToList();

                var client = dbContext.Klienci.GetById(id);

                var sells = dbContext.Zakup.GetAll().Where(z=>z.Id_klienta == id);

                var vm = new List<Samochod>();

                foreach (var sell in sells)
                {
                    var car = cars.Where(c => c.Id == sell.Id_samochodu).FirstOrDefault();

                    vm.Add(car);
                }

                return View(vm);
            }
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
            using (var dbContext = new DbContext())
            {
                var dzialy = dbContext.Klienci.GetAll();
                return View(dzialy.Where(d => d.Id == id).FirstOrDefault());
            }
        }

        // POST: Klient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Klient collection)
        {
            try
            {
                // TODO: Add update logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Klienci.Update(collection);
                    dbContext.SaveChanges();
                }
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
