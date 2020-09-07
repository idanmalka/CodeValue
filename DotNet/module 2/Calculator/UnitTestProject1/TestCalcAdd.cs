using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace UnitTestProject1
{
    //Nice.
    [TestClass]
    public class TestCalcAdd
    {
        [TestMethod]
        public void Calc_Add_BothPositive()
        {
            double res = Calc.Calculate(5, 6, "+");
            Assert.AreEqual(res, 11);
        }

        [TestMethod]
        public void Calc_Add_bothNegative()
        {
            double res = Calc.Calculate(-1, -1, "+");
            Assert.AreEqual(res,-2);
        }

        [TestMethod]
        public void Calc_Add_PosAndNeg()
        {
            double res = Calc.Calculate(-5, 6, "+");
            Assert.AreEqual(res,1);
        }

        public void Calc_Add_WithZero()
        {
            double res = Calc.Calculate(0, 1, "+");
            Assert.AreEqual(res,1);
        }

        [TestMethod]
        public void Calc_Add_Commutative()
        {
            double first = 5;
            double second = 6;
            Assert.AreEqual(Calc.Calculate(first, second,"+"), Calc.Calculate(second, first,"+"));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Calc_Add_AddOverflow()
        {
            var result = Calc.Calculate(double.MaxValue, 1, "+");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Calc_Add_AddUnderrflow()
        {
            var result = Calc.Calculate(double.MinValue, -1, "+");
        }

    }
}