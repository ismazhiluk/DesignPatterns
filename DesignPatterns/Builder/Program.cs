using Builder.Builder;
using Builder.Sender;

namespace Builder
{
    class Program
    {
        static void Main()
        {
            const string body = "Привет! Высылаю следующее домашнее задание (Смажилюк Игорь).";

            IEmailBuilder emailBuilder = new StateEmailBuilder()
                                            .AddReceiverAndBody("Design@Patterns.ru", body)
                                            .AddReceiver("Copy@Patterns.ru")
                                            .SetSubject("Домашнее задание №3 (Builder)");

            IEmail email = emailBuilder.CreateEmail();

            IEmailSender emailSender = new ConsoleEmailSender();
            emailSender.Send(email);
        }
    }
}
