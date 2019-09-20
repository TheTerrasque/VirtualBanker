using System.Collections.Generic;
using VirtualBankLib.Models;

namespace VirtualBankLib
{
    public interface ICurrencyHolder
    {
        decimal SumAvailable();
        decimal SumTaken();
        ICurrencyNotation GetClosestUnder(decimal value);
        ICurrencyNotation GetClosestOver(decimal value);
        Dictionary<string, int> GetUsedNotations();
        void ClearNotations();
        void AddNotation(ICurrencyNotation notation);
    }
}