using System;

namespace PrologDebugger.ProjectTemplate
{
    public static class PackageGuids
    {
        public const string GuidPkgString = "96bf4c26-d94e-43bf-a56a-f8500b52bfad";
        public const string GuidCmdSetString = "72c23e1d-f389-410a-b5f1-c938303f1391";
        public const string GuidFactoryString = "471EC4BB-E47E-4229-A789-D1F5F83B52D4";

        public static readonly Guid GuidCmdSet = new Guid(GuidCmdSetString);
        public static readonly Guid GuidFactory = new Guid(GuidFactoryString);
    }
}
