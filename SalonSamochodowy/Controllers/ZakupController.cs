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
        public ActionResult Create(int id)
        {
            ZakupViewModel zvm;
            using (var dbContext = new DbContext())
            {
                var s = dbContext.Klienci.GetAll();

                zvm = new ZakupViewModel
                {
                    Id_samochodu = id,
                    Id_pracownika = int.Parse(User.Identity.Name)
                };
                zvm.Klienci = s.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Imie + " " + x.Nazwisko + " " + x.PESEL

                });
            }
          

            return View(zvm);
        }

        // POST: Zakup/Create
        [HttpPost]
        public ActionResult Create(ZakupViewModel z)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    var zakup = new Zakup
                    {
                        Id_klienta = z.Id_klienta,
                        Id_samochodu = z.Id_samochodu,
                        Id_pracownika = z.Id_pracownika,
                        Data_zakupu = z.Data_zakupu
                    };

                    dbContext.Zakup.Add(zakup);
                    var samochod = dbContext.Samochody.GetById(z.Id_samochodu);
                    samochod.Status = "Sprzedany";
                    dbContext.Samochody.Update(samochod);
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
