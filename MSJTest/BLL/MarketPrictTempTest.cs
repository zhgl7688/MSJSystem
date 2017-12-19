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
            Assert.AreEqual(1.09m,decimal.Round( result[0].EY[0].M[0],2));

            Assert.AreEqual(-3.07m,decimal.Round( result[1].EY[1].M[4],2));
            Assert.AreEqual(0.46m,decimal.Round( result[2].EY[1].M[2],2));

            //由于市场价格ah公式可能有问题，与ab和an不同。
        }
    }
}
