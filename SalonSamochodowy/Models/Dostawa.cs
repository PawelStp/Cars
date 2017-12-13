using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Dostawa : IEntity
    {
        [Display(Name = "Id dostawy")]
        public virtual int Id { get; set; }
        [Required]
        [Display(Name = "Id zamówienia")]
        public virtual int Id_zamowienia { get; set; }
        [Required]
        [Display(Name = "Data dostawy")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime Data_dostawy { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
        [Display(Name = "Ilość dostarczonych")]
        public virtual int? Ilosc_dostarczonych { get; set; }
    }
}