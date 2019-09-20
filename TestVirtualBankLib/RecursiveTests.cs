using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBankLib;
using System.Collections.Generic;
using VirtualBankLib.Models;
using VirtualBankLib.ChangeRounder;

namespace TestVirtualBankLib
{
    [TestClass]
    public class RecursiveTests
    {
        IChangeRounder _rounder = new NoRounding();
        [TestMethod]
        public void TestSimpleNumber()
        {
            IChangeSolver solver = new RecursiveSolver(_rounder);
            SolverTestsCommon.TestSimpleNumber(solver);
        }

        [TestMethod]
        public void TestComplicatedNumber()
        {
            IChangeSolver solver = new RecursiveSolver(_rounder);
            SolverTestsCommon.TestComplicatedNumber(solver);
        }

        [TestMethod]
        public void TestCustomNotations()
        {
            IChangeSolver solver = new RecursiveSolver(_rounder);
            SolverTestsCommon.TestCustomNotations(solver);
        }

        [TestMethod]
        public void TestCustomNotationsWithLeftover()
        {
            IChangeSolver solver = new RecursiveSolver(_rounder);
            SolverTestsCommon.TestCustomNotationsWithLeftover(solver);
        }

    }
}
