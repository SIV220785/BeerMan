using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartPartyDate { get; set; }
        public string About { get; set; }

        public int UserId { get; set; }
        //[ForeignKey("UserId")]
        public AspNetUsers AspNetUser { get; set; }

        //public ICollection<Photo> Photos { get; set; }
        public ICollection<AspNetUsers> AspNetUsers { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}