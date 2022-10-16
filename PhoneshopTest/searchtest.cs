using Phoneshop.Business;
using Phoneshop.Domain.Models;

namespace PhoneshopTest
{
    public class searchtest
    {
        [Fact]
        public void GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            List<Phone> phone = phoneService.Search("cam");
            //asses
            Assert.Equal(4, phone.Count());
        }
        [Fact]
        public void GetByIDTest_ShouldReturHuaweiPhones()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            List<Phone> phone = phoneService.Search("Huawei");
            //asses
            Assert.Equal(1, phone.Count());
        }
    }
}