using System;
using System.Collections.Generic;
using System.Text;
using VirtualBankLib.ChangeRounder;

namespace VirtualBankLib
{
    public class IterativeSolver : IChangeSolver
    {
        private IChangeRounder _rounder;

        public IterativeSolver(IChangeRounder rounder)
        {
            _rounder = rounder;
        }

        public void FindReturnFor(ICurrencyHolder holder, decimal amount)
        {
            var closest = holder.GetClosestUnder(amount);
            var amountLeft = amount;
            while (closest != null)
            {
                closest.Take();
                amountLeft = amount - holder.SumTaken();
                closest = holder.GetClosestUnder(amountLeft);
            }

            var closestOver = holder.GetClosestOver(amountLeft);
            if (closestOver != null)
            {
                if (_rounder.ShouldRoundUp(amountLeft, closestOver.Value))
                {
                    closestOver.Take();
                }
            }

        }
    }
}
