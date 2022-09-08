namespace PhoneshopTest
{
    using Phoneshop.Business;
    using Phoneshop.Domain.Models;
    using System.Diagnostics;
    public class Phonshopservicetest
    {
        [Fact]
        public void GetByIDTest_ShouldReturnIphone()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            Phone phone = phoneService.GetPhoneById(12);
            //asses
            Debug.WriteLine(phone.Type);
            Assert.Equal("IPhone 11", phone.Type);
        }

        [Fact]
        public void GetAllPhonesTest_shouldReturn5phones()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            List<Phone> phone = phoneService.GetAllPhones();
            //asses
            Assert.Equal(5, phone.Count());
        }

        [Fact]
        public void GetByIDZeroTest_SHouldReturnNull()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            Phone phone = phoneService.GetPhoneById(0);
            //asses
            Assert.Null(phone);
        }
    }
}