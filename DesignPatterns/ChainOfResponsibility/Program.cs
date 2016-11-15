using System;
using System.Linq;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                ExecuteExample();
            }
        }

        private static void ExecuteExample()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            PrintDebug();
            var bancomat = new Bancomat();
            PrintDebug();
            Console.ResetColor();

            try
            {
                Console.WriteLine("Введите валюту целым положительным числом:");

                var currencies = Enum.GetNames(typeof(CurrencyType));
                for (int i = 0; i < currencies.Length; i++)
                {
                    Console.WriteLine($"{i} - {currencies[i]}");
                }

                var currencyInt = int.Parse(Console.ReadLine());
                if (currencyInt < 0 || currencyInt >= currencies.Length)
                {
                    throw new Exception("Валюта введена неправильно.");
                }

                Console.WriteLine("Введите сумму целыи неотрицательным числом:");

                var amountOfMoney = int.Parse(Console.ReadLine());
                var banknotes = bancomat.GetCash((CurrencyType)currencyInt, amountOfMoney);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Join("; ", banknotes.Select(b => b.ToString())));
                Console.ResetColor();
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message);
                Console.ResetColor();
            }
        }

        private static void PrintDebug()
        {
            const string debug = "====================DEBUG====================";
            Console.WriteLine(debug);
        }
    }
}
