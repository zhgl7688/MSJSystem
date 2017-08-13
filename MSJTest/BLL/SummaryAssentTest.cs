using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class SummaryAssentTest:BaseTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            var result = summaryAssent.Get();
            Assert.AreEqual(18, result.Count);
        }
    }
}
