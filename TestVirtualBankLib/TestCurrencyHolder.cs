using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualBankLib;
using VirtualBankLib.Models;

namespace TestVirtualBankLib
{
    [TestClass]
    public class TestCurrencyHolder
    {
        [TestMethod] 
        public void TestGetOver()
        {
            ICurrencyHolder holder = new CurrencyHolder(new List<ICurrencyNotation>() {
                new CurrencyNotation("Test1", 10, 2),
                new CurrencyNotation("Test2", 100, 2),
                
            });
            var h1 = holder.GetClosestOver(5);
            var h2 = holder.GetClosestOver(11);
            Assert.AreEqual("Test1", h1.Name);
            Assert.AreEqual("Test2", h2.Name);
        }
    }
}
