using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strings;

namespace TestStrings
{
    //Consider a better name
    //You can add more UnitTests.
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Test_Strings_ValidReverse()
        {
            string[] str = {"to", "be", "or", "not"};
            string[] str2 = { "to", "be", "or", "not" };
            Program.Reverse(str);
            for(int i=0;i<str.Length;i++)
                Assert.AreEqual(str[i],str2[str.Length-1-i]);
        }

        [TestMethod]
        public void Test_Strings_EmptyString()
        {
            Assert.AreEqual(true, Program.CheckEmptyString(""));
        }

        [TestMethod]
        public void Test_Strings_ValidSort()
        {
            string[] str = { "not", "or", "be", "to" };
            string[] str2 = { "be", "not", "or", "to" };
            Program.SortReversedArray(str);
            for(int i=0; i<str.Length;i++)
                Assert.AreEqual(str[i],str2[i]);
        }

    }
}
