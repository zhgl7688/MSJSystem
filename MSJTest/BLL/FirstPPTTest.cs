using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WebMVC.BLL;


namespace MSJTest.BLL
{
    [TestClass]
    public class FirstPPTTest:BaseTest
    {
         [TestMethod]
        public void TestMethod1()
        {
            var result = firstPPT.GetFirstPPTList();
            Assert.AreEqual(3, result.brandInfos.Count);

        }
    }
}
