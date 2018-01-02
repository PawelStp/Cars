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

        [Display(Name = "Marka")]
        public string Marka { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Typ wyposażenia")]
        public string Typ_wyposazenia { get; set; }

        [Display(Name = "Pojemność silnika [cm3]")]
        public float? Pojemnosc_silnika { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Rok produkcji")]
        public DateTime Data_produkcji { get; set; }

        [Display(Name = "Moc silnika [km]")]
        public int? Moc_silnika { get; set; }

        [Display(Name = "Cena [zł]")]
        public int? Cena_fabryka { get; set; }
    }
}