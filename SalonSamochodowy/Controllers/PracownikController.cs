using SalonSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class PracownikController : Controller
    {
        // GET: Pracownik
        public ActionResult Index()
        {
                using (var dbContext = new DbContext())
                {
                    var pracownicy = dbContext.Pracownicy.GetAll();
                    return View(pracownicy);
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
            return View();
        }

        // POST: Pracownik/Create
        [HttpPost]
        public ActionResult Create(Pracownik pracownik)
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
                        pracownik.Role = "Pracownik";

                        if(p!=null)
                        {
                            ModelState.AddModelError("PeselIstnieje", "Pesel istnieje w bazie danych");
                            return View(pracownik);
                        }
                        dbContext.Pracownicy.Add(pracownik);
                        dbContext.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch(Exception e)
            {
                return View(pracownik);
            }
        }

        // GET: Pracownik/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pracownik/Edit/5
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
