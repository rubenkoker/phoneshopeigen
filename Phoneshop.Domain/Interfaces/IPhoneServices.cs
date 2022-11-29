using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IPhoneService
    {
        Task<Phone?> GetPhoneById(int input);

        Task<List<Phone>> GetAllPhones();

        Task<List<Phone>?> Search(string input);

        Task<bool> RemovePhone(int input);

        Task<bool> AddPhone(Phone input);
    }
}