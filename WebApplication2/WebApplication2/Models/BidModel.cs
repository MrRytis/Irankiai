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

        [Required( ErrorMessage = "Required field.")]
        [StringLength(6, ErrorMessage = "Code must be 6 symbols long.")]
        public string Card { get; set; }
        [Compare("Card", ErrorMessage = "Codes are not equal.")]
        public string CardConfirm { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
    }
}