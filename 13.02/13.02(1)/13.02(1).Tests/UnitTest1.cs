using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW1_1.Tests
{
    [TestClass]
    public class FactorialHomeworkTest
    {
        [TestMethod]
        public void FactorialTest()
        {
            Assert.AreEqual(120, Program.Factorial(5));
        }

        [TestMethod]
        public void FactorialTest2()
        {
            Assert.AreEqual(1, Program.Factorial(1));
            Assert.AreEqual(1, Program.Factorial(0));
            Assert.AreEqual(1, Program.Factorial(-5));
        }
    }
}
