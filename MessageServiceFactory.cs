using System;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class MessageServiceFactory:IMessageServiceFactory
    {
        private readonly IMessageAnalyzer _messageAnalyzer;

        public MessageServiceFactory(IMessageAnalyzer messageAnalyzer)
        {
            _messageAnalyzer = messageAnalyzer ?? throw new ArgumentNullException(nameof(messageAnalyzer));
        }

        public IMessageService GetMessageService() => new MessageService(_messageAnalyzer);
    }
}
