using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace PrologDebugger.Editor
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("Prolog")]
    internal class PrologEditorClassifierProvider : IClassifierProvider
    {
        [Export]
        [Name("Prolog")]
        [BaseDefinition("code")]
        internal static ContentTypeDefinition PrologContentType = null;

        [Export]
        [FileExtension(".pl")]
        [ContentType("Prolog")]
        internal static FileExtensionToContentTypeDefinition PrologPlFileType = null;

#pragma warning disable 649
        [Import]
        private IClassificationTypeRegistryService classificationRegistry;

#pragma warning restore 649

        #region IClassifierProvider

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty<PrologEditorClassifier>(creator: () => new PrologEditorClassifier(this.classificationRegistry));
        }

        #endregion
    }
}
