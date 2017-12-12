using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "PESEL")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pesel jest wymagany")]
        public string PESEL { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Haslo jest wymagane")]
        public string Password { get; set; }
    }
}