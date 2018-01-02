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

        [Display(Name = "Ilość zamówionych")]
        [Required]
        public  int Ilosc_zamowionych { get; set; }

        [Display(Name = "Data zamówienia")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public  DateTime Data_zamowienia { get; set; }


        public  int Id_samochodu_fabryka { get; set; }

        [Required]
        [Display(Name = "Samochody z fabryki")]
        public IEnumerable<SelectListItem> SamochodyFabryczne { get; set; }

        [Display(Name = "Ilość dostarczonych")]
        public  int? Ilosc_dostarczonych { get; set; }
        
        [Display(Name = "Status")]
        public  string Obecny_status { get; set; }
    }
}