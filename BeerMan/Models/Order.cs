using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreateDate { get; set; }

        public int UserID { get; set; }
        public AspNetUsers AspNetUsers { get; set; }

        public int PartyId { get; set; }
        public Party Party { get; set; }

        public ICollection<Food> Foods { get; set; }
        public ICollection<Drink> Drinks { get; set; }       

    }
}