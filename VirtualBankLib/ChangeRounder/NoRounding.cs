using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualBankLib.ChangeRounder
{
    public class NoRounding : IChangeRounder
    {
        public bool ShouldRoundUp(decimal amount, decimal closestNomination)
        {
            return false;
        }
    }
}
