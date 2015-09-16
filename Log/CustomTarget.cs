using System;
using NLog;
using NLog.Config;
using NLog.Targets;
using BLL.Interface;
using BLL.Interface.Entities;
using Ninject;

namespace Log
{
    [Target("CustomTarget")]

    public class CustomTarget: TargetWithLayout
    {
        private readonly IService<LogMessageEntity> service;
        private static IKernel kernel = new StandardKernel(new NinjectDependencyResolver());

        public CustomTarget ()
	    {
            this.service = kernel.Get<IService<LogMessageEntity>>();
	    }

        protected override void Write(LogEventInfo info)
        {
            string logMessage = this.Layout.Render(info);

            service.Create(new LogMessageEntity() { Message = logMessage, Level = info.Level.Name, TimeOccured = DateTime.Now });
        }
    }
}
