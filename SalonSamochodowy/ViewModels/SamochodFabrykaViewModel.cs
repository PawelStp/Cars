using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonSamochodowy.ViewModels
{
    public class SamochodFabrykaViewModel
    {
        public int Id { get; set; }

        public string FabrykaName { get; set; }

        [Display(Name = "Fabryka")]
        public IEnumerable<SelectListItem> Fabryki { get; set; }

        public virtual int FabrykaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Marka wymagana")]
        [Display(Name = "Marka")]
        public string Marka { get; set; }

        [Display(Name = "Model")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Model wymagany")]
        public string Model { get; set; }

        [Display(Name = "Typ wyposażenia")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Typ wymagany")]
        public string Typ_wyposazenia { get; set; }

        [Display(Name = "Pojemność silnika [cm3]")]
        [Range(800, 15000, ErrorMessage = "Nieprawidłowa wartość")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pojemność wymagana")]
        public float? Pojemnosc_silnika { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Rok produkcji")]
        public DateTime Data_produkcji { get; set; }

        [Display(Name = "Moc silnika [km]")]
        [Range(20, 500, ErrorMessage = "Nieprawidłowa wartość")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Moc wymagana")]
        public int? Moc_silnika { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Cena wymagana")]
        [Display(Name = "Cena [zł]")]
        public int? Cena_fabryka { get; set; }
    }
}