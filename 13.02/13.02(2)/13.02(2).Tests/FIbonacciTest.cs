using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW1_2.Tests
{
    [TestClass]
    public class FibonacciHomeworkTests
    {
        [TestMethod]
        public void FibonacciTest()
        {
            Assert.AreEqual(8, Program.Fibonacci(6));
            Assert.AreEqual(1, Program.Fibonacci(1));
            Assert.AreEqual(1, Program.Fibonacci(0));
            Assert.AreEqual(1, Program.Fibonacci(-5));
        }
    }
}
