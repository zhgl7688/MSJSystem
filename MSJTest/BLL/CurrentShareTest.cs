using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;


namespace MSJTest.BLL
{
    [TestClass]
    public class CurrentShareTest:BaseTest
    {
      
        [TestMethod]
        public void TestMethod1()
        {
            var result = currentShare.Get();
           // Assert.AreEqual(2, result.Count);
            Assert.AreEqual(0.357m, decimal.Round( result[1].H[0].M[0],3));
            Assert.AreEqual(26,decimal.Round( result[1].CT[0].Agent[1],0));

        }
    }
}
