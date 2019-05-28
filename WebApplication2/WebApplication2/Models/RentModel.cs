using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table(name: "Rent")]
    public class RentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Requered field.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Requered field.")]
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public virtual InvoiceModel Invoice { get; set; }
        public virtual ItemModel Item { get; set; }
        public virtual TransportRequestModel Transport { get; set; }


    }
}