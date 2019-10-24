using System;

namespace BeerMan.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TypeCost Type { get; set; }

        public string WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }

    public enum TypeCost
    {
        Cash,
        Card,
        Cashless
    }
}