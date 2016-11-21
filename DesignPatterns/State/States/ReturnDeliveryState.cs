using System;

namespace State.States
{
    public class ReturnDeliveryState : CancelState
    {
        public override void ReturnDelivery(CopyMachine copyMachine)
        {
            if (copyMachine.Cash > 0)
            {
                Console.WriteLine($"Возьмите сдачу: \"{copyMachine.Cash}\"");
                copyMachine.Cash = 0;
            }
            copyMachine.State = new GoodbyeState();
            copyMachine.State.SayGoodbye(copyMachine);
        }
    }
}
