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
    [Authorize]
    public class SamochodFabrykaController : Controller
    {
        // GET: SamochodFabryka
        public ActionResult Index()
        {
            List<SamochodFabrykaViewModel> vm = new List<SamochodFabrykaViewModel>();
            using (var dbContext = new DbContext())
            {
                var samochodyFabryczne = dbContext.Samochody_fabryczne.GetAll();
                
                foreach (var auto in samochodyFabryczne)
                {
                    var fabryka = dbContext.Fabryki.GetById(auto.Id_fabryki);
                    vm.Add(new SamochodFabrykaViewModel
                    {
                        Cena_fabryka = auto.Cena_fabryka,
                        Data_produkcji = auto.Data_produkcji,
                        FabrykaName = fabryka.Nazwa,
                        Marka = auto.Marka,
                        Moc_silnika = auto.Moc_silnika,
                        Model = auto.Model,
                        Pojemnosc_silnika = auto.Pojemnosc_silnika,
                        Typ_wyposazenia = auto.Typ_wyposazenia
                    });
                }

                return View(vm);
            }
        }

        // GET: SamochodFabryka/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SamochodFabryka/Create
        public ActionResult Create()
        {
            using (var dbContext = new DbContext())
            {
                var fabryki = dbContext.Fabryki.GetAll();

                var vm = new SamochodFabrykaViewModel();

                vm.Fabryki = fabryki.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nazwa
                });

                return View(vm);
            }
        }

        // POST: SamochodFabryka/Create
        [HttpPost]
        public ActionResult Create(SamochodFabrykaViewModel samochod)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Samochody_fabryczne.Add(new Samochod_fabryka
                    {
                        Cena_fabryka = samochod.Cena_fabryka,
                        Typ_wyposazenia = samochod.Typ_wyposazenia,
                        Pojemnosc_silnika = samochod.Pojemnosc_silnika,
                        Data_produkcji = samochod.Data_produkcji,
                        Marka = samochod.Marka,
                        Moc_silnika = samochod.Moc_silnika,
                        Model = samochod.Model,
                        Id_fabryki = samochod.FabrykaId
                    });
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SamochodFabryka/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SamochodFabryka/Edit/5
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

        // GET: SamochodFabryka/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SamochodFabryka/Delete/5
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
