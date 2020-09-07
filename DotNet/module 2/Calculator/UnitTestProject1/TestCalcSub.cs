using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestCalcSub
    {
        [TestMethod]
        public void Calc_Sub_BothPositivePosResult()
        {
            double res = Calc.Calculate(6, 5, "-");
            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void Calc_Sub_BothPositiveNegResult()
        {
            double res = Calc.Calculate(5, 6, "-");
            Assert.AreEqual(res, -1);
        }

        public void Calc_Sub_BothPositiveZeroResult()
        {
            double res = Calc.Calculate(5, 5, "-");
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void Calc_Sub_bothNegativePosResult()
        {
            double res = Calc.Calculate(-1, -2, "-");
            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void Calc_Sub_bothNegativeNegResult()
        {
            double res = Calc.Calculate(-2, -1, "-");
            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void Calc_Sub_bothNegativeZeroResult()
        {
            double res = Calc.Calculate(-1, -1, "-");
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void Calc_Sub_PosAndNeg()
        {
            double res = Calc.Calculate(-5, 6, "-");
            Assert.AreEqual(res, -11);
        }

        public void Calc_Sub_WithZero()
        {
            double res = Calc.Calculate(0, 1, "-");
            Assert.AreEqual(res, -1);
        }


        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Calc_Sub_SubOverflow()
        {
            var result = Calc.Calculate(double.MaxValue, -1, "-");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Calc_Sub_SubUnderrflow()
        {
            var result = Calc.Calculate(double.MinValue, 1, "-");
        }
    }
}
