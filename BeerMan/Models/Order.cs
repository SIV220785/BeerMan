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
        public DateTime? CreateDate { get; set; }

        public string AspNetUsersID { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }

        public int? PartyId { get; set; }
        public virtual Party Party { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }

        public Order()
        {
            Foods = new List<Food>();
            Drinks = new List<Drink>();
        }

    }
}