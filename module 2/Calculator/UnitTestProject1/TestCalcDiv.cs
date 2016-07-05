using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for TestCalcDiv
    /// </summary>
    [TestClass]
    public class TestCalcDiv
    {
        [TestMethod]
        public void Calc_Div_BothPositive()
        {
            double res = Calc.Calculate(6, 5, "/");
            Assert.AreEqual(res, (double)6/5);
        }


        [TestMethod]
        public void Calc_Div_bothNegative()
        {
            double res = Calc.Calculate(-1, -2, "/");
            Assert.AreEqual(res, (double)1/2);
        }


        [TestMethod]
        public void Calc_Div_PosAndNeg()
        {
            double res = Calc.Calculate(-5, 6, "/");
            Assert.AreEqual(res, -(double)5/6);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calc_Div_WithZero()
        {
            double res = Calc.Calculate(1, 0, "/");
        }


        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Calc_Div_DivOverflow()
        {
            var result = Calc.Calculate(double.MaxValue, 0.5, "/");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Calc_Div_DivUnderrflow()
        {
            var result = Calc.Calculate(double.MinValue, 0.5, "/");
        }
    }
}
