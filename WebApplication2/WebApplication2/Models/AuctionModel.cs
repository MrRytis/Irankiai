using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class AuctionModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime End_Date { get; set; }
        [StringLength(10), MinLength(2)]
        public string Status { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


    }
}