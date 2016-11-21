using System;
using System.Linq;

namespace State
{
    public partial class CopyMachine
    {
        private class ChooseDeviceState : CancelState
        {
            public override void ChooseDevice(CopyMachine copyMachine)
            {
                ConsolePrintHelper.WriteLineLabel("Выберите устройство:");
                foreach (var device in Program.Devices)
                {
                    ConsolePrintHelper.WriteLabel($"{nameof(device.Id)} : ");
                    ConsolePrintHelper.WriteValue(device.Id.ToString());
                    ConsolePrintHelper.WriteLabel("; ");
                    ConsolePrintHelper.WriteLabel($"{nameof(device.Name)} : ");
                    ConsolePrintHelper.WriteLineValue(device.Name);
                }
                var deviceId = int.Parse(Console.ReadLine());
                copyMachine.Device = Program.Devices.First(i => i.Id == deviceId);
                copyMachine.State = new ChooseDocumentState();
                copyMachine.State.ChooseDocument(copyMachine);
            }
        }
    }
}
