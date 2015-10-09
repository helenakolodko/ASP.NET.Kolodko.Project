using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Mappers;
using DAL.Interface;
using DAL.Interface.Entities;
using HelperModule;
using ORM.Entities;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>()
                .Select(role => new DalRole()
                {
                    Id = role.Id,
                    Name = role.Name,
                });
        }

        public DalRole GetById(int id)
        {
            var ormRole = context.Set<Role>().FirstOrDefault(role => role.Id == id);
            return ormRole.ToDalRole();
        }

        public IEnumerable<DalUser> GetUsers(int id)
        {
            var ormUser = context.Set<Role>().FirstOrDefault(role => role.Id == id);
            return ormUser.Users.Select(user => user.ToDalUser());
        }

        public IEnumerable<DalRole> GetByPredicate(System.Linq.Expressions.Expression<Func<DalRole, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<Role, DalRole>.Tranform(predicate);
            return context.Set<Role>().Where(expression)
                .Select(role => new DalRole() 
                { 
                    Id = role.Id,
                    Name = role.Name,
                });
        }

        public int Add(DalRole entity)
        {
            var ormRole = entity.ToRole();
            context.Set<Role>().Add(ormRole);
            return ormRole.Id;
        }

        public void Delete(DalRole entity)
        {
            context.Set<Role>().Remove(entity.ToRole());
        }

        public void Update(DalRole entity)
        {
            Role ormRole = entity.ToRole();
            context.Entry(ormRole).State = EntityState.Modified;
        }
    }
}
