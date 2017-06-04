using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace PrologDebugger.Editor
{
    internal static class PrologEditorClassifierClassificationDefinition
    {
#pragma warning disable 169

        /// <summary>
        /// Defines the "PrologEditorClassifier" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("PrologEditorClassifier")]
        private static ClassificationTypeDefinition typeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(PrologTokens.PrologTokenNames.Comment)]
        internal static ClassificationTypeDefinition comment = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(PrologTokens.PrologTokenNames.RuleName)]
        internal static ClassificationTypeDefinition ruleName = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(PrologTokens.PrologTokenNames.Clause)]
        internal static ClassificationTypeDefinition clause = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(PrologTokens.PrologTokenNames.Keyword)]
        internal static ClassificationTypeDefinition keyword = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(PrologTokens.PrologTokenNames.Text)]
        internal static ClassificationTypeDefinition text = null;

#pragma warning restore 169
    }
}
