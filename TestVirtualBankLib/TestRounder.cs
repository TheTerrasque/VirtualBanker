using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualBankLib.ChangeRounder;

namespace TestVirtualBankLib
{
    [TestClass]
    public class TestRounder
    {
        [TestMethod]
        public void TestSimpleRounding()
        {
            var rounder = new NaiveRounder();
            Assert.IsTrue(rounder.ShouldRoundUp(5, 7));
            Assert.IsFalse(rounder.ShouldRoundUp(5, 11));
        }
    }
}
