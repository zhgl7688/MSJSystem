using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.Common;


namespace MSJTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("第一阶段", Stage.第一阶段.ToString());
            Assert.AreEqual("第一阶段",Enum.GetName(typeof(Stage), Stage.第一阶段));
        }
    }
}
