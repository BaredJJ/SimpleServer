using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class EmptyResponse : IResponse
    {
        private const string _serverName = "BaredJJ server";

        public string Response() => _serverName + '\n';
    }
}
