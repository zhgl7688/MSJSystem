using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class InvoicingReportTest
    {
        InvoicingReport invoicing = new InvoicingReport();
        [TestMethod]
        public void TestMethod1()
        {
            var result = invoicing.Get();
            Assert.AreEqual(4, result.Count);
           
        }
    }
}
