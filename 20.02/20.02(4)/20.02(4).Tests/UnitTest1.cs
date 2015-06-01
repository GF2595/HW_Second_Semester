using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackCalcNamespace;

namespace StackCalcNamespace.Tests
{
    [TestClass]
    public class StackCalcTest
    {
        private StackCalc calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new StackCalc();
        }

        [TestMethod]
        public void PopTest()
        {
            calculator.Push(2);
            calculator.Push(3);

            Assert.AreEqual(3, calculator.Pop());
        }

        [TestMethod]
        public void OperationTest1()
        {
            calculator.Push(2);
            calculator.Push(6);
            calculator.Operation('+');

            Assert.AreEqual(8, calculator.Pop());
        }

        [TestMethod]
        public void OperationTest2()
        {
            calculator.Push(2);
            calculator.Push(6);
            calculator.Operation('*');

            Assert.AreEqual(12, calculator.Pop());
        }
    }
}
