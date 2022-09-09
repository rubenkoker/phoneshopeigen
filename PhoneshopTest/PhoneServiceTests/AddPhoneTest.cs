using Phoneshop.Domain.Models;

namespace Phoneshop.Business.Test.PhoneServiceTests
{
    public class AddPhoneTest
    {
        [Fact]
        public void GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            PhoneService phoneService = new();
            Phone phone = new();
            phone.Brand = "fairphone";
            phone.Stock = 8;
            phone.Price = 500m;
            phone.Description = "deze nederlandse telefoon is fairtrade en heef 5g";
            phone.Type = "4";

            bool Result = phoneService.AddPhone(phone);
            //act

            //asses
            Assert.True(Result);
        }
    }
}
