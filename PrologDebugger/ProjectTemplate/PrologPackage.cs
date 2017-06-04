using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using PrologDebugger.Executor;

namespace PrologDebugger.ProjectTemplate
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0")]
    [ProvideProjectFactory(typeof(PrologProjectFactory), "Prolog",
    "Prolog Project Files (*.plproj);*.plproj", "plproj", "plproj",
    @"ProjectTemplate\Template", LanguageVsTemplate = "PrologProject")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ToolWindow))]
    [Guid(PackageGuids.GuidPkgString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class PrologPackage : Package
    {
        protected override void Initialize()
        {
            base.Initialize();
            RegisterProjectFactory(new PrologProjectFactory(this));
            ToolWindowCommand.Initialize(this);
        }
    }
}
