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
    public class NaprawaController : Controller
    {
        // GET: Naprawa
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var naprawy = dbContext.Naprawy.GetAll();
                var list = new List<NaprawaViewModels>();
                var pracownicy = dbContext.Pracownicy.GetAll();
                var samochody = dbContext.Samochody.GetAll();
                var usterki = dbContext.Usterki.GetAll();

                foreach (var naprawa in naprawy)
                {
                    var pracownik = pracownicy.Where(p => p.Id == naprawa.Id_pracownika).FirstOrDefault();
                    var usterka = usterki.Where(u => u.Id == naprawa.Id_usterki).FirstOrDefault();
                    var samochod = samochody.Where(s => s.Id == naprawa.Id_samochodu).FirstOrDefault();

                    list.Add(new NaprawaViewModels
                    {
                        Id = naprawa.Id,
                        Data_naprawy = naprawa.Data_naprawy,
                        Id_pracownika = pracownik.Id,
                        Imie = pracownik.Imie,
                        Nazwisko = pracownik.Nazwisko,
                        NazwaUsterki = usterka.Nazwa,
                        Marka = samochod.Marka,
                        Model = samochod.Model,
                        Id_samochodu = samochod.Id
                    });
                }
                return View(list);
            }
        }

        // GET: Naprawa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Naprawa/Create
        public ActionResult Create(int id)
        {
            NaprawaViewModels zvm = new NaprawaViewModels()
            {
                Id_pracownika = int.Parse(User.Identity.Name),
                Id_samochodu = id
            };
            using (var dbContext = new DbContext())
            {
                var s = dbContext.Usterki.GetAll();
                zvm.Usterki = s.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nazwa

                });
            }
            return View(zvm);
        }

        // POST: Naprawa/Create
        [HttpPost]
        public ActionResult Create(NaprawaViewModels n)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Naprawy.Add(new Naprawa
                    {
                        Id_pracownika = n.Id_pracownika,
                        Data_naprawy = n.Data_naprawy,
                        Id_samochodu = n.Id_samochodu,
                        Id_usterki = n.Id_usterki
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

        // GET: Naprawa/Edit/5
        public ActionResult Edit(int id)
        {
            using (var dbContext = new DbContext())
            {
                var dzialy = dbContext.Pracownicy.GetAll();
                return View(dzialy.Where(d => d.Id == id).FirstOrDefault());
            }
        }

        // POST: Naprawa/Edit/5
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

        // GET: Naprawa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Naprawa/Delete/5
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
