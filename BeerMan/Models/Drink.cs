
namespace BeerMan.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int? Count { get; set; }

        public int? PhotoId { get; set; }
        public virtual Photo Photo { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}