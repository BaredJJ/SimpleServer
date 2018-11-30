using System.Collections.Generic;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly Dictionary<int, ILog> _loggers;

        public LoggerFactory() => _loggers = new Dictionary<int, ILog>();

        public ILog GetLog(int id)
        {
            if (_loggers.ContainsKey(id))
                return _loggers[id];
            else
            {
                var log = new Logger(id);
                _loggers.Add(id, log);
                return log;
            }           
        }
    }
}
