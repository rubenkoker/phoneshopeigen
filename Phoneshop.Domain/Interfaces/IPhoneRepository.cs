using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IPhoneRepository
    {
        public void Create(Phone input);

        public void Update(Phone input);

        public void Delete(Phone input);

        public List<Phone> GetAll();

        public Phone Get(int id);
    }
}