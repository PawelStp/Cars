using SalonSamochodowy.Models;
using SalonSamochodowy.ViewModels;
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
            ZamowienieViewModel zvm = new ZamowienieViewModel();
            using (var dbContext = new DbContext())
            {
                var s = dbContext.Samochody_fabryczne.GetAll();
                zvm.SamochodyFabryczne = s.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Marka + " " + x.Model + " " + x.Pojemnosc_silnika + " " + x.Moc_silnika 

                });
            }
            return View(zvm);
        }

        // POST: Zamowienie/Create
        [HttpPost]
        public ActionResult Create(ZamowienieViewModel zamowienie)
        {
            try
            {
                Zamowienie z = new Zamowienie
                {
                    Id_pracownika = int.Parse(User.Identity.Name),
                    Data_zamowienia = zamowienie.Data_zamowienia,
                    Ilosc_dostarczonych = 0,
                    Ilosc_zamowionych = zamowienie.Ilosc_zamowionych,
                    Obecny_status = "Niezrealizowane",
                    Id_samochodu_fabryka = zamowienie.Id_samochodu_fabryka
                };

                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Zamowienia.Add(z);
                    dbContext.SaveChanges();
                }
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
