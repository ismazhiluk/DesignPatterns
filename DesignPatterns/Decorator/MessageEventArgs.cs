using System;

namespace Decorator
{
    public class MessageEventArgs : EventArgs
    {
        public Message Message { get; set; }
    }
}
