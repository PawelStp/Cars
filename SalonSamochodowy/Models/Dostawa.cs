using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Dostawa : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual int Id_zamowienia { get; set; }
        [Required]
        public virtual DateTime Data_dostawy { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
        public virtual int? Ilosc_dostarczonych { get; set; }
    }
}