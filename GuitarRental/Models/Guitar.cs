using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarRental.Models
{
    public class Guitar
    {
        [HiddenInput]
        public int GuitarId { get; set; }
        [Required(ErrorMessage = "Musisz podać nazwę gitary")]
        [MinLength(2, ErrorMessage = "Nazwa powinna zawierać więcej niż dwa znaki.")]
        [MaxLength(30, ErrorMessage = "Nazwa powinna zawierać mniej niż 30 znaków.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Musisz podać rok produkcji gitary")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Rok powienien zawierać 4 cyfry")]
        [Range(minimum: 1900, maximum: 2022, ErrorMessage = "Podaj rok pomiędzy 1900 a 2022")]
        public int ProductionYear { get; set; }


        [Required(ErrorMessage = "Musisz podać id typu gitary")]
        [Range(minimum: 1, maximum: 3, ErrorMessage = "Podaj id typu gitary od 1 do 3")]
        public int? GuitarTypeId { get; set; }
        public GuitarType GuitarType { get; set; }

        [Required(ErrorMessage = "Musisz podać id strun gitary")]
        [Range(minimum: 1, maximum: 2, ErrorMessage = "Podaj id strun gitary od 1 do 2")]
        public int? GuitarStringsId { get; set; }
        public GuitarStrings GuitarStrings { get; set; }

    }
}
