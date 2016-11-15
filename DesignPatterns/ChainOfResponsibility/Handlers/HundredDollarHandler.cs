namespace ChainOfResponsibility.Handlers
{
    public class HundredDollarHandler : BanknoteHandler
    {
        protected override Banknote Banknote => new Banknote { Currency = CurrencyType.Dollar, Value = 100 };

        public HundredDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
}
