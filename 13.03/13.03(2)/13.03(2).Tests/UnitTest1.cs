using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilterHomework.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void FilterTest()
        {
            List<int> list = Program.Filter(new List<int> { 1, 2, 5, 8, 2, 4}, x => { return x % 2 == 0; });

            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(8, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(4, list[3]);
        }
    }
}
