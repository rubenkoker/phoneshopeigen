namespace Phoneshop.Domain.Models
{

    public class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"Brand: {Brand}\nType:{Type}\n";
        }

    }

}
