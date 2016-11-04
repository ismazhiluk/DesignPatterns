using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Client;

namespace Decorator
{
    public class EchoMessenger
    {
        private readonly IClient _client;

        public EchoMessenger(IClient client)
        {
            _client = client;
        }

        public void Start()
        {
            while (true)
            {
                var messageDto = _client.SendMessage();

                _client.ReceiveMessage(new MessageDto
                {
                    Source = nameof(EchoMessenger),
                    Destination = messageDto.Source,
                    Text = messageDto.Text
                });
            }
        }
    }
}
