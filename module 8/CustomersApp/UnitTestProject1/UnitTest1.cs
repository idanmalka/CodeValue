using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomersApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_customersCompare()
        {
            Customer c1 = new Customer("idan",12345,"1'st street");
            Customer c2 = new Customer("Adir",13243,"2'nd street");

            Assert.AreEqual(c1.CompareTo(c2), String.Compare("idan", "Adir", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void Test_CustomersEquatingFail()
        {
            Customer c1 = new Customer("idan", 12345, "1'st street");
            Customer c2 = new Customer("Adir", 13243, "2'nd street");

            Assert.AreEqual(c1.Equals(c2),false);
        }

        [TestMethod]
        public void Test_CustomersEquatingSuccess()
        {
            Customer c1 = new Customer("idan", 12345, "1'st street");
            Customer c2 = new Customer("idan", 12345, "2'nd street");

            Assert.AreEqual(c1.Equals(c2),true);
        }

        [TestMethod]
        public void Test_customersAnotherCompare()
        {
            Customer[] c = new Customer[3];
            c[0] = new Customer("idan", 55555, "1'st street");
            c[1] = new Customer("Adir", 11111, "2'nd street");
            c[2] = new Customer("moaiad", 22222,"3'rd street");
            AnotherCustomerComparer comparer = new AnotherCustomerComparer();
            Array.Sort(c,comparer);
            Assert.AreEqual("Adir", c[0].Name);
            Assert.AreEqual("moaiad", c[1].Name);
            Assert.AreEqual("idan", c[2].Name);
        }
    }
}
