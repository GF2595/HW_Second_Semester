using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW1_3.Tests
{
    [TestClass]
    public class ArrayTest
    {
        private HW1_3.Array array;

        [TestInitialize]
        public void Initialize()
        {
            array = new HW1_3.Array(5);
        }

        [TestMethod]
        public void PlaceElementTest()
        {
            array.PlaceElement(3, 1);

            Assert.AreEqual(3, array.CheckElement(1));
        }

        [TestMethod]
        public void SortTest()
        {
            array.PlaceElement(18, 0);
            array.PlaceElement(4, 1);
            array.PlaceElement(7, 2);
            array.PlaceElement(9, 3);
            array.PlaceElement(1, 4);

            array.BubbleSort();

            Assert.AreEqual(1, array.CheckElement(0));
            Assert.AreEqual(4, array.CheckElement(1));
            Assert.AreEqual(7, array.CheckElement(2));
            Assert.AreEqual(9, array.CheckElement(3));
            Assert.AreEqual(18, array.CheckElement(4));
        }
    }
}
