using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Usterka : IEntity
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Nazwa { get; set; }

        [Display(Name = "Koszt części")]
        public virtual int? Koszt_czesci { get; set; }

        [Display(Name = "Koszt robocizny")]
        public virtual int? Koszt_robocizny { get; set; }

        [Display(Name = "Ogólny koszt")]
        public virtual int? Ogolny_koszt { get; set; }
    }
}