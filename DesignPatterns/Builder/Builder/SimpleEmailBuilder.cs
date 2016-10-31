using System.Collections.Generic;

namespace Builder.Builder
{
    public class SimpleEmailBuilder : IEmailBuilder
    {
        private readonly List<string> _receivers = new List<string>();
        private readonly string _body;

        private string _subject = "";

        public SimpleEmailBuilder(string receiver, string body)
        {
            _body = body;
            AddReceiver(receiver);
        }

        public IEmailBuilder AddReceiver(string receiver)
        {
            _receivers.Add(receiver);
            return this;
        }

        public IEmailBuilder SetSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public IEmail CreateEmail()
        {
            return new Email
            {
                Body = _body,
                Receivers = _receivers,
                Subject = _subject
            };
        }

        private class Email : IEmail
        {
            public string Body { get; set; }
            public IEnumerable<string> Receivers { get; set; }
            public string Subject { get; set; }
        }
    }
}
