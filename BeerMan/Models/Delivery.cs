using System;
using System.Collections.Generic;

namespace BeerMan.Models
{
    public class DeliveryOrder
    {
        public int Id { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal Cost { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }

        public int CourierId { get; set; }
        public Courier Courier { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public ICollection<AspNetUsers> AspNetUsers { get; set; }

    }
}