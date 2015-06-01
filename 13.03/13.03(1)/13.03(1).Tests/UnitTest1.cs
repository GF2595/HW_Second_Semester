using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapHomework.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void MapTest()
        {
            List<int> list = Program.Map(new List<int>() { 1, 2, 3 }, x => x * 2);

            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(4, list[1]);
            Assert.AreEqual(6, list[2]);
        }
    }
}
