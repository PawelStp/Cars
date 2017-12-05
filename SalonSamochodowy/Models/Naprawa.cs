using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Naprawa : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual int Id_pracownika { get; set; }
        [Required]
        public virtual int Id_samochodu { get; set; }
        [Required]
        public virtual DateTime Data_naprawy { get; set; }
        [Required]
        public virtual int Id_usterki { get; set; }
        public virtual Samochod Samochod { get; set; }
        public virtual Usterka Usterka { get; set; }
        public virtual Pracownik Pracownik { get; set; }
    }
}