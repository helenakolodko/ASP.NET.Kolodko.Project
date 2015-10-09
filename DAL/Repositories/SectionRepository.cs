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
    public class SectionRepository : IRepository<DalSection>
    {
        private readonly DbContext context;

        public SectionRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalSection> GetAll()
        {
            return context.Set<Section>()
                .Select(ormSection => new DalSection()
                {
                    Id = ormSection.Id,
                    Name = ormSection.Name,
                    Info = ormSection.Info
                });
        }

        public DalSection GetById(int id)
        {
            var ormSection = context.Set<Section>().FirstOrDefault(section => section.Id == id);
            return ormSection.ToDalSection();
        }

        public IEnumerable<DalSection> GetByPredicate(System.Linq.Expressions.Expression<Func<DalSection, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<Section, DalSection>.Tranform(predicate);
            return context.Set<Section>().Where(expression)
                .Select(ormSection => new DalSection()
                {
                    Id = ormSection.Id,
                    Name = ormSection.Name,
                    Info = ormSection.Info
                });
        }

        public int Add(DalSection entity)
        {
            var ormSection = entity.ToSection();
            context.Set<Section>().Add(ormSection);
            return ormSection.Id;
        }

        public void Delete(DalSection entity)
        {
            context.Set<Section>().Remove(entity.ToSection());
        }

        public void Update(DalSection entity)
        {
            Section ormSection = context.Set<Section>().FirstOrDefault(section => section.Id == entity.Id);
            ormSection.Info = entity.Info;
            entity.Name = entity.Name;
            context.Entry(ormSection).State = EntityState.Modified;
        }
    }
}
