﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonSamochodowy.ViewModels
{
    public class ZakupViewModel
    {


        public virtual DateTime Data_zakupu { get; set; }
        public virtual int Id_klienta { get; set; }

        public IEnumerable<SelectListItem> Klienci { get; set; }

        public virtual int Id_pracownika { get; set; }
        public virtual int Id_samochodu { get; set; }
    }
}