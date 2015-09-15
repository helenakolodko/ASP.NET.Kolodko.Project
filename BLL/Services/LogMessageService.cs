using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface;
using HelperModule;


namespace BLL.Services
{
    public class LogMessageService: IService<LogMessageEntity>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<DalLogMessage> logRepository;

        public LogMessageService(IUnitOfWork unitOfWork, IRepository<DalLogMessage> repository)
        {
            this.unitOfWork = unitOfWork;
            this.logRepository = repository;
        }

        public LogMessageEntity GetEntity(int id)
        {
            return logRepository.GetById(id).ToBllLogMessage();
        }

        public IEnumerable<LogMessageEntity> GetAllEntities()
        {
            return logRepository.GetAll().Select(log => log.ToBllLogMessage());
        }

        public IEnumerable<LogMessageEntity> GetByPredicate(System.Linq.Expressions.Expression<Func<LogMessageEntity, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<DalLogMessage, LogMessageEntity>.Tranform(predicate);
            return logRepository.GetByPredicate(expression).Select(log => log.ToBllLogMessage()); ;
        }


        public int Create(LogMessageEntity entity)
        {
            int id = logRepository.Add(entity.ToDalLogMessage());
            unitOfWork.Commit();
            return id;
        }

        public void Delete(LogMessageEntity entity)
        {
            logRepository.Delete(entity.ToDalLogMessage());
            unitOfWork.Commit();
        }


        public void Update(LogMessageEntity entity)
        {
            logRepository.Update(entity.ToDalLogMessage());
            unitOfWork.Commit();
        }
    }
}
