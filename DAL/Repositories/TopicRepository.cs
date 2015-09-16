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
    public class TopicRepository : IRepository<DalTopic>
    {
        private readonly DbContext context;

        public TopicRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalTopic> GetAll()
        {
            return context.Set<Topic>()
                .Select(topic => new DalTopic()
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    UserId = topic.AuthorId,
                    SectionId = topic.SectionId,
                    Text = topic.Text,
                    DateAdded = topic.DateAdded,
                });
        }

        public DalTopic GetById(int id)
        {
            var ormTopic = context.Set<Topic>().FirstOrDefault(topic => topic.Id == id);
            return ormTopic.ToDalTopic();
        }

        public IEnumerable<DalTopic> GetByPredicate(System.Linq.Expressions.Expression<Func<DalTopic, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<Topic, DalTopic>.Tranform(predicate);
            return context.Set<Topic>().Where(expression)
                .Select(topic => new DalTopic() 
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    UserId = topic.AuthorId,
                    SectionId = topic.SectionId,
                    Text = topic.Text,
                    DateAdded = topic.DateAdded,
                });
        }

        public int Add(DalTopic entity)
        {
            var ormTopic = entity.ToTopic();
            context.Set<Topic>().Add(ormTopic);
            return ormTopic.Id;
        }

        public void Delete(DalTopic entity)
        {
            context.Set<Topic>().Remove(entity.ToTopic());
        }

        public void Update(DalTopic entity)
        {
            Topic ormTopic = entity.ToTopic();
            context.Set<Topic>().Attach(ormTopic);
            context.Entry(ormTopic).State = EntityState.Modified;
        }
    }
}