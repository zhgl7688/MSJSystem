﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebMVC.Common;

namespace WebMVC.BLL
{
    /// <summary>
    /// 资产汇总表
    /// </summary>
    public class SummaryAssent
    {


        List<SummaryTable> summarys = new List<SummaryTable>();
        List<StockReportTable> stockReports;//=进货报表!F3
        List<InvoicingTable> invocicings;  // =进销存报表!E4*
        List<MarketTable> markets;   //市场价格!CE5
        List<InvestmentTable> investments;     //=投资表!B5
        List<CurrentShareTable> currentShares;    //市场容量及各品牌当年占有率
        public SummaryAssent(StockReport StockReport, InvoicingReport InvoicingReport, MarketPrice MarketPrice,
           Investment Investment, CurrentShare CurrentShare)
        {
            stockReports = StockReport.Get();
            invocicings = InvoicingReport.Get();
            markets = MarketPrice.Get();
            investments = Investment.Get();
            currentShares = CurrentShare.Get();
            Init();
        }
        public void Init()
        {

            #region 初始化表
            var summaryAssent1 = new SummaryTable { Id = 1, A = "期初库存" };
            var summaryAssent2 = new SummaryTable { Id = 2, A = "期初现金余额" };
            var summaryAssent3 = new SummaryTable { Id = 3, A = "银行借贷金额" };
            var summaryAssent4 = new SummaryTable { Id = 4, A = "期间销售额" };
            var summaryAssent5 = new SummaryTable { Id = 5, A = "期间销售成本" };
            var summaryAssent6 = new SummaryTable { Id = 6, A = "期间产生费用" };
            var summaryAssent7 = new SummaryTable { Id = 7, A = "卖场费用" };
            var summaryAssent8 = new SummaryTable { Id = 8, A = "卖场要求补差费用" };
            var summaryAssent9 = new SummaryTable { Id = 9, A = "期末库存" };
            var summaryAssent10 = new SummaryTable { Id = 10, A = "年末S品牌商费用投放返还" };
            var summaryAssent11 = new SummaryTable { Id = 11, A = "品牌商综合经营费用" };
            var summaryAssent12 = new SummaryTable { Id = 12, A = "期末现金余额" };
            var summaryAssent13 = new SummaryTable { Id = 13, A = "销售利润" };
            var summaryAssent14 = new SummaryTable { Id = 14, A = "应支付银行利息" };
            var summaryAssent15 = new SummaryTable { Id = 15, A = "库存需按照10%计提跌价损失" };
            var summaryAssent16 = new SummaryTable { Id = 16, A = "扣除计提跌价损失及银行利息后的利润" };
            var summaryAssent17 = new SummaryTable { Id = 17, A = "经营中损失的销售" };
            var summaryAssent18 = new SummaryTable { Id = 18, A = "经营中损失的金额" };
            summarys.Add(summaryAssent1);
            summarys.Add(summaryAssent2);
            summarys.Add(summaryAssent3);
            summarys.Add(summaryAssent4);
            summarys.Add(summaryAssent5);
            summarys.Add(summaryAssent6);
            summarys.Add(summaryAssent7);
            summarys.Add(summaryAssent8);
            summarys.Add(summaryAssent9);
            summarys.Add(summaryAssent10);
            summarys.Add(summaryAssent11);
            summarys.Add(summaryAssent12);
            summarys.Add(summaryAssent13);
            summarys.Add(summaryAssent14);
            summarys.Add(summaryAssent15);
            summarys.Add(summaryAssent16);
            summarys.Add(summaryAssent17);
            summarys.Add(summaryAssent18);
            summaryAssent2.B = summaryAssent2.C = summaryAssent2.D = summaryAssent2.E = summaryAssent2.F
                = summaryAssent2.G = summaryAssent2.H = summaryAssent2.I = 2000;
            summaryAssent2.J = summaryAssent2.K = summaryAssent2.L = summaryAssent2.M = summaryAssent2.N = summaryAssent2.O = 15000;
            #endregion
            var count = 4;
            var currentShare1 = currentShares.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            currentShare1 = currentShare1 ?? new CurrentShareTable();
            var currentShare2 = currentShares.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            currentShare2 = currentShare2 ?? new CurrentShareTable();
            var currentShare3 = currentShares.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            currentShare3 = currentShare3 ?? new CurrentShareTable();
            var investment1 = investments.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            currentShare1 = currentShare1 ?? new CurrentShareTable();
            var investment2 = investments.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            currentShare2 = currentShare2 ?? new CurrentShareTable();
            var investment3 = investments.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            currentShare3 = currentShare3 ?? new CurrentShareTable();
            var market1 = markets.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            market1 = market1 ?? new MarketTable();
            var market2 = markets.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            market2 = market2 ?? new MarketTable();
            var market3 = markets.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            market3 = market3 ?? new MarketTable();
            var stockReport1 = stockReports.Where(s => s.Stage == Stage.第一阶段.ToString());
             var stockReport2 = stockReports.Where(s => s.Stage == Stage.第二阶段.ToString());
            var stockReport3 = stockReports.Where(s => s.Stage == Stage.第三阶段.ToString());
            // AVERAGE(市场容量及各品牌当年占有率!CB5:CE5)
            var cb5_ce5 = Common.Cal.GetMJAAverage(currentShare1.CB[1], count, MJAType.J); 
            //AVERAGE(市场容量及各品牌当年占有率!BJ5:BM5)
            var bj5_bm5 = Common.Cal.GetMJAAverage(currentShare1.BJ[1], count, MJAType.M);


            //AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6)
            var bj6_bm6 = Common.Cal.GetMJAAverage(currentShare2.BJ[1], count, MJAType.M);
            //AVERAGE(市场容量及各品牌当年占有率!BP6:BS6
            var bp6_bs6 = Common.Cal.GetMJAAverage(currentShare2.BJ[2], count, MJAType.M);
            // AVERAGE(市场容量及各品牌当年占有率!CB6:CE6)
            var cb6_ce6 = Common.Cal.GetMJAAverage(currentShare2.CB[1], count, MJAType.J);
            //AVERAGE(市场容量及各品牌当年占有率!CH6:CK6
            var ch6_ck6 = Common.Cal.GetMJAAverage(currentShare2.CB[2], count, MJAType.J);

            //AVERAGE(市场容量及各品牌当年占有率!BJ7:BM7
            var bj7_bm7 = Common.Cal.GetMJAAverage(currentShare3.BJ[1], count, MJAType.M);
            //AVERAGE(市场容量及各品牌当年占有率!BP7:BS7
            var bp7_bs7 = Common.Cal.GetMJAAverage(currentShare3.BJ[2], count, MJAType.M);
            //AVERAGE(市场容量及各品牌当年占有率!BV7:BY7)
            var bv7_by7 = Common.Cal.GetMJAAverage(currentShare3.BJ[3], count, MJAType.M);
            // AVERAGE(市场容量及各品牌当年占有率!CB7:CE7)
            var cb7_ce7 = Common.Cal.GetMJAAverage(currentShare3.CB[1], count, MJAType.J);
            //AVERAGE(市场容量及各品牌当年占有率!CH7:CK7
            var ch7_ck7 = Common.Cal.GetMJAAverage(currentShare3.CB[2], count, MJAType.J);
            //AVERAGE(市场容量及各品牌当年占有率!CN7:CQ7)
            var cn7_cq7 = Common.Cal.GetMJAAverage(currentShare3.CB[3], count, MJAType.J);

            var de5 = market1.DE[1].M;//市场价格!DF6
            var df5 = market1.DE[1].J;//市场价格!DH6
            var df6 = market2.DE[1].J;//市场价格!DF6
            var dh6 = market2.DE[2].J;//市场价格!DH6

            foreach (var item in invocicings)
            {
                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                switch (agentName)
                {
                    case AgentName.代1:
                        summaryAssent1.J = item.D;
                        summaryAssent4.J = item.G * market1.EF[1].Agent1;
                        summaryAssent4.X = item.O * market2.EF[1].Agent1 + item.Q * market2.EF[2].Agent1;
                        summaryAssent4.AL = item.AC * market3.EF[1].Agent1 + item.AE * market3.EF[2].Agent1 + item.AG * market3.EF[3].Agent1;
                        summaryAssent5.C = item.E * market1.CD[1].S;
                        summaryAssent5.J = item.G * market1.CM[1].S;
                        summaryAssent5.X = item.O * market2.CM[1].S + item.Q * market2.CM[2].S;
                        summaryAssent5.AE = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AL = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.J = item.G * market1.DK[1].Agent1 * 0.05m + item.G * market1.EF[1].Agent1 * 0.06m + 300;
                        if (item.H != 0) summaryAssent7.X = item.O * market2.DK[1].Agent1 * 0.05m + item.O * market2.EF[1].Agent1 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent1 * 0.05m + item.Q * market2.EF[2].Agent1 * 0.06m + 300;
                        if (item.P != 0 && item.R != 0) summaryAssent7.AL = item.AC * market3.DK[1].Agent1 * 0.05m + item.AC * market3.EF[1].Agent1 *
                                   ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent1 * 0.05m + item.AE * market3.EF[2].Agent1
                                   * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent1 * 0.05m +
                                   item.AG * market3.EF[3].Agent1 * 0.06m + 300;
                        summaryAssent8.J = item.G * (market1.EF[1].Agent1 > market1.DK[1].Agent1 ? (market1.EF[1].Agent1 - market1.DK[1].Agent1) : 0);
                        summaryAssent8.X = item.O * (market2.EF[1].Agent1 > market2.DK[1].Agent1 ? (market2.EF[1].Agent1 - market2.DK[1].Agent1) : 0) +
                            item.Q * (market2.EF[2].Agent1 > market2.DK[2].Agent1 ? (market2.EF[2].Agent1 - market2.DK[2].Agent1) : 0);
                        summaryAssent8.AL = item.AC * (market3.EF[1].Agent1 > market3.DK[1].Agent1 ? (market3.EF[1].Agent1 - market3.DK[1].Agent1) : 0) +
                            item.AE * (market3.EF[2].Agent1 > market3.DK[2].Agent1 ? (market3.EF[2].Agent1 - market3.DK[2].Agent1) : 0) +
                            item.AG * (market3.EF[3].Agent1 > market3.DK[3].Agent1 ? (market3.EF[3].Agent1 - market3.DK[3].Agent1) : 0);
                        summaryAssent1.X = summaryAssent9.J = item.I;
                        summaryAssent15.J = summaryAssent9.J * market1.CM[1].S * 0.10m;
                        summaryAssent1.AL = summaryAssent9.X = item.S + item.U;
                        summaryAssent9.AL = item.AI + item.AK + item.AM;
                        summaryAssent15.X = (item.S * market2.CM[1].S + item.U * market2.CM[2].S) * 0.10m;
                        summaryAssent15.AL = (item.AI * market3.CM[1].S + item.AK * market3.CM[2].S + item.AM * market3.CM[3].S) * 0.10m;

                        break;
                    case AgentName.代2:
                        summaryAssent1.K = item.D;
                        summaryAssent4.K = item.G * market1.EF[1].Agent2;
                        summaryAssent4.Y = item.O * market2.EF[1].Agent2 + item.Q * market2.EF[2].Agent2;
                        summaryAssent4.AM = item.AC * market3.EF[1].Agent2 + item.AE * market3.EF[2].Agent2 + item.AG * market3.EF[3].Agent2;
                        summaryAssent5.D = item.E * market1.CD[1].S;
                        summaryAssent5.K = item.G * market1.CM[1].S;
                        summaryAssent5.Y = item.O * market2.CM[1].S + item.Q * market2.CM[2].S;
                        summaryAssent5.AF = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AM = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.K = item.G * market1.DK[1].Agent2 * 0.05m + item.G * market1.EF[1].Agent2 * 0.06m + 300;
                        if (item.H != 0) summaryAssent7.Y = item.O * market2.DK[1].Agent2 * 0.05m + item.O * market2.EF[1].Agent2 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent2 * 0.05m + item.Q * market2.EF[2].Agent2 * 0.06m + 300;
                        if (item.P != 0 && item.R != 0) summaryAssent7.AM = item.AC * market3.DK[1].Agent2 * 0.05m + item.AC * market3.EF[1].Agent2 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent2 * 0.05m + item.AE * market3.EF[2].Agent2
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent2 * 0.05m +
                          item.AG * market3.EF[3].Agent2 * 0.06m + 300;
                        summaryAssent8.K = item.G * (market1.EF[1].Agent2 > market1.DK[1].Agent2 ? (market1.EF[1].Agent2 - market1.DK[1].Agent2) : 0);
                        summaryAssent8.Y = item.O * (market2.EF[1].Agent2 > market2.DK[1].Agent2 ? (market2.EF[1].Agent2 - market2.DK[1].Agent2) : 0) +
                         item.Q * (market2.EF[2].Agent2 > market2.DK[2].Agent2 ? (market2.EF[2].Agent2 - market2.DK[2].Agent2) : 0);
                        summaryAssent8.AM = item.AC * (market3.EF[1].Agent2 > market3.DK[1].Agent2 ? (market3.EF[1].Agent2 - market3.DK[1].Agent2) : 0) +
                         item.AE * (market3.EF[2].Agent2 > market3.DK[2].Agent2 ? (market3.EF[2].Agent2 - market3.DK[2].Agent2) : 0) +
                         item.AG * (market3.EF[3].Agent2 > market3.DK[3].Agent2 ? (market3.EF[3].Agent2 - market3.DK[3].Agent2) : 0);
                        summaryAssent1.Y = summaryAssent9.K = item.I;
                        summaryAssent15.K = summaryAssent9.K * market1.CM[1].S * 0.10m;
                        summaryAssent1.AM = summaryAssent9.Y = item.S + item.U;
                        summaryAssent9.AM = item.AI + item.AK + item.AM;
                        summaryAssent15.Y = (item.S * market2.CM[1].S + item.U * market2.CM[2].S) * 0.10m;
                        summaryAssent15.AM = (item.AI * market3.CM[1].S + item.AK * market3.CM[2].S + item.AM * market3.CM[3].S) * 0.10m;

                        break;
                    case AgentName.代3:
                        summaryAssent1.L = item.D;
                        summaryAssent4.L = item.G * market1.EF[1].Agent3;
                        summaryAssent4.Z = item.O * market2.EF[1].Agent3 + item.Q * market2.EF[2].Agent3;
                        summaryAssent4.AN = item.AC * market3.EF[1].Agent3 + item.AE * market3.EF[2].Agent3 + item.AG * market3.EF[3].Agent3;
                        summaryAssent5.E = item.E * market1.CD[1].S;
                        summaryAssent5.L = item.G * market1.CM[1].S;
                        summaryAssent5.Z = item.O * market2.CM[1].S + item.Q * market2.CM[2].S;
                        summaryAssent5.AG = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AN = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.L = item.G * market1.DK[1].Agent3 * 0.05m + item.G * market1.EF[1].Agent3 * 0.06m + 300;
                        if (item.H != 0) summaryAssent7.Z = item.O * market2.DK[1].Agent3 * 0.05m + item.O * market2.EF[1].Agent3 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent3 * 0.05m + item.Q * market2.EF[2].Agent3 * 0.06m + 300;
                        if (item.P != 0 && item.R != 0) summaryAssent7.AN = item.AC * market3.DK[1].Agent3 * 0.05m + item.AC * market3.EF[1].Agent3 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent3 * 0.05m + item.AE * market3.EF[2].Agent3
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent3 * 0.05m +
                          item.AG * market3.EF[3].Agent3 * 0.06m + 300;
                        summaryAssent8.L = item.G * (market1.EF[1].Agent3 > market1.DK[1].Agent3 ? (market1.EF[1].Agent3 - market1.DK[1].Agent3) : 0);
                        summaryAssent8.Z = item.O * (market2.EF[1].Agent3 > market2.DK[1].Agent3 ? (market2.EF[1].Agent3 - market2.DK[1].Agent3) : 0) +
                         item.Q * (market2.EF[2].Agent3 > market2.DK[2].Agent3 ? (market2.EF[2].Agent3 - market2.DK[2].Agent3) : 0);
                        summaryAssent8.AN = item.AC * (market3.EF[1].Agent3 > market3.DK[1].Agent3 ? (market3.EF[1].Agent3 - market3.DK[1].Agent3) : 0) +
                         item.AE * (market3.EF[2].Agent3 > market3.DK[2].Agent3 ? (market3.EF[2].Agent3 - market3.DK[2].Agent3) : 0) +
                         item.AG * (market3.EF[3].Agent3 > market3.DK[3].Agent3 ? (market3.EF[3].Agent3 - market3.DK[3].Agent3) : 0);
                        summaryAssent1.Z = summaryAssent9.L = item.I;
                        summaryAssent15.L = summaryAssent9.L * market1.CM[1].S * 0.10m;

                        summaryAssent1.AN = summaryAssent9.Z = item.S + item.U;
                        summaryAssent9.AN = item.AI + item.AK + item.AM;
                        summaryAssent15.Z = (item.S * market2.CM[1].S + item.U * market2.CM[2].S) * 0.10m;
                        summaryAssent15.AN = (item.AI * market3.CM[1].S + item.AK * market3.CM[2].S + item.AM * market3.CM[3].S) * 0.10m;

                        break;
                    case AgentName.代4:
                        summaryAssent1.M = item.D;
                        summaryAssent4.M = item.G * market1.EF[1].Agent4;
                        summaryAssent4.AA = item.O * market2.EF[1].Agent4 + item.Q * market2.EF[2].Agent4;
                        summaryAssent4.AO = item.AC * market3.EF[1].Agent4 + item.AE * market3.EF[2].Agent4 + item.AG * market3.EF[3].Agent4;
                        summaryAssent5.F = item.E * market1.CD[1].S;
                        summaryAssent5.M = item.G * market1.CM[1].S;
                        summaryAssent5.AA = item.O * market2.CM[1].S + item.Q * market2.CM[2].S;
                        summaryAssent5.AH = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AO = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.M = item.G * market1.DK[1].Agent4 * 0.05m + item.G * market1.EF[1].Agent4 * 0.06m + 300;
                        if (item.H != 0) summaryAssent7.AA = item.O * market2.DK[1].Agent4 * 0.05m + item.O * market2.EF[1].Agent4 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent4 * 0.05m + item.Q * market2.EF[2].Agent4 * 0.06m + 300;
                        if (item.P != 0 && item.R != 0) summaryAssent7.AO = item.AC * market3.DK[1].Agent4 * 0.05m + item.AC * market3.EF[1].Agent4 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent4 * 0.05m + item.AE * market3.EF[2].Agent4
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent4 * 0.05m +
                          item.AG * market3.EF[3].Agent4 * 0.06m + 300;
                        summaryAssent8.M = item.G * (market1.EF[1].Agent4 > market1.DK[1].Agent4 ? (market1.EF[1].Agent4 - market1.DK[1].Agent4) : 0);
                        summaryAssent8.AA = item.O * (market2.EF[1].Agent4 > market2.DK[1].Agent4 ? (market2.EF[1].Agent4 - market2.DK[1].Agent4) : 0) +
                         item.Q * (market2.EF[2].Agent4 > market2.DK[2].Agent4 ? (market2.EF[2].Agent4 - market2.DK[2].Agent4) : 0);
                        summaryAssent8.AO = item.AC * (market3.EF[1].Agent4 > market3.DK[1].Agent4 ? (market3.EF[1].Agent4 - market3.DK[1].Agent4) : 0) +
                         item.AE * (market3.EF[2].Agent4 > market3.DK[2].Agent4 ? (market3.EF[2].Agent4 - market3.DK[2].Agent4) : 0) +
                         item.AG * (market3.EF[3].Agent4 > market3.DK[3].Agent4 ? (market3.EF[3].Agent4 - market3.DK[3].Agent4) : 0);
                        summaryAssent1.AA = summaryAssent9.M = item.I;
                        summaryAssent15.M = summaryAssent9.M * market1.CM[1].S * 0.10m;
                        summaryAssent1.AO = summaryAssent9.AA = item.S + item.U;
                        summaryAssent9.AO = item.AI + item.AK + item.AM;
                        summaryAssent15.AA = (item.S * market2.CM[1].S + item.U * market2.CM[2].S) * 0.10m;
                        summaryAssent15.AO = (item.AI * market3.CM[1].S + item.AK * market3.CM[2].S + item.AM * market3.CM[3].S) * 0.10m;

                        break;
                    case AgentName.代5:
                        summaryAssent1.N = item.D;
                        summaryAssent4.N = item.G * market1.EF[1].Agent5;
                        summaryAssent4.AB = item.O * market2.EF[1].Agent5 + item.Q * market2.EF[2].Agent5;
                        summaryAssent4.AP = item.AC * market3.EF[1].Agent5 + item.AE * market3.EF[2].Agent5 + item.AG * market3.EF[3].Agent5;
                        summaryAssent5.G = item.E * market1.CD[1].S;
                        summaryAssent5.N = item.G * market1.CM[1].S;
                        summaryAssent5.AB = item.O * market2.CM[1].S + item.Q * market2.CM[2].S;
                        summaryAssent5.AI = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AP = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.N = item.G * market1.DK[1].Agent5 * 0.05m + item.G * market1.EF[1].Agent5 * 0.06m + 300;
                        if (item.H != 0) summaryAssent7.AB = item.O * market2.DK[1].Agent5 * 0.05m + item.O * market2.EF[1].Agent5 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent5 * 0.05m + item.Q * market2.EF[2].Agent5 * 0.06m + 300;
                        if (item.P != 0 && item.R != 0) summaryAssent7.AP = item.AC * market3.DK[1].Agent5 * 0.05m + item.AC * market3.EF[1].Agent5 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent5 * 0.05m + item.AE * market3.EF[2].Agent5
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent5 * 0.05m +
                          item.AG * market3.EF[3].Agent5 * 0.06m + 300;
                        summaryAssent8.N = item.G * (market1.EF[1].Agent5 > market1.DK[1].Agent5 ? (market1.EF[1].Agent5 - market1.DK[1].Agent5) : 0);
                        summaryAssent8.AB = item.O * (market2.EF[1].Agent5 > market2.DK[1].Agent5 ? (market2.EF[1].Agent5 - market2.DK[1].Agent5) : 0) +
                         item.Q * (market2.EF[2].Agent5 > market2.DK[2].Agent5 ? (market2.EF[2].Agent5 - market2.DK[2].Agent5) : 0);
                        summaryAssent8.AP = item.AC * (market3.EF[1].Agent5 > market3.DK[1].Agent5 ? (market3.EF[1].Agent5 - market3.DK[1].Agent5) : 0) +
                         item.AE * (market3.EF[2].Agent5 > market3.DK[2].Agent5 ? (market3.EF[2].Agent5 - market3.DK[2].Agent5) : 0) +
                         item.AG * (market3.EF[3].Agent5 > market3.DK[3].Agent5 ? (market3.EF[3].Agent5 - market3.DK[3].Agent5) : 0);
                        summaryAssent1.AB = summaryAssent9.N = item.I;
                        summaryAssent15.N = summaryAssent9.N * market1.CM[1].S * 0.10m;
                        summaryAssent1.AP = summaryAssent9.AB = item.S + item.U;
                        summaryAssent9.AP = item.AI + item.AK + item.AM;
                        summaryAssent15.AB = (item.S * market2.CM[1].S + item.U * market2.CM[2].S) * 0.10m;
                        summaryAssent15.AP = (item.AI * market3.CM[1].S + item.AK * market3.CM[2].S + item.AM * market3.CM[3].S) * 0.10m;

                        break;
                    case AgentName.代6:
                        summaryAssent1.O = item.D;
                        summaryAssent4.O = item.G * market1.EF[1].Agent6;
                        summaryAssent4.AC = item.O * market2.EF[1].Agent6 + item.Q * market2.EF[2].Agent6;
                        summaryAssent4.AQ = item.AC * market3.EF[1].Agent6 + item.AE * market3.EF[2].Agent6 + item.AG * market3.EF[3].Agent6;
                        summaryAssent5.H = item.E * market1.CD[1].S;
                        summaryAssent5.O = item.G * market1.CM[1].S;
                        summaryAssent5.AC = item.O * market2.CM[1].S + item.Q * market2.CM[2].S;
                        summaryAssent5.AJ = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AQ = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.O = item.G * market1.DK[1].Agent6 * 0.05m + item.G * market1.EF[1].Agent6 * 0.06m + 300;
                        if (item.H != 0) summaryAssent7.AC = item.O * market2.DK[1].Agent6 * 0.05m + item.O * market2.EF[1].Agent6 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent6 * 0.05m + item.Q * market2.EF[2].Agent6 * 0.06m + 300;
                        if (item.P != 0 && item.R != 0) summaryAssent7.AQ = item.AC * market3.DK[1].Agent6 * 0.05m + item.AC * market3.EF[1].Agent6 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent6 * 0.05m + item.AE * market3.EF[2].Agent6
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent6 * 0.05m +
                          item.AG * market3.EF[3].Agent6 * 0.06m + 300;
                        summaryAssent8.O = item.G * (market1.EF[1].Agent6 > market1.DK[1].Agent6 ? (market1.EF[1].Agent6 - market1.DK[1].Agent6) : 0);
                        summaryAssent8.AC = item.O * (market2.EF[1].Agent6 > market2.DK[1].Agent6 ? (market2.EF[1].Agent6 - market2.DK[1].Agent6) : 0) +
                         item.Q * (market2.EF[2].Agent6 > market2.DK[2].Agent6 ? (market2.EF[2].Agent6 - market2.DK[2].Agent6) : 0);
                        summaryAssent8.AQ = item.AC * (market3.EF[1].Agent6 > market3.DK[1].Agent6 ? (market3.EF[1].Agent6 - market3.DK[1].Agent6) : 0) +
                         item.AE * (market3.EF[2].Agent6 > market3.DK[2].Agent6 ? (market3.EF[2].Agent6 - market3.DK[2].Agent6) : 0) +
                         item.AG * (market3.EF[3].Agent6 > market3.DK[3].Agent6 ? (market3.EF[3].Agent6 - market3.DK[3].Agent6) : 0);
                        summaryAssent1.AC = summaryAssent9.O = item.I;
                        summaryAssent15.O = summaryAssent9.O * market1.CM[1].S * 0.10m;
                        summaryAssent1.AQ = summaryAssent9.AC = item.S + item.U;
                        summaryAssent9.AQ = item.AI + item.AK + item.AM;
                        summaryAssent15.AC = (item.S * market2.CM[1].S + item.U * market2.CM[2].S) * 0.10m;
                        summaryAssent15.AQ = (item.AI * market3.CM[1].S + item.AK * market3.CM[2].S + item.AM * market3.CM[3].S) * 0.10m;

                        break;
                    default:
                        break;
                }
            }

            foreach (var item in investment1.EI.Keys)
            {
                switch (item)
                {
                    case 1: summaryAssent3.J = investment1.EI[item]; break;
                    case 2: summaryAssent3.K = investment1.EI[item]; break;
                    case 3: summaryAssent3.L = investment1.EI[item]; break;
                    case 4: summaryAssent3.M = investment1.EI[item]; break;
                    case 5: summaryAssent3.N = investment1.EI[item]; break;
                    case 6: summaryAssent3.O = investment1.EI[item]; break;
                }
            }
            summaryAssent14.J = summaryAssent3.J * 0.08m;
            summaryAssent14.K = summaryAssent3.K * 0.08m;
            summaryAssent14.L = summaryAssent3.L * 0.08m;
            summaryAssent14.M = summaryAssent3.M * 0.08m;
            summaryAssent14.N = summaryAssent3.N * 0.08m;
            summaryAssent14.O = summaryAssent3.O * 0.08m;

            foreach (var item in investment2.EI.Keys)
            {
                switch (item)
                {
                    case 1: summaryAssent3.X = investment2.EI[item]; break;
                    case 2: summaryAssent3.Y = investment2.EI[item]; break;
                    case 3: summaryAssent3.Z = investment2.EI[item]; break;
                    case 4: summaryAssent3.AA = investment2.EI[item]; break;
                    case 5: summaryAssent3.AB = investment2.EI[item]; break;
                    case 6: summaryAssent3.AC = investment2.EI[item]; break;

                }
            }
            summaryAssent14.X = summaryAssent3.X * 0.08m;
            summaryAssent14.Y = summaryAssent3.Y * 0.08m;
            summaryAssent14.Z = summaryAssent3.Z * 0.08m;
            summaryAssent14.AA = summaryAssent3.AA * 0.08m;
            summaryAssent14.AB = summaryAssent3.AB * 0.08m;
            summaryAssent14.AC = summaryAssent3.AC * 0.08m;
            foreach (var item in investment3.EI.Keys)
            {
                switch (item)
                {
                    case 1: summaryAssent3.AL = investment3.EI[item]; break;
                    case 2: summaryAssent3.AM = investment3.EI[item]; break;
                    case 3: summaryAssent3.AN = investment3.EI[item]; break;
                    case 4: summaryAssent3.AO = investment3.EI[item]; break;
                    case 5: summaryAssent3.AP = investment3.EI[item]; break;
                    case 6: summaryAssent3.AQ = investment3.EI[item]; break;
                }
            }
            summaryAssent14.AL = summaryAssent3.AL * 0.08m;
            summaryAssent14.AM = summaryAssent3.AM * 0.08m;
            summaryAssent14.AN = summaryAssent3.AN * 0.08m;
            summaryAssent14.AO = summaryAssent3.AO * 0.08m;
            summaryAssent14.AP = summaryAssent3.AP * 0.08m;
            summaryAssent14.AQ = summaryAssent3.AQ * 0.08m;

            summaryAssent4.B = bj5_bm5 * market1.DE[1].M / (1 + 0.10m);
            summaryAssent11.B = summaryAssent4.B * 0.19m;


            foreach (var item in stockReport1)
            {
                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                switch (agentName)
                {
                    case AgentName.代1: summaryAssent4.C = item.E[1].Amount; break;
                    case AgentName.代2: summaryAssent4.D = item.E[1].Amount; break;
                    case AgentName.代3: summaryAssent4.E = item.E[1].Amount; break;
                    case AgentName.代4: summaryAssent4.F = item.E[1].Amount; break;
                    case AgentName.代5: summaryAssent4.G = item.E[1].Amount; break;
                    case AgentName.代6: summaryAssent4.H = item.E[1].Amount; break;

                }
            }

            summaryAssent11.C = summaryAssent4.C * 0.2m;
            summaryAssent11.D = summaryAssent4.D * 0.2m;
            summaryAssent11.E = summaryAssent4.E * 0.2m;
            summaryAssent11.F = summaryAssent4.F * 0.2m;
            summaryAssent11.G = summaryAssent4.G * 0.2m;
            summaryAssent11.H = summaryAssent4.H * 0.2m;

            summaryAssent4.I = cb5_ce5 * market1.DE[1].J / (1 + 0.12m);
            summaryAssent11.I = summaryAssent4.I * 0.2m;

            summaryAssent4.P = bj6_bm6 * market2.DE[1].M / (1 + 0.10m) + bp6_bs6 * market2.DE[2].M / (1 + 0.10m);
            summaryAssent11.P = summaryAssent4.P * 0.19m;

            foreach (var item in stockReport2)
            {
                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                switch (agentName)
                {
                    case AgentName.代1:
                        //=进货报表!B13*市场价格!$CE$6+进货报表!D13*市场价格!$CH$6
                        summaryAssent5.Q = item.E[1].Stock * market2.CD[1].S + item.E[2].Stock * market2.CD[2].S;
                        summaryAssent4.Q = item.Sum.Sum;
                        break;
                    case AgentName.代2:
                        summaryAssent5.R = item.E[1].Stock * market2.CD[1].S + item.E[1].Stock * market2.CD[2].S;
                        summaryAssent4.R = item.Sum.Sum;
                        break;
                    case AgentName.代3:
                        summaryAssent5.S = item.E[1].Stock * market2.CD[1].S + item.E[1].Stock * market2.CD[2].S;
                        summaryAssent4.S = item.Sum.Sum;
                        break;
                    case AgentName.代4:
                        summaryAssent5.T = item.E[1].Stock * market2.CD[1].S + item.E[1].Stock * market2.CD[2].S;
                        summaryAssent4.T = item.Sum.Sum;
                        break;
                    case AgentName.代5:
                        summaryAssent5.U = item.E[1].Stock * market2.CD[1].S + item.E[1].Stock * market2.CD[2].S;
                        summaryAssent4.U = item.Sum.Sum;
                        break;
                    case AgentName.代6:
                        summaryAssent5.V = item.E[1].Stock * market2.CD[1].S + item.E[1].Stock * market2.CD[2].S;
                        summaryAssent4.V = item.Sum.Sum;
                        break;
                    default:
                        break;
                }
            }


            summaryAssent11.Q = summaryAssent4.Q * 0.2m;
            summaryAssent11.R = summaryAssent4.R * 0.2m;
            summaryAssent11.S = summaryAssent4.S * 0.2m;
            summaryAssent11.T = summaryAssent4.T * 0.2m;
            summaryAssent11.U = summaryAssent4.U * 0.2m;
            summaryAssent11.V = summaryAssent4.V * 0.2m;


            summaryAssent4.W = cb6_ce6 * market2.DE[1].J / (1 + 0.12m) + ch6_ck6 * market2.DE[2].J / (1 + 0.12m);
            summaryAssent11.W = summaryAssent4.W * 0.2m;
            //=AVERAGE(市场容量及各品牌当年占有率!BJ7:BM7)*市场价格!DE7/(1+10%)+
            //AVERAGE(市场容量及各品牌当年占有率!BP7:BS7)*市场价格!DG7/(1+10%)+
            //AVERAGE(市场容量及各品牌当年占有率!BV7:BY7)*市场价格!DI7/(1+10%)
            summaryAssent4.AD = bj7_bm7 * market3.DE[1].M / (1 + 0.10m) + bp7_bs7 * market3.DE[2].M / (1 + 0.10m)
                +bv7_by7*market3.DE[3].M/(1+0.10m);
            summaryAssent11.AD = summaryAssent4.AD * 0.19m;


            foreach (var item in stockReport3)
            {
                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                switch (agentName)
                {
                    case AgentName.代1: summaryAssent4.AE = item.Sum.Sum; break;
                    case AgentName.代2: summaryAssent4.AF = item.Sum.Sum; break;
                    case AgentName.代3: summaryAssent4.AG = item.Sum.Sum; break;
                    case AgentName.代4: summaryAssent4.AH = item.Sum.Sum; break;
                    case AgentName.代5: summaryAssent4.AI = item.Sum.Sum; break;
                    case AgentName.代6: summaryAssent4.AJ = item.Sum.Sum; break;
                }
            }
            summaryAssent11.AE = summaryAssent4.AE * 0.2m;
            summaryAssent11.AF = summaryAssent4.AF * 0.2m;
            summaryAssent11.AG = summaryAssent4.AG * 0.2m;
            summaryAssent11.AH = summaryAssent4.AH * 0.2m;
            summaryAssent11.AI = summaryAssent4.AI * 0.2m;
            summaryAssent11.AJ = summaryAssent4.AJ * 0.2m;
            // = AVERAGE(市场容量及各品牌当年占有率!CB7:CE7) * 市场价格!DF7 / (1 + 12 %) + 
            //AVERAGE(市场容量及各品牌当年占有率!CH7:CK7) * 市场价格!DH7 / (1 + 12 %) +
            //AVERAGE(市场容量及各品牌当年占有率!CN7:CQ7) * 市场价格!DJ7 / (1 + 12 %)
            summaryAssent4.AK = cb7_ce7 * market3.DE[1].J / (1 + 0.12m) + ch7_ck7 * market3.DE[2].J / (1 + 0.12m) + cn7_cq7 * market3.DE[3].J / (1 + 0.12m);
            summaryAssent11.AK = summaryAssent4.AK * 0.2m;

            summaryAssent5.B = bj5_bm5 * market1.CD[1].M;
            summaryAssent5.I = cb5_ce5 * market1.CD[1].J;
            summaryAssent5.P = bj6_bm6 * market2.CD[1].M + bp6_bs6 * market2.CD[2].M;
            summaryAssent5.W = cb6_ce6 * market2.CD[1].J + ch6_ck6 * market2.CD[2].J;
            summaryAssent5.AD = bj7_bm7 * market3.CD[1].M + bp7_bs7 * market3.CD[2].M + bv7_by7 * market3.CD[3].M;
            summaryAssent5.AK = cb7_ce7 * market3.CD[1].J + ch7_ck7 * market3.CD[2].J + cn7_cq7 * market3.CD[3].J;

            #region 期间产生费用
            summaryAssent6.B = investment1.B;
            summaryAssent6.C = investment1.C;
            summaryAssent6.D = investment1.D;
            summaryAssent6.E = investment1.E;
            summaryAssent6.F = investment1.F;
            summaryAssent6.G = investment1.G;
            summaryAssent6.H = investment1.H;
            summaryAssent6.I = investment1.I;
            summaryAssent6.J = investment1.CL.InputSum;
            summaryAssent6.K = investment1.CT.InputSum;
            summaryAssent6.L = investment1.DB.InputSum;
            summaryAssent6.M = investment1.DJ.InputSum;
            summaryAssent6.N = investment1.DR.InputSum;
            summaryAssent6.O = investment1.DZ.InputSum;
            summaryAssent6.P = investment2.B;
            summaryAssent6.Q = investment2.C;
            summaryAssent6.R = investment2.D;
            summaryAssent6.S = investment2.E;
            summaryAssent6.T = investment2.F;
            summaryAssent6.U = investment2.G;
            summaryAssent6.V = investment2.H;
            summaryAssent6.W = investment2.I;
            summaryAssent6.X = investment2.CL.InputSum;
            summaryAssent6.Y = investment2.CT.InputSum;
            summaryAssent6.Z = investment2.DB.InputSum;
            summaryAssent6.AA = investment2.DJ.InputSum;
            summaryAssent6.AB = investment2.DR.InputSum;
            summaryAssent6.AC = investment2.DZ.InputSum;
            summaryAssent6.AD = investment3.B;
            summaryAssent6.AE = investment3.C;
            summaryAssent6.AF = investment3.D;
            summaryAssent6.AG = investment3.E;
            summaryAssent6.AH = investment3.F;
            summaryAssent6.AI = investment3.G;
            summaryAssent6.AJ = investment3.H;
            summaryAssent6.AK = investment3.I;
            summaryAssent6.AL = investment3.CL.InputSum;
            summaryAssent6.AM = investment3.CT.InputSum;
            summaryAssent6.AN = investment3.DB.InputSum;
            summaryAssent6.AO = investment3.DJ.InputSum;
            summaryAssent6.AP = investment3.DR.InputSum;
            summaryAssent6.AQ = investment3.DZ.InputSum;



            #endregion
            #region 卖场费用 summaryAssent7
            summaryAssent7.B = 500 + de5 * bj5_bm5 * 0.05m + de5 / (1 + 0.10m) * bj5_bm5 * 0.05m;
            summaryAssent7.I = 200 + df5 * cb5_ce5 * 0.04m + df5 / (1 + 0.12m) * cb5_ce5 * 0.07m;
            //=500+(市场价格!DE6*(AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6))*5%+市场价格!DE6/(1+10%)*(AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6))*5%)
            //+市场价格!DG6*(AVERAGE(市场容量及各品牌当年占有率!BP6:BS6))*5%+市场价格!DG6/(1+10%)*(AVERAGE(市场容量及各品牌当年占有率!BP6:BS6)*5%)
            summaryAssent7.P = 500 + (market2.DE[1].M * bj6_bm6) * 0.05m + market2.DE[1].M / (1 + 0.10m) * bj6_bm6 * 0.05m
                + market2.DE[2].M * bp6_bs6 * 0.05m + market2.DE[2].M / (1 + 0.10m) * bp6_bs6 * 0.05m;

            summaryAssent7.W = 200 + (df6 * (cb6_ce6) * 0.04m + df6 / (1 + 0.12m) * cb6_ce6 * 0.07m) +
                dh6 * ch6_ck6 * 0.04m + dh6 / (1 + 0.12m) * ch6_ck6 * 0.07m;
            summaryAssent7.AD = 500 + market3.DE[1].M * bj7_bm7 * 0.05m + market3.DE[1].M / (1 + 0.10m) *
                bj7_bm7 * 0.05m + market3.DE[2].M * bp7_bs7 * 0.05m + market3.DE[2].M / (1 + 0.10m) *
                bp7_bs7 * 0.05m + market3.DE[3].M * bv7_by7 * 0.05m + market3.DE[3].M / (1 + 0.10m) *
                bv7_by7 * 0.05m;
            summaryAssent7.AK = 200 + market3.DE[1].J * cb7_ce7 * 0.04m + market3.DE[1].J / (1 + 0.12m) *
                cb7_ce7 * 0.07m + market3.DE[2].J * ch7_ck7 * 0.04m + market3.DE[2].J / (1 + 0.12m) *
                ch7_ck7 * 0.07m + market3.DE[3].J * cn7_cq7 * 0.04m + market3.DE[3].J / (1 + 0.12m) * cn7_cq7 * 0.07m;
            #endregion
            #region 年末S品牌商费用投放返还 summaryAssent10
            summaryAssent10.J = investment1.AJ.InputSum;
            summaryAssent10.K = investment1.AS.InputSum;
            summaryAssent10.L = investment1.BB.InputSum;
            summaryAssent10.M = investment1.BK.InputSum;
            summaryAssent10.N = investment1.BT.InputSum;
            summaryAssent10.O = investment1.CC.InputSum;
            summaryAssent10.X = investment2.AJ.InputSum;
            summaryAssent10.Y = investment2.AS.InputSum;
            summaryAssent10.Z = investment2.BB.InputSum;
            summaryAssent10.AA = investment2.BK.InputSum;
            summaryAssent10.AB = investment2.BT.InputSum;
            summaryAssent10.AC = investment2.CC.InputSum;

            summaryAssent10.AL = investment3.AJ.InputSum;
            summaryAssent10.AM = investment3.AS.InputSum;
            summaryAssent10.AN = investment3.BB.InputSum;
            summaryAssent10.AO = investment3.BK.InputSum;
            summaryAssent10.AP = investment3.BT.InputSum;
            summaryAssent10.AQ = investment3.CC.InputSum;
            #endregion


            #region 最后计算



            #region 期末现金余额 summaryAssent12
            summaryAssent2.P = summaryAssent12.B = summaryAssent2.B + summaryAssent4.B - summaryAssent5.B - summaryAssent6.B - summaryAssent7.B - summaryAssent11.B;
            summaryAssent2.Q = summaryAssent12.C = summaryAssent2.C + summaryAssent4.C - summaryAssent5.C - summaryAssent6.C - summaryAssent7.C - summaryAssent11.C;
            summaryAssent2.R = summaryAssent12.D = summaryAssent2.D + summaryAssent4.D - summaryAssent5.D - summaryAssent6.D - summaryAssent7.D - summaryAssent11.D;
            summaryAssent2.S = summaryAssent12.E = summaryAssent2.E + summaryAssent4.E - summaryAssent5.E - summaryAssent6.E - summaryAssent7.E - summaryAssent11.E;
            summaryAssent2.T = summaryAssent12.F = summaryAssent2.F + summaryAssent4.F - summaryAssent5.F - summaryAssent6.F - summaryAssent7.F - summaryAssent11.F;
            summaryAssent2.U = summaryAssent12.G = summaryAssent2.G + summaryAssent4.G - summaryAssent5.G - summaryAssent6.G - summaryAssent7.G - summaryAssent11.G;
            summaryAssent2.V = summaryAssent12.H = summaryAssent2.H + summaryAssent4.H - summaryAssent5.H - summaryAssent6.H - summaryAssent7.H - summaryAssent11.H;
            summaryAssent2.W = summaryAssent12.I = summaryAssent2.I + summaryAssent4.I - summaryAssent5.I - summaryAssent6.I - summaryAssent7.I - summaryAssent11.I;

            summaryAssent2.X = summaryAssent12.J = summaryAssent2.J + summaryAssent3.J + summaryAssent4.J - summaryAssent5.J - summaryAssent6.J - summaryAssent7.J - summaryAssent8.J - (summaryAssent9.J - summaryAssent1.J) * market1.CM[1].S + summaryAssent10.J;
            summaryAssent2.Y = summaryAssent12.K = summaryAssent2.K + summaryAssent3.K + summaryAssent4.K - summaryAssent5.K - summaryAssent6.K - summaryAssent7.K - summaryAssent8.K - (summaryAssent9.K - summaryAssent1.K) * market1.CM[1].S + summaryAssent10.K;
            summaryAssent2.Z = summaryAssent12.L = summaryAssent2.L + summaryAssent3.L + summaryAssent4.L - summaryAssent5.L - summaryAssent6.L - summaryAssent7.L - summaryAssent8.L - (summaryAssent9.L - summaryAssent1.L) * market1.CM[1].S + summaryAssent10.L;
            summaryAssent2.AA = summaryAssent12.M = summaryAssent2.M + summaryAssent3.M + summaryAssent4.M - summaryAssent5.M - summaryAssent6.M - summaryAssent7.M - summaryAssent8.M - (summaryAssent9.M - summaryAssent1.M) * market1.CM[1].S + summaryAssent10.M;
            summaryAssent2.AB = summaryAssent12.N = summaryAssent2.N + summaryAssent3.N + summaryAssent4.N - summaryAssent5.N - summaryAssent6.N - summaryAssent7.N - summaryAssent8.N - (summaryAssent9.N - summaryAssent1.N) * market1.CM[1].S + summaryAssent10.N;
            summaryAssent2.AC = summaryAssent12.O = summaryAssent2.O + summaryAssent3.O + summaryAssent4.O - summaryAssent5.O - summaryAssent6.O - summaryAssent7.O - summaryAssent8.O - (summaryAssent9.O - summaryAssent1.O) * market1.CM[1].S + summaryAssent10.O;

            summaryAssent2.AD = summaryAssent12.P = summaryAssent2.P + summaryAssent4.P - summaryAssent5.P - summaryAssent6.P - summaryAssent7.P - summaryAssent11.P;
            summaryAssent2.AE = summaryAssent12.Q = summaryAssent2.Q + summaryAssent4.Q - summaryAssent5.Q - summaryAssent6.Q - summaryAssent7.Q - summaryAssent11.Q;
            summaryAssent2.AF = summaryAssent12.R = summaryAssent2.R + summaryAssent4.R - summaryAssent5.R - summaryAssent6.R - summaryAssent7.R - summaryAssent11.R;
            summaryAssent2.AG = summaryAssent12.S = summaryAssent2.S + summaryAssent4.S - summaryAssent5.S - summaryAssent6.S - summaryAssent7.S - summaryAssent11.S;
            summaryAssent2.AH = summaryAssent12.T = summaryAssent2.T + summaryAssent4.T - summaryAssent5.T - summaryAssent6.T - summaryAssent7.T - summaryAssent11.T;
            summaryAssent2.AI = summaryAssent12.U = summaryAssent2.U + summaryAssent4.U - summaryAssent5.U - summaryAssent6.U - summaryAssent7.U - summaryAssent11.U;
            summaryAssent2.AJ = summaryAssent12.V = summaryAssent2.V + summaryAssent4.V - summaryAssent5.V - summaryAssent6.V - summaryAssent7.V - summaryAssent11.V;
            summaryAssent2.AK = summaryAssent12.W = summaryAssent2.W + summaryAssent4.W - summaryAssent5.W - summaryAssent6.W - summaryAssent7.W - summaryAssent11.W;


            summaryAssent12.AD = summaryAssent2.AD + summaryAssent4.AD - summaryAssent5.AD - summaryAssent6.AD - summaryAssent7.AD - summaryAssent11.AD;
            summaryAssent12.AE = summaryAssent2.AE + summaryAssent4.AE - summaryAssent5.AE - summaryAssent6.AE - summaryAssent7.AE - summaryAssent11.AE;
            summaryAssent12.AF = summaryAssent2.AF + summaryAssent4.AF - summaryAssent5.AF - summaryAssent6.AF - summaryAssent7.AF - summaryAssent11.AF;
            summaryAssent12.AG = summaryAssent2.AG + summaryAssent4.AG - summaryAssent5.AG - summaryAssent6.AG - summaryAssent7.AG - summaryAssent11.AG;
            summaryAssent12.AH = summaryAssent2.AH + summaryAssent4.AH - summaryAssent5.AH - summaryAssent6.AH - summaryAssent7.AH - summaryAssent11.AH;
            summaryAssent12.AI = summaryAssent2.AI + summaryAssent4.AI - summaryAssent5.AI - summaryAssent6.AI - summaryAssent7.AI - summaryAssent11.AI;
            summaryAssent12.AJ = summaryAssent2.AJ + summaryAssent4.AJ - summaryAssent5.AJ - summaryAssent6.AJ - summaryAssent7.AJ - summaryAssent11.AJ;
            summaryAssent12.AK = summaryAssent2.AK + summaryAssent4.AK - summaryAssent5.AK - summaryAssent6.AK - summaryAssent7.AK - summaryAssent11.AK;

            foreach (var item in invocicings)
            {
                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                switch (agentName)
                {
                    case AgentName.代1:
                        summaryAssent2.AL = summaryAssent12.X = summaryAssent2.X + summaryAssent3.X + summaryAssent4.X - summaryAssent5.X - summaryAssent6.X - summaryAssent7.X - summaryAssent8.X - ((item.S - item.I) * market2.CM[1].S + item.U * market2.CM[2].S) + summaryAssent10.X;

                        summaryAssent12.AL = summaryAssent2.AL + summaryAssent4.AL - summaryAssent5.AL - summaryAssent6.AL - summaryAssent7.AL - ((item.AI - item.S) * market3.CM[1].S + (item.AK - item.U) * market3.CM[2].S + item.AM * market3.CM[3].S) + summaryAssent10.AL;
                        summaryAssent17.C = summaryAssent17.J = decimal.Round((summaryAssent9.J == 0 ? (item.D + item.E - currentShare1.CT[1].Agent1) : 0), 0);
                        summaryAssent17.Q = summaryAssent17.X = decimal.Round(decimal.Round((summaryAssent9.X == 0 ? ((item.I + item.K - currentShare2.CT[1].Agent1) + (item.M - currentShare2.CT[2].Agent1)) : 0), 0), 0);
                        summaryAssent17.AE = summaryAssent17.AL = decimal.Round((summaryAssent9.AL == 0 ? ((item.S + item.W - currentShare3.CT[1].Agent1) + (item.U + item.Y - currentShare3.CT[2].Agent1) + (item.AA - currentShare3.CT[3].Agent1)) : 0), 0);

                        break;
                    case AgentName.代2:
                        summaryAssent2.AM = summaryAssent12.Y = summaryAssent2.Y + summaryAssent3.Y + summaryAssent4.Y - summaryAssent5.Y - summaryAssent6.Y - summaryAssent7.Y - summaryAssent8.Y - ((item.S - item.I) * market2.CM[1].S + item.U * market2.CM[2].S) + summaryAssent10.Y;

                        summaryAssent12.AM = summaryAssent2.AM + summaryAssent4.AM - summaryAssent5.AM - summaryAssent6.AM - summaryAssent7.AM - ((item.AI - item.S) * market3.CM[1].S + (item.AK - item.U) * market3.CM[2].S + item.AM * market3.CM[3].S) + summaryAssent10.AM;
                        summaryAssent17.D = summaryAssent17.K = decimal.Round((summaryAssent9.K == 0 ? (item.D + item.E - currentShare1.CT[1].Agent2) : 0), 0);
                        summaryAssent17.R = summaryAssent17.Y = decimal.Round(decimal.Round((summaryAssent9.Y == 0 ? ((item.I + item.K - currentShare2.CT[1].Agent2) + (item.M - currentShare2.CT[2].Agent2)) : 0), 0), 0);
                        summaryAssent17.AF = summaryAssent17.AM = decimal.Round((summaryAssent9.AM == 0 ? ((item.S + item.W - currentShare3.CT[1].Agent2) + (item.U + item.Y - currentShare3.CT[2].Agent2) + (item.AA - currentShare3.CT[3].Agent2)) : 0), 0);

                        break;
                    case AgentName.代3:
                        summaryAssent2.AN = summaryAssent12.Z = summaryAssent2.Z + summaryAssent3.Z + summaryAssent4.Z - summaryAssent5.Z - summaryAssent6.Z - summaryAssent7.Z - summaryAssent8.Z - ((item.S - item.I) * market2.CM[1].S + item.U * market2.CM[2].S) + summaryAssent10.Z;

                        summaryAssent12.AN = summaryAssent2.AN + summaryAssent4.AN - summaryAssent5.AN - summaryAssent6.AN - summaryAssent7.AN - ((item.AI - item.S) * market3.CM[1].S + (item.AK - item.U) * market3.CM[2].S + item.AM * market3.CM[3].S) + summaryAssent10.AN;
                        summaryAssent17.E = summaryAssent17.L = decimal.Round((summaryAssent9.L == 0 ? (item.D + item.E - currentShare1.CT[1].Agent3) : 0), 0);
                        summaryAssent17.S = summaryAssent17.Z = decimal.Round(decimal.Round((summaryAssent9.Z == 0 ? ((item.I + item.K - currentShare2.CT[1].Agent3) + (item.M - currentShare2.CT[2].Agent3)) : 0), 0), 0);
                        summaryAssent17.AG = summaryAssent17.AN = decimal.Round((summaryAssent9.AN == 0 ? ((item.S + item.W - currentShare3.CT[1].Agent3) + (item.U + item.Y - currentShare3.CT[2].Agent3) + (item.AA - currentShare3.CT[3].Agent3)) : 0), 0);

                        break;
                    case AgentName.代4:
                        summaryAssent2.AO = summaryAssent12.AA = summaryAssent2.AA + summaryAssent3.AA + summaryAssent4.AA - summaryAssent5.AA - summaryAssent6.AA - summaryAssent7.AA - summaryAssent8.AA - ((item.S - item.I) * market2.CM[1].S + item.U * market2.CM[2].S) + summaryAssent10.AA;

                        summaryAssent12.AO = summaryAssent2.AO + summaryAssent4.AO - summaryAssent5.AO - summaryAssent6.AO - summaryAssent7.AO - ((item.AI - item.S) * market3.CM[1].S + (item.AK - item.U) * market3.CM[2].S + item.AM * market3.CM[3].S) + summaryAssent10.AO;
                        summaryAssent17.F = summaryAssent17.M = decimal.Round((summaryAssent9.M == 0 ? (item.D + item.E - currentShare1.CT[1].Agent4) : 0), 0);
                        summaryAssent17.T = summaryAssent17.AA = decimal.Round(decimal.Round((summaryAssent9.AA == 0 ? ((item.I + item.K - currentShare2.CT[1].Agent4) + (item.M - currentShare2.CT[2].Agent4)) : 0), 0), 0);
                        summaryAssent17.AH = summaryAssent17.AO = decimal.Round((summaryAssent9.AO == 0 ? ((item.S + item.W - currentShare3.CT[1].Agent4) + (item.U + item.Y - currentShare3.CT[2].Agent4) + (item.AA - currentShare3.CT[3].Agent4)) : 0), 0);

                        break;
                    case AgentName.代5:
                        summaryAssent2.AP = summaryAssent12.AB = summaryAssent2.AB + summaryAssent3.AB + summaryAssent4.AB - summaryAssent5.AB - summaryAssent6.AB - summaryAssent7.AB - summaryAssent8.AB - ((item.S - item.I) * market2.CM[1].S + item.U * market2.CM[2].S) + summaryAssent10.AB;

                        summaryAssent12.AP = summaryAssent2.AP + summaryAssent4.AP - summaryAssent5.AP - summaryAssent6.AP - summaryAssent7.AP - ((item.AI - item.S) * market3.CM[1].S + (item.AK - item.U) * market3.CM[2].S + item.AM * market3.CM[3].S) + summaryAssent10.AP;
                        summaryAssent17.G = summaryAssent17.N = decimal.Round((summaryAssent9.N == 0 ? (item.D + item.E - currentShare1.CT[1].Agent5) : 0), 0);
                        summaryAssent17.U = summaryAssent17.AB = decimal.Round(decimal.Round((summaryAssent9.AB == 0 ? ((item.I + item.K - currentShare2.CT[1].Agent5) + (item.M - currentShare2.CT[2].Agent5)) : 0), 0), 0);
                        summaryAssent17.AI = summaryAssent17.AP = decimal.Round((summaryAssent9.AP == 0 ? ((item.S + item.W - currentShare3.CT[1].Agent5) + (item.U + item.Y - currentShare3.CT[2].Agent5) + (item.AA - currentShare3.CT[3].Agent5)) : 0), 0);

                        break;
                    case AgentName.代6:
                        summaryAssent2.AQ = summaryAssent12.AC = summaryAssent2.AC + summaryAssent3.AC + summaryAssent4.AC - summaryAssent5.AC - summaryAssent6.AC - summaryAssent7.AC - summaryAssent8.AC - ((item.S - item.I) * market2.CM[1].S + item.U * market2.CM[2].S) + summaryAssent10.AC;
                        summaryAssent12.AQ = summaryAssent2.AQ + summaryAssent4.AQ - summaryAssent5.AQ - summaryAssent6.AQ - summaryAssent7.AQ - ((item.AI - item.S) * market3.CM[1].S + (item.AK - item.U) * market3.CM[2].S + item.AM * market3.CM[3].S) + summaryAssent10.AQ;

                        summaryAssent17.H = summaryAssent17.O = decimal.Round((summaryAssent9.O == 0 ? (item.D + item.E - currentShare1.CT[1].Agent6) : 0), 0);
                        summaryAssent17.V = summaryAssent17.AC = decimal.Round(decimal.Round((summaryAssent9.AC == 0 ? ((item.I + item.K - currentShare2.CT[1].Agent6) + (item.M - currentShare2.CT[2].Agent6)) : 0), 0), 0);
                        summaryAssent17.AJ = summaryAssent17.AQ = decimal.Round((summaryAssent9.AQ == 0 ? ((item.S + item.W - currentShare3.CT[1].Agent6) + (item.U + item.Y - currentShare3.CT[2].Agent6) + (item.AA - currentShare3.CT[3].Agent6)) : 0), 0);


                        break;
                }
            }

            #endregion

            #region 销售利润 summaryAssent13
            summaryAssent13.B = summaryAssent4.B - summaryAssent5.B - summaryAssent6.B - summaryAssent7.B - summaryAssent11.B;
            summaryAssent13.C = summaryAssent4.C - summaryAssent5.C - summaryAssent6.C - summaryAssent11.C;
            summaryAssent13.D = summaryAssent4.D - summaryAssent5.D - summaryAssent6.D - summaryAssent11.D;
            summaryAssent13.E = summaryAssent4.E - summaryAssent5.E - summaryAssent6.E - summaryAssent11.E;
            summaryAssent13.F = summaryAssent4.F - summaryAssent5.F - summaryAssent6.F - summaryAssent11.F;
            summaryAssent13.G = summaryAssent4.G - summaryAssent5.G - summaryAssent6.G - summaryAssent11.G;
            summaryAssent13.H = summaryAssent4.H - summaryAssent5.H - summaryAssent6.H - summaryAssent11.H;
            summaryAssent13.I = summaryAssent4.I - summaryAssent5.I - summaryAssent6.I - summaryAssent7.I - summaryAssent11.I;

            summaryAssent13.J = summaryAssent4.J - summaryAssent5.J - summaryAssent6.J - summaryAssent7.J + summaryAssent10.J - summaryAssent8.J;
            summaryAssent13.K = summaryAssent4.K - summaryAssent5.K - summaryAssent6.K - summaryAssent7.K + summaryAssent10.K - summaryAssent8.K;
            summaryAssent13.L = summaryAssent4.L - summaryAssent5.L - summaryAssent6.L - summaryAssent7.L + summaryAssent10.L - summaryAssent8.L;
            summaryAssent13.M = summaryAssent4.M - summaryAssent5.M - summaryAssent6.M - summaryAssent7.M + summaryAssent10.M - summaryAssent8.M;
            summaryAssent13.N = summaryAssent4.N - summaryAssent5.N - summaryAssent6.N - summaryAssent7.N + summaryAssent10.N - summaryAssent8.N;
            summaryAssent13.O = summaryAssent4.O - summaryAssent5.O - summaryAssent6.O - summaryAssent7.O + summaryAssent10.O - summaryAssent8.O;
            summaryAssent13.P = summaryAssent4.P - summaryAssent5.P - summaryAssent6.P - summaryAssent7.P + summaryAssent10.P - summaryAssent8.P;
            summaryAssent13.Q = summaryAssent4.Q - summaryAssent5.Q - summaryAssent6.Q - summaryAssent7.Q + summaryAssent10.Q - summaryAssent8.Q;

            summaryAssent13.P = summaryAssent4.P - summaryAssent5.P - summaryAssent6.P - summaryAssent7.P - summaryAssent11.P;
            summaryAssent13.Q = summaryAssent4.Q - summaryAssent5.Q - summaryAssent6.Q - summaryAssent11.Q;
            summaryAssent13.R = summaryAssent4.R - summaryAssent5.R - summaryAssent6.R - summaryAssent11.R;
            summaryAssent13.S = summaryAssent4.S - summaryAssent5.S - summaryAssent6.S - summaryAssent11.S;
            summaryAssent13.T = summaryAssent4.T - summaryAssent5.T - summaryAssent6.T - summaryAssent11.T;
            summaryAssent13.U = summaryAssent4.U - summaryAssent5.U - summaryAssent6.U - summaryAssent11.U;
            summaryAssent13.V = summaryAssent4.V - summaryAssent5.V - summaryAssent6.V - summaryAssent11.V;
            summaryAssent13.W = summaryAssent4.W - summaryAssent5.W - summaryAssent6.W - summaryAssent7.W - summaryAssent11.W;

            summaryAssent13.X = summaryAssent4.X - summaryAssent5.X - summaryAssent6.X - summaryAssent7.X + summaryAssent10.X - summaryAssent8.X;
            summaryAssent13.Y = summaryAssent4.Y - summaryAssent5.Y - summaryAssent6.Y - summaryAssent7.Y + summaryAssent10.Y - summaryAssent8.Y;
            summaryAssent13.Z = summaryAssent4.Z - summaryAssent5.Z - summaryAssent6.Z - summaryAssent7.Z + summaryAssent10.Z - summaryAssent8.Z;
            summaryAssent13.AA = summaryAssent4.AA - summaryAssent5.AA - summaryAssent6.AA - summaryAssent7.AA + summaryAssent10.AA - summaryAssent8.AA;
            summaryAssent13.AB = summaryAssent4.AB - summaryAssent5.AB - summaryAssent6.AB - summaryAssent7.AB + summaryAssent10.AB - summaryAssent8.AB;
            summaryAssent13.AC = summaryAssent4.AC - summaryAssent5.AC - summaryAssent6.AC - summaryAssent7.AC + summaryAssent10.AC - summaryAssent8.AC;

            summaryAssent13.AD = summaryAssent4.AD - summaryAssent5.AD - summaryAssent6.AD - summaryAssent7.AD - summaryAssent11.AD;
            summaryAssent13.AE = summaryAssent4.AE - summaryAssent5.AE - summaryAssent6.AE - summaryAssent11.AE;
            summaryAssent13.AF = summaryAssent4.AF - summaryAssent5.AF - summaryAssent6.AF - summaryAssent11.AF;
            summaryAssent13.AG = summaryAssent4.AG - summaryAssent5.AG - summaryAssent6.AG - summaryAssent11.AG;
            summaryAssent13.AH = summaryAssent4.AH - summaryAssent5.AH - summaryAssent6.AH - summaryAssent11.AH;
            summaryAssent13.AI = summaryAssent4.AI - summaryAssent5.AI - summaryAssent6.AI - summaryAssent11.AI;
            summaryAssent13.AJ = summaryAssent4.AJ - summaryAssent5.AJ - summaryAssent6.AJ - summaryAssent11.AJ;
            summaryAssent13.AK = summaryAssent4.AK - summaryAssent5.AK - summaryAssent6.AK - summaryAssent7.AK - summaryAssent11.AK;
            //=AL7-AL8-AL9-AL10+AL13-AL11
            summaryAssent13.AL = summaryAssent4.AL - summaryAssent5.AL - summaryAssent6.AL - summaryAssent7.AL + summaryAssent10.AL - summaryAssent8.AL;
            summaryAssent13.AM = summaryAssent4.AM - summaryAssent5.AM - summaryAssent6.AM - summaryAssent7.AM + summaryAssent10.AM - summaryAssent8.AM;
            summaryAssent13.AN = summaryAssent4.AN - summaryAssent5.AN - summaryAssent6.AN - summaryAssent7.AN + summaryAssent10.AN - summaryAssent8.AN;
            summaryAssent13.AO = summaryAssent4.AO - summaryAssent5.AO - summaryAssent6.AO - summaryAssent7.AO + summaryAssent10.AO - summaryAssent8.AO;
            summaryAssent13.AP = summaryAssent4.AP - summaryAssent5.AP - summaryAssent6.AP - summaryAssent7.AP + summaryAssent10.AP - summaryAssent8.AP;
            summaryAssent13.AQ = summaryAssent4.AQ - summaryAssent5.AQ - summaryAssent6.AQ - summaryAssent7.AQ + summaryAssent10.AQ - summaryAssent8.AQ;

            #endregion





            #region 扣除计提跌价损失及银行利息后的利润 summaryAssent16
            summaryAssent16.J = summaryAssent13.J - summaryAssent15.J - summaryAssent14.J;
            summaryAssent16.K = summaryAssent13.K - summaryAssent15.K - summaryAssent14.K;
            summaryAssent16.L = summaryAssent13.L - summaryAssent15.L - summaryAssent14.L;
            summaryAssent16.M = summaryAssent13.M - summaryAssent15.M - summaryAssent14.M;
            summaryAssent16.N = summaryAssent13.N - summaryAssent15.N - summaryAssent14.N;
            summaryAssent16.O = summaryAssent13.O - summaryAssent15.O - summaryAssent14.O;

            summaryAssent16.X = summaryAssent13.X - summaryAssent15.X - summaryAssent14.X;
            summaryAssent16.Y = summaryAssent13.Y - summaryAssent15.Y - summaryAssent14.Y;
            summaryAssent16.Z = summaryAssent13.Z - summaryAssent15.Z - summaryAssent14.Z;
            summaryAssent16.AA = summaryAssent13.AA - summaryAssent15.AA - summaryAssent14.AA;
            summaryAssent16.AB = summaryAssent13.AB - summaryAssent15.AB - summaryAssent14.AB;
            summaryAssent16.AC = summaryAssent13.AC - summaryAssent15.AC - summaryAssent14.AC;

            summaryAssent16.AL = summaryAssent13.AL - summaryAssent15.AL - summaryAssent14.AL;
            summaryAssent16.AM = summaryAssent13.AM - summaryAssent15.AM - summaryAssent14.AM;
            summaryAssent16.AN = summaryAssent13.AN - summaryAssent15.AN - summaryAssent14.AN;
            summaryAssent16.AO = summaryAssent13.AO - summaryAssent15.AO - summaryAssent14.AO;
            summaryAssent16.AP = summaryAssent13.AP - summaryAssent15.AP - summaryAssent14.AP;
            summaryAssent16.AQ = summaryAssent13.AQ - summaryAssent15.AQ - summaryAssent14.AQ;

            #endregion




            #region 经营中损失的金额  summaryAssent18
            summaryAssent18.C = summaryAssent17.C * market1.CM[1].S;
            summaryAssent18.D = summaryAssent17.D * market1.CM[1].S;
            summaryAssent18.E = summaryAssent17.E * market1.CM[1].S;
            summaryAssent18.F = summaryAssent17.F * market1.CM[1].S;
            summaryAssent18.G = summaryAssent17.G * market1.CM[1].S;
            summaryAssent18.H = summaryAssent17.H * market1.CM[1].S;

            summaryAssent18.J = summaryAssent17.J * market1.EF[1].Agent1;
            summaryAssent18.K = summaryAssent17.K * market1.EF[1].Agent2;
            summaryAssent18.L = summaryAssent17.L * market1.EF[1].Agent3;
            summaryAssent18.M = summaryAssent17.M * market1.EF[1].Agent4;
            summaryAssent18.N = summaryAssent17.N * market1.EF[1].Agent5;
            summaryAssent18.O = summaryAssent17.O * market1.EF[1].Agent6;

            foreach (var item in invocicings)
            {
                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                switch (agentName)
                {
                    case AgentName.代1:
                        summaryAssent18.Q = (summaryAssent17.Q == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent1) * market2.CM[1].S + (item.M - currentShare2.CT[2].Agent1) * market2.CM[2].S);
                        summaryAssent18.X = (summaryAssent17.X == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent1) * market2.EF[1].Agent1 + (item.M - currentShare2.CT[2].Agent1) * market2.EF[2].Agent1);
                        summaryAssent18.AE = (summaryAssent17.AE == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent1) * market3.CM[1].S + (item.U + item.Y - currentShare3.CT[2].Agent1) * market3.CM[2].S + (item.AA - currentShare3.CT[3].Agent1) * market3.CM[3].S);
                        summaryAssent18.AL = (summaryAssent17.AL == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent1) * market3.EF[1].Agent1 + (item.U + item.Y - currentShare3.CT[2].Agent1) * market3.EF[2].Agent1 + (item.AA - currentShare3.CT[3].Agent1) * market3.EF[3].Agent1);
                        //=IF(AL20=0,0,(进销存报表!$S4+进销存报表!$W4-市场容量及各品牌当年占有率!CT7)*市场价格!EF7+(进销存报表!$U4+进销存报表!$Y4-市场容量及各品牌当年占有率!CZ7)*市场价格!EL7+(进销存报表!$AA4-市场容量及各品牌当年占有率!DF7)*市场价格!ER7)
                        break;
                    case AgentName.代2:
                        summaryAssent18.R = (summaryAssent17.Q == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent2) * market2.CM[1].S + (item.M - currentShare2.CT[2].Agent2) * market2.CM[2].S);
                        summaryAssent18.Y = (summaryAssent17.Y == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent2) * market2.EF[1].Agent2 + (item.M - currentShare2.CT[2].Agent2) * market2.EF[2].Agent2);
                        summaryAssent18.AF = (summaryAssent17.AF == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent2) * market3.CM[1].S + (item.U + item.Y - currentShare3.CT[2].Agent2) * market3.CM[2].S + (item.AA - currentShare3.CT[3].Agent2) * market3.CM[3].S);
                        summaryAssent18.AM = (summaryAssent17.AM == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent2) * market3.EF[1].Agent2 + (item.U + item.Y - currentShare3.CT[2].Agent2) * market3.EF[2].Agent2 + (item.AA - currentShare3.CT[3].Agent2) * market3.EF[3].Agent2);

                        break;
                    case AgentName.代3:
                        summaryAssent18.S = (summaryAssent17.Q == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent3) * market2.CM[1].S + (item.M - currentShare2.CT[2].Agent3) * market2.CM[2].S);
                        summaryAssent18.Z = (summaryAssent17.Z == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent3) * market2.EF[1].Agent3 + (item.M - currentShare2.CT[2].Agent3) * market2.EF[2].Agent3);
                        summaryAssent18.AG = (summaryAssent17.AG == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent3) * market3.CM[1].S + (item.U + item.Y - currentShare3.CT[2].Agent3) * market3.CM[2].S + (item.AA - currentShare3.CT[3].Agent3) * market3.CM[3].S);
                        summaryAssent18.AN = (summaryAssent17.AN == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent3) * market3.EF[1].Agent3 + (item.U + item.Y - currentShare3.CT[2].Agent3) * market3.EF[2].Agent3 + (item.AA - currentShare3.CT[3].Agent3) * market3.EF[3].Agent3);

                        break;
                    case AgentName.代4:
                        summaryAssent18.T = (summaryAssent17.Q == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent4) * market2.CM[1].S + (item.M - currentShare2.CT[2].Agent4) * market2.CM[2].S);
                        summaryAssent18.AA = (summaryAssent17.AA == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent4) * market2.EF[1].Agent4 + (item.M - currentShare2.CT[2].Agent4) * market2.EF[2].Agent4);
                        summaryAssent18.AH = (summaryAssent17.AH == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent4) * market3.CM[1].S + (item.U + item.Y - currentShare3.CT[2].Agent4) * market3.CM[2].S + (item.AA - currentShare3.CT[3].Agent4) * market3.CM[3].S);
                        summaryAssent18.AO = (summaryAssent17.AO == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent4) * market3.EF[1].Agent4 + (item.U + item.Y - currentShare3.CT[2].Agent4) * market3.EF[2].Agent4 + (item.AA - currentShare3.CT[3].Agent4) * market3.EF[3].Agent4);

                        break;
                    case AgentName.代5:
                        summaryAssent18.U = (summaryAssent17.Q == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent5) * market2.CM[1].S + (item.M - currentShare2.CT[2].Agent5) * market2.CM[2].S);
                        summaryAssent18.AB = (summaryAssent17.AB == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent5) * market2.EF[1].Agent5 + (item.M - currentShare2.CT[2].Agent5) * market2.EF[2].Agent5);
                        summaryAssent18.AI = (summaryAssent17.AI == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent5) * market3.CM[1].S + (item.U + item.Y - currentShare3.CT[2].Agent5) * market3.CM[2].S + (item.AA - currentShare3.CT[3].Agent5) * market3.CM[3].S);
                        summaryAssent18.AP = (summaryAssent17.AP == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent5) * market3.EF[1].Agent5 + (item.U + item.Y - currentShare3.CT[2].Agent5) * market3.EF[2].Agent5 + (item.AA - currentShare3.CT[3].Agent5) * market3.EF[3].Agent5);

                        break;
                    case AgentName.代6:
                        summaryAssent18.V = (summaryAssent17.Q == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent6) * market2.CM[1].S + (item.M - currentShare2.CT[2].Agent6) * market2.CM[2].S);
                        summaryAssent18.AC = (summaryAssent17.AC == 0 ? 0 : (item.I + item.K - currentShare2.CT[1].Agent6) * market2.EF[1].Agent6 + (item.M - currentShare2.CT[2].Agent6) * market2.EF[2].Agent6);
                        summaryAssent18.AJ = (summaryAssent17.AJ == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent6) * market3.CM[1].S + (item.U + item.Y - currentShare3.CT[2].Agent6) * market3.CM[2].S + (item.AA - currentShare3.CT[3].Agent6) * market3.CM[3].S);
                        summaryAssent18.AQ = (summaryAssent17.AQ == 0 ? 0 : (item.S + item.W - currentShare3.CT[1].Agent6) * market3.EF[1].Agent6 + (item.U + item.Y - currentShare3.CT[2].Agent6) * market3.EF[2].Agent6 + (item.AA - currentShare3.CT[3].Agent6) * market3.EF[3].Agent6);

                        break;
                    default:
                        break;
                }
            }
            #endregion



            #endregion
        }

        public List<SummaryTable> Get()
        {
            return summarys;
        }
    }
    public class SummaryTable
    {
        public int Id { get; set; }

        public string A { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal B { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal C { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal D { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal E { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal F { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal G { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal H { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal I { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal J { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal K { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal L { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal M { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal N { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal O { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal P { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal Q { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal R { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal S { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal T { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal U { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal V { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal W { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal X { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal Y { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal Z { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AA { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AB { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AC { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AD { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AE { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AF { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AG { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AH { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AI { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AJ { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AK { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AL { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AM { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AN { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AO { get; internal set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AP { get; internal set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AQ { get; internal set; }
    }
}