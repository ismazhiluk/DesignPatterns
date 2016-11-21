using System;

namespace State
{
    public partial class CopyMachine
    {
        private class AskTheQuestionState : CancelState
        {
            public override void AskTheQuestion(CopyMachine copyMachine)
            {
                ConsolePrintHelper.WriteLineLabel("Хотите распечатать еще документ?");
                ConsolePrintHelper.WriteLabel("1 : ");
                ConsolePrintHelper.WriteLineValue("Да");
                ConsolePrintHelper.WriteLabel("2 : ");
                ConsolePrintHelper.WriteLineValue("Нет");

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
