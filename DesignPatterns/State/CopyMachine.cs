using State.Device;
using State.States;

namespace State
{
    public class CopyMachine : ICopyMachine
    {
        public AbstractState State { get; set; }
        public double Cash { get; set; }
        public AbstractDevice Device { get; set; }
        public Document Document { get; set; }
        public string Error { get; set; }

        public double CostOfPage { get; private set; }

        public CopyMachine(double costOfPage)
        {
            CostOfPage = costOfPage;
            State = new AddCashState();
        }

        public void Print()
        {
            State.AddCash(this);
        }

        public void Cancel()
        {
            State.Cancel(this);
        }
    }
}
