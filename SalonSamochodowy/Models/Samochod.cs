using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Samochod : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Marka { get; set; }
        [Required]
        public virtual string Model { get; set; }
        public virtual string Typ_wyposazenia { get; set; }
        public virtual DateTime Data_produkcji { get; set; }
        public virtual float Pojemnosc_silnika { get; set; }
        public virtual int Moc_silnika { get; set; }
        public virtual int Cena { get; set; }
        [Required]
        public virtual int Id_dostawy { get; set; }
        public virtual Dostawa Dostawa { get; set; }
    }
}