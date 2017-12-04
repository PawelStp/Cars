using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Klient : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Imie { get; set; }
        public virtual string Nazwisko { get; set; }
        public virtual string Kod_pocztowy { get; set; }
        public virtual string Miejscowosc { get; set; }
        public virtual string Ulica { get; set; }
        public virtual int Nr_domu { get; set; }
        public virtual string Nr_telefonu { get; set; }
        public virtual string PESEL { get; set; }
        public virtual string NIP { get; set; }
    }
}