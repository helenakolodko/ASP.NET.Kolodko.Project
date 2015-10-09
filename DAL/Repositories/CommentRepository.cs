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
    public class CommentRepository : IRepository<DalComment>
    {
        private readonly DbContext context;

        public CommentRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalComment> GetAll()
        {
            return context.Set<Comment>()
                .Select(comment => new DalComment()
                {
                    Id = comment.Id,
                    UserId = comment.AuthorId,
                    TopicId = comment.TopicId,
                    Text = comment.Text,
                    DateAdded = comment.DateAdded,
                });
        }

        public DalComment GetById(int id)
        {
            var ormComment = context.Set<Comment>().FirstOrDefault(comment => comment.Id == id);
            return ormComment.ToDalComment();
        }

        public IEnumerable<DalComment> GetByPredicate(System.Linq.Expressions.Expression<Func<DalComment, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<Comment, DalComment>.Tranform(predicate);
            return context.Set<Comment>().Where(expression)
                .Select(comment => new DalComment() 
                {
                    Id = comment.Id,
                    UserId = comment.AuthorId,
                    TopicId = comment.TopicId,
                    Text = comment.Text,
                    DateAdded = comment.DateAdded,
                });
        }

        public int Add(DalComment entity)
        {
            var ormComment = entity.ToComment();
            context.Set<Comment>().Add(ormComment);
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