using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarRental.Models
{
    public class GuitarStrings
    {
        [Key]
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musisz podać rodzaj strun")]
        [MinLength(2, ErrorMessage = "Nazwa powinna zawierać więcej niż dwa znaki.")]
        [MaxLength(30, ErrorMessage = "Nazwa powinna zawierać mniej niż 40 znaków.")]
        public string StringsName { get; set; }
        public List<Guitar> Guitars { get; set; }
    }
}
