using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Dzial : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Nazwa { get; set; }
        
    }
}