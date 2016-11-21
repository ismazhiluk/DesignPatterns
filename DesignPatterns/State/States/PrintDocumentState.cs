using System;

namespace State.States
{
    public class PrintDocumentState : CancelState
    {
        public override void PrintDocument(CopyMachine copyMachine)
        {
            var cost = copyMachine.Document.AmountOfPages*copyMachine.CostOfPage;
            if (copyMachine.Cash - cost < 0)
            {
                copyMachine.Error = "Внесенных средств недостаточно";
                copyMachine.State = new ErrorState();
                copyMachine.State.PrintError(copyMachine);
                return;
            }
            copyMachine.Cash -= cost;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Печать документа: \"{copyMachine.Document.Name}\"");
            Console.ResetColor();
            copyMachine.State = new AskTheQuestionState();
            copyMachine.State.AskTheQuestion(copyMachine);
        }
    }
}
