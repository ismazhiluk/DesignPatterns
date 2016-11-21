namespace State
{
    public static class StringHelper
    {
        public static string ReplaceLast(this string str, string lastChar)
        {
            return str.Remove(str.Length - 1, 1) + lastChar;
        }
    }
}
