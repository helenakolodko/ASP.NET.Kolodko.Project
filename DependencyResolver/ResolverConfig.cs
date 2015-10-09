using System.Data.Entity;
using BLL.Interface.Entities;
using BLL.Interface;
using BLL;
using BLL.Services;
using DAL;
using DAL.Repositories;
using DAL.Interface;
using DAL.Interface.Entities;
using Ninject;
using Ninject.Web.Common;
using ORM;
using Log.Interface;
using Log;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<ForumContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<ForumContext>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();

            kernel.Bind<IService<UserInfoEntity>>().To<UserInfoService>().InRequestScope();
            kernel.Bind<IRepository<DalUserInfo>>().To<UserInfoRepository>().InRequestScope();

            kernel.Bind<IRoleService>().To<RoleService>().InRequestScope();
            kernel.Bind<IRoleRepository>().To<RoleRepository>().InRequestScope();

            kernel.Bind<IService<SectionEntity>>().To<SectionService>().InRequestScope();
            kernel.Bind<IRepository<DalSection>>().To<SectionRepository>().InRequestScope();

            kernel.Bind<IService<LogMessageEntity>>().To<LogMessageService>().InRequestScope();
            kernel.Bind<IRepository<DalLogMessage>>().To<LogMessageRepository>().InRequestScope();

            kernel.Bind<IServiceWithRaiting<CommentEntity>>().To<CommentService>().InRequestScope();
            kernel.Bind<IRepository<DalComment>>().To<CommentRepository>().InRequestScope();

            kernel.Bind<IServiceWithRaiting<TopicEntity>>().To<TopicService>().InRequestScope();
            kernel.Bind<IRepository<DalTopic>>().To<TopicRepository>().InRequestScope();

            kernel.Bind<IVoteRepository<DalTopicVote>>().To<TopicVoteRepository>().InRequestScope();
            kernel.Bind<IVoteRepository<DalCommentVote>>().To<CommentVoteRepository>().InRequestScope();

            kernel.Bind<ILogger>().To<NLogAdapter>();
        }
    }
}
