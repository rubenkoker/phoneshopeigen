using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IPhoneService
    {
        Phone GetPhoneById(int input);

        List<Phone> GetAllPhones();

        List<Phone> Search(string input);
    }
}