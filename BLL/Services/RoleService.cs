using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface;
using BLL.Mappers;
using BLL.Interface.Entities;
using DAL.Interface;
using DAL.Interface.Entities;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class RoleService: IService<RoleEntity>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<DalRole> roleRepository;

        public RoleService(IUnitOfWork unitOfWork, IRepository<DalRole> repository)
        {
            this.unitOfWork = unitOfWork;
            this.roleRepository = repository;
        }

        public RoleEntity GetEntity(int id)
        {
            return roleRepository.GetById(id).ToBllRole(); 
        }

        public IEnumerable<RoleEntity> GetAllEntities()
        {
            return roleRepository.GetAll().Select(role => role.ToBllRole()); 
        }

        public int Create(RoleEntity entity)
        {
            int id = roleRepository.Add(entity.ToDalRole());
            unitOfWork.Commit();
            return id;
        }

        public void Delete(RoleEntity entity)
        {
            roleRepository.Delete(entity.ToDalRole());
            unitOfWork.Commit();
        }

        public void Update(RoleEntity entity)
        {
            roleRepository.Update(entity.ToDalRole());
            unitOfWork.Commit();
        }


        public IEnumerable<RoleEntity> GetByPredicate(Expression<Func<RoleEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
