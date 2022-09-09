using Phoneshop.Business;
using Phoneshop.Domain.Models;
using System.Diagnostics;

namespace PhoneshopTest
{
    public class should__Return_4phones_withcam
    {
        [Fact]
        public void GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            List<Phone> phone = phoneService.Search("camera");
            //asses
            Debug.WriteLine(phone);
            Assert.Equal(4, phone.Count());
        }
    }
}