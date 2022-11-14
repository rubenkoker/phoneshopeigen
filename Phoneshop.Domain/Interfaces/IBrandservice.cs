using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IBrandservice
    {
        public void InsertBrand(Brand input);
        public Brand? FindBrandByName(string Name);
        public bool DoesBrandExist(string CheckQuery);
    }
}