using SimpleServer.Net;


namespace SimpleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandFactory = new CommandManager();
            var messageAnalyzer = new MessageAnalyzer(commandFactory);
            var messageServiceFactory = new MessageServiceFactory(messageAnalyzer);
            var server = new Server(1023, messageServiceFactory);
        }
    }
}
