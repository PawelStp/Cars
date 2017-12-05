using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Dzial : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Nazwa { get; set; }
        
    }
}