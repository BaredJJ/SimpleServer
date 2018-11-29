using System;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class CommandManagerFactory : ICommandManagerFactory
    {
        private readonly ICommandFactory _commandFactory;

        public CommandManagerFactory(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
        }

        public ICommandManager GetCommandManager(int id) => new CommandManager(_commandFactory, id);
    }
}
