using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualBankLib.Models;

namespace VirtualBankLib
{
    public class CurrencyHolder : ICurrencyHolder
    {
        public List<ICurrencyNotation> Notations = new List<ICurrencyNotation>();

        public CurrencyHolder()
        {
            Notations.Add(new CurrencyNotation($"1 Dollar", 1));

            foreach (var i in new[] { 2, 5, 10, 100 })
            {
                Notations.Add(new CurrencyNotation($"{i} Dollars", i));
            }
        }

        public void ClearNotations()
        {
            Notations.Clear();
        }

        public void Reset()
        {
            Notations.ForEach(f => f.Reset());
        }

        public void AddNotation(ICurrencyNotation notation)
        {
            Notations.Add(notation);
        }

        public CurrencyHolder(List<ICurrencyNotation> Notations)
        {
            this.Notations = Notations;
        }

        public Dictionary<string, int> GetUsedNotations()
        {
            return Notations.Where(f => f.Used > 0).ToDictionary(f => f.Name, g => g.Used);
        }

        public ICurrencyNotation GetClosestOver(decimal value)
        {
            Notations = Notations.OrderByDescending(f => f.Value).ToList();
            ICurrencyNotation NearestNotation = null;
            foreach (var moneyEntry in Notations)
            {
                if (moneyEntry.Value < value) break;
                if (moneyEntry.Available > 0)
                    NearestNotation = moneyEntry;
            }
            return NearestNotation;
        }

        public ICurrencyNotation GetClosestUnder(decimal value)
        {
            Notations = Notations.OrderBy(f=>f.Value).ToList();
            ICurrencyNotation NearestNotation = null;
            foreach (var moneyEntry in Notations)
            {
                if (moneyEntry.Value > value) break;
                if (moneyEntry.Available > 0) 
                    NearestNotation = moneyEntry;
            }
            return NearestNotation;
        }

        public decimal SumTaken()
        {
            return Notations.Sum(f => f.Value * f.Used);
        }

        public decimal SumAvailable()
        {
            return Notations.Sum(f => f.Value * f.Available);
        }
    }
}
