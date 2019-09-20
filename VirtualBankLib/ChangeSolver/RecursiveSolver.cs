using System;
using System.Collections.Generic;
using System.Text;
using VirtualBankLib.ChangeRounder;

namespace VirtualBankLib
{
    public class RecursiveSolver : IChangeSolver
    {

        private IChangeRounder _rounder;

        public RecursiveSolver(IChangeRounder rounder)
        {
            _rounder = rounder;
        }

        public void FindReturnFor(ICurrencyHolder holder, decimal amount)
        {
            var amountLeft = amount - holder.SumTaken();
            var closest = holder.GetClosestUnder(amountLeft);
            if (closest == null)
            {
                closest = holder.GetClosestOver(amountLeft);
                if (closest != null)
                {
                    if (_rounder.ShouldRoundUp(amountLeft, closest.Value)) closest.Take();
                }
                return;
            }
            closest.Take();
            FindReturnFor(holder, amount);
        }
    }
}
