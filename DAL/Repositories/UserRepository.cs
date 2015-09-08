using System;
using System.Data.Entity;
using System.Collections.Generic;
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
            return new List<DalUser>();
                //context.Set<User>().Select(user => new DalUser()
                //{
                //    Id = user.Id,
                //    Username = user.Username,
                //    Email = user.Email
                        
                //});
        }

        public DalUser GetById(int id)
        {
           // var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return new DalUser()
                {
                   // Id = ormuser.Id,
                   // Username = ormuser.Username

                };
        }

        public DalUser GetByPredicate(System.Linq.Expressions.Expression<Func<DalUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
