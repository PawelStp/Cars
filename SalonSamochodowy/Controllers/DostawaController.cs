using SalonSamochodowy.Models;
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
        public ActionResult Create(int id)
        {

            return View(new Dostawa { Id_zamowienia = id });
        }

        // POST: Dostawa/Create
        [HttpPost]
        public ActionResult Create(Dostawa dostawa)
        {
            try
            {
                // TODO: Add insert logic here
                using (var dbContext = new DbContext())
                {
                    var zamowiewnie = dbContext.Zamowienia.GetById(dostawa.Id_zamowienia);
                    var ileDoszlo = dostawa.Ilosc_dostarczonych;


                    zamowiewnie.Ilosc_dostarczonych += dostawa.Ilosc_dostarczonych;
                    var samochod = dbContext.Samochody_fabryczne.GetAll().Where(s => s.Id == zamowiewnie.Id_samochodu_fabryka).FirstOrDefault();

                    if (zamowiewnie.Ilosc_dostarczonych > zamowiewnie.Ilosc_zamowionych)
                    {
                        zamowiewnie.Obecny_status = "Zrealizowane";
                        var zamowione = zamowiewnie.Ilosc_zamowionych;
                        var dostarczone = zamowiewnie.Ilosc_dostarczonych;
                        ileDoszlo = zamowione - (dostarczone - ileDoszlo) ?? 0;
                        zamowiewnie.Ilosc_dostarczonych = zamowiewnie.Ilosc_zamowionych;
                    }
                    else if(zamowiewnie.Ilosc_dostarczonych == zamowiewnie.Ilosc_zamowionych)
                    {
                        zamowiewnie.Obecny_status = "Zrealizowane";
                    }

                    dbContext.Zamowienia.Update(zamowiewnie);
                    dbContext.Dostawy.Add(dostawa);

                    for (int i = 0; i < ileDoszlo; i++)
                    {
                        Samochod s = new Samochod
                        {
                            Cena = samochod.Cena_fabryka+3000,
                            Data_produkcji = samochod.Data_produkcji,
                            Marka = samochod.Marka,
                            Moc_silnika = samochod.Moc_silnika,
                            Id_dostawy = dostawa.Id,
                            Model = samochod.Model,
                            Pojemnosc_silnika = samochod.Pojemnosc_silnika,
                            Typ_wyposazenia = samochod.Typ_wyposazenia,
                            Status = "Niesprzedany"
                        };

                        dbContext.Samochody.Add(s);
                    }
                    dbContext.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Dostawa/Edit/5
        public ActionResult Edit(int id)
        {
            using (var dbContext = new DbContext())
            {
                var dzialy = dbContext.Dostawy.GetAll();
                return View(dzialy.Where(d => d.Id == id).FirstOrDefault());
            }
        }

        // POST: Dostawa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Dostawa collection)
        {
            try
            {
                // TODO: Add update logic here
                using (var dbContext = new DbContext())
                {
                    dbContext.Dostawy.Update(collection);
                    dbContext.SaveChanges();
                }
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
