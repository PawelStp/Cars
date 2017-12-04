using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Samochod_fabryka : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int Id_fabryki { get; set; }
        public virtual string Marka { get; set; }
        public virtual string Model { get; set; }
        public virtual string Typ_wyposazenia { get; set; }
        public virtual float Pojemnosc_silnika { get; set; }
        public virtual int Moc_silnika { get; set; }
        public virtual int Cena_fabryka { get; set; }
        public virtual Fabryka Fabryka { get; set; }
    }
}