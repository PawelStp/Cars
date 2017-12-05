using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Zakup : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual DateTime Data_zakupu { get; set; }
        [Required]
        public virtual int Id_klienta { get; set; }
        [Required]
        public virtual int Id_pracownika { get; set; }
        [Required]
        public virtual int Id_samochodu { get; set; }
        public virtual Samochod Samochod { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual Pracownik Pracownik { get; set; }
    }
}