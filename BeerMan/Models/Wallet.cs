using System.Collections.Generic;

namespace BeerMan.Models
{
    public class Wallet
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public AspNetUsers AspNetUsers { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Coin> Coins { get; set; }
    }
}                      
