using System;
using SimpleServer.Interfaces;

namespace SimpleServer.Net
{
    public class Server
    {
        private readonly int _port;
        private readonly IMessageServiceFactory _messageServiceFactory;

        public Server(int port, IMessageServiceFactory messageServiceFactory)
        {
            _port = port;
            _messageServiceFactory =
                messageServiceFactory ?? throw new ArgumentNullException(nameof(messageServiceFactory));
        }
    }
}
