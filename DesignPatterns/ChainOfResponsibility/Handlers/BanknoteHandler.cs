using System;
using System.Collections.Generic;
using System.Threading;

namespace ChainOfResponsibility.Handlers
{
    public abstract class BanknoteHandler
    {
        protected abstract Banknote Banknote { get; }
        protected int AmountOfBanknote { get; set; }

        private readonly BanknoteHandler _nextHandler;

        protected BanknoteHandler(BanknoteHandler nextHandler)
        {
            _nextHandler = nextHandler;
            AmountOfBanknote = new Random((int)DateTime.Now.Ticks).Next(5);
            Thread.Sleep(100);
            Console.WriteLine($"{GetType().Name} имеет {AmountOfBanknote} банкнот");
        }

        public bool Validate(Banknote banknote)
        {
            return Banknote.Equals(banknote) || _nextHandler != null && _nextHandler.Validate(banknote);
        }

        public Banknote[] GetCash(CurrencyType currency, int amountOfMoney)
        {
            var currentResult = _nextHandler?.GetCash(currency, amountOfMoney);
            if (currency != Banknote.Currency)
            {
                return currentResult;
            }
            
            var sum = currentResult.Sum();
            if (sum == amountOfMoney)
            {
                return currentResult;
            }

            var residue = amountOfMoney - sum;
            var outAmountOfBanknote = Math.Min(residue/Banknote.Value, AmountOfBanknote);

            var result = new List<Banknote>(currentResult ?? new Banknote[0]);
            for (var i = 0; i < outAmountOfBanknote; i++)
            {
                result.Add(Banknote);
            }
            return result.ToArray();
        }
    }
}