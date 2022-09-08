using Phoneshop.Business;
using Phoneshop.Domain.Models;

namespace PhoneshopTest
{
    public class emtpysearchtest
    {
        [Fact]
        public void GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            List<Phone> phone = phoneService.SearchPhonesByString("cam");
            //asses
            Assert.Equal(4, phone.Count());
        }
    }
}