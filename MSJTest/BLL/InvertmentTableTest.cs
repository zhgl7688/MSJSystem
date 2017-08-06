using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;
using System.Linq;

namespace MSJTest.BLL
{
    [TestClass]
    public class InvertmentTableTest
    {
        Investment inverstmentTable = new Investment();
        [TestMethod]
        public void TestMethod1()
        {
            var ss = inverstmentTable.Get();
            Assert.AreEqual(980, ss.FirstOrDefault(s => s.Stage.Contains("第一")).BK.AJ);
            Assert.AreEqual(2500, ss.FirstOrDefault(s => s.Stage .Contains( "第一")).DB.InputSum);
            Assert.AreEqual(75, ss.FirstOrDefault(s => s.Stage.Contains("第一")).BB.demonstrator);
            Assert.AreEqual(2000, ss.FirstOrDefault(s => s.Stage.Contains("第一")).B);
            Assert.AreEqual(3292, ss.FirstOrDefault(s => s.Stage.Contains("第二")).B);
            Assert.AreEqual(7585, ss.FirstOrDefault(s => s.Stage.Contains("第三")).B);
        }
    }
}
