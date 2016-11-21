namespace State
{
    public partial class CopyMachine
    {
        private class ErrorState : CancelState
        {
            public override void PrintError(CopyMachine copyMachine)
            {
                ConsolePrintHelper.WriteLabel("Произошла ошибка: ");
                ConsolePrintHelper.WriteLineValue(copyMachine.Error);

                copyMachine.State = new ReturnDeliveryState();
                copyMachine.State.ReturnDelivery(copyMachine);
            }
        }
    }
}
