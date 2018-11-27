using System;
using System.Collections.Generic;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class TimeCommand:IMessageCommand
    {
        public static readonly string _name = "time";

        public string Name => _name;

        public Switch State => Switch.on;

        public string Execute(IMessageCommand command) => DateTime.Now.ToShortDateString();

        public IMessageCommand GetCommand(IEnumerable<string> data) => this;
    }
}
