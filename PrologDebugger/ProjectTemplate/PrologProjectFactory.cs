using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Project;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace PrologDebugger.ProjectTemplate
{
    [Guid(PackageGuids.GuidFactoryString)]
    public class PrologProjectFactory : ProjectFactory
    {
        private readonly PrologPackage _package;

        public PrologProjectFactory(PrologPackage package) : base(package)  
        {
            _package = package;
        }

        protected override ProjectNode CreateProject()
        {
            var project = new PrologProjectNode();

            project.SetSite((IOleServiceProvider)((IServiceProvider)_package).GetService(typeof(IOleServiceProvider)));
            return project;
        }
    }
}
