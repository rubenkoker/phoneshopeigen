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
            phone.Brand = "redphone";
            phone.Price = 100;

            //act
            var priceWithoutVat = phone.PriceWithoutVat();


            //asses
            Assert.Equal(121, priceWithoutVat);
        }
    }
}
