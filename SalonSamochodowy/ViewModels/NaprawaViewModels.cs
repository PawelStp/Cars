using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonSamochodowy.ViewModels
{
    public class NaprawaViewModels
    {

        [Required]
        public virtual int Id_pracownika { get; set; }
        [Required]
        public virtual int Id_samochodu { get; set; }
        [Required]
        public virtual DateTime Data_naprawy { get; set; }

        public virtual int Id_usterki { get; set; }

        public IEnumerable<SelectListItem> Usterki { get; set; }

    }
}