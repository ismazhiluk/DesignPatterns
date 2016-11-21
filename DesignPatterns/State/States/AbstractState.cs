using System;

namespace State
{
    public partial class CopyMachine
    {
        private abstract class AbstractState
        {
            public virtual void AddCash(CopyMachine copyMachine)
            {
                ThrowException();
            }

            public virtual void ChooseDevice(CopyMachine copyMachine)
            {
                ThrowException();
            }

            public virtual void ChooseDocument(CopyMachine copyMachine)
            {
                ThrowException();
            }

            public virtual void PrintDocument(CopyMachine copyMachine)
            {
                ThrowException();
            }

            public virtual void AskTheQuestion(CopyMachine copyMachine)
            {
                ThrowException();
            }

            public virtual void ReturnDelivery(CopyMachine copyMachine)
            {
                ThrowException();
            }

            public virtual void SayGoodbye(CopyMachine copyMachine)
            {
                ThrowException();
            }

            public virtual void Cancel(CopyMachine copyMachine)
            {
                ThrowException();
            }

            public virtual void PrintError(CopyMachine copyMachine)
            {
                ThrowException();
            }

            private void ThrowException()
            {
                throw new Exception("Ошибка при выполнении операции");
            }
        }
    }
}
