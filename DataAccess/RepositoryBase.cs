using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected ApplicationDbContext DbContext { get; }

        public RepositoryBase(ApplicationDbContext context)
        {
            DbContext = context;
        }

        public virtual TEntity GetById(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query, params string[] includes)
        {
            var dbSet = AddIncludes(DbContext.Set<TEntity>(), includes);

            return dbSet.Where(query);
        }

        public virtual IEnumerable<TEntity> GetAll(params string[] includes)
        {
            var dbSet = AddIncludes(DbContext.Set<TEntity>(), includes);

            return dbSet.ToArray();
        }

        public virtual void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        protected IQueryable<TEntity> AddIncludes(IQueryable<TEntity> query, string[] includes)
        {
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }
    }
}
