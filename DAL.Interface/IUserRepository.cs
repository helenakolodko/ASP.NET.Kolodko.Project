using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;

namespace DAL.Interface
{
    public interface IUserRepository: IRepository<DalUser>
    {
        DalUser GetByLogin(string login);
        IEnumerable<DalRole> GetRoles(int id);
    }
}
