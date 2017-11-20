using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Klient
    {
        public virtual int Id_klienta { get; set; }
        public virtual IEnumerable<Zakup> ZakupList { get; set; }
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