using System;

namespace State
{
    public static class ShowValueHelper
    {
        public static void ShowValue(object value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\"{value}\"");
            Console.ResetColor();
        }

        public static void ShowLabel(string label)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\"{label}\"");
            Console.ResetColor();
        }
    }
}
