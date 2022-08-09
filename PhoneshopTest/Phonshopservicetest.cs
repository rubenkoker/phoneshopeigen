namespace PhoneshopTest
{
    using Phoneshop.Business;
    using Phoneshop.Domain.Models;
    public class Phonshopservicetest
    {
        [Fact]
        public void GetByIDTest()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            Phone phone = phoneService.GetPhoneById(3);
            //asses
            Assert.Equal("IPhone 11", phone.Type);

        }
        [Fact]
        public void GetAllPhonesTest()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            List<Phone> phone = phoneService.GetAllPhones();
            //asses
            Assert.Equal(5, phone.Count());

        }
        [Fact]
        public void GetByIDZeroTest()
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