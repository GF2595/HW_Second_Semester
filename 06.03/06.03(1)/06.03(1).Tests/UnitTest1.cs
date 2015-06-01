using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeNamespace.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        private Calculator calc;

        [TestInitialize]
        public void Initialize()
        {
            calc = new Calculator("../expression.txt");
        }
        [TestMethod]
        public void CalculateTest()
        {
            Assert.AreEqual(57, calc.GetExpressionResult());
        }
    }
}
