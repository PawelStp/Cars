using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.ViewModels
{
    public class PracownikViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Display(Name = "Dział")]
        public string NazwaDzialu { get; set; }

        [Display(Name = "Stanowisko")]
        public string Stanowisko { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        [Display(Name = "Data zatrudnienia")]
        public DateTime DataZatrudnienia { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data zakończenia umowy")]
        public DateTime DoKiedyZatrudniony { get; set; }

        [Display(Name = "Pesel")]
        public string PESEL { get; set; }

        [Display(Name = "Nr telefonu")]
        public string NrTelefonu { get; set; }

        [Display(Name = "Pensja")]
        public int Pensja { get; set; }
    }
}