using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeerMan.Models
{
    public class Wallet
    {
        [Key, ForeignKey("AspNetUsers")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public dynamic Coins { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public Wallet()
        {
            Transactions = new List<Transaction>();
        }  
    }

}                      
