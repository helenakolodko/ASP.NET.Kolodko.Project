using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DAL.Mappers;
using DAL.Interface;
using DAL.Interface.Entities;
using ORM.Entities;
using HelperModule;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(ormUser => new DalUser()
            {
                Id = ormUser.Id,
                Username = ormUser.UserName,
                Email = ormUser.Email,
                Password = ormUser.Password,
                RegistryDate = ormUser.DateAdded,
            });
        }

        public DalUser GetById(int id)
        {
            var ormUser = context.Set<User>().FirstOrDefault(user => user.Id == id);
            return ormUser.ToDalUser();
        }

        public DalUser GetByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetRoles(int id)
        {
            var ormUser = context.Set<User>().FirstOrDefault(user => user.Id == id);
            return ormUser.Roles.Select(role => role.ToDalRole());
        }

        public IEnumerable<DalUser> GetByPredicate(Expression<Func<DalUser, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<User, DalUser>.Tranform(predicate);
            return context.Set<User>().Where(expression)
                .Select(ormUser => new DalUser()
                {
                    Id = ormUser.Id,
                    Username = ormUser.UserName,
                    Email = ormUser.Email,
                    Password = ormUser.Password,
                    RegistryDate = ormUser.DateAdded,
                });
        }

        public int Add(DalUser entity)
        {
            var user = entity.ToUser();
            context.Set<User>().Add(user);
            return user.Id;
        }

        public void Delete(DalUser entity)
        {
            User ormUser = entity.ToUser();
            context.Set<User>().Remove(ormUser);
        }

        public void Update(DalUser entity)
        {
            User ormUser = entity.ToUser();
            context.Entry(ormUser).State = EntityState.Modified;
        }
    }
}
