using System;
using System.Collections.Generic;
using System.Linq;
using SimpleServer.Interfaces;
using SimpleServer.MessageCommand;

namespace SimpleServer
{
    public class MessageAnalyzer : IMessageAnalyzer
    {
        private static readonly char[] Separator = {':','.','\\','\'','?','!','\r','\n'};
        private readonly List<string> _commands;
        private readonly List<string> _states;
        private readonly AcceptCommandDto _defAcceptCommandDto;

        public MessageAnalyzer()
        {
            _commands = Enum.GetNames(typeof(Commands)).ToList();
            _states = Enum.GetNames(typeof(Switch)).ToList();
            Commands acceptCommand = Commands.Error;
            Switch acceptSwitch = Switch.on;
            _defAcceptCommandDto = new AcceptCommandDto(acceptCommand, acceptSwitch);
        }

        public AcceptCommandDto AnalyzeMessage(string message)
        {
            if (string.IsNullOrEmpty(message)) return null;
            //if (message == null) return _defAcceptCommandDto;
            var messageSplit = message.Split(Separator);
            if (messageSplit.Length < 1 || messageSplit.Length > 2) return _defAcceptCommandDto;

            if (!_commands.Contains(messageSplit[0])) return _defAcceptCommandDto;

            var state = Switch.on;
            if(messageSplit.Length == 2 && _states.Contains(messageSplit[1]))
                Enum.TryParse(messageSplit[1], out state);

            Enum.TryParse(messageSplit[0], out Commands acceptCommand);


            return new AcceptCommandDto(acceptCommand, state);
        }

        
    }
}
