using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonSamochodowy.ViewModels
{
    public class ZamowienieViewModel
    {
        public  int Id_pracownika { get; set; }
        [Required]
        public  int Ilosc_zamowionych { get; set; }
        [Required]
        public  DateTime Data_zamowienia { get; set; }

        public  int Id_samochodu_fabryka { get; set; }
        [Required]
        public IEnumerable<SelectListItem> SamochodyFabryczne { get; set; }

        public  int? Ilosc_dostarczonych { get; set; }

        public  string Obecny_status { get; set; }
    }
}