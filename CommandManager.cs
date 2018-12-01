using System;
using System.Collections.Generic;
using SimpleServer.Interfaces;
using SimpleServer.MessageCommand;

namespace SimpleServer
{
    public class CommandManager:ICommandManager
    {
        private readonly Dictionary<Commands, Switch> _states;
        private readonly ICommandFactory _commandFactory;
        private IResponse _response;
        private readonly int _id;

        public CommandManager(ICommandFactory commandFactory, int id)
        {
            _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
            _states = new Dictionary<Commands, Switch>();
            var commands = (Commands[])Enum.GetValues(typeof(Commands));
            foreach (var command in commands)
            {
                _states.Add(command, Switch.off);
            }

            _id = id;
        }

        public string GetResponse(AcceptCommandDto command)
        {
            if(!IsStateChange(command)) return _response.Response();

            ChangeState(command);//todo нужно подумать как обыграть ситуацию с отключением и подключением.
            var currentCommand = GetCurrentCommand(command.Command);
            _response = _commandFactory.GetResponseObject(_states, _id, currentCommand);

            return _response.Response();
        }

        private bool IsStateChange(AcceptCommandDto command) => (_states[command.Command] != command.State);

        private void ChangeState(AcceptCommandDto command) => _states[command.Command] = command.State;

        private KeyValuePair<Commands, Switch> GetCurrentCommand(Commands command) => new KeyValuePair<Commands, Switch>(command, _states[command]);
    }
}
