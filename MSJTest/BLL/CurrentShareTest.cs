using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;


namespace MSJTest.BLL
{
    [TestClass]
    public class CurrentShareTest
    {
        CurrentShare currrent = new CurrentShare();

        [TestMethod]
        public void TestMethod1()
        {
            var result = currrent.Get();
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(0.368, result[1].H[1].M1);
        }
    }
}
