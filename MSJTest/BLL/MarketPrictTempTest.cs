using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class MarketPrictTempTest:BaseTest
    {
          [TestMethod]
        public void TestmarketPriceTemp()
        {
            var result = marketPriceTemp.Get();
            Assert.AreEqual(1.09m,decimal.Round( result[0].EY[1].M1,2));
            Assert.AreEqual(-2.86m,decimal.Round( result[0].EY[1].M5,2));
        }
    }
}
