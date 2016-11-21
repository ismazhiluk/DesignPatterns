using System;

namespace State
{
    public partial class CopyMachine
    {
        private class GoodbyeState : CancelState
        {
            public override void SayGoodbye(CopyMachine copyMachine)
            {
                copyMachine.State = null;
                Console.WriteLine("До свидания!");
            }
        }
    }
}
