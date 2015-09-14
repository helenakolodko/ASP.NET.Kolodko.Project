using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL.Interface
{
    public interface IService<T>
    {
        T GetEntity(int id);
        IEnumerable<T> GetAllEntities();
        IEnumerable<T> GetByPredicate(Expression<Func<T, bool>> predicate);
        int Create(T entity);
        void Delete(T entity);
        void Update(T entity);   
    }
}
