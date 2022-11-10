using Phoneshop.Business.Extensions;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business.Test
{
    public class Should_ReturnPriceWithoutVAT
    {
        [Fact]
        public void PriceWithoutVAT()
        {
            //arrange
            var phone = new Phone();
            phone.Brand.Name = "redphone";
            phone.Price = 121;

            //act

            var priceWithoutVat = phone.VATFreePrice();

            //asses
            Assert.Equal(100, priceWithoutVat);
        }
    }
}