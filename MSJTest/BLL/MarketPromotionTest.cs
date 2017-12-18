using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;


namespace MSJTest.BLL
{
    /// <summary>
    /// MarketPromotionTest 的摘要说明
    /// </summary>
    [TestClass]
    public class MarketPromotionTest:BaseTest
    {
         

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO:  在此处添加测试逻辑
            //
          var result=  marketPromotion.Get();
            //Assert.AreEqual(1, result.Count);
            Assert.AreEqual(240, result[0].B.M);
            Assert.AreEqual(230, result[0].B.Agent[3]);
            Assert.AreEqual(0.25m,Decimal.Round( result[0].AX.M[1],2));
            Assert.AreEqual(0.25m,decimal.Round( result[0].BP.M[1], 2));
            Assert.AreEqual(369, result[1].B.M);
            Assert.AreEqual(462, result[1].B.Agent[3]);
            Assert.AreEqual(0.52m, Decimal.Round(result[1].AX.M[1], 2));
            Assert.AreEqual(0.33m, decimal.Round(result[1].BP.M[1], 2));
            Assert.AreEqual(768, result[2].B.M);
            Assert.AreEqual(800, result[2].B.Agent[3]);
            Assert.AreEqual(0.6m, Decimal.Round(result[2].AX.M[1], 2));
            Assert.AreEqual(0.33m, decimal.Round(result[2].BP.M[1], 2));
        }
    }
}
