using System;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class MessageService : IMessageService
    {
        private readonly IMessageAnalyzer _messageAnalyzer;

        public event EventHandler OnSendMessage;

        public MessageService(IMessageAnalyzer messageAnalyzer)
        {
            _messageAnalyzer = messageAnalyzer ?? throw new ArgumentNullException(nameof(messageAnalyzer));
        }

        public void ProcessMessage(string message)
        {
            var command = _messageAnalyzer.AnalyzeMessage(message);
        }
    }
}
