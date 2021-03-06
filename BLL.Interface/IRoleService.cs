﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface
{
    public interface IRoleService: IService<RoleEntity>
    {
        IEnumerable<UserEntity> GetUsers(int id);
        IEnumerable<RoleEntity> GetRolesForUser(int userId);

    }
}
