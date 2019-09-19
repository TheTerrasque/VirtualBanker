using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualBankLib.Models
{
    public class CurrencyNotation : ICurrencyNotation
    {
        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public int Available { get; private set; }
        public int Used { get; private set; }

        public CurrencyNotation(string Name, decimal Value)
        {
            this.Name = Name;
            this.Value = Value;
            this.Available = int.MaxValue;
        }

        public CurrencyNotation(string Name, decimal Value, int numAvailable)
        {
            this.Name = Name;
            this.Value = Value;
            this.Available = numAvailable;
        }

        public void Take(int number=1)
        {
            number = Math.Min(number, Available);
            Used += number;
            Available -= number;
        }
    }
}
