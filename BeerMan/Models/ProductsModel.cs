using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class ProductsModel
    {
        public List<Food> Foods { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}