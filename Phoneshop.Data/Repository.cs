using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class

    {
        private readonly DbSet<TEntity> entities;
        private readonly PhoneshopContext context;

        public Repository(PhoneshopContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        IQueryable GetAll()
        {
            return entities.AsQueryable();
        }
        TEntity GetById(int id)
        {
            return entities.Find(id);

        }
        void Create(TEntity entity)
        {
            entities.Add(entity);
        }
        void Delete(int id)
        {
            entities.Remove(entities.Find(id)); ;
        }

        IQueryable<TEntity> IRepository<TEntity>.GetAll()
        {
            return entities.AsQueryable();
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
            entities.Remove(entities.Find(id));
        }
    }
}
