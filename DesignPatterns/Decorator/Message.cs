using System;

namespace Decorator
{
    public class Message
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{nameof(Source)} : \"{Source}\"{Environment.NewLine}{nameof(Destination)} : \"{Destination}\"{Environment.NewLine}{nameof(Text)} : \"{Text}\"";
        }
    }
}
