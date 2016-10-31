using System.Collections.Generic;

namespace Builder
{
    public interface IEmail
    {
        IEnumerable<string> Receivers { get; }
        string Body { get; }
        string Subject { get; }
    }
}