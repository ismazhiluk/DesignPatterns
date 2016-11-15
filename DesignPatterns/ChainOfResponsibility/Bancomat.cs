using System;
using ChainOfResponsibility.Handlers;

namespace ChainOfResponsibility
{
    public class Bancomat
    {
        private readonly BanknoteHandler _handler;

        public Bancomat()
        {
            _handler = new HundredDollarHandler(null);
            _handler = new FiftyDollarHandler(_handler);
            _handler = new TenDollarHandler(_handler);
            _handler = new TenRubleHandler(_handler);
        }

        public bool Validate(Banknote banknote)
        {
            return _handler.Validate(banknote);
        }

        public Banknote[] GetCash(CurrencyType currency, int amountOfMoney)
        {
            var result = _handler.GetCash(currency, amountOfMoney);
            if (result.Sum() != amountOfMoney)
            {
                throw new Exception($"Банкомат не может выдать {amountOfMoney} в валюте {currency}");
            }
            return result;
        }
    }
}
