using System;

namespace State.States
{
    public class GoodbyeState : CancelState
    {
        public override void SayGoodbye(CopyMachine copyMachine)
        {
            copyMachine.State = null;
            Console.WriteLine("До свидания!");
        }
    }
}
