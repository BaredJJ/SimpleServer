using System.Net.Sockets;

namespace SimpleServer.Interfaces
{
    public interface IClientManager
    {
        void Add(TcpClient client);
    }
}
