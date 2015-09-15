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

        [RequiredParameter]
        public DateTime Time { get; set; }

        public CustomTarget ()
	    {
            IKernel kernel = new StandardKernel(new NinjectDependencyResolver());
            this.service = kernel.Get<IService<LogMessageEntity>>();
	    }

        protected override void Write(LogEventInfo info)
        {
            string logMessage = this.Layout.Render(info);

            service.Create(new LogMessageEntity() { Message = logMessage, Level = info.Level.Name, TimeOccured = Time });
        }
    }
}
