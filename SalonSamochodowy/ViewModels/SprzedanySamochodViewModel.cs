using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.ViewModels
{
    public class SprzedanySamochodViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Marka")]
        public string Marka { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Pojemność [cm3]")]
        public float Pojemnosc { get; set; }
        [Display(Name = "Moc silnika [km]")]
        public int MocSilnika { get; set; }
        [Display(Name = "Data produkcji")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataProdukcji { get; set; }
        [Display(Name = "Imię")]
        public string ImieKlienta { get; set; }
        [Display(Name = "Nazwisko")]
        public string NazwiskoKlienta { get; set; }
        [Display(Name = "Pesel")]
        public string PESEL { get; set; }

    }
}