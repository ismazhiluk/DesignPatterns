//------------------------------------------------------------------------------
// <copyright file="PrologEditorClassifier.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace PrologDebugger.Editor
{
    public class PrologEditorClassifier : IClassifier
    {
        private readonly IClassificationTypeRegistryService _registry;
        private readonly IClassificationType classificationType;

        internal PrologEditorClassifier(IClassificationTypeRegistryService registry)
        {
            _registry = registry;
            this.classificationType = registry.GetClassificationType("PrologEditorClassifier");
        }

#pragma warning disable 67


        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            return TokenParser.Parse(span, _registry);
        }
    }
}
