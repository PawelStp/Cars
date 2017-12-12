using SalonSamochodowy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static SalonSamochodowy.Repository.DBContext;

namespace SalonSamochodowy.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lvm)
        {

            using (var dbContext = new DbContext())
            {
                var pracownicy = dbContext.Pracownicy.GetAll();

                var pracownik = pracownicy.Where(pr => pr.PESEL == lvm.PESEL).FirstOrDefault();
                if (pracownik != null)
                {
                    if (string.Compare(Crypto.Hash(lvm.Password), pracownik.Password) == 0)
                    {
                        var ticket = new FormsAuthenticationTicket(
                            1,
                            pracownik.Id.ToString(),
                            DateTime.Now,
                            DateTime.Now.AddMinutes(20),
                            true,
                            String.Join("|", pracownik.Role)
                            );
                        string encrypted = FormsAuthentication.Encrypt(ticket);

                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(52560020);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }


    }
}
