using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.CrossCuttingConserns.Loging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _log;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]); 
            _log = LogManager.GetLogger(loggerRepository.Name,name);
        }
        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErorEnabled => _log.IsInfoEnabled;
        public void Info(object logMessage)
        {
            _log.Info(logMessage);
        }
        public void Debug(object logMessage)
        {
            _log.Debug(logMessage);
        }
        public void Warn(object logMessage)
        {
            _log.Warn(logMessage);
        }
        public void Fatal(object logMessage)
        {
            _log.Fatal(logMessage);
        }
        public void Error(object logMessage)
        {
            _log.Error(logMessage);
        }
    }
}
