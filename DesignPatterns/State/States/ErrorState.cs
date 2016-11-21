using System;

namespace State
{
    public partial class CopyMachine
    {
        public class ErrorState : CancelState
        {
            public override void PrintError(CopyMachine copyMachine)
            {
                Console.WriteLine($"Произошла ошибка: \"{copyMachine.Error}\"");
                copyMachine.State = new ReturnDeliveryState();
                copyMachine.State.ReturnDelivery(copyMachine);
            }
        }
    }
}
