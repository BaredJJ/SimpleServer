using System.Collections.Generic;

namespace SimpleServer.Interfaces
{
    public interface ICommandManager
    {
        IMessageCommand GetCommand(IEnumerable<string> command);
    }
}
