using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table(name: "Invoice")]
    public class InvoiceModel
    {
        public int Id { get; set; }

        [Range(0, 100)]
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        [Required(ErrorMessage = "Requered field.")]
        public Nullable<int> Card { get; set; }

        [Required(ErrorMessage = "Requered field.")]
        public string CardOwner { get; set; }

        [Range(99, 999)]
        public Nullable<int> CVC { get; set; }
    }
}