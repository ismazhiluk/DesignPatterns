using System;

namespace State
{
    public partial class CopyMachine
    {
        private class AskTheQuestionState : CancelState
        {
            public override void AskTheQuestion(CopyMachine copyMachine)
            {
                Console.WriteLine("Хотите распечатать еще документ?");
                Console.WriteLine("1 : Да");
                Console.WriteLine("2 : Нет");
                var result = int.Parse(Console.ReadLine());
                if (result == 1)
                {
                    copyMachine.State = new ChooseDocumentState();
                    copyMachine.State.ChooseDocument(copyMachine);
                    return;
                }
                copyMachine.State = new ReturnDeliveryState();
                copyMachine.State.ReturnDelivery(copyMachine);
            }
        }
    }
}
