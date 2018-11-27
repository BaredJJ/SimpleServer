using System;
using System.Linq;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class MessageAnalyzer : IMessageAnalyzer
    {
        private static readonly char[] Separator = {':', '\\'};

        private readonly ICommandManager _commandFactory;

        public MessageAnalyzer(ICommandManager commandFactory)
        {
            _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
        }

        public IMessageCommand AnalyzeMessage(string message)
        {
            if (message == null) return null;
            var messageSplit = message.Split(Separator);
            if (messageSplit.Length > 4 || messageSplit.Length < 3) return null;
            if (messageSplit[messageSplit.Length - 1] != "n" && messageSplit[messageSplit.Length - 2] != "r")
                return null;

            var commandData = messageSplit.Where(a => a != "r" || a != "n");
            return _commandFactory.GetCommand(commandData);
        }

        
    }
}
