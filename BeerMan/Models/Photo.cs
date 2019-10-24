using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class Photo
    {

        public int Id { get; set; }
        public string Name { get; set; } 
        public byte[] Image { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        //public string UserID { get; set; }
        //public virtual AspNetUsers AspNetUsers { get; set; }
    }
}