using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
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
            var newClient = new Client(client, _messageServicesFactory.GetMessageService());
            _clients.Add(newClient);
            newClient.OnException += OnException;
            Task.Run( () => newClient.StartAsync());
        }

        private void OnException(object sender, EventArgs e)
        {
            if(!(sender is Client client)) return;

            _clients.Remove(client);
            client.Stop();
        }
    }
}
