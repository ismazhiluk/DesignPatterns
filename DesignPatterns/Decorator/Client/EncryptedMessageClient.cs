using System;
using System.Text;

namespace Decorator.Client
{
    public class EncryptedMessageClient : IClient
    {
        private readonly IClient _client;

        public EncryptedMessageClient(IClient client)
        {
            _client = client;
        }

        public event EventHandler<MessageEventArgs> SendMessage;

        public void StartSending()
        {
            _client.SendMessage += (sender, args) =>
            {
                var newMessage = new Message
                {
                    Source = args.Message.Source,
                    Destination = args.Message.Destination,
                    Text = Crypt(args.Message.Text)
                };
                SendMessage?.Invoke(this, new MessageEventArgs { Message = newMessage });
            };
            _client.StartSending();
        }

        public void ReceiveMessage(Message message)
        {
            _client.ReceiveMessage(new Message
            {
                Source = message.Source,
                Destination = message.Destination,
                Text = Derypt(message.Text)
            });
        }

        private static string Crypt(string text)
        {
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(text));
        }

        private static string Derypt(string text)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(text));
        }
    }
}
