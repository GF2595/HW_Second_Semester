using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListNamespace.Tests
{
    [TestClass]
    public class UniqueListTest
    {
        private _List list;

        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [TestMethod]
        public void AddElementTest1()
        {
            list.AddElement(5);

            Assert.AreEqual(5, list.CheckElement(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ListNamespace.AlreadyAddedElementAddingException))]
        public void AddElementTest2()
        {
            list.AddElement(5);
            list.AddElement(5);
        }

        [TestMethod]
        public void PlaceElementTest1()
        {
            list.PlaceElement(3, 1);
            list.PlaceElement(4, 1);
            list.PlaceElement(5, 2);

            Assert.AreEqual(4, list.CheckElement(1));
            Assert.AreEqual(5, list.CheckElement(2));
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyAddedElementAddingException))]
        public void PlaceElementTest2()
        {
            list.PlaceElement(3, 1);
            list.PlaceElement(4, 1);
            list.PlaceElement(3, 2);
            list.PlaceElement(3, 3);
        }
    }
}
