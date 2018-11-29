using SimpleServer.MessageCommand;

namespace SimpleServer.Interfaces
{
    public interface IMessageAnalyzer
    {
        AcceptCommandDto AnalyzeMessage(string message);
    }
}
