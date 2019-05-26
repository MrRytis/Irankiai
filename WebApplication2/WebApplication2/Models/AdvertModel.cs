using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table(name: "Advert")]
    public class AdvertModel
    {
        public int Id { get; set; }
        [Display(Name = "Valid from:")]
        [DataType(DataType.Date)]
        public DateTime Valid_from { get; set; }
        [Display(Name = "Valid to:")]
        [DataType(DataType.Date)]
        public DateTime Valid_to { get; set; }
        [StringLength(10), MinLength(2)]
        [Required(ErrorMessage = "Privaloma įvesti pavadinimą." )]
        public string Title { get; set; }
        [Required(ErrorMessage = "Skelbimas privalo turėti kainą.")]
        public double Price { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Privaloma įvesti aprašymą.")]
        public string Description { get; set; }
        
    }
}