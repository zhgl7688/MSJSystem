using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;
using System.Linq;


namespace MSJTest.BLL
{
    [TestClass]
    public class InvertmentTable1Test
    {
        InvertmentTable1 invertmentTable1 = new InvertmentTable1();
        [TestMethod]
        public void TestgetBrandsInputs()
        {
            var ss = invertmentTable1.getBrandsInputs();
            Assert.AreEqual(3, ss.Count);
            Assert.AreEqual(2000, ss.FirstOrDefault(s => s.Brand == "M").Sum);
            Assert.AreEqual(1020, ss.FirstOrDefault(s => s.Brand == "S").Sum);
            Assert.AreEqual(2000, ss.FirstOrDefault(s => s.Brand == "J").Sum);
        }
    }
}
