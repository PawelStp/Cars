using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Klient : IEntity
    {
        public virtual int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Imię wymagane")]
        [Display(Name = "Imię")]
        public virtual string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nazwisko wymagane")]
        public virtual string Nazwisko { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kod wymagany")]
        public virtual string Kod_pocztowy { get; set; }

        [Display(Name = "Miejscowość")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Miejscowość wymagana")]
        public virtual string Miejscowosc { get; set; }

        [Display(Name = "Ulica")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ulica wymagana")]
        public virtual string Ulica { get; set; }

        [Display(Name = "Nr domu")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Numer wymagany")]
        public virtual int? Nr_domu { get; set; }

        [Display(Name = "Nr telefonu")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Numer wymagany")]
        public virtual string Nr_telefonu { get; set; }

        [Display(Name = "Pesel")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PESEL wymagany")]
        [StringLength(11, MinimumLength = 11,  ErrorMessage = "PESEL wymagany")]
        public virtual string PESEL { get; set; }
    }
}