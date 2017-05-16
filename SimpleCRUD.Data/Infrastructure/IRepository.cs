using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleCRUD.Data.Infrastructure
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();

        T Get(Guid id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
