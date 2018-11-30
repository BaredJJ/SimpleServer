using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleServer.Interfaces;

namespace SimpleServer.Net
{
    public class Client:IClient, IDisposable
    {
        private static readonly string Welcome = "Welcome on BaredJJ host\n\r";
        private readonly TcpClient _client;
        private readonly IMessageService _messageServices;

        private CancellationTokenSource _tokenSource;
        private CancellationToken _cancellationToken;

        public event EventHandler OnException;

        public Client(TcpClient client, IMessageService messageServices)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _messageServices = messageServices ?? throw new ArgumentNullException(nameof(messageServices));
        }

        public async Task StartAsync(CancellationToken? token = null)
        {
            SetToken(token);

            try
            {
                using (NetworkStream stream = _client.GetStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                       var welcome = Encoding.ASCII.GetBytes(Welcome);
                       stream.Write(welcome, 0, welcome.Length);
                       string message;
                       while (!(message = await reader.ReadLineAsync().ConfigureAwait(false)).Equals("exit", StringComparison.OrdinalIgnoreCase))
                       {
                            await Task.Run(async () =>
                            {
                                
                               if (message == null) _cancellationToken.ThrowIfCancellationRequested();
                               var response = _messageServices.ProcessMessage(message);
                               var report = Encoding.ASCII.GetBytes(response);
                               await  stream.WriteAsync(report, 0, report.Length, _cancellationToken).ConfigureAwait(false);
                            }, _cancellationToken
                            );
                       }                                             
                    }
                }
            }
            finally
            {
                OnException?.Invoke(this, EventArgs.Empty);
                _client?.Close();
            }
        }

        public void Stop() => _tokenSource?.Cancel();

        public void Dispose() => Stop();

        private void SetToken(CancellationToken? token = null)
        {
            _tokenSource = CancellationTokenSource.CreateLinkedTokenSource(token ?? new CancellationToken());
            _cancellationToken = _tokenSource.Token;
        }
    }
}
