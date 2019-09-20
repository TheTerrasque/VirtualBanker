using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualBankLib.ChangeRounder
{
    public class NaiveRounder : IChangeRounder
    {
        public bool ShouldRoundUp(decimal amount, decimal closestNomination)
        {
            return amount > (closestNomination / 2);
        }
    }
}
