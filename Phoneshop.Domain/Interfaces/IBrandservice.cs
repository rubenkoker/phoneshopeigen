using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IBrandservice
    {
        Task InsertBrand(Brand input);

        Task<Brand?> FindBrandByName(string Name);

        Task<bool> DoesBrandExist(string CheckQuery);

        Task<Brand?> GetBrandById(int id);

        Task<bool> RemoveBrand(int input);
    }
}