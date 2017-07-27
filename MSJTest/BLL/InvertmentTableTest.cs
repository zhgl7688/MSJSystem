using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;
using System.Linq;

namespace MSJTest.BLL
{
    [TestClass]
    public class InvertmentTableTest
    {
        InvestmentTable inverstmentTable = new InvestmentTable();
        [TestMethod]
        public void TestMethod1()
        {
            var ss = inverstmentTable.get();
            Assert.AreEqual(48, ss.FirstOrDefault(s => s.阶段.Contains("第一")).M.SurfaceRC1);
            Assert.AreEqual(493, ss.FirstOrDefault(s => s.阶段 .Contains( "第一")).AR.AR);
            Assert.AreEqual(98, ss.FirstOrDefault(s => s.阶段.Contains("第一")).BA.AO);
        }
    }
}
