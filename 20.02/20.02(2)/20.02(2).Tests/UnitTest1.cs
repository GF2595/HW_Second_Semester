using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListNamespace.Test
{
    [TestClass]
    public class _ListTest
    {
        _List list;

        [TestInitialize]
        public void Initialize()
        {
            list = new _List();
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
    }
}
