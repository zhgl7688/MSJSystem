using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class SummaryAssentTest
    {
        SummaryAssent summary = new SummaryAssent();
        [TestMethod]
        public void TestMethod1()
        {
            var result = summary.Get();
            Assert.AreEqual(18, result.Count);
        }
    }
}
