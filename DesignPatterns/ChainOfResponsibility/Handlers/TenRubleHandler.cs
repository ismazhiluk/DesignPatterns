namespace ChainOfResponsibility.Handlers
{
    public class TenRubleHandler : BanknoteHandler
    {
        protected override Banknote Banknote => new Banknote { Currency = CurrencyType.Ruble, Value = 10 };

        public TenRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
}