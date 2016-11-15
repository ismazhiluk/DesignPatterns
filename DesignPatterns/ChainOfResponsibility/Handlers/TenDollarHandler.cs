namespace ChainOfResponsibility.Handlers
{
    public class TenDollarHandler : BanknoteHandler
    {
        protected override Banknote Banknote => new Banknote { Currency = CurrencyType.Dollar, Value = 10 };

        public TenDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
}
