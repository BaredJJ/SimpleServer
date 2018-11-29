namespace SimpleServer.Interfaces
{
    public interface ICommandManagerFactory
    {
        ICommandManager GetCommandManager(int id);
    }
}
