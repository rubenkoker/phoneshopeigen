using Phoneshop.Business.Extensions;
using Phoneshop.Domain.Models;
using System.Diagnostics;
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
            phone.Type = "3s";
            phone.Brand.Id = 43;
            phone.BrandID = phone.Brand.Id;
            phone.Description = "deze vietnamese telefoon is perfect voor lange afstands bellen";
            PhoneService phoneService = new PhoneService();
            string message;
            bool result = phone.IsValid(out message);
            Debug.WriteLine(message);
            Assert.True(result);

        }

        [Fact]
        public void IsValidTestNegative()
        {
            var phone = new Phone();
            phone.Brand.Name = "redphone";
            phone.Price = 121;
            phone.Stock = 42;

            phone.BrandID = phone.Brand.Id;
            PhoneService phoneService = new PhoneService();
            string message;
            Assert.False(phone.IsValid(out message));

        }

    }
}