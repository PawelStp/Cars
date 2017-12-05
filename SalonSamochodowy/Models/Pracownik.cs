using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Pracownik : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual int Id_dzialu { get; set; }
        public virtual Dzial Dzial { get; set; }
        [Required]
        public virtual string Stanowisko { get; set; }
        [Required]
        public virtual DateTime Data_zatrudnienia { get; set; }
        public virtual DateTime Do_kiedy_zatrudniony { get; set; }
        [Required]
        public virtual string Imie { get; set; }
        [Required]
        public virtual string Nazwisko { get; set; }
        public virtual string Kod_pocztowy { get; set; }
        public virtual string Miejscowosc { get; set; }
        public virtual string Ulica { get; set; }
        public virtual int Nr_domu { get; set; }
        [Required]
        public virtual string Nr_telefonu { get; set; }
        public virtual string PESEL { get; set; }
        public virtual int Pensja { get; set; }
    }
}