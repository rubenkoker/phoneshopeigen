﻿using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System.Diagnostics;

namespace Phoneshop.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase

    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> GetAll()

        {
            Debug.WriteLine(context.Set<TEntity>().Count());
            return context.Set<TEntity>();
        }

        public TEntity? GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public bool Delete(int id)
        {
            var item = context.Set<TEntity>().Find(id);
            if (item == null)
            {
                return false;
            }
            context.Set<TEntity>().Remove(context.Set<TEntity>().Find(id));
            return true;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}