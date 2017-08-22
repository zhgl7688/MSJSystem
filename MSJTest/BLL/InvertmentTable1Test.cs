using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;
using System.Linq;
using WebMVC;

namespace MSJTest.BLL
{
    [TestClass]
    public class InvertmentTable1Test
    {
        InvertmentTable1 invertmentTable1 = new InvertmentTable1();
        [TestMethod]
        public void TestgetBrandsInputs()
        {
            var ss = invertmentTable1.getBrandTable();
           // Assert.AreEqual(3, ss.Count);
            Assert.AreEqual(2000, ss.FirstOrDefault(s => s.Brand ==WebMVC.Common.Brand.M品牌.ToString()).Sum);
            Assert.AreEqual(1020, ss.FirstOrDefault(s => s.Brand == WebMVC.Common.Brand.S品牌.ToString()).Sum);
            Assert.AreEqual(2000, ss.FirstOrDefault(s => s.Brand == WebMVC.Common.Brand.J品牌.ToString()).Sum);
        }
        [TestMethod]
        public void TestgetAgents()
        {
            var result = invertmentTable1.getAgents();
            Assert.AreEqual(80, result[0].J.servet);
        }
        [TestMethod]
        public void TestAgentCount()
        {
            var result = invertmentTable1.GetAgentCount;
            Assert.AreEqual(4, result);
        }
    }
}
