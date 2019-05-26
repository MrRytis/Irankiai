using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table(name: "Bid")]
    public class BidModel
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Privaloma suvesti kortelės kodą.")]
        [StringLength(6, ErrorMessage = "Kortelės kodas turi būt 6 skaitmenų.")]
        public string Card { get; set; }
        [Compare("Card", ErrorMessage = "Kortelių kodai neatitinka")]
        public string CardConfirm { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
    }
}