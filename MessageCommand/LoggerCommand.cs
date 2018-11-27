using System;
using System.Collections.Generic;
using System.Linq;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class LoggerCommand:IMessageCommand
    {
        private static readonly string _name = "log";

        private readonly ILoggerFactory _loggerFactory;
        private readonly ILog _log;

        public LoggerCommand()
        {
            State = Switch.off;
        }

        public string Name => _name;
        public Switch State { get; set; }


        public string Execute(IMessageCommand command)
        {
            _log.Write(command.Name);
            return string.Empty;
        }

        public IMessageCommand Create(IEnumerable<string> data)
        {
            if (!Enum.TryParse(data.ElementAt(1).ToLower(), out Switch state)) return null;

            return new LoggerCommand() { State = state };
        }
    }
}
