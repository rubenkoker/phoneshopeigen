using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IPhoneServicecs
    {


        public Phone GetPhoneById(int input);


        public List<Phone> GetAllPhones();




        public Phone SelectPhone();
        public List<Phone> SearchPhonesByString(string input);

    }
}


