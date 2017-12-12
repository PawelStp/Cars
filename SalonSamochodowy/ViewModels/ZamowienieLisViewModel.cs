using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.ViewModels
{
    public class ZamowienieLisViewModel
    {
        public int Id_pracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaFabryki { get; set; }
        public string Model { get; set; }
        public string Marka { get; set; }
        public float PojemnoscSilnika { get; set; }
        public int Moc { get; set; }
        public int Ilość { get; set; }
        public int IloscDostarczonych { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }

    }
}