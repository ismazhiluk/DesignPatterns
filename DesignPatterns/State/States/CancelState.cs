namespace State
{
    public partial class CopyMachine
    {
        private abstract class CancelState : AbstractState
        {
            public override void Cancel(CopyMachine copyMachine)
            {
                copyMachine.State = new ReturnDeliveryState();
                copyMachine.State.ReturnDelivery(copyMachine);
            }
        }
    }
}
