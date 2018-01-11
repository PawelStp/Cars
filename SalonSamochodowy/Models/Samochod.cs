using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Samochod : IEntity
    {
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Marka")]
        public virtual string Marka { get; set; }

        [Display(Name = "Model")]
        [Required]
        public virtual string Model { get; set; }

        public virtual string Typ_wyposazenia { get; set; }

        [Display(Name = "Data produkcji")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime? Data_produkcji { get; set; }

        [Display(Name = "Pojemność silnika [cm3]")]
        [Range(800, 15000, ErrorMessage = "Nieprawidłowa wartość")]
        public virtual float? Pojemnosc_silnika { get; set; }

        [Display(Name = "Moc silnika [km]")]
        [Range(20, 500, ErrorMessage = "Nieprawidłowa wartość")]
        public virtual int? Moc_silnika { get; set; }

        [Display(Name = "Cena [PLN]")]
        public virtual int? Cena { get; set; }

        [Display(Name = "Status")]
        public virtual string Status { get; set; }

        [Required]
        [Display(Name = "Id dostawy")]
        public virtual int Id_dostawy { get; set; }

        public virtual Dostawa Dostawa { get; set; }
    }
}