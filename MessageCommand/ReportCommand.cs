using System;
using System.Collections.Generic;
using System.Linq;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class ReportCommand:IMessageCommand
    {
        private static readonly string _name = "report";

        public ReportCommand() => State = Switch.off;

        public string Name => _name;
        public Switch State { get; set; }

        public string Execute(IMessageCommand command)
        {
            return command.Name;
        }

        public IMessageCommand Create(IEnumerable<string> data)
        {
            if (!Enum.TryParse(data.ElementAt(1).ToLower(), out Switch state)) return null;

            return new ReportCommand() {State = state};
        }
    }
}
