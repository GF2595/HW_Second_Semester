using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericStackNamespace;
using GenericListNamespace;

namespace GenericListStack.Tests
{
    [TestClass]
    public class GenericListTest
    {
        private GenericList<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new GenericList<int>();
        }

        [TestMethod]
        public void AddElementTest()
        {
            list.AddElement(3);

            Assert.AreEqual(3, list.CheckElement(1));
        }

        [TestMethod]
        public void PlaceElementTest()
        {
            list.PlaceElement(3, 1);
            list.PlaceElement(4, 2);
            list.PlaceElement(5, 2);

            Assert.AreEqual(5, list.CheckElement(2));
        }

        [TestMethod]
        public void DeleteElementTest()
        {
            list.AddElement(3);
            list.AddElement(5);
            list.AddElement(7);
            list.DeleteElement(2);

            Assert.AreEqual(7, list.CheckElement(2));
        }

        [TestMethod]
        public void FindElementTest()
        {
            list.AddElement(3);
            list.AddElement(9);
            list.AddElement(2);
            list.AddElement(8);

            Assert.AreEqual(3, list.FindElement(2));
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            for (int i = 0; i < 5; i++)
            {
                list.AddElement(i);
            }

            int testValue = 0;

            foreach(int j in list)
            {
                Assert.AreEqual(testValue, j);
                ++testValue;
            }
        }
    }

    [TestClass]
    public class GenericStackTest
    {
        [TestMethod]
        public void PopTest()
        {
            IStack<int> stack = new GenericStack<int>();

            stack.Push(4);
            stack.Push(6);

            Assert.AreEqual(6, stack.Pop());
        }
    }
}
