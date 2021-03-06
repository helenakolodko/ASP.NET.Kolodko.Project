﻿using System;
using System.Data.Entity;
using Ninject;
using Ninject.Web.Common;
using Ninject.Modules;
using BLL.Interface.Entities;
using BLL.Interface;
using BLL;
using BLL.Services;
using DAL;
using DAL.Repositories;
using DAL.Interface;
using DAL.Interface.Entities;
using ORM;

namespace Log
{
    internal class NinjectDependencyResolver: NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            Bind<DbContext>().To<ForumContext>().InRequestScope();
            Bind<IService<LogMessageEntity>>().To<LogMessageService>();
            Bind<IRepository<DalLogMessage>>().To<LogMessageRepository>();
        }
    }
}
