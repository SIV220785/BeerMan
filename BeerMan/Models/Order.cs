using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class Order
    {
        [Key,ForeignKey("Transaction")]
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsPayment { get; set; }

        public string AspNetUsersID { get; set; }
        [ForeignKey("AspNetUsersID")]
        public virtual AspNetUsers AspNetUsers { get; set; }

        public int? PartyId { get; set; }
        [ForeignKey("PartyId")]
        public virtual Party Party { get; set; }

        //public int? TransactionId { get; set; }
        //[ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }

        public Order()
        {
            Foods = new List<Food>();
            Drinks = new List<Drink>();
        }

    }
}