namespace ChainOfResponsibility.Handlers
{
    public class FiftyDollarHandler : BanknoteHandler
    {
        protected override Banknote Banknote => new Banknote { Currency = CurrencyType.Dollar, Value = 50 };

        public FiftyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
}
