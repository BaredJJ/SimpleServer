using System.Collections.Generic;
using SimpleServer.MessageCommand;

namespace SimpleServer.Interfaces
{
    public interface ICommandFactory
    {
        IResponse GetResponseObject(Dictionary<Commands, Switch> states, int id);
    }
}
