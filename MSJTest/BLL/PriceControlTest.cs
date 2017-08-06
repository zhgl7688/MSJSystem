using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class PriceControlTest
    {
        PriceControl priceControl = new PriceControl();
        [TestMethod]
        public void TestPriceGet()
        {
            var ss = priceControl.Get();
           // Assert.AreEqual(1, ss.Count);
            Assert.AreEqual(799,Convert.ToInt16( ss[0].B.RC1M));
            Assert.AreEqual(759, Convert.ToInt16(ss[1].B.RC1M));
            Assert.AreEqual(699, Convert.ToInt16(ss[1].D[1].Agent1));
            Assert.AreEqual(315, Convert.ToInt16(ss[1].AG.S));
        }
    }
}
