using SalonSamochodowy.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class Pracownik : IEntity
    {
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Id działu")]
        public virtual int Id_dzialu { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Stanowisko wymagane")]
        [Display(Name = "Stanowisko")]
        public virtual string Stanowisko { get; set; }

        [Required]
        [Display(Name = "Data zatrudnienia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime Data_zatrudnienia { get; set; }

        [Display(Name = "Data zakończenia umowy")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime? Do_kiedy_zatrudniony { get; set; }

        [Display(Name = "Imię")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Imię wymagane")]
        public virtual string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nazwisko wymagane")]
        public virtual string Nazwisko { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kod pocztowy wymagany")]
        public virtual string Kod_pocztowy { get; set; }

        [Display(Name = "Miejscowość")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Miejscowość wymagana")]
        public virtual string Miejscowosc { get; set; }

        [Display(Name = "Ulica")]
        public virtual string Ulica { get; set; }

        [Display(Name = "Numer domu")]
        public virtual int? Nr_domu { get; set; }

        [Display(Name = "Numer telefonu")]
        [Required]
        public virtual string Nr_telefonu { get; set; }

        [Display(Name = "Pesel")]
        [Required]
        public virtual string PESEL { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [MinLength(6,ErrorMessage = "Przynajmniej 6 znaków")]
        public virtual string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Potwierdź hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła sie róznią")]
        public virtual string ConfirmPassword { get; set; }

        [Display(Name = "Pensja")]
        public virtual int? Pensja { get; set; }

        public virtual Dzial Dzial { get; set; }

        [Display(Name = "Rola")]
        public virtual string Role { get; set; }

    }
}