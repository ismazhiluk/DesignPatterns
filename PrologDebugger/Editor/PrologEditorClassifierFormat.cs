//------------------------------------------------------------------------------
// <copyright file="PrologEditorClassifierFormat.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace PrologDebugger.Editor
{
    /// <summary>
    /// Defines an editor format for the PrologEditorClassifier type that has a purple background
    /// and is underlined.
    /// </summary>
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "PrologEditorClassifier")]
    [Name("PrologEditorClassifier")]
    [UserVisible(true)] // This should be visible to the end user
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
    internal sealed class PrologEditorClassifierFormat : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrologEditorClassifierFormat"/> class.
        /// </summary>
        public PrologEditorClassifierFormat()
        {
            this.DisplayName = "PrologEditorClassifier"; // Human readable version of the name
            this.BackgroundColor = Colors.BlueViolet;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = PrologTokens.PrologTokenNames.Comment)]
        [Name("CommentFormat")]
        [UserVisible(false)]
        [Order(Before = Priority.Default)]
        internal sealed class CommentFormat : ClassificationFormatDefinition
        {
            public CommentFormat()
            {
                this.DisplayName = "This is a comment";
                this.ForegroundColor = Colors.Green;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = PrologTokens.PrologTokenNames.RuleName)]
        [Name("RuleNameFormat")]
        [UserVisible(false)]
        [Order(Before = Priority.Default)]
        internal sealed class RuleNameFormat : ClassificationFormatDefinition
        {
            public RuleNameFormat()
            {
                this.DisplayName = "This is a rule name";
                this.ForegroundColor = Colors.Brown;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = PrologTokens.PrologTokenNames.Clause)]
        [Name("ClauseFormat")]
        [UserVisible(false)]
        [Order(Before = Priority.Default)]
        internal sealed class ClauseFormat : ClassificationFormatDefinition
        {
            public ClauseFormat()
            {
                this.DisplayName = "This is a clause";
                this.ForegroundColor = Colors.OrangeRed;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = PrologTokens.PrologTokenNames.Keyword)]
        [Name("KeyWordFormat")]
        [UserVisible(false)]
        [Order(Before = Priority.Default)]
        internal sealed class KeyWordFormat : ClassificationFormatDefinition
        {
            public KeyWordFormat()
            {
                this.DisplayName = "This is a keyword";
                this.ForegroundColor = Colors.Blue;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = PrologTokens.PrologTokenNames.Text)]
        [Name("TextFormat")]
        [UserVisible(false)]
        [Order(Before = Priority.Default)]
        internal sealed class TextFormat : ClassificationFormatDefinition
        {
            public TextFormat()
            {
                this.DisplayName = "This is a text";
                this.ForegroundColor = Colors.Black;
            }
        }
    }
}
