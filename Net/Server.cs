using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleServer.Net
{
    public class Server:IDisposable
    {
        private readonly TcpListener _listener;
        private CancellationTokenSource _tokenSource;
        private CancellationToken _cancellationToken;

        public event EventHandler OnNewConnected;

        public Server(int port)
        {
            if(port < 1) throw new ArgumentException("Invalid port value");

            _listener = new TcpListener(IPAddress.Any, port);
        }

        public bool IsListening { get; private set; }

        public async Task StartAsync(CancellationToken? token = null)
        {
            if(IsListening) return;

            SetToken(token);
            _listener.Start();
            IsListening = true;

            try
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    await Task.Run(async () =>
                    {
                        var tcpClient = await _listener.AcceptSocketAsync();
                        OnNewConnected?.Invoke(tcpClient, EventArgs.Empty);
                    }, _cancellationToken);
                }
            }
            finally
            {
                _listener.Stop();
                IsListening = false;
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
