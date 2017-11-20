using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Usterka
    {
        public virtual int Id_usterki { get; set; }
        public virtual string Nazwa { get; set; }
        public virtual int Koszt_czesci { get; set; }
        public virtual int Koszt_robocizny { get; set; }
        public virtual int Ogolny_koszt { get; set; }
        public virtual IEnumerable<Naprawa> NaprawaList { get; set; }
    }
}