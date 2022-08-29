using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IPhoneServicecs
    {


        Phone? GetPhoneById(int input);

        List<Phone> GetAllPhones();

        Phone SelectPhone();

        List<Phone>? SearchPhonesByString(string input);

    }
}


