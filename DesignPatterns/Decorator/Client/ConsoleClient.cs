using System;

namespace Decorator.Client
{
    public class ConsoleClient : IClient
    {
        private const ConsoleColor OwnColor = ConsoleColor.Yellow;
        private const ConsoleColor CompanionColor = ConsoleColor.Green;
        private readonly string _clientId = nameof(ConsoleClient);

        public MessageDto SendMessage()
        {
            Console.WriteLine("Введите получателя:");
            var destination = Console.ReadLine();
            Console.WriteLine("Введите сообщение:");
            var text = Console.ReadLine();

            //Console.ForegroundColor = OwnColor;
            //Console.WriteLine($"Вы отправили \"{destination}\" сообщение: \"{text}\"");
            //Console.ResetColor();
            return new MessageDto
            {
                Source = _clientId,
                Destination = destination,
                Text = text
            };
        }

        public void ReceiveMessage(MessageDto message)
        {
            Console.ForegroundColor = CompanionColor;
            Console.WriteLine($"Вы получили от \"{message.Source}\" сообщение: \"{message.Text}\"");
            Console.ResetColor();
        }
    }
}
