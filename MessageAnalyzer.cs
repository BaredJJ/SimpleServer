using System;
using System.Linq;
using SimpleServer.Interfaces;
using SimpleServer.MessageCommand;

namespace SimpleServer
{
    public class MessageAnalyzer : IMessageAnalyzer
    {
        private static readonly char[] Separator = {':'};
        private readonly string[] _commands;
        private readonly string[] _states;

        public MessageAnalyzer()
        {
            _commands = Enum.GetNames(typeof(Commands));
            _states = Enum.GetNames(typeof(Switch));
        }

        public AcceptCommandDto AnalyzeMessage(string message)
        {
            if (message == null) return null;
            var messageSplit = message.Split(Separator);
            if (messageSplit.Length > 4 || messageSplit.Length < 3) return null;
            Commands acceptCommand = Commands.Error;
            Switch acceptSwitch = Switch.on;

            var command = _commands.First(a => a == messageSplit[0]);
            var state = (messageSplit.Length > 3) ? _states.First(a => a == messageSplit[1]) : Switch.on.ToString();

            if (command != null)
            {
                Commands.TryParse(command, out acceptCommand);
                Switch.TryParse(state, out acceptSwitch);
            }

            return new AcceptCommandDto(acceptCommand, acceptSwitch);
        }

        
    }
}
