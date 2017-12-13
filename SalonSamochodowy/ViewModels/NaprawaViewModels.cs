using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonSamochodowy.ViewModels
{
    public class NaprawaViewModels
    {

        public int Id { get; set; }

        [Display(Name = "Id pracownika")]
        [Required]
        public int Id_pracownika { get; set; }

        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        public string Marka { get; set; }

        public string Model { get; set; }

        [Display(Name = "Id samochodu")]
        [Required]
        public int Id_samochodu { get; set; }

        [Display(Name = "Cena")]
        public int Cena { get; set; }

        [Display(Name = "Nazwa usterki")]
        public string NazwaUsterki { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data naprawy")]
        [Required]
        public DateTime Data_naprawy { get; set; }

        public int Id_usterki { get; set; }

        [Display(Name = "Usterka")]
        public IEnumerable<SelectListItem> Usterki { get; set; }

    }
}