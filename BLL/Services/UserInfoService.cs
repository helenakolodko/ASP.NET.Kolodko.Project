using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using BLL.Interface.Entities;
using DAL.Interface.Entities;
using DAL.Interface;

namespace BLL.Services
{
    public class UserInfoService: IService<UserInfoEntity>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<UserEntity> userInfoRepository;

        public UserInfoEntity GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInfoEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public void Create(UserInfoEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserInfoEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
