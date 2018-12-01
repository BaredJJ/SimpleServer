using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class EmptyResponse : IResponse
    {
        private const string ServerName = "\n\rBaredJJ server\n\r";

        public string Response() => ServerName;
    }
}
