using System;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class MessageServiceFactory:IMessageServiceFactory
    {
        private readonly IMessageAnalyzer _messageAnalyzer;
        private readonly ICommandManagerFactory _commandManagerFactory;
        private int _countId;

        public MessageServiceFactory(IMessageAnalyzer messageAnalyzer, ICommandManagerFactory commandManagerFactory)
        {
            _messageAnalyzer = messageAnalyzer ?? throw new ArgumentNullException(nameof(messageAnalyzer));
            _commandManagerFactory = commandManagerFactory ?? throw new ArgumentNullException(nameof(commandManagerFactory));
        }

        public IMessageService GetMessageService() => 
            new MessageService(_messageAnalyzer, _commandManagerFactory.GetCommandManager(_countId++));
    }
}
