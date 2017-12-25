using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    /// <summary>
    /// 进销存报表
    /// </summary>
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
