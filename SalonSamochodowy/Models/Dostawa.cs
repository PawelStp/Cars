using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Dostawa : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int Id_zamowienia { get; set; }
        public virtual DateTime Data_dostawy { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}