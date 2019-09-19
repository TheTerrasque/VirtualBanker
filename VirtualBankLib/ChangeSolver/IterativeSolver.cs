using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualBankLib
{
    public class IterativeSolver : IChangeSolver
    {
        public void FindReturnFor(ICurrencyHolder holder, decimal amount)
        {
            var closest = holder.GetClosestUnder(amount);
            while (closest != null)
            {
                closest.Take();
                closest = holder.GetClosestUnder(amount - holder.SumTaken());
            }
        }
    }
}
