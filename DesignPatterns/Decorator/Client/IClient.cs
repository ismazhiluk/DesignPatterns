using System;

namespace Decorator.Client
{
    public interface IClient
    {
        event EventHandler<MessageEventArgs> SendMessage;
        void StartSending();
        void ReceiveMessage(Message message);
    }
}