
using System.Collections.Generic;

namespace BeerMan.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int? Count { get; set; }

        public int? PhotoId { get; set; }
        public virtual Photo Photo { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Drink()
        {
            Orders = new List<Order>();
        }
    }
}