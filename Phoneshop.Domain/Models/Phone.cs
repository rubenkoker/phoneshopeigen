namespace Phoneshop.Domain.Models
{
    /// <summary>
    /// Phone type with custom ToString function
    /// </summary>
    public class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Type { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }

        public decimal VATFreePrice()
        {
            return Price / 1.21m;
        }

        public override string ToString()
        {
            return $"Brand: {Brand}\nType:{Type}\nPrice:{Price}\nPricewihout VAT:{Decimal.Round(VATFreePrice(), 2)}\n\"";
        }

        public string FullName => $" {Brand} {Type}";

        public int Stock { get; set; }
    }

}
