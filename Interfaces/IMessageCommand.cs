namespace SimpleServer.Interfaces
{
    public interface IMessageCommand
    {
        string Name { get; }

        string Execute(IMessageCommand command);
    }
}
