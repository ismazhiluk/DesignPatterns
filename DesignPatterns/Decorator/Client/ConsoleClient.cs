using System;

namespace Decorator.Client
{
    public class ConsoleClient : IClient
    {
        private readonly string _name;
        private readonly ConsoleColor _color;

        public ConsoleClient(string name, ConsoleColor color)
        {
            _name = name;
            _color = color;
        }

        public event EventHandler<MessageEventArgs> SendMessage;

        public void StartSending()
        {
            while (true)
            {
                Console.ForegroundColor = _color;
                Console.WriteLine(_name);
                Console.WriteLine("Введите сообщение:");
                var text = Console.ReadLine();
                
                var message = new Message
                {
                    Source = "Отправитель",
                    Destination = "Получатель",
                    Text = text
                };

                Console.WriteLine($"\"{message.Source}\" send to \"{message.Destination}\" message \"{message.Text}\"");
                Console.WriteLine();
                Console.ResetColor();

                SendMessage?.Invoke(this, new MessageEventArgs { Message = message });
            }
        }

        public void ReceiveMessage(Message message)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(_name);
            Console.WriteLine($"\"{message.Destination}\" receive from \"{message.Source}\" message \"{message.Text}\"");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
