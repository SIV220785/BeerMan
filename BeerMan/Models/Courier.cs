using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class Courier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DeliveryOrder> DeliveryOrders { get; set; }
    }
}