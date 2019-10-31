using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerMan.Models
{
    public class Transaction
    {
        //[Key,ForeignKey("Order")]
        public int Id { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TypeCost Type { get; set; }

        public string WalletId { get; set; }
        [ForeignKey("WalletId")]
        public virtual Wallet Wallet { get; set; }
      
        public virtual Order Order { get; set; }

        public Transaction()
        {
        }
    }

    
    public enum TypeCost
    {
        Cash,
        Card,
        Cashless
    }
}