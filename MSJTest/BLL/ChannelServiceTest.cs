using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;


namespace MSJTest.BLL
{
    [TestClass]
    public class ChannelServiceTest:BaseTest
    {
         [TestMethod]
        public void TestMethod1()
        {
            var result = channelService.Get();
            Assert.AreEqual(240, result[1].B.M);
            Assert.AreEqual(280, result[2].B.J);
            Assert.AreEqual(500, result[3].B.J);
            Assert.AreEqual(0.98m, result[0].J.M[5]);
            Assert.AreEqual(0.33m,decimal.Round( result[0].AB.M[5],2));
            Assert.AreEqual(0.68m,decimal.Round(result[1].J.M[0],2));
            Assert.AreEqual(0.48m,decimal.Round(result[1].AB.M[0],2));
            Assert.AreEqual(0.72m, decimal.Round(result[2].J.M[0], 2));
            Assert.AreEqual(0.52m, decimal.Round(result[3].AB.M[0], 2));
        }
    }
}
