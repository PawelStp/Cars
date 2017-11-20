using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Zamowienie
    {
        public virtual int Id_zamowienia { get; set; }
        public virtual int Id_pracownika { get; set; }
        public virtual int Ilosc_zamowionych { get; set; }
        public virtual DateTime Data_zamowienia { get; set; }
        public virtual int Id_samochodu_fabryka { get; set; }
        public virtual Status_zamowienia Status_zamowienia { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public virtual IEnumerable<Dostawa> DostawaList { get; set; }
        public virtual Samochod_fabryka Samochod_fabryka { get; set; }
    }
}