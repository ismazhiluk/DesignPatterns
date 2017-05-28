using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.Project;

namespace PrologDebugger.ProjectTemplate
{
    public class PrologProjectNode : ProjectNode
    {
        private static readonly ImageList ImageList;

        static PrologProjectNode()
        {
            ImageList = Utilities.GetImageList(typeof(PrologProjectNode).Assembly.GetManifestResourceStream("PrologDebugger.Resources.PrologProjectNode.png"));
        }

        public PrologProjectNode()
        {
            imageIndex = ImageHandler.ImageList.Images.Count;

            foreach (Image img in ImageList.Images)
            {
                ImageHandler.AddImage(img);
            }
        }
        public override Guid ProjectGuid
        {
            get { return PackageGuids.GuidFactory; }
        }
        public override string ProjectType
        {
            get { return "ProjectType"; }
        }

        public override void AddFileFromTemplate(
            string source, string target)
        {
            string nameSpace = FileTemplateProcessor.GetFileNamespace(target, this);
            string className = Path.GetFileNameWithoutExtension(target);

            FileTemplateProcessor.AddReplace("$nameSpace$", nameSpace);
            FileTemplateProcessor.AddReplace("$className$", className);

            FileTemplateProcessor.UntokenFile(source, target);
            FileTemplateProcessor.Reset();
        }

        internal static int imageIndex;
        public override int ImageIndex
        {
            get { return imageIndex; }
        }
    }
}
