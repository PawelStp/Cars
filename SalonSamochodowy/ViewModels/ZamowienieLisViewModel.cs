using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.ViewModels
{
    public class ZamowienieLisViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Id")]
        public int Id_pracownika { get; set; }

        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Display(Name = "Fabryka")]
        public string NazwaFabryki { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Marka")]
        public string Marka { get; set; }

        [Display(Name = "Pojemność silnika [cm3]")]
        public float PojemnoscSilnika { get; set; }

        [Display(Name = "Moc [km]")]
        public int Moc { get; set; }

        [Display(Name = "Ilość")]
        public int Ilość { get; set; }

        [Display(Name = "Dostarczone")]
        public int IloscDostarczonych { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

    }
}