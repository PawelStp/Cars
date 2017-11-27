using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Fabryka : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Nazwa { get; set; }
        public virtual string Adres { get; set; }
        public virtual string Nr_telefonu { get; set; }
        public virtual IEnumerable<Samochod_fabryka> SamochodList { get; set; }

    }
}