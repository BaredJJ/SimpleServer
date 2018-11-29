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
            var commandManager = new CommandManager();
            var messageAnalyzer = new MessageAnalyzer(commandManager);
            var messageServicesFactory = new MessageServiceFactory(messageAnalyzer);
            _clientManager = new ClientManager(messageServicesFactory);
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
