using System;
using System.Globalization;

namespace State
{
    public partial class CopyMachine
    {
        private class AddCashState : CancelState
        {
            public override void AddCash(CopyMachine copyMachine)
            {
                Console.WriteLine("Внесите сумму:");
                copyMachine.Cash = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                copyMachine.State = new ChooseDeviceState();
                copyMachine.State.ChooseDevice(copyMachine);
            }
        }
    }
}
