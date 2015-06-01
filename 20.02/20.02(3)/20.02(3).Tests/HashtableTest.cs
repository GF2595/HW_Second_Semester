using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashtableNamespace;

namespace HashtableNamespace.Tests
{
    [TestClass]
    public class HashtableTest
    {
        private Hashtable hashtable;

        [TestInitialize]
        public void Initialize()
        {
            hashtable = new Hashtable();
        }

        [TestMethod]
        public void AddElementTest()
        {
            hashtable.AddElement("test");

            Assert.IsTrue(hashtable.IsElementInTable("test"));
            Assert.IsFalse(hashtable.IsElementInTable("lol"));
        }

        [TestMethod]
        public void DeleteElementTest()
        {
            hashtable.AddElement("test");
            hashtable.DeleteElement("test");

            Assert.IsFalse(hashtable.IsElementInTable("test"));
        }
    }
}
