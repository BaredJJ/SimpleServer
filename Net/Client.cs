using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using SimpleServer.Interfaces;

namespace SimpleServer.Net
{
    public class Client:IClient
    {
        private static readonly string Welcome = "Welcome on BaredJJ host\n\r";
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
        {
            using (NetworkStream stream = _client.GetStream())
            {
                using (StreamReader reader = new StreamReader(_client.GetStream()))
                {
                    var welcome = Encoding.ASCII.GetBytes(Welcome);
                    stream.Write(welcome, 0, welcome.Length);
                    while (true)
                    {
                        var message = reader.ReadLine();
                        var response = _messageServices.ProcessMessage(message);
                        var report = Encoding.ASCII.GetBytes(response);
                        stream.Write(report, 0, report.Length);
                    }
                }
            }
        }
    }
}
