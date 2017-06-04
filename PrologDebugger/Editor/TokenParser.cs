using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace PrologDebugger.Editor
{
    public class TokenParser
    {
        public static IList<ClassificationSpan> Parse(SnapshotSpan span, IClassificationTypeRegistryService registry)
        {
            var snapshot = span.Snapshot;
            var result = new List<ClassificationSpan>();
            ITextSnapshotLine containingLine = span.Start.GetContainingLine();
            int curLoc = containingLine.Start.Position;
            string formattedLine = containingLine.GetText();

            var commentStartIndex = formattedLine.IndexOf("%");

            var code = GetSubstring(formattedLine, commentStartIndex);
            result.AddRange(ParseCode(snapshot, registry, code, curLoc));

            if (commentStartIndex >= 0)
            {
                var comment = formattedLine.Substring(commentStartIndex);
                result.Add(GetSpan(snapshot, registry, curLoc + commentStartIndex, comment.Length,
                    PrologTokens.PrologTokenNames.Comment));
            }

            return result;
        }

        private static IList<ClassificationSpan> ParseCode(
            ITextSnapshot snapshot,
            IClassificationTypeRegistryService registry,
            string code,
            int pointer)
        {
            var result = new List<ClassificationSpan>();
            var clauseIndex = code.IndexOf(":-");
            var head = GetSubstring(code, clauseIndex);

            var nameIndex = head.IndexOf("(");
            result.Add(GetSpan(snapshot, registry, pointer, nameIndex == -1 ? head.Length : nameIndex,PrologTokens.PrologTokenNames.RuleName));

            if (nameIndex != -1)
            {
                result.Add(GetSpan(snapshot, registry, pointer + nameIndex, head.Length - nameIndex, PrologTokens.PrologTokenNames.Text));
            }

            if (clauseIndex != -1)
            {
                result.Add(GetSpan(snapshot, registry, pointer + clauseIndex, 2, PrologTokens.PrologTokenNames.Clause));
                var body = code.Substring(clauseIndex + 2);
                var reg = new Regex(" is ");
                foreach (Match match in reg.Matches(body))
                {
                    result.Add(GetSpan(snapshot, registry, pointer + clauseIndex + 2 + match.Index + 1, 2, PrologTokens.PrologTokenNames.Keyword));
                }
            }
            return result;
        }

        private static ClassificationSpan GetSpan(
            ITextSnapshot snapshot,
            IClassificationTypeRegistryService registry,
            int position,
            int length,
            string type)
        {
            return new ClassificationSpan(
                new SnapshotSpan(new SnapshotPoint(snapshot, position), length),
                registry.GetClassificationType(type));
        }

        private static string GetSubstring(string str, int length)
        {
            return str.Substring(0, length == -1 ? str.Length : length);
        }
    }
}
