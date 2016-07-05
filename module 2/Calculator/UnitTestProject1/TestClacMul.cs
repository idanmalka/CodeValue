using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for TestClacMul
    /// </summary>
    [TestClass]
    public class TestClacMul
    {
        [TestMethod]
        public void Calc_Mul_BothPositive()
        {
            double res = Calc.Calculate(5, 6, "*");
            Assert.AreEqual(res, 30);
        }

        [TestMethod]
        public void Calc_Mul_bothNegative()
        {
            double res = Calc.Calculate(-1, -1, "*");
            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void Calc_Mul_PosAndNeg()
        {
            double res = Calc.Calculate(-5, 6, "*");
            Assert.AreEqual(res, -30);
        }

        public void Calc_Mul_WithZero()
        {
            double res = Calc.Calculate(0, 1, "*");
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void Calc_Mul_Commutative()
        {
            double first = 5;
            double second = 6;
            Assert.AreEqual(Calc.Calculate(first, second, "*"), Calc.Calculate(second, first, "*"));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Calc_Add_MulOverflow()
        {
            var result = Calc.Calculate(double.MaxValue, 2, "*");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Calc_Add_MulUnderrflow()
        {
            var result = Calc.Calculate(double.MinValue, 2, "*");
        }
    }
}
