using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface;
using HelperModule;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository)
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

        public UserEntity GetByLogin(string login)
        {
            return userRepository.GetByLogin(login).ToBllUser();
        }

        public IEnumerable<RoleEntity> GetRoles(int id)
        {
            return userRepository.GetRoles(id).Select(role => role.ToBllRole());
        }

        public IEnumerable<UserEntity> GetByPredicate(System.Linq.Expressions.Expression<Func<UserEntity, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<DalUser, UserEntity>.Tranform(predicate);
            return userRepository.GetByPredicate(expression).Select(user => user.ToBllUser()); ;
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
