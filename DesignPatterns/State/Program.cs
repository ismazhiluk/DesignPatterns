using System;
using System.Threading;
using State.Device;

namespace State
{
    public class Program
    {
        public static AbstractDevice[] Devices = { new FlashDrive(), new WiFiDevice() };

        private static readonly ICopyMachine CopyMachine = new CopyMachine(3);

        static void Main()
        {
            new Thread(ListenCancel) { IsBackground = true }.Start();
            CopyMachine.Print();
        }

        private static void ListenCancel()
        {
            do
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    CopyMachine.Cancel();
                    Environment.Exit(0);
                }
            } while (true);
        }
    }
}
