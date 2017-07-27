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
        public void TestMethod1()
        {
            var ss = priceControl.Get();
            Assert.AreEqual(1, ss.Count);
            Assert.AreEqual(531,Convert.ToInt16( ss[0].Agents[1].Average));
        }
    }
}
