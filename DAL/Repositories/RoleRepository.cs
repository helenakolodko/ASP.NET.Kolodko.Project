using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Mappers;
using DAL.Interface;
using DAL.Interface.Entities;
using ORM.Entities;

namespace DAL.Repositories
{
    public class RoleRepository : IRepository<DalRole>
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(role => role.ToDalRole());
        }

        public DalRole GetById(int id)
        {
            var ormRole = context.Set<Role>().FirstOrDefault(role => role.Id == id);
            return ormRole.ToDalRole();
        }

        public DalRole GetByPredicate(System.Linq.Expressions.Expression<Func<DalRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Add(DalRole entity)
        {
            var ormRole = entity.ToRole();
            context.Set<Role>().Add(ormRole);
            context.SaveChanges();
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
