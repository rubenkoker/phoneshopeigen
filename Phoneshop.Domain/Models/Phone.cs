namespace Phoneshop.Domain.Models

{
    public class Phone : EntityBase
    {
        public int BrandID { get; set; }
        public virtual Brand? Brand { get; set; }
        public string Type { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Brand: {Brand?.Name}\nType:{Type}\nPrice:{Price}\n\n\"";
        }

        public string FullName => $" {Brand?.Name} {Type}";

        public int Stock { get; set; }
    }
}