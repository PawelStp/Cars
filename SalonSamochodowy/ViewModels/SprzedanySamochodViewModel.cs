using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.ViewModels
{
    public class SprzedanySamochodViewModel
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public float Pojemnosc { get; set; }
        public string ImieKlienta { get; set; }
        public string NazwiskoKlienta { get; set; }
        public string PESEL { get; set; }
        public int MocSilnika { get; set; }
    }
}