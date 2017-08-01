using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class MarketPriceTest
    {
        MarketPrice marketPrice = new MarketPrice();
        [TestMethod]
        public void TestMethod1()
        {
         var result=   marketPrice.Get();
            Assert.AreEqual(799, result[0].DE);
            Assert.AreEqual(0.101, result[0].EY[1].M1);
        }
    }
}
