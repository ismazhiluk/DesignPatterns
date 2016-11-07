using System;
using System.Collections.Generic;
using System.Linq;

namespace Decorator.Client
{
    public class HideNameClient : IClient
    {
        private static readonly Dictionary<Guid, string> NamesCache = new Dictionary<Guid, string>();

        private readonly IClient _client;

        public HideNameClient(IClient client)
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
                    Source = GetCodeOfName(args.Message.Source),
                    Destination = GetCodeOfName(args.Message.Destination),
                    Text = args.Message.Text
                };
                SendMessage?.Invoke(this, new MessageEventArgs {Message = newMessage});
            };
            _client.StartSending();
        }

        public void ReceiveMessage(Message message)
        {
            _client.ReceiveMessage(new Message
            {
                Source = GetNameByCode(message.Source),
                Destination = GetNameByCode(message.Destination),
                Text = message.Text
            });
        }

        private string GetCodeOfName(string name)
        {
            if (NamesCache.ContainsValue(name))
            {
                return NamesCache.FirstOrDefault(x => x.Value == name).Key.ToString();
            }
            var newGuid = Guid.NewGuid();
            NamesCache.Add(newGuid, name);
            return newGuid.ToString();
        }

        private string GetNameByCode(string code)
        {
            return NamesCache[Guid.Parse(code)];
        }
    }
}
