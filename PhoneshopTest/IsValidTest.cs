using Phoneshop.Domain.Models;
namespace Phoneshop.Business.Test
{
    public class IsValidTest
    {
        [Fact]
        public void IsValidTestPositive()
        {
            var phone = new Phone();
            phone.Brand.Name = "redphone";
            phone.Price = 121;
            phone.Stock = 42;
            phone.Brand.Id = 43;
            phone.BrandID = phone.Brand.Id;
            phone.Description = "deze vietnamese telefoon is perfect voor lange afstands bellen";

        }

    }
}