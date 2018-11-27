using System;

namespace SimpleServer.Interfaces
{
    public interface IMessageService
    {
        event EventHandler OnSendMessage;

        void ProcessMessage(string message);
    }
}
