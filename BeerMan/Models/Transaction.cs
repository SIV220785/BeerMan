using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerMan.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TypeCost Type { get; set; }

        public string WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Transaction()
        {
            Orders = new List<Order>(); 
        }
    }

    
    public enum TypeCost
    {
        Cash,
        Card,
        Cashless
    }
}