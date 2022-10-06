namespace Phoneshop.Business.Test
{
    public class should__Return_4phones_withcam
    {
        [Fact]
        public void GetByIDTest_ShouldReturnCamPhones()
        {
            //arrange
            PhoneService phoneService = new();
            //act
            bool answer = phoneService.RemovePhone(15);
            //asses

            Assert.True(answer);
        }
    }
}
