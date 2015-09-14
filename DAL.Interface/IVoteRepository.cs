using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IVoteRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllOfTopic(int id);
        IEnumerable<T> GetAllOfUser(int id);
        T GetById(int postId, int userId);
        IEnumerable<T> GetByPredicate(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
