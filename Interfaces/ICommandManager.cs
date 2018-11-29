using SimpleServer.MessageCommand;

namespace SimpleServer.Interfaces
{
    public interface ICommandManager
    {
        string GetResponse(AcceptCommandDto command);
    }
}
