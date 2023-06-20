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
            //tuseen haakjes
            var phone = new Phone()
            {
                Brand = new Brand() { Name = "redphone", Id = 43 },
                Price = 121,
                Stock = 42,
                Type = "3s",
                Description = "deze vietnamese telefoon is perfect voor lange afstands bellen"
            };

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

            string message;
            Assert.False(phone.IsValid(out message));
        }
    }
}