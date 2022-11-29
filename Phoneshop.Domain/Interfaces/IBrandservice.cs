using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IBrandservice
    {
        public Task InsertBrand(Brand input);

        Task<Brand?> FindBrandByName(string Name);

        public Task<bool> DoesBrandExist(string CheckQuery);
    }
}