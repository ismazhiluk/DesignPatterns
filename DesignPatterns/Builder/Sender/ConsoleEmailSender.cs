using System;

namespace Builder.Sender
{
    public class ConsoleEmailSender : IEmailSender
    {
        private const ConsoleColor LabelColor = ConsoleColor.DarkGray;

        public void Send(IEmail email)
        {
            PrintLine(nameof(email.Subject), email.Subject, ConsoleColor.Red);
            PrintLine(nameof(email.Receivers), string.Join(", ", email.Receivers), ConsoleColor.Green);
            PrintLine(nameof(email.Body), email.Body, ConsoleColor.Yellow);

            Console.ResetColor();
        }


        private static void PrintLine(string label, string data, ConsoleColor color)
        {
            PrintLabel(label);
            Console.ForegroundColor = color;
            Console.WriteLine(data);
        }

        private static void PrintLabel(string label)
        {
            Console.ForegroundColor = LabelColor;
            Console.Write($"{label} : ");
            Console.ResetColor();
        }
    }
}
