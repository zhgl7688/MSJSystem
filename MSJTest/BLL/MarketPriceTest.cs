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
         var ss=   marketPrice.Get();
            Assert.AreEqual(799, ss[0].DE);
        }
    }
}
