namespace SimpleServer.Interfaces
{
    public interface IMessageAnalyzer
    {
        IMessageCommand AnalyzeMessage(string message);
    }
}
