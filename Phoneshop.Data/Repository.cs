using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
namespace Phoneshop.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase

    {

        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;

        }

        IQueryable<TEntity> GetAll()

        {
            return context.Set<TEntity>();
        }
        TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);

        }
        void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }
        void Delete(int id)
        {
            context.Set<TEntity>().Remove(context.Set<TEntity>().Find(id)); ;
        }

        IQueryable<TEntity> IRepository<TEntity>.GetAll()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        TEntity IRepository<TEntity>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Delete(int id)
        {
            context.Set<TEntity>().Remove(context.Set<TEntity>().Find(id));
        }
    }
}
