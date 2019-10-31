using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerMan.Models
{
    public class PayOrderModel
    {
        public List<int> Orders { get; set; }
        public List<TypeCost> TypePaymet { get; set; }       
    }
}