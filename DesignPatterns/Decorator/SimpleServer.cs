using System;

namespace Decorator
{
    public class SimpleServer
    {
        private readonly IClient _writer;
        private readonly IClient _reader;

        public SimpleServer(IClient writer, IClient reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public void Start()
        {
            _writer.SendMessage += HandleMessage;
        }

        public void Stop()
        {
            _writer.SendMessage -= HandleMessage;
        }

        private void HandleMessage(object sender, MessageEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{nameof(SimpleServer)} log");
            Console.WriteLine(e.Message.ToString());
            Console.WriteLine();
            _reader.ReceiveMessage(e.Message);
        }
    }
}
