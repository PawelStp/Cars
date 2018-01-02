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
        [Required]
        [Display(Name = "Imię")]
        public virtual string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        [Required]
        public virtual string Nazwisko { get; set; }

        [Display(Name = "Kod pocztowy")]
        public virtual string Kod_pocztowy { get; set; }

        [Display(Name = "Miejscowość")]
        public virtual string Miejscowosc { get; set; }

        [Display(Name = "Ulica")]
        public virtual string Ulica { get; set; }

        [Display(Name = "Nr domu")]
        public virtual int? Nr_domu { get; set; }

        [Display(Name = "Nr telefonu")]
        [Required]
        public virtual string Nr_telefonu { get; set; }

        [Display(Name = "Pesel")]
        [Required]
        public virtual string PESEL { get; set; }
    }
}