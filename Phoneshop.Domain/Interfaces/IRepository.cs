namespace Phoneshop.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity entity);

        void Delete(int id);
    }
}