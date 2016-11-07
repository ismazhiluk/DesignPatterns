using System;

namespace Decorator
{
    class Program
    {
        static void Main()
        {
            IClient writerClient = new ConsoleClient(nameof(writerClient), ConsoleColor.Yellow);
            IClient readerClient = new ConsoleClient(nameof(readerClient), ConsoleColor.Green);
            var echoServer = new SimpleServer(writerClient, readerClient);
            echoServer.Start();
            writerClient.StartSending();
        }
    }
}
