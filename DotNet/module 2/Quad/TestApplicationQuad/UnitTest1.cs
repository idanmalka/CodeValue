using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quad;

namespace TestApplicationQuad
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Quad_ValidData()
        {
            double[] coef = {1, 2, -3};
            var res = Program.CalculateQuad(coef);
            Assert.AreEqual(res[0],1);
            Assert.AreEqual(res[1],-3);
        }

        [TestMethod]
        public void Test_Quad_QuadToLinear()
        {
            double[] coef = {0, 1, 2};
            var res = Program.CalculateQuad(coef);
            Assert.AreNotEqual(double.NaN,res[0]);
            Assert.AreEqual(double.NaN,res[1]);
        }

        [TestMethod]
        public void Test_Quad_NoSolutions()
        {
            double[] coef = {1, 2, 3};
            var res = Program.CalculateQuad(coef);
            Assert.AreEqual(res[0],double.NaN);
            Assert.AreEqual(res[1],double.NaN);
        }

        [TestMethod]
        public void Test_Quad_CoeffsOverThree()
        {
            string[] args = {"1", "2", "3", "4"};
            var coef = new double[0];
            Assert.AreEqual(false,Program.CheckAndParseInput(args,coef));
        }

        [TestMethod]
        public void Test_Quad_CoeffsUnderThree()
        {
            string[] args = { "1", "2" };
            double[] coef = new double[0];
            Assert.AreEqual(false, Program.CheckAndParseInput(args,coef));
        }

        [TestMethod]
        public void Test_Quad_InvalidCoef()
        {
            string[] args = { "1", "2" , "f" };
            double[] coef = new double[3];
            Assert.AreEqual(false, Program.CheckAndParseInput(args,coef));
        }

        [TestMethod]
        public void Test_Quad_OverflowCoef()
        {
            
        }
    }
}
