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
    public class UserRepository: IRepository<DalUser>
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => user.ToDalUser());
        }

        public DalUser GetById(int id)
        {
            var ormUser = context.Set<User>().FirstOrDefault(user => user.Id == id);
            return ormUser.ToDalUser();
        }

        public IEnumerable<DalUser> GetByPredicate(Expression<Func<DalUser, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<User, DalUser>.Tranform(predicate);
            return context.Set<User>().Where(expression).Select(ormuser => new DalUser() 
            { 
                Id = ormuser.Id,
                Username = ormuser.UserName,
                Email = ormuser.Email,
                Password = ormuser.Password,
                RegistryDate = ormuser.DateAdded,                
            });
        }

        public int Add(DalUser entity)
        {
            var user = entity.ToUser();
            context.Set<User>().Add(user);
            context.SaveChanges();
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
