using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualBankLib
{
    public class RecursiveSolver : IChangeSolver
    {
        public void FindReturnFor(ICurrencyHolder holder, decimal amount)
        {
            var closest = holder.GetClosestUnder(amount - holder.SumTaken());
            if (closest == null) return;
            closest.Take();
            FindReturnFor(holder, amount);
        }
    }
}
