using System;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class LoggerFactory : ILoggerFactory
    {
        public ILog GetLog(int id)
        {
            return null;
        }
    }
}
