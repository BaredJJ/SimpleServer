namespace SimpleServer.Interfaces
{
    public interface ILoggerFactory
    {
        ILog GetLog(int id);
    }
}
