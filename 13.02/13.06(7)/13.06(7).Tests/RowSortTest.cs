using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW1_7.Tests
{
    [TestClass]
    public class ArrayTest
    {
        [TestMethod]
        public void RowSortTest()
        {
            int rowSize = 4;
            int columnSize = 3;
            int[] arrayStart = {1, 6, 7, 5, 3, 9, 3, 6, 1, 0, 12, 76};

            Array array = new Array(rowSize, columnSize);

            for (int i = 0; i < columnSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    array.PlaceElement(arrayStart[i + j * 3], i, j);
                }
            }

            array.BubbleSort();

            for (int i = 0; i < columnSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    arrayStart[i + j * 3] = array.GetElement(i, j);
                }
            }

            int[] expectedArray = { 0, 12, 76, 1, 6, 7, 3, 6, 1, 5, 3, 9 };

            for (int i = 0; i < rowSize*columnSize; i++)
            {
                Assert.AreEqual(expectedArray[i], arrayStart[i]);
            }
        }
    }
}
