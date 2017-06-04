using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace PrologDebugger.Executor
{
    [Guid("141fc729-b96a-463f-83ac-a8debdb4818a")]
    public class ToolWindow : ToolWindowPane
    {
        public ToolWindow() : base(null)
        {
            Caption = "Prolog executor";
            Content = new ToolWindowControl();
        }
    }
}
