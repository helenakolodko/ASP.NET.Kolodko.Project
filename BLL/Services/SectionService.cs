using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLL.Interface;
using BLL.Mappers;
using BLL.Interface.Entities;
using DAL.Interface;
using DAL.Interface.Entities;

namespace BLL.Services
{
    public class SectionService: IService<SectionEntity>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<DalSection> sectionRepository;

        public SectionService(IUnitOfWork unitOfWork, IRepository<DalSection> repository)
        {
            this.unitOfWork = unitOfWork;
            this.sectionRepository = repository;
        }

        public SectionEntity GetEntity(int id)
        {
            return sectionRepository.GetById(id).ToBllSection();
        }

        public IEnumerable<SectionEntity> GetAllEntities()
        {
            return sectionRepository.GetAll().Select(section => section.ToBllSection());
        }

        public int Create(SectionEntity entity)
        {
            int id = sectionRepository.Add(entity.ToDalSection());
            unitOfWork.Commit();
            return id;
        }

        public void Delete(SectionEntity entity)
        {
            sectionRepository.Delete(entity.ToDalSection());
            unitOfWork.Commit();
        }

        public void Update(SectionEntity entity)
        {
            sectionRepository.Update(entity.ToDalSection());
            unitOfWork.Commit();
        }


        public IEnumerable<SectionEntity> GetByPredicate(Expression<Func<SectionEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
