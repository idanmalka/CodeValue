using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryDisplay;

namespace TestBinaryDisplays
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_BinaryDisplay_ValidInput()
        {
            Assert.AreEqual("101", Program.GetBinaryRep(5));
            Assert.AreEqual(2,Program.CountOnes(5));
        }

        [TestMethod]
        public void Test_BinaryDisplay_MaxValue()
        {
            Assert.AreEqual("1111111111111111111111111111111",Program.GetBinaryRep(int.MaxValue));
            Assert.AreEqual(31,Program.CountOnes(int.MaxValue));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_BinaryDisplay_NegativeInput()
        {
            Program.CountOnes(-5);
        }
    }
}
