using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IPhoneServicecs
    {

        Phone GetPhoneById(int input);

        List<Phone> GetAllPhones();

        List<Phone> SearchPhonesByString(string input);

    }
}

