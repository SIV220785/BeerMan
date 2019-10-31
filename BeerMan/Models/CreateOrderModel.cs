using System.Collections.Generic;

namespace BeerMan.Models
{
    public class CreateOrderModel
    {
        public List<int> Foods { get; set; }
        public List<int> CountFoods { get; set; }
        public List<int> Drinks { get; set; }
        public List<int> CountDrinks { get; set; }
    }
}