using Phoneshop.Business;
using Phoneshop.Domain.Models;
namespace PhoneshopTest
{
    public class Huaweitest
    {
        [Fact]
        public void GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            List<Phone> phone = phoneService.SearchPhonesByString("Huawei");
            //asses
            Assert.Equal(1, phone.Count());

        }
    }
}
