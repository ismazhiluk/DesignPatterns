using System;
using System.Linq;

namespace State.States
{
    public class ChooseDeviceState : CancelState
    {
        public override void ChooseDevice(CopyMachine copyMachine)
        {
            Console.WriteLine("Выберите устройство:");
            foreach (var device in Program.Devices)
            {
                Console.WriteLine($"{device.Id} : {device.Name}");
            }
            var deviceId = int.Parse(Console.ReadLine());
            copyMachine.Device = Program.Devices.First(i => i.Id == deviceId);
            copyMachine.State = new ChooseDocumentState();
            copyMachine.State.ChooseDocument(copyMachine);
        }
    }
}
