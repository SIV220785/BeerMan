using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }

    
}