using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IPhoneServicecs
    {


        public Phone GetPhoneById(int input);


        public List<Phone> GetAllPhones();

        public void DisplayPhones();


        public Phone SelectPhone();

    }
}


