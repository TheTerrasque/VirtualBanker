using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBankLib;
using VirtualBankLib.ChangeRounder;

namespace TestVirtualBankLib
{
    [TestClass]
    public class IterativeTests
    {
        IChangeRounder rounder = new NoRounding();

        [TestMethod]
        public void TestSimpleNumber()
        {
            IChangeSolver solver = new IterativeSolver(rounder);
            SolverTestsCommon.TestSimpleNumber(solver);
        }

        [TestMethod]
        public void TestComplicatedNumber()
        {
            IChangeSolver solver = new IterativeSolver(rounder);
            SolverTestsCommon.TestComplicatedNumber(solver);
        }

        [TestMethod]
        public void TestCustomNotations()
        {

            IChangeSolver solver = new IterativeSolver(rounder);
            SolverTestsCommon.TestCustomNotations(solver);
        }

        [TestMethod]
        public void TestCustomNotationsWithLeftover()
        {
            IChangeSolver solver = new IterativeSolver(rounder);
            SolverTestsCommon.TestCustomNotationsWithLeftover(solver);
        }

        [TestMethod]
        public void TestSimpleRounding()
        {
            IChangeSolver solver = new IterativeSolver(new NaiveRounder());
            SolverTestsCommon.TestSimpleRounder(solver);
        }

    }
}
