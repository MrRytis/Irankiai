using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class TransportRequest
    {
        public int Id { get; set; }
        public DateTime Pickup_Time { get; set; }
        public DateTime Delivery_Time { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
