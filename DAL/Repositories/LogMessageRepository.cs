using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DAL.Mappers;
using DAL.Interface;
using DAL.Interface.Entities;
using ORM.Entities;
using HelperModule;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class LogMessageRepository: IRepository<DalLogMessage>
    {
        private readonly DbContext context;

        public LogMessageRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalLogMessage> GetAll()
        {
            return context.Set<LogMessage>().Select(ormLog => new DalLogMessage()
            {
                Id = ormLog.Id,
                TimeOccured = ormLog.TimeOccured,
                Level = ormLog.Level,
                Message = ormLog.Message,
            });
        }

        public DalLogMessage GetById(int id)
        {
            var ormLog = context.Set<LogMessage>().FirstOrDefault(log => log.Id == id);
            return ormLog.ToDalLogMessage();
        }

        public IEnumerable<DalLogMessage> GetByPredicate(Expression<Func<DalLogMessage, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<LogMessage, DalLogMessage>.Tranform(predicate);
            return context.Set<LogMessage>().Where(expression)
                .Select(ormLog => new DalLogMessage()
                {
                    Id = ormLog.Id,
                    TimeOccured = ormLog.TimeOccured,
                    Level = ormLog.Level,
                    Message = ormLog.Message,
                });
        }

        public int Add(DalLogMessage entity)
        {
            var log = entity.ToLogMessage();
            context.Set<LogMessage>().Add(log);
            return log.Id;
        }

        public void Delete(DalLogMessage entity)
        {
            LogMessage ormLog = entity.ToLogMessage();

            context.Set<LogMessage>().Remove(ormLog);
        }

        public void Update(DalLogMessage entity)
        {
            LogMessage ormLog = entity.ToLogMessage();
            context.Entry(ormLog).State = EntityState.Modified;
        }
    }
}
