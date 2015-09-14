using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetByPredicate(Expression<Func<T, bool>> predicate);
        int Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
