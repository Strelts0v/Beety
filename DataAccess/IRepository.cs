using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Models;

namespace DataAccess
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        TEntity GetById(long id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query, params string[] includes);

        IEnumerable<TEntity> GetAll(params string[] includes);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void SaveChanges();
    }
}
