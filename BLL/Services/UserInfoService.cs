using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface;

namespace BLL.Services
{
    public class UserInfoService: IService<UserInfoEntity>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<DalUserInfo> userInfoRepository;

        public UserInfoService(IUnitOfWork unitOfWork, IRepository<DalUserInfo> repository)
        {
            this.unitOfWork = unitOfWork;
            this.userInfoRepository = repository;
        }

        public UserInfoEntity GetEntity(int id)
        {
            return userInfoRepository.GetById(id).ToBllUserInfo();
        }

        public IEnumerable<UserInfoEntity> GetAllEntities()
        {
            return userInfoRepository.GetAll().Select(info => info.ToBllUserInfo());
        }

        public int Create(UserInfoEntity entity)
        {
            int id = userInfoRepository.Add(entity.ToDalUserInfo());
            unitOfWork.Commit();
            return id;
        }

        public void Delete(UserInfoEntity entity)
        {
            userInfoRepository.Delete(entity.ToDalUserInfo());
            unitOfWork.Commit();
        }


        public void Update(UserInfoEntity entity)
        {
            userInfoRepository.Update(entity.ToDalUserInfo());
            unitOfWork.Commit();
        }
    }
}
