using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class MarketPriceTest:BaseTest
    {
          [TestMethod]
        public void TestMethod1()
        {
         var result=   marketPrice.Get();
            Assert.AreEqual(0.32m,decimal.Round( result[0].CV[0].S,2));
            Assert.AreEqual(0.28m,decimal.Round( result[0].CV[0].J,2));
        }
       
    }
}
