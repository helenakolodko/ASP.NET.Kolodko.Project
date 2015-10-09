using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface
{
    public interface IUserService: IService<UserEntity>
    {
        UserEntity GetByLogin(string login);
        IEnumerable<RoleEntity> GetRoles(int id);
    }
}
