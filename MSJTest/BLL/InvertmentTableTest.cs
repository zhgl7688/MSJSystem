using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;
using System.Linq;

namespace MSJTest.BLL
{
    [TestClass]
    public class InvertmentTableTest:BaseTest
    {
         [TestMethod]
        public void TestMethod1()
        {
            var ss = investment.Get();
            Assert.AreEqual(980, ss.FirstOrDefault(s => s.Stage.Contains("第一")).AJAgent[4].AJ);
            Assert.AreEqual(2500, ss.FirstOrDefault(s => s.Stage .Contains( "第一")).CLAgent[2].InputSum);
            Assert.AreEqual(75, ss.FirstOrDefault(s => s.Stage.Contains("第一")).AJAgent[3].demonstrator);
            Assert.AreEqual(2000, ss.FirstOrDefault(s => s.Stage.Contains("第一")).B);
            Assert.AreEqual(3292, ss.FirstOrDefault(s => s.Stage.Contains("第二")).B);
            Assert.AreEqual(7585, ss.FirstOrDefault(s => s.Stage.Contains("第三")).B);
        }
    }
}
