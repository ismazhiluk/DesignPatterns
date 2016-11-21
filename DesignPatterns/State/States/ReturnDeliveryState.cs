namespace State
{
    public partial class CopyMachine
    {
        private class ReturnDeliveryState : CancelState
        {
            public override void ReturnDelivery(CopyMachine copyMachine)
            {
                if (copyMachine.Cash > 0)
                {
                    ConsolePrintHelper.WriteLabel("Возьмите сдачу: ");
                    ConsolePrintHelper.WriteLineValue(copyMachine.Cash.ToString());
                    copyMachine.Cash = 0;
                }
                copyMachine.State = new GoodbyeState();
                copyMachine.State.SayGoodbye(copyMachine);
            }
        }
    }
}
