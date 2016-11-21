using System;
using System.Linq;

namespace State
{
    public partial class CopyMachine
    {
        private class ChooseDocumentState : CancelState
        {
            public override void ChooseDocument(CopyMachine copyMachine)
            {
                ConsolePrintHelper.WriteLineLabel("Выберите документ:");
                foreach (var document in copyMachine.Device.Documents)
                {
                    ConsolePrintHelper.WriteLabel($"{nameof(document.Id)} : ");
                    ConsolePrintHelper.WriteValue(document.Id.ToString());
                    ConsolePrintHelper.WriteLabel("; ");
                    ConsolePrintHelper.WriteLabel($"{nameof(document.Name)} : ");
                    ConsolePrintHelper.WriteLineValue(document.Name);
                }
                var documentId = int.Parse(Console.ReadLine());
                copyMachine.Document = copyMachine.Device.Documents.First(i => i.Id == documentId);
                copyMachine.State = new PrintDocumentState();
                copyMachine.State.PrintDocument(copyMachine);
            }
        }
    }
}
