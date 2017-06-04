using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologDebugger.Editor
{
    class PrologTokens
    {
        public enum PrologTokenTypes
        {
            Comment,
            RuleName,
            Clause,
            Keyword,
            Text
        }

        public sealed class PrologTokenNames
        {
            public const string Comment = nameof(PrologTokenTypes.Comment);
            public const string RuleName = nameof(PrologTokenTypes.RuleName);
            public const string Clause = nameof(PrologTokenTypes.Clause);
            public const string Keyword = nameof(PrologTokenTypes.Keyword);
            public const string Text = nameof(PrologTokenTypes.Text);
        }
    }
}
