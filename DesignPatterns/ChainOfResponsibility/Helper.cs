using System.Linq;

namespace ChainOfResponsibility
{
    public static class Helper
    {
        public static int Sum(this Banknote[] banknotes)
        {
            if (banknotes == null || !banknotes.Any()) return 0;
            return banknotes.Aggregate(0, (s, i) => s + i.Value);
        }
    }
}
