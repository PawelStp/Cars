using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Dzial
    {
        public virtual int Id_dzialu { get; set; }
        public virtual IEnumerable<Pracownik> PracownikList { get; set; }
        public virtual string Nazwa { get; set; }
        
    }
}