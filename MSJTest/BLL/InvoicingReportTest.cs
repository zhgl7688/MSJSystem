using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class InvoicingReportTest:BaseTest
    {
      
        [TestMethod]
        public void TestMethod1()
        {
            var result = invoicingReport.Get();
            Assert.AreEqual(4, result.Count);
           
        }
    }
}
