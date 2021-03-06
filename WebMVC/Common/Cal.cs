﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.Common
{
    public static class Cal
    {
        public static decimal EndImage(decimal AJ, decimal CS, decimal CL)
        {
            //=IF(2*AJ5>=CS5,CL5/2,IF(AJ5<CL5/2,AJ5,CL5/2))
            return 2 * AJ >= CS ? CL / 2 : AJ < CL / 2 ? AJ : CL / 2;
        }
        public static decimal Salesperson(decimal AJ, decimal CS, decimal CM, decimal AK)
        {
            //=IF(2*AJ5>=CS5,CM5/2,IF((AJ5-AK5)<CM5/2,(AJ5-AK5),CM5/2))
            return 2 * AJ >= CS ? CM / 2 : AJ - AK < CM / 2 ? AJ - AK : CM / 2;
        }
        public static decimal Servet(decimal AJ, decimal CS, decimal CR, decimal AK, decimal AL)
        {
            //=IF(2*AJ5>=CS5,CR5/2,IF((AJ5-AK5-AL5)<CR5/2,(AJ5-AK5-AL5),CR5/2))
            return 2 * AJ >= CS ? CR / 2 : AJ - AK - AL < CR / 2 ? AJ - AK - AL : CR / 2;
        }
        public static decimal HousePromote(decimal AJ, decimal CS, decimal CN, decimal AK, decimal AL, decimal AQ)
        {
            //=IF(2*AJ5>=CS5,CN5/2,IF((AJ5-AK5-AL5-AQ5)<CN5/2,(AJ5-AK5-AL5-AQ5),CN5/2))
            return 2 * AJ >= CS ? CN / 2 : AJ - AK - AL - AQ < CN / 2 ? AJ - AK - AL - AQ : CN / 2;
        }
        public static decimal Demonstrator(decimal AJ, decimal CS, decimal CO, decimal AK, decimal AL, decimal AQ, decimal AM)
        {
            //=IF(2*AJ5>=CS5,CO5/2,IF((AJ5-AK5-AL5-AM5-AQ5)<CO5/2,(AJ5-AK5-AL5-AM5-AQ5),CO5/2))
            return 2 * AJ >= CS ? CO / 2 : AJ - AK - AL - AQ - AM < CO / 2 ? AJ - AK - AL - AQ - AM : CO / 2;
        }

        public static decimal OutdoorActivity(decimal AJ, decimal CS, decimal CP, decimal AK, decimal AL, decimal AQ, decimal AM, decimal AN)
        {
            //=IF(2*AJ5>=CS5,CP5/2,IF((AJ5-AK5-AL5-AM5-AN5-AQ5)<CP5/2,(AJ5-AK5-AL5-AM5-AN5-AQ5),CP5/2))
            return 2 * AJ >= CS ? CP / 2 : AJ - AK - AL - AQ - AM - AN < CP / 2 ? AJ - AK - AL - AQ - AM - AN : CP / 2;
        }
        public static decimal PromotionTeam(decimal AJ, decimal CS, decimal CQ, decimal AK, decimal AL, decimal AQ, decimal AM, decimal AN, decimal AO)
        {
            // =IF(2*AJ5>=CS5, CQ5/2, IF((AJ5-AK5-AL5-AM5-AN5-AO5-AQ5)<CQ5/2,(AJ5-AK5-AL5-AM5-AN5-AO5-AQ5),CQ5/2))
            return 2 * AJ >= CS ? CQ / 2 : AJ - AK - AL - AQ - AM - AN - AO < CQ / 2 ? AJ - AK - AL - AQ - AM - AN - AO : CQ / 2;
        }

        /// <summary>
        /// 品牌力指数CBPI
        /// </summary>
        /// <param name="lastE">上期的品牌力指数</param>
        /// <param name="lastK">上期的广告投放指数</param>
        /// <param name="lastN">上期的广告投放指数平均指数</param>
        /// <param name="currentK">当前的广告投放指数</param>
        /// <param name="currentN">当前的广告投放指数的平均指数</param>
        /// <returns></returns>
        public static decimal CBPI(decimal lastE, decimal lastK, decimal lastN, decimal currentK, decimal currentN)
        {
            //=E3*(1+35%*(K3-$N3)+65%*(K4-$N4))
            return lastE * (1 + 0.35M * (lastK - lastN) + 0.65m * (currentK - currentN));
        }
        /// <summary>
        /// 产出系数计算
        /// </summary>
        /// <param name="t"></param>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="avg"></param>
        /// <returns></returns>
        public static decimal OutputCoefficient(decimal t, decimal u, decimal v, decimal avg)
        {
            if (t > u && t > v)
                return 1.2m;
            else if (t < u && t < v)
                return 0.8m;
            else if (t > avg)
                return 1.1m;
            else if (t == avg)
                return 1m;
            else
                return 0.9m;

        }
        /// <summary>
        /// 创新指数计算
        /// </summary>
        /// <param name="k"></param>
        /// <param name="bd"></param>
        /// <param name="bg"></param>
        /// <param name="cb"></param>
        /// <param name="bp"></param>
        /// <param name="bs">平均指数</param>
        /// <param name="ck"></param>
        /// <returns></returns>
        public static decimal InnovationIndex(decimal k, decimal bd, decimal bg, decimal cb, decimal bp, decimal bs, decimal ck)
        {
            return k + (bd - bg) * cb * 0.4m + (bp - bs) * ck * 0.6m;
        }
        /// <summary>
        /// 市场推广指数
        /// </summary>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="z"></param>
        /// <param name="aa"></param>
        /// <param name="ab"></param>
        /// <param name="ah"></param>
        /// <param name="ai"></param>
        /// <param name="aj"></param>
        /// <param name="ap"></param>
        /// <param name="aq"></param>
        /// <param name="ar"></param>
        /// <returns></returns>
        public static decimal MarketingIndex(decimal b, decimal c, decimal d, decimal j, decimal k, decimal l, decimal r, decimal s,
            decimal t, decimal z, decimal aa, decimal ab, decimal ah, decimal ai, decimal aj, decimal ap, decimal aq, decimal ar)
        {
            var t1 = b + c + d;
            var t2 = j + k + l;
            var t3 = r + s + t;
            var t4 = z + aa + ab;
            var t5 = ah + ai + aj;
            var t6 = ap + aq + ar;
            if (t1 == 0 || t2 == 0 || t3 == 0 || t4 == 0 || t5 == 0 || t6 == 0) return 0;
            //=25%*B3/(B3+C3+D3)+25%*J3/(J3+K3+L3)+20%*R3/(R3+S3+T3)+15%*Z3/(Z3+AA3+AB3)+10%*AH3/(AH3+AI3+AJ3)+5%*AP3/(AP3+AQ3+AR3)
            return 0.25m * b / t1 + 0.25m * j / t2 + 0.20m * r / t3 + 0.15m * z / t4 + 0.10m * ah / t5 + 0.05m * ap / t6;
        }
        /// <summary>
        /// a / (a + b + c)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static decimal Percent(decimal a, decimal b, decimal c)
        {
            return a + b + c == 0 ? 0 : a / (a + b + c);
        }
        public static MJA SetMJA(this MJA mja)
        {
            //= IF(市场价格!$DF5 <= 599,$D$5 *$F5 * Z5, IF(市场价格!$DF5 <= 739,$D$6 *$F5 * Z5,$D$7 *$F5 * Z5))
            // mja.J1
            return mja;
        }
        public static decimal GetPositive(decimal a, decimal b)
        {
            if (b == 0) return b;
            return a / b < 0 ? 0 : a / b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mja"></param>
        /// <param name="count">从第一位开始到第几个</param>
        /// <param name="mjatype">平均的类型：M,J,Agent</param>
        /// <returns></returns>
        public static decimal GetMJAAverage(MJA mja, int count, MJAType mjatype)
        {
            Func<decimal[], int, decimal> av = (a, b) => (b == 0 ? 0 : a.Take(count).Sum() / b);
            switch (mjatype)
            {
                case MJAType.M: return av(mja.M.ToArray(), count);
                case MJAType.J: return av(mja.J.ToArray(), count);
                case MJAType.Agent: return av(mja.Agent.ToArray(), count);
            }
            return 0;
        }


        public static TChild AutoCopy<TParent, TChild>(TParent parent) where TChild : TParent, new()
        {
            TChild child = new TChild();
            var ParentType = typeof(TParent);
            var Properties = ParentType.GetProperties();
            foreach (var Propertie in Properties)
            {
                //循环遍历属性
                if (Propertie.CanRead && Propertie.CanWrite)
                {
                    //进行属性拷贝
                    Propertie.SetValue(child, Propertie.GetValue(parent, null), null);
                }
            }
            return child;
        }
        public static decimal FunctionIndex(decimal m, decimal s, decimal j, decimal Averaget)
        {
            return m > s && m > j ? 1.3m : m < s && m < j ? 0.7m : m > Averaget ? 1.15m : m == Averaget ? 1 : 0.85m;

        }

        /// <summary>
        ///    进销存报表中实际销售
        /// </summary>
        /// <param name="ct">市场容量及各品牌当年占有率!CT4</param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Dictionary<int, List<decimal>> ActualSale(int v, Dictionary<int, Dictionary<int, MJA>> cts, out Dictionary<int, List<decimal>> d, Dictionary<int, List<decimal>> b)
        {

            d = new Dictionary<int, List<decimal>>();
            //v代理商次数
            var result = new Dictionary<int, List<decimal>>();

            result.Add(0, new List<decimal> { cts[0][0].Agent[v] });
            d.Add(0, new List<decimal> { b[0][0] - cts[0][0].Agent[v] });
            for (int i = 1; i < cts.Count; i++)//阶段次数 4次
            {
                result.Add(i, new List<decimal>());
                d.Add(i, new List<decimal>());
                for (int j = 0; j < i; j++)
                {

                    var ddt = i > 1 ? (i - 1 == j ? 0 : d[i - 1][j]) : d[i - 1][j];
                    decimal rr = 0;
                    if (b.Count>i&&b[i]!=null&&b[i].Count>j&&
                        cts[i]!=null&& cts[i].Count>j&&
                        cts[i][j]!=null&& cts[i][j].Agent.Count>v)
                  rr = cct(ddt, b[i][j], cts[i][j].Agent[v]);

                    result[i].Add(rr);
                     var tt =    (b.Count > i && b[i] != null && b[i].Count > j)?
                 b[i][j]:0;
                    var ddtt = (ddt + tt - rr) > 0 ? (ddt +tt - rr) : 0;
                    d[i].Add(ddtt);
                }
            }




            return result;

        }


        public static decimal cct(decimal d, decimal e, decimal ct)
        {
            return decimal.Round((d + e) < ct ? d + e : ct, 0);
        }
    }
}