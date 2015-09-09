using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IService<T>
    {
        T GetEntity(int id);
        IEnumerable<T> GetAllEntities();
        int Create(T entity);
        void Delete(T entity);
        void Update(T entity);   
    }
}
