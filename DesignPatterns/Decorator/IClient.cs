using System;

namespace Decorator
{
    public interface IClient
    {
        void StartSending();
        event EventHandler<MessageEventArgs> SendMessage;
        void ReceiveMessage(Message message);
    }
}