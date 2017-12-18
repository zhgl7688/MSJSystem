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
            var ss = priceControl.Get();
           // Assert.AreEqual(1, ss.Count);
            Assert.AreEqual(799,Convert.ToInt16( ss[0].B.RcM[0]));
            Assert.AreEqual(759, Convert.ToInt16(ss[1].B.RcM[0]));
            Assert.AreEqual(699, Convert.ToInt16(ss[1].D[0].Agent[0]));
            Assert.AreEqual(315, Convert.ToInt16(ss[1].AG.S));
        }
    }
}
