using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DAL.Mappers;
using DAL.Interface;
using DAL.Interface.Entities;
using ORM.Entities;

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

        public DalUser GetByPredicate(System.Linq.Expressions.Expression<Func<DalUser, bool>> predicate)
        {
            throw new NotImplementedException();
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
