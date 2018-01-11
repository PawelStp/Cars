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
    public class PracownikController : Controller
    {
        // GET: Pracownik
        public ActionResult Index()
        {
            using (var dbContext = new DbContext())
            {
                var pracownicy = dbContext.Pracownicy.GetAll();
                var dzialy = dbContext.Dzialy.GetAll();

                var list = new List<PracownikViewModel>();

                foreach (var pracownik in pracownicy)
                {
                    var dzial = dzialy.Where(d => d.Id == pracownik.Id_dzialu).FirstOrDefault();

                    list.Add(new PracownikViewModel
                    {
                        Id = pracownik.Id,
                        Imie = pracownik.Imie,
                        Nazwisko = pracownik.Nazwisko,
                        NazwaDzialu = dzial.Nazwa,
                        Stanowisko = pracownik.Stanowisko,
                        DataZatrudnienia = pracownik.Data_zatrudnienia,
                        DoKiedyZatrudniony = pracownik.Do_kiedy_zatrudniony ?? DateTime.Now,
                        PESEL = pracownik.PESEL,
                        NrTelefonu = pracownik.Nr_telefonu,
                        Pensja = pracownik.Pensja ?? 0
                    });
                }

                return View(list);
            }
        }

        // GET: Pracownik/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pracownik/Create
        public ActionResult Create()
        {
            using (var dbContext = new DbContext())
            {
                var dzialy = dbContext.Dzialy.GetAll();

                var vm = new AddPracownikViewModel();

                vm.Dzialy = dzialy.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nazwa
                });

                return View(vm);
            }
        }

        // POST: Pracownik/Create
        [HttpPost]
        public ActionResult Create(AddPracownikViewModel pracownik)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    using (var dbContext = new DbContext())
                    {
                        var pracownicy = dbContext.Pracownicy.GetAll();

                        var p = pracownicy.Where(pr => pr.PESEL == pracownik.PESEL).FirstOrDefault();

                        pracownik.Password = Crypto.Hash(pracownik.Password);
                        //  pracownik.ConfirmPassword = Crypto.Hash(pracownik.ConfirmPassword);

                        if (p != null)
                        {
                            ModelState.AddModelError("PeselIstnieje", "Pesel istnieje w bazie danych");

                            var dzialy = dbContext.Dzialy.GetAll();

                            var vm = new AddPracownikViewModel();

                            vm.Dzialy = dzialy.Select(c => new SelectListItem
                            {
                                Value = c.Id.ToString(),
                                Text = c.Nazwa
                            });

                            return View(vm);
                        }

                        Pracownik pra = new Pracownik
                        {
                            Data_zatrudnienia = pracownik.Data_zatrudnienia,
                            Do_kiedy_zatrudniony = pracownik.Do_kiedy_zatrudniony,
                            Id_dzialu = pracownik.DzialId,
                            Imie = pracownik.Imie,
                            Kod_pocztowy = pracownik.Kod_pocztowy,
                            Miejscowosc = pracownik.Miejscowosc,
                            Nazwisko = pracownik.Nazwisko,
                            Nr_domu = pracownik.Nr_domu,
                            Nr_telefonu = pracownik.Nr_telefonu,
                            Password = pracownik.Password,
                            Pensja = pracownik.Pensja,
                            PESEL = pracownik.PESEL,
                            Role = "Pracownik",
                            Stanowisko = pracownik.Stanowisko,
                            Ulica = pracownik.Ulica
                        };

                        dbContext.Pracownicy.Add(pra);
                        dbContext.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    using (var dbContext = new DbContext())
                    {
                        var dzialy = dbContext.Dzialy.GetAll();

                        var vm = new AddPracownikViewModel();

                        vm.Dzialy = dzialy.Select(c => new SelectListItem
                        {
                            Value = c.Id.ToString(),
                            Text = c.Nazwa
                        });

                        return View(vm);
                    }
                }

            }
            catch (Exception e)
            {
                using (var dbContext = new DbContext())
                {
                    var dzialy = dbContext.Dzialy.GetAll();

                    var vm = new AddPracownikViewModel();

                    vm.Dzialy = dzialy.Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nazwa
                    });

                    return View(vm);
                }
            }
        }

        // GET: Pracownik/Edit/5
        public ActionResult Edit(int id)
        {
            using (var dbContext = new DbContext())
            {
                var dzialy = dbContext.Pracownicy.GetAll();
                return View(dzialy.Where(d => d.Id == id).FirstOrDefault());
            }
        }

        // POST: Pracownik/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pracownik collection)
        {
            try
            {
                // TODO: Add update logic here
                using (var dbContext = new DbContext())
                {
                    collection.Password = Crypto.Hash(collection.Password);
                    dbContext.Pracownicy.Update(collection);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pracownik/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pracownik/Delete/5
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
