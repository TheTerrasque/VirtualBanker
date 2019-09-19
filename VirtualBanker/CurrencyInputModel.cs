using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualBankLib.Models;

namespace VirtualBanker
{
    public class CurrencyInputModel
    {
        private CurrencyNotation _notation;
        public string Name { get; set; }
        public int Available { get; set; } = 3;
        public decimal Value { get; set; }
        public int AmountUsed { get; private set; }
        public decimal TotalValue => Value * AmountUsed;

        public void Update()
        {
            if (_notation == null) return;
            AmountUsed = _notation.Used;
        }

        public ICurrencyNotation GetNotation()
        {
            _notation = new CurrencyNotation(Name, Value, Available);
            return _notation;
        }
    }
}
