using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class StockReportTest:BaseTest
    {
      
        [TestMethod]
        public void TestMethod1()
        {

            var result = stockReport.Get();
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(31, result[1].B);
            Assert.AreEqual(12090m, decimal.Round(result[3].E[1].Amount, 2));
        }
    }
}
