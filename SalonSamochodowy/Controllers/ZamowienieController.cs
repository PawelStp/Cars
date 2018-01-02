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
                var zamowenia = dbContext.Zamowienia.GetAll().Where(z=>z.Obecny_status=="Zrealizowane").ToList();

                var pracownicy = dbContext.Pracownicy.GetAll();
                var samochody = dbContext.Samochody_fabryczne.GetAll();
                var fabryki = dbContext.Fabryki.GetAll();

                var zvm = new List<ZamowienieLisViewModel>();

                foreach (var zamowienie in zamowenia)
                {

                    var pracownik = pracownicy.Where(p => p.Id == zamowienie.Id_pracownika).FirstOrDefault();
                    var samochod = samochody.Where(s => s.Id == zamowienie.Id_samochodu_fabryka).FirstOrDefault();
                    var fabryka = fabryki.Where(f => f.Id == samochod.Id_fabryki).FirstOrDefault();

                    zvm.Add(new ZamowienieLisViewModel
                    {
                        Id_pracownika = pracownik.Id,
                        Data = zamowienie.Data_zamowienia,
                        IloscDostarczonych = zamowienie.Ilosc_dostarczonych??0,
                        Ilość = zamowienie.Ilosc_zamowionych,
                        Imie = pracownik.Imie,
                        Marka=samochod.Marka,
                        Moc = samochod.Moc_silnika??0,
                        Model = samochod.Model,
                        NazwaFabryki = fabryka.Nazwa,
                        Nazwisko = pracownik.Nazwisko,
                        PojemnoscSilnika = samochod.Pojemnosc_silnika??0,
                        Status = zamowienie.Obecny_status
                    });

                }
                ViewBag.Message = "Zrealizowane";

                return View(zvm);
            }
        }

        public ActionResult NotEnded()
        {
            using (var dbContext = new DbContext())
            {
                var zamowenia = dbContext.Zamowienia.GetAll().Where(z=>z.Obecny_status!="Zrealizowane").ToList();

                var pracownicy = dbContext.Pracownicy.GetAll();
                var samochody = dbContext.Samochody_fabryczne.GetAll();
                var fabryki = dbContext.Fabryki.GetAll();

                var zvm = new List<ZamowienieLisViewModel>();

                foreach (var zamowienie in zamowenia)
                {

                    var pracownik = pracownicy.Where(p => p.Id == zamowienie.Id_pracownika).FirstOrDefault();
                    var samochod = samochody.Where(s => s.Id == zamowienie.Id_samochodu_fabryka).FirstOrDefault();
                    var fabryka = fabryki.Where(f => f.Id == samochod.Id_fabryki).FirstOrDefault();

                    zvm.Add(new ZamowienieLisViewModel
                    {
                        Id_pracownika = pracownik.Id,
                        Data = zamowienie.Data_zamowienia,
                        IloscDostarczonych = zamowienie.Ilosc_dostarczonych ?? 0,
                        Ilość = zamowienie.Ilosc_zamowionych,
                        Imie = pracownik.Imie,
                        Marka = samochod.Marka,
                        Moc = samochod.Moc_silnika ?? 0,
                        Model = samochod.Model,
                        NazwaFabryki = fabryka.Nazwa,
                        Nazwisko = pracownik.Nazwisko,
                        PojemnoscSilnika = samochod.Pojemnosc_silnika ?? 0,
                        Status = zamowienie.Obecny_status
                    }); 

                }
                return View("Index", zvm);
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
