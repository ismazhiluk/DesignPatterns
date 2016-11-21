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
                ConsolePrintHelper.WriteLineLabel("Добро пожаловать!");
                ConsolePrintHelper.WriteLabel("Цена одной страницы : ");
                ConsolePrintHelper.WriteLineValue(copyMachine.CostOfPage.ToString());
                ConsolePrintHelper.WriteLineLabel("Внесите сумму:");
                copyMachine.Cash = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                copyMachine.State = new ChooseDeviceState();
                copyMachine.State.ChooseDevice(copyMachine);
            }
        }
    }
}
