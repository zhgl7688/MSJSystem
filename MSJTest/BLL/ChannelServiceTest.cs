using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;


namespace MSJTest.BLL
{
    [TestClass]
    public class ChannelServiceTest
    {
        ChannelService channel = new ChannelService();
        [TestMethod]
        public void TestMethod1()
        {
            var result = channel.Get();
            Assert.AreEqual(0.98m, result[0].J.M6);
            Assert.AreEqual(0.33m,decimal.Round( result[0].AB.M6,2));
            Assert.AreEqual(200, result[1].B.Agent3);

        }
    }
}
