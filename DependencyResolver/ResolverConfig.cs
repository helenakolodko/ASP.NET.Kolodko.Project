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

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<IService<UserInfoEntity>>().To<UserInfoService>();
            kernel.Bind<IRepository<DalUserInfo>>().To<UserInfoRepository>();

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();

            kernel.Bind<IService<SectionEntity>>().To<SectionService>();
            kernel.Bind<IRepository<DalSection>>().To<SectionRepository>();

            kernel.Bind<IService<LogMessageEntity>>().To<LogMessageService>();
            kernel.Bind<IRepository<DalLogMessage>>().To<LogMessageRepository>();

            kernel.Bind<IServiceWithRaiting<CommentEntity>>().To<CommentService>();
            kernel.Bind<IRepository<DalComment>>().To<CommentRepository>();

            kernel.Bind<IServiceWithRaiting<TopicEntity>>().To<TopicService>();
            kernel.Bind<IRepository<DalTopic>>().To<TopicRepository>();

            kernel.Bind<IVoteRepository<DalTopicVote>>().To<TopicVoteRepository>();
            kernel.Bind<IVoteRepository<DalCommentVote>>().To<CommentVoteRepository>();

            kernel.Bind<ILogger>().To<NLogAdapter>();
        }
    }
}
