using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table(name: "Transport")]
    public class TransportRequestModel
    {
        public int Id { get; set; }
        [Display(Name = "Pickup time:")]
        [DataType(DataType.Date)]
        public DateTime Pickup_Time { get; set; }
        [Display(Name = "Delivery time:")]
        [DataType(DataType.Date)]
        public DateTime Delivery_Time { get; set; }
        [StringLength(10), MinLength(2)]
        [Required(ErrorMessage = "Required field.")]
        public string Status { get; set; }
        [Display(Name = "Route from -> to:")]
        public string Notes { get; set; }

    }
}