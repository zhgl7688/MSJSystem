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
            Assert.AreEqual(1, ss.Count);
            Assert.AreEqual(799,Convert.ToInt16( ss[0].B.RC1M));
        }
    }
}
