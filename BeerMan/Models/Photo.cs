using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Link { get; set; }

        public int UserID { get; set; }
        public AspNetUsers AspNetUsers { get; set; }
    }
}