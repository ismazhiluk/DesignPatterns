using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using State.Device;

namespace State
{
    public class Program
    {
        public static AbstractDevice[] Devices = {new FlashDrive(), new WiFiDevice()};

        static void Main()
        {
            var copyMachine = new CopyMachine(3);
            copyMachine.Print();
        }
    }
}
