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

        private IQueryable<TEntity> GetAll()

        {
            return context.Set<TEntity>();
        }

        private TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        private void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        private void Delete(int id)
        {
            context.Set<TEntity>().Remove(context.Set<TEntity>().Find(id)); ;
            context.SaveChanges();
        }

        IQueryable<TEntity> IRepository<TEntity>.GetAll()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        TEntity IRepository<TEntity>.GetById(int id)
        {
            return GetById(id);
        }

        void IRepository<TEntity>.Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        void IRepository<TEntity>.Delete(int id)
        {
            context.Set<TEntity>().Remove(context.Set<TEntity>().Find(id));
        }
    }
}