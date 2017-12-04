using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Zamowienie : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int Id_pracownika { get; set; }
        public virtual int Ilosc_zamowionych { get; set; }
        public virtual DateTime Data_zamowienia { get; set; }
        public virtual int Id_samochodu_fabryka { get; set; }
        public virtual int Ilosc_dostarczonych { get; set; }
        public virtual string Obecny_status { get; set; }
        public virtual Samochod_fabryka Samochod_fabryka { get; set; }
        public virtual Pracownik Pracownik { get; set; }
    }
}