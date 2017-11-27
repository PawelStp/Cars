using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Pracownik : IEntity
    {
        public virtual int Id { get; set; }
        public virtual Pracownik_personalia Pracownik_personalia { get; set; }
        public virtual Dzial Dzial { get; set; }
        public virtual int Id_dzialu { get; set; }
        public virtual DateTime Od_kiedy { get; set; }
        public virtual DateTime Do_kiedy { get; set; }
        public virtual IEnumerable<Naprawa> NaprawaList { get; set; }
        public virtual IEnumerable<Zamowienie> ZamowienieList { get; set; }
    }
}