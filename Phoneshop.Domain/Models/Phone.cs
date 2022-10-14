namespace Phoneshop.Domain.Models
{
    /// <summary>
    /// Phone type with custom ToString function
    /// </summary>
    public class Phone
    {
        public int Id { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; } = new Brand();
        public string Type { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }

        public decimal VATFreePrice()
        {
            return Price / 1.21m;
        }

        public override string ToString()
        {
            return $"Brand: {Brand.Name}\nType:{Type}\nPrice:{Price}\nPricewihout VAT:{Decimal.Round(VATFreePrice(), 2)}\n\"";
        }

        public string FullName => $" {Brand.Name} {Type}";

        public int Stock { get; set; }
    }
}