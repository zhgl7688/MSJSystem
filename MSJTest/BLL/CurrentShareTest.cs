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
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(0.357m, decimal.Round( result[1].H[1].M1,3));
            Assert.AreEqual(26,decimal.Round( result[1].CT[1].Agent2,0));

        }
    }
}
