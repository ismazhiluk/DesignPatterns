namespace ChainOfResponsibility
{
    public class Banknote
    {
        public CurrencyType Currency { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Value}, {Currency}";
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}