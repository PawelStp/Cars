using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Usterka : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Nazwa { get; set; }
        public virtual int Koszt_czesci { get; set; }
        public virtual int Koszt_robocizny { get; set; }
        public virtual int Ogolny_koszt { get; set; }
    }
}