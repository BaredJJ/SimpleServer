using System;
using System.Collections.Generic;
using System.Net.Sockets;
using SimpleServer.Interfaces;

namespace SimpleServer.Net
{
    public class ClientManager : IClientManager
    {
        private readonly List<IClient> _clients;
        private readonly IMessageServiceFactory _messageServicesFactory;

        public ClientManager(IMessageServiceFactory messageServiceFactory)
        {
            _messageServicesFactory =
                messageServiceFactory ?? throw new ArgumentNullException(nameof(messageServiceFactory));

            _clients = new List<IClient>();
        }

        public void Add(TcpClient client)//todo Подумать о фабрике
        {
            //if(_clients.Contains(client)) return;
            var newClient = new Client(client, _messageServicesFactory.GetMessageService());
            _clients.Add(newClient);
            newClient.Start();
        }
    }
}
