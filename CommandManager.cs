using System.Collections.Generic;
using System.Linq;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class CommandManager:ICommandManager
    {
        private readonly Dictionary<string, IMessageCommand> _commands;

        public CommandManager()
        {
            _commands = new Dictionary<string, IMessageCommand>();
        }

        public bool AddCommand(IMessageCommand command)
        {
            if (command == null) return false;
            if (_commands.ContainsKey(command.Name)) return false;

            _commands.Add(command.Name, command);
            return true;
        }

        public IMessageCommand GetCommand(IEnumerable<string> command)
        {
            if (!_commands.ContainsKey(command.ElementAt(0))) return null;

            var messageCommand = _commands[command.ElementAt(0)];
        }
    }
}
