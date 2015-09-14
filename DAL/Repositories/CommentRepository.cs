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
    public class CommentRepository : IRepository<DalComment>
    {
        private readonly DbContext context;

        public CommentRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalComment> GetAll()
        {
            return context.Set<Comment>().Select(content => content.ToDalComment());
        }

        public DalComment GetById(int id)
        {
            var ormComment = context.Set<Comment>().FirstOrDefault(content => content.Id == id);
            return ormComment.ToDalComment();
        }

        public IEnumerable<DalComment> GetByPredicate(System.Linq.Expressions.Expression<Func<DalComment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Add(DalComment entity)
        {
            var ormComment = entity.ToComment();
            context.Set<Comment>().Add(ormComment);
            context.SaveChanges();
            return ormComment.Id;
        }

        public void Delete(DalComment entity)
        {
            context.Set<Comment>().Remove(entity.ToComment());
        }

        public void Update(DalComment entity)
        {
            Comment ormComment = entity.ToComment();
            context.Entry(ormComment).State = EntityState.Modified;
        }
    }
}