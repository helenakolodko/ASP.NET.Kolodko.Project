using System;
using NLog;
using Log.Interface;

namespace Log
{
    public class NLogAdapter: Log.Interface.ILogger
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            logger.Error(message, exception);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Trace(string message)
        {
            logger.Trace(message);
        }
    }
}
