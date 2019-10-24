using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class CreateOrderModel
    {
        public List<int> Pizzas { get; set; }
        public List<int> Count { get; set; }
    }
}