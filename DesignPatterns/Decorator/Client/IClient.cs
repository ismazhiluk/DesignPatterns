namespace Decorator.Client
{
    public interface IClient
    {
        MessageDto SendMessage();
        void ReceiveMessage(MessageDto message);
    }
}