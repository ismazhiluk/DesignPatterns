using System;

namespace State
{
    public static class ConsolePrintHelper
    {
        public static void WriteValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\"{value}\"");
            Console.ResetColor();
        }

        public static void WriteLineValue(string value)
        {
            WriteValue(value);
            Console.WriteLine();
        }

        public static void WriteLabel(string label)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{label}");
            Console.ResetColor();
        }

        public static void WriteLineLabel(string label)
        {
            WriteLabel(label);
            Console.WriteLine();
        }
    }
}
