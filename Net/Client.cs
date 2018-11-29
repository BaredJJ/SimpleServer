using System;
using System.Net.Sockets;
using SimpleServer.Interfaces;

namespace SimpleServer.Net
{
    public class Client:IClient
    {
        private readonly TcpClient _client;
        private readonly IMessageService _messageServices;
        private readonly byte[] _buffer;

        public Client(TcpClient client, IMessageService messageServices)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _messageServices = messageServices ?? throw new ArgumentNullException(nameof(messageServices));
            _buffer = new byte[1024];
        }

        public void Start()
        { }
    }
}
