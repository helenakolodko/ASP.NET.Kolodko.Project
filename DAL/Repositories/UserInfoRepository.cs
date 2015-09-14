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
    public class UserInfoRepository : IRepository<DalUserInfo>
    {
        private readonly DbContext context;

        public UserInfoRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalUserInfo> GetAll()
        {
            return context.Set<UserInfo>()
                .Select(info => new DalUserInfo()
                {
                    Id = info.UserId,
                    FirstName = info.FirstName,
                    LastName = info.LastName,
                    About = info.About,
                    BirthDate = info.BirthDate,
                    Country = info.Country,
                    City = info.City,
                    AvatarPath = info.AvatarPath,
                });
        }

        public DalUserInfo GetById(int id)
        {
            UserInfo ormUserInfo = context.Set<UserInfo>().FirstOrDefault(info => info.UserId == id);
            return ormUserInfo.ToDalUserInfo();
        }

        public IEnumerable<DalUserInfo> GetByPredicate(System.Linq.Expressions.Expression<Func<DalUserInfo, bool>> predicate)
        {
            var expression = CustomExpretionVisitor<UserInfo, DalUserInfo>.Tranform(predicate);
            return context.Set<UserInfo>().Where(expression)
                .Select(info => new DalUserInfo()
                {
                    Id = info.UserId,
                    FirstName = info.FirstName,
                    LastName = info.LastName,
                    About = info.About,
                    BirthDate = info.BirthDate,
                    Country = info.Country,
                    City = info.City,
                    AvatarPath = info.AvatarPath,
                });
        }

        public int Add(DalUserInfo entity)
        {
            UserInfo userInfo = entity.ToUserInfo();
            context.Set<UserInfo>().Add(userInfo);
            context.SaveChanges();
            return userInfo.UserId;
        }

        public void Delete(DalUserInfo entity)
        {
            context.Set<UserInfo>().Remove(entity.ToUserInfo());
        }

        public void Update(DalUserInfo entity)
        {
            var ormUserInfo = entity.ToUserInfo();
            context.Entry(ormUserInfo).State = EntityState.Modified;
        }
    }
}
