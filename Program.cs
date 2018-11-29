using System.Net.Sockets;
using SimpleServer.Interfaces;
using SimpleServer.MessageCommand;
using SimpleServer.Net;


namespace SimpleServer
{
    class Program
    {
        private ClientManager _clientManager;

        static void Main(string[] args)
        {
            var program = new Program();
            program.Init();
        }

        public void Init()
        {
            var messageAnalyzer = new MessageAnalyzer();
            var loggerFactory = new LoggerFactory();
            var commandFactory = new CommandFactory(loggerFactory);
            var commandManagerFactory = new CommandManagerFactory(commandFactory);
            var messageServiceFactory = new MessageServiceFactory(messageAnalyzer, commandManagerFactory);
            _clientManager = new ClientManager(messageServiceFactory);
            var server = new Server(1023);
            server.OnNewConnected += OnNewConnected;
        }

        private void OnNewConnected(object sender, System.EventArgs e)
        {
            if (!(sender is TcpClient client)) return;
            _clientManager.Add(client);
        }
    }
}
