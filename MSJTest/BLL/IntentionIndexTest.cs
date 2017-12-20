using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class IntentionIndexTest:BaseTest
    {
          [TestMethod]
        public void TestMethod1()
        {
            var result = intentionIndex.Get();
            //Assert.AreEqual(1, result.Count);
            Assert.AreEqual(0.33m,decimal.Round( result[0].BDAvg[0].Average[0],2));
            Assert.AreEqual(0.331m,decimal.Round( result[0].AL[1].Agent[0], 3));
            Assert.AreEqual(0.33m, decimal.Round(result[1].BDAvg[0].Average[0], 2));
            Assert.AreEqual(0.311m, decimal.Round(result[1].AL[1].Agent[0], 3));
            Assert.AreEqual(0.33m, decimal.Round(result[2].BDAvg[0].Average[0], 2));
            Assert.AreEqual(0.388m, decimal.Round(result[2].AL[1].Agent[0], 3));
        }
    }
}
