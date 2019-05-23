using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int Card { get; set; }
        public string CardOwner { get; set; }
        public int CVC { get; set; }
    }
}