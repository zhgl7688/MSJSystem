using System;
using System.Collections.Generic;
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
        public SummaryAssent()
        {
            stockReports = new StockReport().Get();
            invocicings = new InvoicingReport().Get();
            markets = new MarketPrice().Get();
            investments = new Investment().Get();
            currentShares = new CurrentShare().Get();
            Init();
        }
        public void Init()
        {
            #region 初始化表
            var summaryAssent1 = new SummaryTable { 科目 = "期初库存" };
            var summaryAssent2 = new SummaryTable { 科目 = "期初现金余额" };
            var summaryAssent3 = new SummaryTable { 科目 = "银行借贷金额" };
            var summaryAssent4 = new SummaryTable { 科目 = "期间销售额" };
            var summaryAssent5 = new SummaryTable { 科目 = "期间销售成本" };
            var summaryAssent6 = new SummaryTable { 科目 = "期间产生费用" };
            var summaryAssent7 = new SummaryTable { 科目 = "卖场费用" };
            var summaryAssent8 = new SummaryTable { 科目 = "卖场要求补差费用" };
            var summaryAssent9 = new SummaryTable { 科目 = "期末库存" };
            var summaryAssent10 = new SummaryTable { 科目 = "年末S品牌商费用投放返还" };
            var summaryAssent11 = new SummaryTable { 科目 = "品牌商综合经营费用" };
            var summaryAssent12 = new SummaryTable { 科目 = "期末现金余额" };
            var summaryAssent13 = new SummaryTable { 科目 = "销售利润" };
            var summaryAssent14 = new SummaryTable { 科目 = "应支付银行利息" };
            var summaryAssent15 = new SummaryTable { 科目 = "库存需按照10%计提跌价损失" };
            var summaryAssent16 = new SummaryTable { 科目 = "扣除计提跌价损失及银行利息后的利润" };
            var summaryAssent17 = new SummaryTable { 科目 = "经营中损失的销售" };
            var summaryAssent18 = new SummaryTable { 科目 = "经营中损失的金额" };

            #endregion
            var currentShare1 = currentShares.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            var currentShare2 = currentShares.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            var currentShare3 = currentShares.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            var investment1 = investments.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            var investment2 = investments.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            var investment3 = investments.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            var market1 = markets.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            var market2 = markets.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            var market3 = markets.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            var stockReport1 = stockReports.Where(s => s.Stage == Stage.第一阶段.ToString());
            // AVERAGE(市场容量及各品牌当年占有率!CB5:CE5)
            var cb5_ce5 = (currentShare1.CB[1].J1 + currentShare1.CB[1].J2 + currentShare1.CB[1].J3 + currentShare1.CB[1].J4) / 4m;
            //AVERAGE(市场容量及各品牌当年占有率!BJ5:BM5)
            var bj5_bm5 = (currentShare1.BJ[1].M1 + currentShare1.BJ[1].M2 + currentShare1.BJ[1].M3 + currentShare1.BJ[1].M4) / 4m;


            //AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6)
            var bj6_bm6 = (currentShare2.BJ[1].M1 + currentShare2.BJ[1].M2 + currentShare2.BJ[1].M3 + currentShare2.BJ[1].M4) / 4m;
            //AVERAGE(市场容量及各品牌当年占有率!BP6:BS6
            var bp6_bs6 = (currentShare2.BJ[2].M1 + currentShare2.BJ[2].M2 + currentShare2.BJ[2].M3 + currentShare2.BJ[2].M4) / 4m;
            // AVERAGE(市场容量及各品牌当年占有率!CB6:CE6)
            var cb6_ce6 = (currentShare2.CB[1].J1 + currentShare2.CB[1].J2 + currentShare2.CB[1].J3 + currentShare2.CB[1].J4) / 4m;
            //AVERAGE(市场容量及各品牌当年占有率!CH6:CK6
            var ch6_ck6 = (currentShare2.CB[2].J1 + currentShare2.CB[2].J2 + currentShare2.CB[2].J3 + currentShare2.CB[2].J4) / 4m;

            //AVERAGE(市场容量及各品牌当年占有率!BJ7:BM7
            var bj7_bm7 = (currentShare3.BJ[1].M1 + currentShare3.BJ[1].M2 + currentShare3.BJ[1].M3 + currentShare3.BJ[1].M4) / 4m;
            //AVERAGE(市场容量及各品牌当年占有率!BP7:BS7
            var bp7_bs7 = (currentShare3.BJ[2].M1 + currentShare3.BJ[2].M2 + currentShare3.BJ[2].M3 + currentShare3.BJ[2].M4) / 4m;
            //AVERAGE(市场容量及各品牌当年占有率!BV7:BY7)
            var bv7_by7 = (currentShare3.BJ[3].M1 + currentShare3.BJ[3].M2 + currentShare3.BJ[3].M3 + currentShare3.BJ[3].M4) / 4m;
            // AVERAGE(市场容量及各品牌当年占有率!CB7:CE7)
            var cb7_ce7 = (currentShare3.CB[1].J1 + currentShare3.CB[1].J2 + currentShare3.CB[1].J3 + currentShare3.CB[1].J4) / 4m;
            //AVERAGE(市场容量及各品牌当年占有率!CH7:CK7
            var ch7_ck7 = (currentShare3.CB[2].J1 + currentShare3.CB[2].J2 + currentShare3.CB[2].J3 + currentShare3.CB[2].J4) / 4m;
            //AVERAGE(市场容量及各品牌当年占有率!CN7:CQ7)
            var cn7_cq7 = (currentShare3.CB[3].J1 + currentShare3.CB[3].J2 + currentShare3.CB[3].J3 + currentShare3.CB[3].J4) / 4m;

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
                        summaryAssent5.Q = item.B * market2.CD[1].S + item.D * market2.CD[2].S;
                        summaryAssent5.X = item.O * market2.CM[1].S + item.Q * market2.CD[2].S;
                        summaryAssent5.AE = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AL = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.J = item.G * market1.DK[1].Agent1 * 0.05m + item.G * market1.EF[1].Agent1 * 0.06m + 300;
                        summaryAssent7.X = item.O * market2.DK[1].Agent1 * 0.05m + item.O * market2.EF[1].Agent1 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent1 * 0.05m + item.Q * market2.EF[2].Agent1 * 0.06m + 300;
                        summaryAssent7.AL = item.AC * market3.DK[1].Agent1 * 0.05m + item.AC * market3.EF[1].Agent1 *
                            ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent1 * 0.05m + item.AE * market3.EF[2].Agent1
                            * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent1 * 0.05m +
                            item.AG * market3.EF[3].Agent1 * 0.06m + 300;
                        summaryAssent8.J = item.G * (market1.EF[1].Agent1 > market1.DK[1].Agent1 ? (market1.EF[1].Agent1 - market1.DK[1].Agent1): 0);
                        summaryAssent8.X = item.O * (market2.EF[1].Agent1 > market2.DK[1].Agent1 ? (market2.EF[1].Agent1 - market2.DK[1].Agent1) : 0) +
                            item.Q * (market2.EF[2].Agent1 > market2.DK[2].Agent1 ? (market2.EF[2].Agent1 - market2.DK[2].Agent1) : 0);
                        summaryAssent8.AL= item.AC* (market3.EF[1].Agent1 > market3.DK[1].Agent1?(market3.EF[1].Agent1 - market3.DK[1].Agent1):0)+
                            item.AE* (market3.EF[2].Agent1 > market3.DK[2].Agent1?(market3.EF[2].Agent1 - market3.DK[2].Agent1):0)+
                            item.AG* (market3.EF[3].Agent1 > market3.DK[3].Agent1?(market3.EF[3].Agent1 - market3.DK[3].Agent1):0);
                        summaryAssent9.J = item.I;
                        summaryAssent9.X = item.S + item.U;
                        summaryAssent9.AL =item.AI +item.AK +item.AM;

                        break;
                    case AgentName.代2:
                        summaryAssent1.K = item.D;
                        summaryAssent4.K = item.G * market1.EF[1].Agent2;
                        summaryAssent4.Y = item.O * market2.EF[1].Agent2 + item.Q * market2.EF[2].Agent2;
                        summaryAssent4.AM = item.AC * market3.EF[1].Agent2 + item.AE * market3.EF[2].Agent2 + item.AG * market3.EF[3].Agent2;
                        summaryAssent5.D = item.E * market1.CD[1].S;
                        summaryAssent5.K = item.G * market1.CM[1].S;
                        summaryAssent5.R = item.B * market2.CD[1].S + item.D * market2.CD[2].S;
                        summaryAssent5.Y = item.O * market2.CM[1].S + item.Q * market2.CD[2].S;
                        summaryAssent5.AF = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AM = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.K = item.G * market1.DK[1].Agent2 * 0.05m + item.G * market1.EF[1].Agent2 * 0.06m + 300;
                        summaryAssent7.Y = item.O * market2.DK[1].Agent2 * 0.05m + item.O * market2.EF[1].Agent2 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent2 * 0.05m + item.Q * market2.EF[2].Agent2 * 0.06m + 300;
                        summaryAssent7.AM = item.AC * market3.DK[1].Agent2 * 0.05m + item.AC * market3.EF[1].Agent2 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent2 * 0.05m + item.AE * market3.EF[2].Agent2
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent2 * 0.05m +
                          item.AG * market3.EF[3].Agent2 * 0.06m + 300;
                        summaryAssent8.K = item.G * (market1.EF[1].Agent2 > market1.DK[1].Agent2 ? (market1.EF[1].Agent2 - market1.DK[1].Agent2) : 0);
                        summaryAssent8.Y = item.O * (market2.EF[1].Agent1 > market2.DK[1].Agent1 ? (market2.EF[1].Agent1 - market2.DK[1].Agent1) : 0) +
                         item.Q * (market2.EF[2].Agent1 > market2.DK[2].Agent1 ? (market2.EF[2].Agent1 - market2.DK[2].Agent1) : 0);
                        summaryAssent8.AM = item.AC * (market3.EF[1].Agent1 > market3.DK[1].Agent1 ? (market3.EF[1].Agent1 - market3.DK[1].Agent1) : 0) +
                         item.AE * (market3.EF[2].Agent1 > market3.DK[2].Agent1 ? (market3.EF[2].Agent1 - market3.DK[2].Agent1) : 0) +
                         item.AG * (market3.EF[3].Agent1 > market3.DK[3].Agent1 ? (market3.EF[3].Agent1 - market3.DK[3].Agent1) : 0);
                        summaryAssent9.K = item.I;
                        summaryAssent9.Y = item.S + item.U;
                        summaryAssent9.AM = item.AI + item.AK + item.AM;

                        break;
                    case AgentName.代3:
                        summaryAssent1.L = item.D;
                        summaryAssent4.L = item.G * market1.EF[1].Agent3;
                        summaryAssent4.Z = item.O * market2.EF[1].Agent3 + item.Q * market2.EF[2].Agent3;
                        summaryAssent4.AN = item.AC * market3.EF[1].Agent3 + item.AE * market3.EF[2].Agent3 + item.AG * market3.EF[3].Agent3;
                        summaryAssent5.E = item.E * market1.CD[1].S;
                        summaryAssent5.L = item.G * market1.CM[1].S;
                        summaryAssent5.S = item.B * market2.CD[1].S + item.D * market2.CD[2].S;
                        summaryAssent5.Z = item.O * market2.CM[1].S + item.Q * market2.CD[2].S;
                        summaryAssent5.AG = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AN = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.L = item.G * market1.DK[1].Agent3 * 0.05m + item.G * market1.EF[1].Agent3 * 0.06m + 300;
                        summaryAssent7.Z = item.O * market2.DK[1].Agent3 * 0.05m + item.O * market2.EF[1].Agent3 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent3 * 0.05m + item.Q * market2.EF[2].Agent3 * 0.06m + 300;
                        summaryAssent7.AN = item.AC * market3.DK[1].Agent3 * 0.05m + item.AC * market3.EF[1].Agent3 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent3 * 0.05m + item.AE * market3.EF[2].Agent3
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent3 * 0.05m +
                          item.AG * market3.EF[3].Agent3 * 0.06m + 300;
                        summaryAssent8.L = item.G * (market1.EF[1].Agent3 > market1.DK[1].Agent3 ? (market1.EF[1].Agent3 - market1.DK[1].Agent3) : 0);
                        summaryAssent8.Z = item.O * (market2.EF[1].Agent1 > market2.DK[1].Agent1 ? (market2.EF[1].Agent1 - market2.DK[1].Agent1) : 0) +
                         item.Q * (market2.EF[2].Agent1 > market2.DK[2].Agent1 ? (market2.EF[2].Agent1 - market2.DK[2].Agent1) : 0);
                        summaryAssent8.AN = item.AC * (market3.EF[1].Agent1 > market3.DK[1].Agent1 ? (market3.EF[1].Agent1 - market3.DK[1].Agent1) : 0) +
                         item.AE * (market3.EF[2].Agent1 > market3.DK[2].Agent1 ? (market3.EF[2].Agent1 - market3.DK[2].Agent1) : 0) +
                         item.AG * (market3.EF[3].Agent1 > market3.DK[3].Agent1 ? (market3.EF[3].Agent1 - market3.DK[3].Agent1) : 0);
                        summaryAssent9.L = item.I;
                        summaryAssent9.Z = item.S + item.U;
                        summaryAssent9.AN = item.AI + item.AK + item.AM;

                        break;
                    case AgentName.代4:
                        summaryAssent1.M = item.D;
                        summaryAssent4.M = item.G * market1.EF[1].Agent4;
                        summaryAssent4.AA = item.O * market2.EF[1].Agent4 + item.Q * market2.EF[2].Agent4;
                        summaryAssent4.AO = item.AC * market3.EF[1].Agent4 + item.AE * market3.EF[2].Agent4 + item.AG * market3.EF[3].Agent4;
                        summaryAssent5.F = item.E * market1.CD[1].S;
                        summaryAssent5.M = item.G * market1.CM[1].S;
                        summaryAssent5.T = item.B * market2.CD[1].S + item.D * market2.CD[2].S;
                        summaryAssent5.AA = item.O * market2.CM[1].S + item.Q * market2.CD[2].S;
                        summaryAssent5.AH = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AO = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.M = item.G * market1.DK[1].Agent4 * 0.05m + item.G * market1.EF[1].Agent4 * 0.06m + 300;
                        summaryAssent7.AA = item.O * market2.DK[1].Agent4 * 0.05m + item.O * market2.EF[1].Agent4 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent4 * 0.05m + item.Q * market2.EF[2].Agent4 * 0.06m + 300;
                        summaryAssent7.AO = item.AC * market3.DK[1].Agent1 * 0.05m + item.AC * market3.EF[1].Agent1 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent1 * 0.05m + item.AE * market3.EF[2].Agent1
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent1 * 0.05m +
                          item.AG * market3.EF[3].Agent1 * 0.06m + 300;
                        summaryAssent8.M = item.G * (market1.EF[1].Agent4 > market1.DK[1].Agent4 ? (market1.EF[1].Agent4 - market1.DK[1].Agent4) : 0);
                        summaryAssent8.AA = item.O * (market2.EF[1].Agent1 > market2.DK[1].Agent1 ? (market2.EF[1].Agent1 - market2.DK[1].Agent1) : 0) +
                         item.Q * (market2.EF[2].Agent1 > market2.DK[2].Agent1 ? (market2.EF[2].Agent1 - market2.DK[2].Agent1) : 0);
                        summaryAssent8.AO = item.AC * (market3.EF[1].Agent1 > market3.DK[1].Agent1 ? (market3.EF[1].Agent1 - market3.DK[1].Agent1) : 0) +
                         item.AE * (market3.EF[2].Agent1 > market3.DK[2].Agent1 ? (market3.EF[2].Agent1 - market3.DK[2].Agent1) : 0) +
                         item.AG * (market3.EF[3].Agent1 > market3.DK[3].Agent1 ? (market3.EF[3].Agent1 - market3.DK[3].Agent1) : 0);
                        summaryAssent9.M = item.I;
                        summaryAssent9.AA = item.S + item.U;
                        summaryAssent9.AO = item.AI + item.AK + item.AM;

                        break;
                    case AgentName.代5:
                        summaryAssent1.N = item.D;
                        summaryAssent4.N = item.G * market1.EF[1].Agent5;
                        summaryAssent4.AB = item.O * market2.EF[1].Agent5 + item.Q * market2.EF[2].Agent5;
                        summaryAssent4.AP = item.AC * market3.EF[1].Agent5 + item.AE * market3.EF[2].Agent5 + item.AG * market3.EF[3].Agent5;
                        summaryAssent5.G = item.E * market1.CD[1].S;
                        summaryAssent5.N = item.G * market1.CM[1].S;
                        summaryAssent5.U = item.B * market2.CD[1].S + item.D * market2.CD[2].S;
                        summaryAssent5.AB = item.O * market2.CM[1].S + item.Q * market2.CD[2].S;
                        summaryAssent5.AI = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AP = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.N = item.G * market1.DK[1].Agent5 * 0.05m + item.G * market1.EF[1].Agent5 * 0.06m + 300;
                        summaryAssent7.AB = item.O * market2.DK[1].Agent5 * 0.05m + item.O * market2.EF[1].Agent5 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent5 * 0.05m + item.Q * market2.EF[2].Agent5 * 0.06m + 300;
                        summaryAssent7.AP = item.AC * market3.DK[1].Agent5 * 0.05m + item.AC * market3.EF[1].Agent5 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent5 * 0.05m + item.AE * market3.EF[2].Agent5
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent5 * 0.05m +
                          item.AG * market3.EF[3].Agent5 * 0.06m + 300;
                        summaryAssent8.N = item.G * (market1.EF[1].Agent5 > market1.DK[1].Agent5 ? (market1.EF[1].Agent5 - market1.DK[1].Agent5) : 0);
                        summaryAssent8.AB = item.O * (market2.EF[1].Agent1 > market2.DK[1].Agent1 ? (market2.EF[1].Agent1 - market2.DK[1].Agent1) : 0) +
                         item.Q * (market2.EF[2].Agent1 > market2.DK[2].Agent1 ? (market2.EF[2].Agent1 - market2.DK[2].Agent1) : 0);
                        summaryAssent8.AP = item.AC * (market3.EF[1].Agent1 > market3.DK[1].Agent1 ? (market3.EF[1].Agent1 - market3.DK[1].Agent1) : 0) +
                         item.AE * (market3.EF[2].Agent1 > market3.DK[2].Agent1 ? (market3.EF[2].Agent1 - market3.DK[2].Agent1) : 0) +
                         item.AG * (market3.EF[3].Agent1 > market3.DK[3].Agent1 ? (market3.EF[3].Agent1 - market3.DK[3].Agent1) : 0);
                        summaryAssent9.N= item.I;
                        summaryAssent9.AB = item.S + item.U;
                        summaryAssent9.AP = item.AI + item.AK + item.AM;

                        break;
                    case AgentName.代6:
                        summaryAssent1.O = item.D;
                        summaryAssent4.O = item.G * market1.EF[1].Agent6;
                        summaryAssent4.AC = item.O * market2.EF[1].Agent6 + item.Q * market2.EF[2].Agent6;
                        summaryAssent4.AQ = item.AC * market3.EF[1].Agent6 + item.AE * market3.EF[2].Agent6 + item.AG * market3.EF[3].Agent6;
                        summaryAssent5.H = item.E * market1.CD[1].S;
                        summaryAssent5.O = item.G * market1.CM[1].S;
                        summaryAssent5.V = item.B * market2.CD[1].S + item.D * market2.CD[2].S;
                        summaryAssent5.AC = item.O * market2.CM[1].S + item.Q * market2.CD[2].S;
                        summaryAssent5.AJ = item.W * market3.CD[1].S + item.Y * market3.CD[2].S + item.AA * market3.CD[3].S;
                        summaryAssent5.AQ = item.AC * market3.CM[1].S + item.AE * market3.CM[2].S + item.AG * market3.CM[3].S;
                        summaryAssent7.O = item.G * market1.DK[1].Agent6 * 0.05m + item.G * market1.EF[1].Agent6 * 0.06m + 300;
                        summaryAssent7.AC = item.O * market2.DK[1].Agent6 * 0.05m + item.O * market2.EF[1].Agent6 * ((item.P / item.H - 1) < 0.15m ? 0.06m : 0.05m) + item.Q * market2.DK[2].Agent6 * 0.05m + item.Q * market2.EF[2].Agent6 * 0.06m + 300;
                        summaryAssent7.AQ = item.AC * market3.DK[1].Agent6 * 0.05m + item.AC * market3.EF[1].Agent6 *
                          ((item.AD / item.P - 1) < 0.15m ? 0.06m : 0.05m) + item.AE * market3.DK[2].Agent6 * 0.05m + item.AE * market3.EF[2].Agent6
                          * ((item.AF / item.R - 1) < 0.15m ? 0.06m : 0.05m) + item.AG * market3.DK[3].Agent6 * 0.05m +
                          item.AG * market3.EF[3].Agent6 * 0.06m + 300;
                        summaryAssent8.O= item.G * (market1.EF[1].Agent6 > market1.DK[1].Agent6 ? (market1.EF[1].Agent6 - market1.DK[1].Agent6) : 0);
                        summaryAssent8.AC = item.O * (market2.EF[1].Agent1 > market2.DK[1].Agent1 ? (market2.EF[1].Agent1 - market2.DK[1].Agent1) : 0) +
                         item.Q * (market2.EF[2].Agent1 > market2.DK[2].Agent1 ? (market2.EF[2].Agent1 - market2.DK[2].Agent1) : 0);
                        summaryAssent8.AQ = item.AC * (market3.EF[1].Agent1 > market3.DK[1].Agent1 ? (market3.EF[1].Agent1 - market3.DK[1].Agent1) : 0) +
                         item.AE * (market3.EF[2].Agent1 > market3.DK[2].Agent1 ? (market3.EF[2].Agent1 - market3.DK[2].Agent1) : 0) +
                         item.AG * (market3.EF[3].Agent1 > market3.DK[3].Agent1 ? (market3.EF[3].Agent1 - market3.DK[3].Agent1) : 0);
                        summaryAssent9.O = item.I;
                        summaryAssent9.AC = item.S + item.U;
                        summaryAssent9.AQ = item.AI + item.AK + item.AM;

                        break;
                    default:
                        break;
                }
            }
            summaryAssent2.B = 2000;
            summaryAssent2.C = 2000;
            summaryAssent2.D = 2000;
            summaryAssent2.E = 2000;
            summaryAssent2.F = 2000;
            summaryAssent2.G = 2000;
            summaryAssent2.H = 2000;
            summaryAssent2.I = 2000;
            summaryAssent2.J = 1500;
            summaryAssent2.K = 1500;
            summaryAssent2.L = 1500;
            summaryAssent2.M = 1500;
            summaryAssent2.N = 1500;
            summaryAssent2.O = 1500;

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

            summaryAssent4.B = bj5_bm5 * market1.DE[1].M / (1 + 0.10m);
            summaryAssent4.I = cb5_ce5 * market1.DE[1].J / (1 + 0.12m);
            summaryAssent4.P = bj6_bm6 * market2.DE[1].M / (1 + 0.10m) + bp6_bs6 * market2.DE[2].M / (1 + 0.10m);
            summaryAssent4.W = cb6_ce6 * market2.DE[1].J / (1 + 0.12m) + ch6_ck6 * market2.DE[2].J / (1 + 0.12m);
            summaryAssent4.AD = bj7_bm7 * market3.DE[1].M / (1 + 0.10m) + bj7_bm7 * market3.DE[2].M / (1 + 0.10m);
            summaryAssent4.AK = cb7_ce7 * market3.DE[1].J / (1 + 0.12m) + ch7_ck7 * market3.DE[2].J / (1 + 0.12m) + cn7_cq7 * market3.DE[3].J / (1 + 0.12m);

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
            var summary2 = stockReports.Where(s => s.Stage == Stage.第二阶段.ToString());
            foreach (var item in summary2)
            {
                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                switch (agentName)
                {
                    case AgentName.代1: summaryAssent4.Q = item.Sum.Sum; break;
                    case AgentName.代2: summaryAssent4.R = item.Sum.Sum; break;
                    case AgentName.代3: summaryAssent4.S = item.Sum.Sum; break;
                    case AgentName.代4: summaryAssent4.T = item.Sum.Sum; break;
                    case AgentName.代5: summaryAssent4.U = item.Sum.Sum; break;
                    case AgentName.代6: summaryAssent4.V = item.Sum.Sum; break;
                }
            }
            var summary3 = stockReports.Where(s => s.Stage == Stage.第三阶段.ToString());
            foreach (var item in summary2)
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
            summaryAssent5.B = bj5_bm5 * market1.CD[1].M;
            summaryAssent5.I = cb5_ce5 * market1.CD[1].J;
            summaryAssent5.P = bj6_bm6 * market2.CD[1].M + bp6_bs6 * market2.CD[2].M;
            summaryAssent5.W = cb6_ce6 * market2.CD[1].J + ch6_ck6 * market2.CD[2].J;
            summaryAssent5.AD = bj7_bm7 * market3.CD[1].M + bp7_bs7 * market3.CD[2].M + bv7_by7 * market3.CD[3].M;
            summaryAssent5.AK = cb6_ce6 * market2.CD[1].J + ch6_ck6 * market2.CD[2].J + cn7_cq7 * market2.CD[3].J;
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
            summaryAssent7.J = 200 + df5 * cb5_ce5 * 0.04m + df5 / (1 + 0.12m) * cb5_ce5 * 0.07m;
            summaryAssent7.P = 500 + (market2.DE[1].M * bj6_bm6) * 0.05m + market2.DE[1].M / (1 + 0.10m) * bj6_bm6 * 0.05m
                + market2.DE[1].M * bp6_bs6 * 0.05m + market2.DE[1].M / (1 + 0.10m) * bp6_bs6 * 0.05m;

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
            #region 期初库存
            summaryAssent1.X = summaryAssent9.J;
            summaryAssent1.Y = summaryAssent9.K;
            summaryAssent1.Z = summaryAssent9.L;
            summaryAssent1.AA = summaryAssent9.M;
            summaryAssent1.AB = summaryAssent9.N;
            summaryAssent1.AC = summaryAssent9.O;

            summaryAssent1.AL = summaryAssent9.X;
            summaryAssent1.AM = summaryAssent9.Y;
            summaryAssent1.AN = summaryAssent9.Z;
            summaryAssent1.AO = summaryAssent9.AA;
            summaryAssent1.AP = summaryAssent9.AB;
            summaryAssent1.AQ = summaryAssent9.AC;
            #endregion

            #region 期初现金余额
            summaryAssent2.P = summaryAssent9.B;
            summaryAssent2.Q = summaryAssent9.C;
            summaryAssent2.R = summaryAssent9.D;
            summaryAssent2.S = summaryAssent9.E;
            summaryAssent2.T = summaryAssent9.F;
            summaryAssent2.U = summaryAssent9.G;
            summaryAssent2.V = summaryAssent9.H;
            summaryAssent2.W = summaryAssent9.I;
            summaryAssent2.X = summaryAssent9.J;
            summaryAssent2.Y = summaryAssent9.K;
            summaryAssent2.Z = summaryAssent9.L;
            summaryAssent2.AA = summaryAssent9.M;
            summaryAssent2.AB = summaryAssent9.N;
            summaryAssent2.AC = summaryAssent9.O;
            summaryAssent2.AD = summaryAssent9.P;
            summaryAssent2.AE = summaryAssent9.Q;
            summaryAssent2.AF = summaryAssent9.R;
            summaryAssent2.AG = summaryAssent9.S;
            summaryAssent2.AH = summaryAssent9.T;
            summaryAssent2.AI = summaryAssent9.U;
            summaryAssent2.AJ = summaryAssent9.V;
            summaryAssent2.AK = summaryAssent9.W;
            summaryAssent2.AL = summaryAssent9.X;
            summaryAssent2.AM = summaryAssent9.Y;
            summaryAssent2.AN = summaryAssent9.Z;
            summaryAssent2.AO = summaryAssent9.AA;
            summaryAssent2.AP = summaryAssent9.AB;
            summaryAssent2.AQ = summaryAssent9.AC;
            #endregion

            #region 品牌商综合经营费用 summaryAssent11
            summaryAssent11.B = summaryAssent4.B * 0.19m;
            summaryAssent11.C = summaryAssent4.C * 0.2m;
            summaryAssent11.D = summaryAssent4.D * 0.2m;
            summaryAssent11.E = summaryAssent4.E * 0.2m;
            summaryAssent11.F = summaryAssent4.F * 0.2m;
            summaryAssent11.G = summaryAssent4.G * 0.2m;
            summaryAssent11.H = summaryAssent4.H * 0.2m;
            summaryAssent11.I = summaryAssent4.I * 0.2m;

            summaryAssent11.P = summaryAssent4.P * 0.19m;
            summaryAssent11.Q = summaryAssent4.Q * 0.2m;
            summaryAssent11.R = summaryAssent4.R * 0.2m;
            summaryAssent11.S = summaryAssent4.S * 0.2m;
            summaryAssent11.T = summaryAssent4.T * 0.2m;
            summaryAssent11.U = summaryAssent4.U * 0.2m;
            summaryAssent11.V = summaryAssent4.V * 0.2m;
            summaryAssent11.W = summaryAssent4.W * 0.2m;

            summaryAssent11.AD = summaryAssent4.AD * 0.19m;
            summaryAssent11.AE = summaryAssent4.AE * 0.2m;
            summaryAssent11.AF = summaryAssent4.AF * 0.2m;
            summaryAssent11.AG = summaryAssent4.AG * 0.2m;
            summaryAssent11.AH = summaryAssent4.AH * 0.2m;
            summaryAssent11.AI = summaryAssent4.AI * 0.2m;
            summaryAssent11.AJ = summaryAssent4.AJ * 0.2m;
            summaryAssent11.AK = summaryAssent4.AK * 0.2m;

            #endregion

            #region 期末现金余额 summaryAssent12
            summaryAssent12.B = summaryAssent2.B + summaryAssent4.B - summaryAssent5.B - summaryAssent6.B - summaryAssent7.B - summaryAssent11.B;
            summaryAssent12.C = summaryAssent2.C + summaryAssent4.C - summaryAssent5.C - summaryAssent6.C - summaryAssent7.C - summaryAssent11.C;
            summaryAssent12.D = summaryAssent2.D + summaryAssent4.D - summaryAssent5.D - summaryAssent6.D - summaryAssent7.D - summaryAssent11.D;
            summaryAssent12.E = summaryAssent2.E + summaryAssent4.E - summaryAssent5.E - summaryAssent6.E - summaryAssent7.E - summaryAssent11.E;
            summaryAssent12.F = summaryAssent2.F + summaryAssent4.F - summaryAssent5.F - summaryAssent6.F - summaryAssent7.F - summaryAssent11.F;
            summaryAssent12.G = summaryAssent2.G + summaryAssent4.G - summaryAssent5.G - summaryAssent6.G - summaryAssent7.G - summaryAssent11.G;
            summaryAssent12.H = summaryAssent2.H + summaryAssent4.H - summaryAssent5.H - summaryAssent6.H - summaryAssent7.H - summaryAssent11.H;
            summaryAssent12.I = summaryAssent2.I + summaryAssent4.I - summaryAssent5.I - summaryAssent6.I - summaryAssent7.I - summaryAssent11.I;
             
            summaryAssent12.J = summaryAssent2.J + summaryAssent3.J + summaryAssent4.J - summaryAssent5.J - summaryAssent6.J - summaryAssent7.J - summaryAssent7.J - (summaryAssent9.J - summaryAssent1.J) * market1.CM[1].S + summaryAssent10.J;
            summaryAssent12.K = summaryAssent2.K + summaryAssent3.K + summaryAssent4.K - summaryAssent5.K - summaryAssent6.K - summaryAssent7.K - summaryAssent7.K - (summaryAssent9.K - summaryAssent1.K) * market1.CM[1].S + summaryAssent10.K;
            summaryAssent12.L = summaryAssent2.L + summaryAssent3.L + summaryAssent4.L - summaryAssent5.L - summaryAssent6.L - summaryAssent7.L - summaryAssent7.L - (summaryAssent9.L - summaryAssent1.L) * market1.CM[1].S + summaryAssent10.L;
            summaryAssent12.M = summaryAssent2.M + summaryAssent3.M + summaryAssent4.M - summaryAssent5.M - summaryAssent6.M - summaryAssent7.M - summaryAssent7.M - (summaryAssent9.M - summaryAssent1.M) * market1.CM[1].S + summaryAssent10.M;
            summaryAssent12.N = summaryAssent2.N + summaryAssent3.N + summaryAssent4.N - summaryAssent5.N - summaryAssent6.N - summaryAssent7.N - summaryAssent7.N - (summaryAssent9.N - summaryAssent1.N) * market1.CM[1].S + summaryAssent10.N;
            summaryAssent12.O = summaryAssent2.O + summaryAssent3.O + summaryAssent4.O - summaryAssent5.O - summaryAssent6.O - summaryAssent7.O - summaryAssent7.O - (summaryAssent9.O - summaryAssent1.O) * market1.CM[1].S + summaryAssent10.O;

            summaryAssent12.P = summaryAssent2.P + summaryAssent4.P - summaryAssent5.P - summaryAssent6.P - summaryAssent7.P - summaryAssent11.P;
            summaryAssent12.Q = summaryAssent2.Q + summaryAssent4.Q - summaryAssent5.Q - summaryAssent6.Q - summaryAssent7.Q - summaryAssent11.Q;
            summaryAssent12.R = summaryAssent2.R + summaryAssent4.R - summaryAssent5.R - summaryAssent6.R - summaryAssent7.R - summaryAssent11.R;
            summaryAssent12.S = summaryAssent2.S + summaryAssent4.S - summaryAssent5.S - summaryAssent6.S - summaryAssent7.S - summaryAssent11.S;
            summaryAssent12.T = summaryAssent2.T + summaryAssent4.T - summaryAssent5.T - summaryAssent6.T - summaryAssent7.T - summaryAssent11.T;
            summaryAssent12.U = summaryAssent2.U + summaryAssent4.U - summaryAssent5.U - summaryAssent6.U - summaryAssent7.U - summaryAssent11.U;
            summaryAssent12.V = summaryAssent2.V + summaryAssent4.V - summaryAssent5.V - summaryAssent6.V - summaryAssent7.V - summaryAssent11.V;
            summaryAssent12.W = summaryAssent2.W + summaryAssent4.W - summaryAssent5.W - summaryAssent6.W - summaryAssent7.W - summaryAssent11.W;



            summaryAssent12.AD = summaryAssent2.AD + summaryAssent4.AD - summaryAssent5.AD - summaryAssent6.AD - summaryAssent7.AD - summaryAssent11.AD;
            summaryAssent12.AE = summaryAssent2.AE + summaryAssent4.AE - summaryAssent5.AE - summaryAssent6.AE - summaryAssent7.AE - summaryAssent11.AE;
            summaryAssent12.AF = summaryAssent2.AF + summaryAssent4.AF - summaryAssent5.AF - summaryAssent6.AF - summaryAssent7.AF - summaryAssent11.AF;
            summaryAssent12.AG = summaryAssent2.AG + summaryAssent4.AG - summaryAssent5.AG - summaryAssent6.AG - summaryAssent7.AG - summaryAssent11.AG;
            summaryAssent12.AH = summaryAssent2.AH + summaryAssent4.AH - summaryAssent5.AH - summaryAssent6.AH - summaryAssent7.AH - summaryAssent11.AH;
            summaryAssent12.AI = summaryAssent2.AI + summaryAssent4.AI - summaryAssent5.AI - summaryAssent6.AI - summaryAssent7.AI - summaryAssent11.AI;
            summaryAssent12.AJ = summaryAssent2.AJ + summaryAssent4.AJ - summaryAssent5.AJ - summaryAssent6.AJ - summaryAssent7.AJ - summaryAssent11.AJ;
            summaryAssent12.AK = summaryAssent2.AK + summaryAssent4.AK - summaryAssent5.AK - summaryAssent6.AK - summaryAssent7.AK - summaryAssent11.AK;
           

            #endregion
            #endregion
        }

        public List<SummaryTable> GetSummarys()
        {
            return summarys;
        }
    }
    public class SummaryTable
    {
        public string 科目 { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D { get; set; }
        public decimal E { get; set; }
        public decimal F { get; set; }
        public decimal G { get; set; }
        public decimal H { get; set; }
        public decimal I { get; set; }
        public decimal J { get; set; }
        public decimal K { get; set; }
        public decimal L { get; set; }
        public decimal M { get; set; }
        public decimal N { get; set; }
        public decimal O { get; set; }
        public decimal P { get; set; }
        public decimal Q { get; set; }
        public decimal R { get; set; }
        public decimal S { get; set; }
        public decimal T { get; set; }
        public decimal U { get; set; }
        public decimal V { get; set; }
        public decimal W { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public decimal AA { get; set; }
        public decimal AB { get; set; }
        public decimal AC { get; set; }
        public decimal AD { get; set; }
        public decimal AE { get; set; }
        public decimal AF { get; set; }
        public decimal AG { get; set; }
        public decimal AH { get; set; }
        public decimal AI { get; set; }
        public decimal AJ { get; set; }
        public decimal AK { get; set; }
        public decimal AL { get; set; }
        public decimal AM { get; set; }
        public decimal AN { get; set; }
        public decimal AO { get; internal set; }
        public decimal AP { get; internal set; }
        public decimal AQ { get; internal set; }
    }
}