using System.Threading;
using System.Threading.Tasks;

namespace SimpleServer.Interfaces
{
    public interface IClient
    {
        Task StartAsync(CancellationToken? token = null);
    }
}
