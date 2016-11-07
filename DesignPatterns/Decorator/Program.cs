using System;
using Decorator.Client;

namespace Decorator
{
    class Program
    {
        static void Main()
        {
            var writerClient = new ClientBuilder(new ConsoleClient("writerClient", ConsoleColor.Yellow))
                                        .WithHideName()
                                        .WithEncryptedMessage()
                                        .Build();

            var readerClient = new ClientBuilder(new ConsoleClient("readerClient", ConsoleColor.Green))
                                        .WithHideName()
                                        .WithEncryptedMessage()
                                        .Build();

            var server = new SimpleServer(writerClient, readerClient);
            server.Start();
            writerClient.StartSending();
        }
    }
}
