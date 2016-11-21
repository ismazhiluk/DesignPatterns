using System;

namespace State
{
    public partial class CopyMachine
    {
        private abstract class AbstractState
        {
            public virtual void AddCash(CopyMachine copyMachine)
            {
                throw new NotImplementedException();
            }

            public virtual void ChooseDevice(CopyMachine copyMachine)
            {
                throw new NotImplementedException();
            }

            public virtual void ChooseDocument(CopyMachine copyMachine)
            {
                throw new NotImplementedException();
            }

            public virtual void PrintDocument(CopyMachine copyMachine)
            {
                throw new NotImplementedException();
            }

            public virtual void AskTheQuestion(CopyMachine copyMachine)
            {
                throw new NotImplementedException();
            }

            public virtual void ReturnDelivery(CopyMachine copyMachine)
            {
                throw new NotImplementedException();
            }

            public virtual void SayGoodbye(CopyMachine copyMachine)
            {
                throw new NotImplementedException();
            }

            public virtual void Cancel(CopyMachine copyMachine)
            {
                throw new NotImplementedException();
            }

            public virtual void PrintError(CopyMachine copyMachine)
            {
                throw new NotImplementedException();
            }
        }

    }
}
