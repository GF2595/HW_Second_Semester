using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SetNamespace.Tests
{
    [TestClass]
    public class GenericSetTest
    {
        private GenericSet<int> set;

        [TestInitialize]
        public void Initialize()
        {
            set = new GenericSet<int>();
        }

        [TestMethod]
        public void AddElementTest()
        {
            set.AddElement(3);

            Assert.IsTrue(set.IsElementInSet(3));
        }

        [TestMethod]
        public void DeleteElementTest()
        {
            set.AddElement(4);
            set.AddElement(5);
            set.DeleteElement(4);

            Assert.IsFalse(set.IsElementInSet(4));
        }

        [TestMethod]
        public void IntersectionTest()
        {
            set.AddElement(3);
            set.AddElement(6);

            GenericSet<int> secondSet = new GenericSet<int>();
            secondSet.AddElement(3);
            secondSet.AddElement(7);

            GenericSet<int> thirdSet = GenericSet<int>.Intersection(set, secondSet);

            Assert.IsTrue(thirdSet.IsElementInSet(3));
            Assert.IsFalse(thirdSet.IsElementInSet(7));
        }

        [TestMethod]
        public void UnionTest()
        {
            set.AddElement(3);
            set.AddElement(6);

            GenericSet<int> secondSet = new GenericSet<int>();
            secondSet.AddElement(3);
            secondSet.AddElement(7);

            GenericSet<int> thirdSet = GenericSet<int>.Union(set, secondSet);

            Assert.IsTrue(thirdSet.IsElementInSet(3));
            Assert.IsTrue(thirdSet.IsElementInSet(6));
        }
    }
}
