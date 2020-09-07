using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericApp;

namespace TestMultiDictionary
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Test_Dictionary_SuccessfulContainKeyCheck()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string> {{1, "one"}};
            Assert.AreEqual(true, dictionary.ContainsKey(1));
        }

        [TestMethod]
        public void Test_Dictionary_SuccessfulContainCheck()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string> { { 1, "one" } };
            Assert.AreEqual(true, dictionary.Contains(1, "one"));
        }

        [TestMethod]
        public void Test_Dictionary_SuccessfulAdd()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>();
            dictionary.Add(1, "one");
            dictionary.Add(1,"ich");
            Assert.AreEqual(true,dictionary.Contains(1, "one"));
            Assert.AreEqual(true, dictionary.Contains(1,"ich"));
        }

        [TestMethod]
        public void Test_Dictionary_RemoveKey()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string> {{1, "one"}, {2, "two"}};
            dictionary.Remove(1);
            Assert.AreEqual(true, dictionary.ContainsKey(2));
            Assert.AreEqual(false,dictionary.ContainsKey(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Dictionary_UnsuccessfulRemoveKey()
        {
            var dictionary = new MultiDictionary<int,string>();
            dictionary.Remove(1);
        }

        [TestMethod]
        public void Test_Dictionary_RemoveValue()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string> { { 1, "one" }, { 1, "ich" } };
            dictionary.Remove(1,"one");
            Assert.AreEqual(true, dictionary.Contains(1,"ich"));
            Assert.AreEqual(false, dictionary.Contains(1,"one"));
        }

        [TestMethod]
        public void Test_Dictionary_UnsuccessfulRemoveValue()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>();
            Assert.AreEqual(false,dictionary.Remove(1, "one"));
        }

        [TestMethod]
        public void Test_Dictionary_Clear()
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string> { { 1, "one" }, { 1, "ich" } };
            dictionary.Clear();
            Assert.AreEqual(0,dictionary.Count);
        }
    }
}
