using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Status_zamowienia
    {
        public virtual int Id_zamowienia { get; set; }
        public virtual string Obecny_status { get; set; }
        public virtual int Ilosc_dostarczonych { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}