
namespace BeerMan.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public int FotoId { get; set; }
        public Photo Foto { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}