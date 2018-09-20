using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class PriceControlTest:BaseTest
    {
          [TestMethod]
        public void TestPriceGet()
        {
            var ss = priceControl.GetPriceBy(WebMVC.Common.Stage.第1阶段);
              ss = priceControl.GetPriceBy(WebMVC.Common.Stage.第2阶段);
            // Assert.AreEqual(1, ss.Count);
            Assert.AreEqual(799,Convert.ToInt16( ss .B.RcM[0]));
            Assert.AreEqual(759, Convert.ToInt16(ss .B.RcM[0]));
            Assert.AreEqual(699, Convert.ToInt16(ss .D[0].Agent[0]));
            Assert.AreEqual(315, Convert.ToInt16(ss .AG.S));
        }
    }
}
