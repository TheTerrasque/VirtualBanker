using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualBankLib;
using VirtualBankLib.Models;

namespace TestVirtualBankLib
{
    internal class SolverTestsCommon
    {
        public static void TestSimpleRounder(IChangeSolver solver)
        {
            ICurrencyHolder holder = new CurrencyHolder(new List<ICurrencyNotation>() {
                new CurrencyNotation("10 Cent", 0.1M),
                new CurrencyNotation("25 Cent", 0.25M),
                new CurrencyNotation("75 Cent", 0.75M),
                new CurrencyNotation("5 Dollar", 5),
            });

            solver.FindReturnFor(holder, 24.41M);
            Assert.AreEqual(24.45M, holder.SumTaken());
        }

        public static void TestSimpleNumber(IChangeSolver solver)
        {
            ICurrencyHolder holder = new CurrencyHolder();

            solver.FindReturnFor(holder, 200);
            var result = holder.GetUsedNotations();

            Assert.AreEqual(holder.SumTaken(), 200);

            // There should be one entry in results, and it should be 2 of that notation.
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result["100 Dollars"], 2);
        }

        public static void TestComplicatedNumber(IChangeSolver solver)
        {
            ICurrencyHolder holder = new CurrencyHolder();

            solver.FindReturnFor(holder, 367);
            var result = holder.GetUsedNotations();

            Assert.AreEqual(367, holder.SumTaken());

            // There should be one entry in results, and it should be 2 of that notation.
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result["100 Dollars"], 3);
            Assert.AreEqual(result["10 Dollars"], 6);
            Assert.AreEqual(result["5 Dollars"], 1);
            Assert.AreEqual(result["2 Dollars"], 1);
        }

        public static void TestCustomNotations(IChangeSolver solver)
        {
            ICurrencyHolder holder = new CurrencyHolder(new List<ICurrencyNotation>() {
                new CurrencyNotation("10 Cent", 0.1M),
                new CurrencyNotation("25 Cent", 0.25M),
                new CurrencyNotation("75 Cent", 0.75M),
                new CurrencyNotation("5 Dollar", 5),
            });

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

        public static void TestCustomNotationsWithLeftover(IChangeSolver solver)
        {
            ICurrencyHolder holder = new CurrencyHolder(new List<ICurrencyNotation>() {
                new CurrencyNotation("10 Cent", 0.1M),
                new CurrencyNotation("25 Cent", 0.25M),
                new CurrencyNotation("75 Cent", 0.75M),
                new CurrencyNotation("5 Dollar", 5),
            });

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
