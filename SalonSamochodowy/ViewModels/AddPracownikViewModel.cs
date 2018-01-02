using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonSamochodowy.ViewModels
{
    public class AddPracownikViewModel
    {


        [Display(Name = "Dział")]
        public IEnumerable<SelectListItem> Dzialy { get; set; }

        public virtual int DzialId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Stanowisko wymagane")]
        [Display(Name = "Stanowisko")]
        public string Stanowisko { get; set; }

        [Required]
        [Display(Name = "Data zatrudnienia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data_zatrudnienia { get; set; }

        [Display(Name = "Data zakończenia umowy")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Do_kiedy_zatrudniony { get; set; }

        [Display(Name = "Imię")]
        [Required]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        [Required]
        public string Nazwisko { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string Kod_pocztowy { get; set; }

        [Display(Name = "Miejscowość")]
        public string Miejscowosc { get; set; }

        [Display(Name = "Ulica")]
        public string Ulica { get; set; }

        [Display(Name = "Numer domu")]
        public int? Nr_domu { get; set; }

        [Display(Name = "Numer telefonu")]
        [Required]
        public string Nr_telefonu { get; set; }

        [Display(Name = "Pesel")]
        [Required]
        public string PESEL { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [MinLength(6, ErrorMessage = "Przynajmniej 6 znaków")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Potwierdź hasło")]
        [DataType(DataType.Password)]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Hasła sie róznią")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Pensja")]
        public int? Pensja { get; set; }


        [Display(Name = "Rola")]
        public string Role { get; set; }
    }
}