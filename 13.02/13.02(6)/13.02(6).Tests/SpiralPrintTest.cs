using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW1_6.Tests
{
    [TestClass]
    public class ArrayTest
    {
        private Array array;

        [TestInitialize]
        public void Initialize()
        {
            array = new Array(3);
        }

        [TestMethod]
        public void SpiralPrintTest()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array.PlaceElement(i + 1, i, j);
                }
            }

            Assert.AreEqual("2 1 1 2 3 3 3 2 1 ", array.SpiralPrint());
        }
    }
}
