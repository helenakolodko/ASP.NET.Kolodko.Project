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
    public class SectionRepository : IRepository<DalSection>
    {
        private readonly DbContext context;

        public SectionRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalSection> GetAll()
        {
            return context.Set<Section>().Select(ormSection => ormSection.ToDalSection());
        }

        public DalSection GetById(int id)
        {
            var ormSection = context.Set<Section>().FirstOrDefault(section => section.Id == id);
            return ormSection.ToDalSection();
        }

        public IEnumerable<DalSection> GetByPredicate(System.Linq.Expressions.Expression<Func<DalSection, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Add(DalSection entity)
        {
            var ormSection = entity.ToSection();
            context.Set<Section>().Add(ormSection);
            context.SaveChanges();
            return ormSection.Id;
        }

        public void Delete(DalSection entity)
        {
            context.Set<Section>().Remove(entity.ToSection());
        }

        public void Update(DalSection entity)
        {
            Section ormSection = entity.ToSection();
            context.Entry(ormSection).State = EntityState.Modified;
        }
    }
}
