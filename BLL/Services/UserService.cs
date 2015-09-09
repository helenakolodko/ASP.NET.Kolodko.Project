using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface;

namespace BLL.Services
{
    public class UserService : IService<UserEntity>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<DalUser> userRepository;

        public UserService(IUnitOfWork unitOfWork, IRepository<DalUser> repository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = repository;
        }

        public UserEntity GetEntity(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        }

        public IEnumerable<UserEntity> GetAllEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public int Create(UserEntity entity)
        {
            int id = userRepository.Add(entity.ToDalUser());
            unitOfWork.Commit();
            return id;
        }

        public void Delete(UserEntity entity)
        {
            userRepository.Delete(entity.ToDalUser());
            unitOfWork.Commit();
        }


        public void Update(UserEntity entity)
        {
            userRepository.Update(entity.ToDalUser());
            unitOfWork.Commit();
        }
    }
}
