using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBankLib;
using System.Collections.Generic;
using VirtualBankLib.Models;

namespace TestVirtualBankLib
{
    [TestClass]
    public class IterativeTests
    {
        [TestMethod]
        public void TestSimpleNumber()
        {
            ICurrencyHolder holder = new CurrencyHolder();
            IChangeSolver solver = new IterativeSolver();

            solver.FindReturnFor(holder, 200);
            var result = holder.GetUsedNotations();

            Assert.AreEqual(holder.SumTaken(), 200);
            
            // There should be one entry in results, and it should be 2 of that notation.
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result["100 Dollars"], 2);
        }

        [TestMethod]
        public void TestComplicatedNumber()
        {
            ICurrencyHolder holder = new CurrencyHolder();
            IChangeSolver solver = new IterativeSolver();

            solver.FindReturnFor(holder, 367);
            var result = holder.GetUsedNotations();

            Assert.AreEqual(holder.SumTaken(), 367);

            // There should be one entry in results, and it should be 2 of that notation.
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result["100 Dollars"], 3);
            Assert.AreEqual(result["10 Dollars"], 6);
            Assert.AreEqual(result["5 Dollars"], 1);
            Assert.AreEqual(result["2 Dollars"], 1);
        }

        [TestMethod]
        public void TestCustomNotations()
        {
            ICurrencyHolder holder = new CurrencyHolder(new List<ICurrencyNotation>() {
                new CurrencyNotation("10 Cent", 0.1M),
                new CurrencyNotation("25 Cent", 0.25M),
                new CurrencyNotation("75 Cent", 0.75M),
                new CurrencyNotation("5 Dollar", 5),
            });
            IChangeSolver solver = new IterativeSolver();

            solver.FindReturnFor(holder, 24.35M);

            var result = holder.GetUsedNotations();

            Assert.AreEqual(holder.SumTaken(), 24.35M);

            // There should be one entry in results, and it should be 2 of that notation.
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result["10 Cent"], 1);
            Assert.AreEqual(result["25 Cent"], 2);
            Assert.AreEqual(result["75 Cent"], 5);
            Assert.AreEqual(result["5 Dollar"], 4);
        }

        [TestMethod]
        public void TestCustomNotationsWithLeftover()
        {
            ICurrencyHolder holder = new CurrencyHolder(new List<ICurrencyNotation>() {
                new CurrencyNotation("10 Cent", 0.1M),
                new CurrencyNotation("25 Cent", 0.25M),
                new CurrencyNotation("75 Cent", 0.75M),
                new CurrencyNotation("5 Dollar", 5),
            });
            IChangeSolver solver = new IterativeSolver();

            solver.FindReturnFor(holder, 24.38M);

            var result = holder.GetUsedNotations();

            Assert.AreEqual(holder.SumTaken(), 24.35M);

            // There should be one entry in results, and it should be 2 of that notation.
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result["10 Cent"], 1);
            Assert.AreEqual(result["25 Cent"], 2);
            Assert.AreEqual(result["75 Cent"], 5);
            Assert.AreEqual(result["5 Dollar"], 4);
        }

    }
}
