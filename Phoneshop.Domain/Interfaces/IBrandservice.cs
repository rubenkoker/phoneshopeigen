using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IBrandservice
    {
        public void InsertBrand(Phone input);
        public bool DoesBrandExist(string CheckQuery, bool BrandExists);
    }
}
