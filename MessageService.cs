using System;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class MessageService : IMessageService
    {
        private readonly IMessageAnalyzer _messageAnalyzer;
        private readonly ICommandManager _commandManager;

        public MessageService(IMessageAnalyzer messageAnalyzer, ICommandManager commandManager)
        {
            _messageAnalyzer = messageAnalyzer ?? throw new ArgumentNullException(nameof(messageAnalyzer));
            _commandManager = commandManager ?? throw new ArgumentNullException(nameof(commandManager));
        }

        public string ProcessMessage(string message)
        {
            var command = _messageAnalyzer.AnalyzeMessage(message);
            return _commandManager.GetResponse(command);
        }
    }
}
