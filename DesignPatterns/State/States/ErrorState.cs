using System;

namespace State.States
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
