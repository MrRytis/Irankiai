using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class AuctionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
