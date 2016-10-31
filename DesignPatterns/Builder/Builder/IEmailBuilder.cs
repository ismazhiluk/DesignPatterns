namespace Builder.Builder
{
    public interface IEmailBuilder
    {
        IEmailBuilder AddReceiver(string receiver);
        IEmailBuilder SetSubject(string subject);
        IEmail CreateEmail();
    }
}
