using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.Models;

namespace MSJTest.BLL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestActualSale()
        {
            //基础阶段
            var cts = new Dictionary<int, Dictionary<int, MJA>>();
            var ct = new Dictionary<int, MJA>();
            ct.Add(0, new MJA { Agent = new List<decimal> { 30, 30, 30, 30 } });
            cts.Add(0, ct);
            var ct1 = new Dictionary<int, MJA>();
            //第一阶段
            ct1.Add(0, new MJA { Agent = new List<decimal> { 24, 26, 28, 25 } });
            cts.Add(1, ct1);
            var ct2 = new Dictionary<int, MJA>();
            //第二阶段
            ct2.Add(0, new MJA { Agent = new List<decimal> { 33, 35, 39, 32 } });
            ct2.Add(1, new MJA { Agent = new List<decimal> { 31, 33, 22, 13 } });//cz6
            cts.Add(2, ct2);
            var ct3 = new Dictionary<int, MJA>();
            //第三阶段
            ct3.Add(0, new MJA { Agent = new List<decimal> { 38, 39, 40, 37 } });//ct7
            ct3.Add(1, new MJA { Agent = new List<decimal> { 29, 30, 31, 29 } });//cz7
            ct3.Add(2, new MJA { Agent = new List<decimal> { 15, 15, 16, 14 } });//df7
            cts.Add(3, ct3);
            //库存
            var d = new Dictionary<int, List<decimal>>();//int-阶段
            //d.Add(0, new List<decimal> { 1 });//D
            //d.Add(1, new List<decimal> { 7 });//i
            //d.Add(2, new List<decimal> { 0, 0 });//s,u
            d.Add(3, new List<decimal> { 0, 0, 0 });//ai,ak,am
            //进货
            var b = new Dictionary<int, List<decimal>>();
            b.Add(0, new List<decimal> { 31 });//B
            b.Add(1, new List<decimal> { 30 });//e
            b.Add(2, new List<decimal> { 10, 18 });//k,m
            b.Add(3, new List<decimal> { 20, 20, 11 });//w,y,aa

            var result = ActualSale(0, cts,out d, b);
            Assert.AreEqual(4, d.Count);

            

        }

        private Dictionary<int, List<decimal>> ActualSale(int v, Dictionary<int, Dictionary<int, MJA>> cts, out Dictionary<int, List<decimal>> d, Dictionary<int, List<decimal>> b)
        {

              d = new Dictionary<int, List<decimal>>();
           //v代理商次数
           var result = new Dictionary<int, List<decimal>>();

            result.Add(0, new List<decimal> { cts[0][0].Agent[v] });
            d.Add(0,new List<decimal> { b[0][0]- cts[0][0].Agent[v] });
            for (int i = 1; i < cts.Count; i++)//阶段次数 4次
            {
                result.Add(i , new List<decimal>());
                d.Add(i, new List<decimal>());
                for (int j = 0; j < i; j++)
                {
               
                    var ddt =i>1? (i - 1 == j ? 0 : d[i - 1][j] ): d[i - 1][j];
                    var val = cct(ddt, b[i][j], cts[i][j].Agent[v]);

                    result[i].Add(val);
                 
                    var ddtt = (ddt + b[i][j] - val) > 0 ? (ddt + b[i][j] - val) : 0;
                    d[i].Add(ddtt);
                }
            }


           

            return result;

        }
        public decimal cct(decimal d, decimal e, decimal ct)
        {
            return decimal.Round((d + e) < ct ? d + e : ct, 0);
        }
        public decimal cct(decimal m, decimal cz)
        {
            // ROUND(IF(M4 < 市场容量及各品牌当年占有率!CZ6, M4, 市场容量及各品牌当年占有率!CZ6), 0)
            return decimal.Round(m < cz ? m : cz, 0);
        }
        public Dictionary<int, List<decimal>> ActualSale(string agent, Dictionary<int, List<decimal>> ct,
           Dictionary<int, List<decimal>> d, Dictionary<int, List<decimal>> e)
        {
            var result = new Dictionary<int, List<decimal>>();
            result.Add(0, ct[0]);
            for (int i = 0; i < ct.Count; i++)//代理次数
            {
                //D基础库存，E第一进货，
                //第一阶段
                //  = ROUND(IF((D4 + E4) < 市场容量及各品牌当年占有率!CT5, (D4 + E4), 市场容量及各品牌当年占有率!CT5), 0)

                var value1 = decimal.Round((d[0][i] + e[1][i]) < ct[1][i] ? d[0][i] + e[1][i] : ct[1][i], 0);
                //第二阶段 
                //I第一库存，K第二进货rc1
                //=ROUND(IF((I4+K4)<市场容量及各品牌当年占有率!CT6,(I4+K4),市场容量及各品牌当年占有率!CT6),0)
                var value21 = decimal.Round((d[1][i] + e[2][i]) < ct[2][i] ? d[1][i] + e[2][i] : ct[2][i], 0);
                // = ROUND(IF(M4 < 市场容量及各品牌当年占有率!CZ6, M4, 市场容量及各品牌当年占有率!CZ6), 0)
                //M 第二进货rc2
                var value22 = decimal.Round((d[i][0] + e[1][0]) < ct[2][1] ? d[0][0] + e[1][0] : ct[1][0], 0);
                //= ROUND(IF((S4 + W4) < 市场容量及各品牌当年占有率!CT7, (S4 + W4), 市场容量及各品牌当年占有率!CT7), 0)
                // = ROUND(IF((U4 + Y4) < 市场容量及各品牌当年占有率!CZ7, (U4 + Y4), 市场容量及各品牌当年占有率!CZ7), 0)
                //= ROUND(IF(AA4 < 市场容量及各品牌当年占有率!DF7, AA4, 市场容量及各品牌当年占有率!DF7), 0)
            }
            //= 市场容量及各品牌当年占有率!CT4

            return result;

        }
    }
}
