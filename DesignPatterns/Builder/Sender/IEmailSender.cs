namespace Builder.Sender
{
    public interface IEmailSender
    {
        void Send(IEmail email);
    }
}
