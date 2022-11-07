namespace Phoneshop.Domain.Models

{

    /// <summary>
    /// Phone type with custom ToString function
    /// </summary>
    public class Phone : EntityBase
    {
        public int Id { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; } = new Brand();
        public string Type { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Brand: {Brand.Name}\nType:{Type}\nPrice:{Price}\n\n\"";
        }

        public string FullName => $" {Brand.Name} {Type}";

        public int Stock { get; set; }
    }
}