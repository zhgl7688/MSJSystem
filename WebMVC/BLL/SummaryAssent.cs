using System;
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
        AgentStages agentStages;
        public SummaryAssent(StockReport StockReport, InvoicingReport InvoicingReport, MarketPrice MarketPrice,
           Investment Investment, CurrentShare CurrentShare)
        {
            agentStages = new AgentStages();
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
            summarys.ForEach(s =>
            {
                s.count = agentStages.agents.Count;
                s.AgentInit();
            });
            summaryAssent2.B = summaryAssent2.I = 2000;
            for (int i = 0; i < agentStages.agents.Count; i++)
            {

                summaryAssent2.CAgent[i]=(2000);
                summaryAssent2.JAgent[i]=(15000);
             }
            #endregion
            var count = agentStages.agents.Count;
            var currentShare1 = currentShares.FirstOrDefault(s => s.Stage == Stage.第1阶段.ToString());
            currentShare1 = currentShare1 ?? new CurrentShareTable();
            var currentShare2 = currentShares.FirstOrDefault(s => s.Stage == Stage.第2阶段.ToString());
            currentShare2 = currentShare2 ?? new CurrentShareTable();
            var currentShare3 = currentShares.FirstOrDefault(s => s.Stage == Stage.第3阶段.ToString());
            currentShare3 = currentShare3 ?? new CurrentShareTable();
            var investment1 = investments.FirstOrDefault(s => s.Stage == Stage.第1阶段.ToString());
            currentShare1 = currentShare1 ?? new CurrentShareTable();
            var investment2 = investments.FirstOrDefault(s => s.Stage == Stage.第2阶段.ToString());
            currentShare2 = currentShare2 ?? new CurrentShareTable();
            var investment3 = investments.FirstOrDefault(s => s.Stage == Stage.第3阶段.ToString());
            currentShare3 = currentShare3 ?? new CurrentShareTable();
            var market1 = markets.FirstOrDefault(s => s.Stage == Stage.第1阶段.ToString());
            market1 = market1 ?? new MarketTable();
            var market2 = markets.FirstOrDefault(s => s.Stage == Stage.第2阶段.ToString());
            market2 = market2 ?? new MarketTable();
            var market3 = markets.FirstOrDefault(s => s.Stage == Stage.第3阶段.ToString());
            market3 = market3 ?? new MarketTable();
            var stockReport1 = stockReports.Where(s => s.Stage == Stage.第1阶段.ToString());
            var stockReport2 = stockReports.Where(s => s.Stage == Stage.第2阶段.ToString());
            var stockReport3 = stockReports.Where(s => s.Stage == Stage.第3阶段.ToString());
            // AVERAGE(市场容量及各品牌当年占有率!CB5:CE5)
            var cb5_ce5 = Common.Cal.GetMJAAverage(currentShare1.CB[0], count, MJAType.J);
            //AVERAGE(市场容量及各品牌当年占有率!BJ5:BM5)
            var bj5_bm5 = Common.Cal.GetMJAAverage(currentShare1.BJ[0], count, MJAType.M);


            //AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6)
            var bj6_bm6 = Common.Cal.GetMJAAverage(currentShare2.BJ[0], count, MJAType.M);
            //AVERAGE(市场容量及各品牌当年占有率!BP6:BS6
            var bp6_bs6 = Common.Cal.GetMJAAverage(currentShare2.BJ[1], count, MJAType.M);
            // AVERAGE(市场容量及各品牌当年占有率!CB6:CE6)
            var cb6_ce6 = Common.Cal.GetMJAAverage(currentShare2.CB[0], count, MJAType.J);
            //AVERAGE(市场容量及各品牌当年占有率!CH6:CK6
            var ch6_ck6 = Common.Cal.GetMJAAverage(currentShare2.CB[1], count, MJAType.J);

            //AVERAGE(市场容量及各品牌当年占有率!BJ7:BM7
            var bj7_bm7 = Common.Cal.GetMJAAverage(currentShare3.BJ[0], count, MJAType.M);
            //AVERAGE(市场容量及各品牌当年占有率!BP7:BS7
            var bp7_bs7 = Common.Cal.GetMJAAverage(currentShare3.BJ[1], count, MJAType.M);
            //AVERAGE(市场容量及各品牌当年占有率!BV7:BY7)
            var bv7_by7 = Common.Cal.GetMJAAverage(currentShare3.BJ[2], count, MJAType.M);
            // AVERAGE(市场容量及各品牌当年占有率!CB7:CE7)
            var cb7_ce7 = Common.Cal.GetMJAAverage(currentShare3.CB[0], count, MJAType.J);
            //AVERAGE(市场容量及各品牌当年占有率!CH7:CK7
            var ch7_ck7 = Common.Cal.GetMJAAverage(currentShare3.CB[1], count, MJAType.J);
            //AVERAGE(市场容量及各品牌当年占有率!CN7:CQ7)
            var cn7_cq7 = Common.Cal.GetMJAAverage(currentShare3.CB[2], count, MJAType.J);

            var de5 = market1.DE[0].M;//市场价格!DF6
            var df5 = market1.DE[0].J;//市场价格!DH6
            var df6 = market2.DE[0].J;//市场价格!DF6
            var dh6 = market2.DE[1].J;//市场价格!DH6

            for (int i = 0; i < invocicings.Count; i++)//代理循环
            {
                var item = invocicings.FirstOrDefault(s => s.AgentName == agentStages.agents[i]);

                for (int j = 0; j < agentStages.stages.Count - 1; j++)
                {
                    summaryAssent4.JAgent[i]=item.CStage[1][0] * market1.EF[0].Agent[i];
                    summaryAssent4.XAgent[i]=(item.CStage[2][0] * market2.EF[0].Agent[i] + item.CStage[2][1] * market2.EF[1].Agent[i]);
                    summaryAssent4.ALAgent[i]=(item.CStage[3][0] * market3.EF[0].Agent[i] + item.CStage[3][1] * market3.EF[1].Agent[i] + item.CStage[3][2] * market3.EF[2].Agent[i]);

                }

                summaryAssent5.XAgent[i]=(item.CStage[2][0] * market2.CM[1].S + item.CStage[2][1] * market2.CM[2].S);
                summaryAssent8.XAgent[i]=(item.CStage[2][0] * (market2.EF[1].Agent[i] > market2.DK[1].Agent[i] ?
                    (market2.EF[1].Agent[i] - market2.DK[1].Agent[i]) : 0) +
                           item.CStage[2][0] * (market2.EF[1].Agent[i] > market2.DK[1].Agent[i] ? (market2.EF[1].Agent[i] - market2.DK[1].Agent[i]) : 0));
                if (item.HStage[1][0] != 0)
                    //=进销存报表!$O4*市场价格!DK6*5%+进销存报表!$O4*市场价格!EF6*
                    //IF((进销存报表!$P4/进销存报表!$H4-1)<15%,6%,5%)+进销存报表!$Q4*市场价格!DR6*5%+
                    //进销存报表!$Q4*市场价格!EL6*6%+300
                    summaryAssent7.XAgent[i]=(item.CStage[2][0] * market2.DK[0].Agent[i] * 0.05m +
                        item.CStage[2][0] * market2.EF[0].Agent[i] *
                        ((item.HStage[2][0] / item.HStage[1][0] - 1) < 0.15m ? 0.06m : 0.05m) +
                        item.CStage[2][1] * market2.DK[1].Agent[i] * 0.05m
                        + item.CStage[2][1] * market2.EF[1].Agent[i] * 0.06m + 300);
                summaryAssent1.XAgent[i]=(item.DStage[1][0]);
                summaryAssent9.JAgent[i]=(item.DStage[1][0]);
                summaryAssent1.ALAgent[i]=(item.DStage[2][0] + item.DStage[2][1]);
                summaryAssent9.XAgent[i]=(item.DStage[2][0] + item.DStage[2][1]);
                //=(进销存报表!S4*市场价格!$CN$6+进销存报表!U4*市场价格!$CQ$6)*10%
                summaryAssent15.XAgent[i]=((item.DStage[2][0] * market2.CM[0].S + item.DStage[2][1] * market2.CM[1].S) * 0.10m);
                //=进销存报表!$AC4*市场价格!$CN$7+进销存报表!$AE4*市场价格!$CQ$7+进销存报表!$AG4*市场价格!$CT$7
                summaryAssent5.ALAgent[i]=(
                    item.CStage[3][0] * market3.CM[0].S
                    + item.CStage[3][1] * market3.CM[1].S
                    + item.CStage[3][2] * market3.CM[2].S);
                if (item.HStage[2][0] != 0 && item.HStage[2][1] != 0)
                    //=进销存报表!$AC4*市场价格!DK7*5%+进销存报表!$AC4*市场价格!EF7*
                    //IF((进销存报表!$AD4/进销存报表!$P4-1)<15%,6%,5%)+
                    //进销存报表!$AE4*市场价格!DR7*5%+进销存报表!$AE4*市场价格!EL7
                    //*IF((进销存报表!$AF4/进销存报表!$R4-1)<15%,6%,5%)+进销存报表!$AG4*市场价格!DY7*5%+进销存报表!$AG4*市场价格!ER7*6%+300
                    summaryAssent7.ALAgent[i]=(
                        item.CStage[3][0] * market3.DK[0].Agent[i] * 0.05m +
                        item.CStage[3][0] * market3.EF[0].Agent[i] *
                        ((item.HStage[3][0] / item.HStage[2][0] - 1) < 0.15m ? 0.06m : 0.05m) +
                       item.CStage[3][1] * market3.DK[1].Agent[i] * 0.05m + item.CStage[3][1] * market3.EF[1].Agent[i] *
                   ((item.HStage[3][1] / item.HStage[2][1] - 1) < 0.15m ? 0.06m : 0.05m) +
                   item.CStage[3][2] * market3.DK[2].Agent[i] * 0.05m +
                   item.CStage[3][2] * market3.EF[2].Agent[i] * 0.06m + 300);
                /*
                 =进销存报表!$AC4 --30
                    *IF(市场价格!EF7 --00
                    >市场价格!DK7  --00
                    ,(市场价格!EF7--00
                    -市场价格!DK7 --00
                    ),0)+进销存报表!$AE4--31
                    *IF(市场价格!EL7  --10
                    >市场价格!DR7   --10
                    ,(市场价格!EL7  --10
                    -市场价格!DR7 --10
                    ),0)+进销存报表!$AG4--32
                    *IF(市场价格!ER7--20
                    >市场价格!DY7--20
                    ,(市场价格!ER7  --20
                    -市场价格!DY7--20
                    ),0)
                 */
                summaryAssent8.ALAgent[i]=(item.CStage[3][0] * (market3.EF[0].Agent[i] > market3.DK[0].Agent[i] ?
                    (market3.EF[0].Agent[i] - market3.DK[0].Agent[i]) : 0) +
                      item.CStage[3][1] * (market3.EF[1].Agent[i] > market3.DK[1].Agent[i] ?
                      (market3.EF[1].Agent[i] - market3.DK[1].Agent[i]) : 0) +
                                          item.CStage[3][2] * (market3.EF[2].Agent[i] >
                                          market3.DK[2].Agent[i] ? (market3.EF[2].Agent[i] - market3.DK[2].Agent[i]) : 0));
                //=进销存报表!$AI4  -30
                //+进销存报表!$AK4-- 31
                // + 进销存报表!$AM4--32
                summaryAssent9.ALAgent[i]=(item.DStage[3][0] + item.DStage[3][1] + item.DStage[3][2]);
                /*
                 =(进销存报表!$AI4  --30
*市场价格!$CN$7  --00
+进销存报表!$AK4  --31
*市场价格!$CQ$7  --11
+进销存报表!$AM4  --32
*市场价格!$CT$7  --22
)*10%
                 */
                summaryAssent15.ALAgent[i]=((item.DStage[3][0] * market3.CM[0].S +
                    item.DStage[3][1] * market3.CM[1].S +
                    item.DStage[3][2] * market3.CM[2].S) * 0.10m);
                summaryAssent1.JAgent[i]=(item.DStage[0][0]);
                //=进销存报表!E4  10  *市场价格!CE5  00
                summaryAssent5.CAgent[i]=(item.EStage[1][0] * market1.CD[0].S);
                //=进销存报表!G4   10 *市场价格!$CN$5 00
                summaryAssent5.JAgent[i]=(item.CStage[1][0] * market1.CM[0].S);
                /*=进销存报表!W4  --30
                *市场价格!CE7--00
             + 进销存报表!Y4--31
            * 市场价格!CH7--10
           + 进销存报表!AA4--32
          * 市场价格!CK7--20
          */
                summaryAssent5.AEAgent[i]=(item.EStage[3][0] * market3.CD[0].S +
                    item.EStage[3][1] * market3.CD[1].S +
                    item.EStage[3][2] * market3.CD[2].S);

                //=进销存报表!G4  10*市场价格!DK5 00*5%+进销存报表!G4  10*市场价格!EF5  00*6%+300
                summaryAssent7.JAgent[i]=(item.CStage[1][0] *
                    market1.DK[0].Agent[i] * 0.05m +
                    item.CStage[1][0] *
                    market1.EF[0].Agent[i] * 0.06m + 300);
                //=进销存报表!$G4*IF(市场价格!EF5>市场价格!DK5,(市场价格!EF5-市场价格!DK5),0)
                summaryAssent8.JAgent[i]=(item.CStage[1][0] *
                    (market1.EF[0].Agent[i] > market1.DK[0].Agent[i] ? (market1.EF[0].Agent[i] - market1.DK[0].Agent[i]) : 0));
                summaryAssent15.JAgent[i]=(summaryAssent9.JAgent[i] * market1.CM[0].S * 0.10m);

            }
            if (investment1 != null && investment1.EI != null && investment1.EI.Keys != null)
            {

 
                foreach (var item in investment1.EI.Keys)
                {
                    summaryAssent3.JAgent[item] = investment1.EI[item];
                }
            }


            if (investment2 != null && investment2.EI != null && investment2.EI.Keys != null)
            {
 
                foreach (var item in investment2.EI.Keys)
                {
                    summaryAssent3.XAgent[item] = investment2.EI[item];
                }
            }
            for (int i = 0; i < agentStages.agents.Count; i++)
            {
                summaryAssent14.JAgent[i]=(summaryAssent3.JAgent[i] * 0.08m);
                summaryAssent14.XAgent[i]=(summaryAssent3.XAgent[i] * 0.08m);
            }

            if (investment3 != null && investment3.EI != null && investment3.EI.Keys != null)
            {
  
                foreach (var item in investment3.EI.Keys)
                {
                    summaryAssent3.ALAgent[item] = investment3.EI[item];

                }
            }
            for (int i = 0; i < agentStages.agents.Count; i++)
            {
                summaryAssent14.ALAgent[i]=(summaryAssent3.ALAgent[i] * 0.08m);
            }


            summaryAssent4.B = bj5_bm5 * market1.DE[1].M / (1 + 0.10m);
            summaryAssent11.B = summaryAssent4.B * 0.19m;

            for (int i = 0; i < stockReport1.Count(); i++)
            {
                var item = stockReport1.FirstOrDefault(s => s.AgentName == agentStages.agents[i]);
                if (item != null)
                {
                    summaryAssent4.CAgent[i] = (item.E[0].Amount);
                }

            }

            for (int i = 0; i < summaryAssent4.CAgent.Count; i++)
            {
                summaryAssent11.CAgent[i] = (summaryAssent4.CAgent[i] * 0.2m);
            }


            summaryAssent4.I = cb5_ce5 * market1.DE[0].J / (1 + 0.12m);
            summaryAssent11.I = summaryAssent4.I * 0.2m;
            //=AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6)*市场价格!DE6/(1+10%)+AVERAGE(市场容量及各品牌当年占有率!BP6:BS6)*市场价格!DG6/(1+10%)
            summaryAssent4.P = bj6_bm6 * market2.DE[0].M / (1 + 0.10m) + bp6_bs6 * market2.DE[1].M / (1 + 0.10m);
            summaryAssent11.P = summaryAssent4.P * 0.19m;


            foreach (var item in stockReport2)
            {
                var indexAgent = agentStages.agents.IndexOf(item.AgentName);
                //=进货报表!B13*市场价格!$CE$6+进货报表!D13*市场价格!$CH$6


                //=进货报表!B13*市场价格!$CE$6+进货报表!D13*市场价格!$CH$6
                summaryAssent5.QAgent[indexAgent] = item.E[0].Stock * market2.CD[0].S + item.E[1].Stock * market2.CD[1].S;
                summaryAssent4.QAgent[indexAgent] = item.Sum.Sum;
            }

            for (int i = 0; i < summaryAssent4.QAgent.Count; i++)
            {
                summaryAssent11.QAgent[i] = summaryAssent4.QAgent[i] * 0.2m;
            }


            //=AVERAGE(市场容量及各品牌当年占有率!CB6:CE6)*市场价格!DF6/(1+12%)+AVERAGE(市场容量及各品牌当年占有率!CH6:CK6)*市场价格!DH6/(1+12%)
            summaryAssent4.W = cb6_ce6 * market2.DE[0].J / (1 + 0.12m) + ch6_ck6 * market2.DE[1].J / (1 + 0.12m);
            summaryAssent11.W = summaryAssent4.W * 0.2m;
            //=AVERAGE(市场容量及各品牌当年占有率!BJ7:BM7)*市场价格!DE7/(1+10%)+
            //AVERAGE(市场容量及各品牌当年占有率!BP7:BS7)*市场价格!DG7/(1+10%)+
            //AVERAGE(市场容量及各品牌当年占有率!BV7:BY7)*市场价格!DI7/(1+10%)
            summaryAssent4.AD = bj7_bm7 * market3.DE[0].M / (1 + 0.10m) + bp7_bs7 * market3.DE[1].M / (1 + 0.10m)
                + bv7_by7 * market3.DE[2].M / (1 + 0.10m);
            summaryAssent11.AD = summaryAssent4.AD * 0.19m;


            foreach (var item in stockReport3)
            {
                var indexAgent = agentStages.agents.IndexOf(item.AgentName);
                summaryAssent4.AEAgent[indexAgent] = item.Sum.Sum;
            }
            for (int i = 0; i < summaryAssent4.AEAgent.Count; i++)
            {
                summaryAssent11.AEAgent[i] = summaryAssent4.AEAgent[i] * 0.2m;
            }

            // = AVERAGE(市场容量及各品牌当年占有率!CB7:CE7) * 市场价格!DF7 / (1 + 12 %) + 
            //AVERAGE(市场容量及各品牌当年占有率!CH7:CK7) * 市场价格!DH7 / (1 + 12 %) +
            //AVERAGE(市场容量及各品牌当年占有率!CN7:CQ7) * 市场价格!DJ7 / (1 + 12 %)
            summaryAssent4.AK = cb7_ce7 * market3.DE[0].J / (1 + 0.12m) + ch7_ck7 * market3.DE[1].J / (1 + 0.12m) + cn7_cq7 * market3.DE[2].J / (1 + 0.12m);
            summaryAssent11.AK = summaryAssent4.AK * 0.2m;
            //= AVERAGE(市场容量及各品牌当年占有率!BJ5:BM5) * 市场价格!CD5
            summaryAssent5.B = bj5_bm5 * market1.CD[0].M;
            summaryAssent5.I = cb5_ce5 * market1.CD[0].J;
            summaryAssent5.P = bj6_bm6 * market2.CD[0].M + bp6_bs6 * market2.CD[1].M;
            summaryAssent5.W = cb6_ce6 * market2.CD[0].J + ch6_ck6 * market2.CD[1].J;
            summaryAssent5.AD = bj7_bm7 * market3.CD[0].M + bp7_bs7 * market3.CD[1].M + bv7_by7 * market3.CD[2].M;
            summaryAssent5.AK = cb7_ce7 * market3.CD[0].J + ch7_ck7 * market3.CD[1].J + cn7_cq7 * market3.CD[2].J;

            #region 期间产生费用
            if (investment1 != null)
            {
                summaryAssent6.B = investment1.B;
                for (int i = 0; i < investment1.CAgents.Count; i++)
                {
                    summaryAssent6.CAgent[i] = investment1.CAgents[i];
                    summaryAssent6.JAgent[i] = investment1.CLAgent[i].InputSum;
                }

                summaryAssent6.I = investment1.I;

            }
            if (investment2 != null)
            {
                summaryAssent6.P = investment2.B;
                for (int i = 0; i < investment2.CAgents.Count; i++)
                {
                    summaryAssent6.QAgent[i] = investment2.CAgents[i];
                    summaryAssent6.XAgent[i] = investment2.CLAgent[i].InputSum;
                }
                summaryAssent6.W = investment2.I;
            }
            if (investment3 != null)
            {
                summaryAssent6.AD = investment3.B;
                summaryAssent6.AK = investment3.I;
                for (int i = 0; i < investment3.CAgents.Count; i++)
                {
                    summaryAssent6.AEAgent[i] = investment3.CAgents[i];
                    summaryAssent6.ALAgent[i] = investment3.CLAgent[i].InputSum;
                }
            }

            #endregion
            #region 卖场费用 summaryAssent7
            summaryAssent7.B = 500 + de5 * bj5_bm5 * 0.05m + de5 / (1 + 0.10m) * bj5_bm5 * 0.05m;
            summaryAssent7.I = 200 + df5 * cb5_ce5 * 0.04m + df5 / (1 + 0.12m) * cb5_ce5 * 0.07m;
            //=500+(市场价格!DE6*(AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6))*5%+市场价格!DE6/(1+10%)*(AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6))*5%)
            //+市场价格!DG6*(AVERAGE(市场容量及各品牌当年占有率!BP6:BS6))*5%+市场价格!DG6/(1+10%)*(AVERAGE(市场容量及各品牌当年占有率!BP6:BS6)*5%)
            summaryAssent7.P = 500 + (market2.DE[0].M * bj6_bm6) * 0.05m + market2.DE[0].M / (1 + 0.10m) * bj6_bm6 * 0.05m
                + market2.DE[1].M * bp6_bs6 * 0.05m + market2.DE[1].M / (1 + 0.10m) * bp6_bs6 * 0.05m;

            summaryAssent7.W = 200 + (df6 * (cb6_ce6) * 0.04m + df6 / (1 + 0.12m) * cb6_ce6 * 0.07m) +
                dh6 * ch6_ck6 * 0.04m + dh6 / (1 + 0.12m) * ch6_ck6 * 0.07m;

            summaryAssent7.AD = 500 + market3.DE[0].M * bj7_bm7 * 0.05m + market3.DE[0].M / (1 + 0.10m) *
                bj7_bm7 * 0.05m + market3.DE[1].M * bp7_bs7 * 0.05m + market3.DE[1].M / (1 + 0.10m) *
                bp7_bs7 * 0.05m + market3.DE[2].M * bv7_by7 * 0.05m + market3.DE[2].M / (1 + 0.10m) *
                bv7_by7 * 0.05m;
            summaryAssent7.AK = 200 + market3.DE[0].J * cb7_ce7 * 0.04m + market3.DE[0].J / (1 + 0.12m) *
                cb7_ce7 * 0.07m + market3.DE[1].J * ch7_ck7 * 0.04m + market3.DE[1].J / (1 + 0.12m) *
                ch7_ck7 * 0.07m + market3.DE[2].J * cn7_cq7 * 0.04m + market3.DE[2].J / (1 + 0.12m) * cn7_cq7 * 0.07m;
            #endregion
            #region 年末S品牌商费用投放返还 summaryAssent10



            if (investment1 != null)
            {
                for (int i = 0; i < investment1.AJAgent.Count; i++)
                {
                    summaryAssent10.JAgent[i] = investment1.AJAgent[i].InputSum;
                }
            }
            if (investment2 != null)
            {
                for (int i = 0; i < investment2.AJAgent.Count; i++)
                {
                    summaryAssent10.XAgent[i] = (investment2.AJAgent[i].InputSum);
                }
            }
            if (investment3 != null)
            {
                for (int i = 0; i < investment3.AJAgent.Count; i++)
                {
                    summaryAssent10.ALAgent[i] = (investment3.AJAgent[i].InputSum);
                }
            }


            #endregion


            #region 最后计算



            #region 期末现金余额 summaryAssent12
            summaryAssent2.P = summaryAssent12.B = summaryAssent2.B + summaryAssent4.B - summaryAssent5.B - summaryAssent6.B - summaryAssent7.B - summaryAssent11.B;
            summaryAssent2.W = summaryAssent12.I = summaryAssent2.I + summaryAssent4.I - summaryAssent5.I - summaryAssent6.I - summaryAssent7.I - summaryAssent11.I;

            for (int i = 0; i < summaryAssent2.CAgent.Count; i++)
            {
                //=C5+C7-C8-C9-C14
                var cat = summaryAssent2.CAgent[i] + summaryAssent4.CAgent[i] - summaryAssent5.CAgent[i] - summaryAssent6.CAgent[i] - summaryAssent11.CAgent[i];
                summaryAssent2.QAgent[i]=(cat);
                summaryAssent12.CAgent[i]=(cat);
                var sumt = summaryAssent2.JAgent[i] + summaryAssent3.JAgent[i] + summaryAssent4.JAgent[i] - summaryAssent5.JAgent[i] - summaryAssent6.JAgent[i] - summaryAssent7.JAgent[i] - summaryAssent8.JAgent[i] - (summaryAssent9.JAgent[i] - summaryAssent1.JAgent[i]) * market1.CM[1].S + summaryAssent10.JAgent[i];

                summaryAssent2.XAgent[i]=(sumt);
                summaryAssent12.JAgent[i]=(sumt);

            }
            for (int i = 0; i < summaryAssent12.QAgent.Count; i++)
            {
                var sumt = summaryAssent2.QAgent[i] + summaryAssent4.QAgent[i] - summaryAssent5.QAgent[i] - summaryAssent6.QAgent[i] - summaryAssent7.QAgent[i] - summaryAssent11.QAgent[i];

                summaryAssent2.AEAgent[i]=(sumt);
                summaryAssent12.QAgent[i]=(sumt);
                var sumtt = summaryAssent2.AEAgent[i] + summaryAssent4.AEAgent[i] - summaryAssent5.AEAgent[i] - summaryAssent6.AEAgent[i] - summaryAssent7.AEAgent[i] - summaryAssent11.AEAgent[i];
                summaryAssent12.AEAgent[i]=(sumtt);

            }

            summaryAssent2.AD = summaryAssent12.P = summaryAssent2.P + summaryAssent4.P - summaryAssent5.P - summaryAssent6.P - summaryAssent7.P - summaryAssent11.P;
            summaryAssent2.AK = summaryAssent12.W = summaryAssent2.W + summaryAssent4.W - summaryAssent5.W - summaryAssent6.W - summaryAssent7.W - summaryAssent11.W;
            summaryAssent12.AD = summaryAssent2.AD + summaryAssent4.AD - summaryAssent5.AD - summaryAssent6.AD - summaryAssent7.AD - summaryAssent11.AD;
            summaryAssent12.AK = summaryAssent2.AK + summaryAssent4.AK - summaryAssent5.AK - summaryAssent6.AK - summaryAssent7.AK - summaryAssent11.AK;

            for (int i = 0; i < summaryAssent12.XAgent.Count; i++)
            {

            }
            foreach (var item in invocicings)
            {
                var indexAgent = agentStages.agents.IndexOf(item.AgentName);
                summaryAssent2.ALAgent[indexAgent] = summaryAssent12.XAgent[indexAgent] = summaryAssent2.XAgent[indexAgent] + summaryAssent3.XAgent[indexAgent] + summaryAssent4.XAgent[indexAgent] - summaryAssent5.XAgent[indexAgent] - summaryAssent6.XAgent[indexAgent] - summaryAssent7.XAgent[indexAgent] - summaryAssent8.XAgent[indexAgent] - ((item.DStage[2][0] - item.DStage[1][0]) * market2.CM[1].S + item.DStage[2][1] * market2.CM[2].S) + summaryAssent10.XAgent[indexAgent];

                summaryAssent17.QAgent[indexAgent] = summaryAssent17.XAgent[indexAgent] = decimal.Round(decimal.Round((summaryAssent9.XAgent[indexAgent] == 0 ? ((item.DStage[1][0] + item.EStage[2][0] - currentShare2.CT[1].Agent[indexAgent]) + (item.EStage[2][1] - currentShare2.CT[2].Agent[indexAgent])) : 0), 0), 0);
                summaryAssent12.ALAgent[indexAgent] = summaryAssent2.ALAgent[indexAgent] + summaryAssent4.ALAgent[indexAgent] - summaryAssent5.ALAgent[indexAgent] - summaryAssent6.ALAgent[indexAgent] - summaryAssent7.ALAgent[indexAgent] - ((item.DStage[3][0] - item.DStage[2][0]) * market3.CM[1].S + (item.DStage[3][1] - item.DStage[2][1]) * market3.CM[2].S + item.DStage[3][2] * market3.CM[3].S) + summaryAssent10.ALAgent[indexAgent];
                summaryAssent17.AEAgent[indexAgent] = summaryAssent17.ALAgent[indexAgent] = decimal.Round((summaryAssent9.ALAgent[indexAgent] == 0 ? ((item.DStage[2][0] + item.EStage[3][0] - currentShare3.CT[1].Agent[indexAgent]) + (item.DStage[2][1] + item.EStage[3][1] - currentShare3.CT[2].Agent[indexAgent]) + (item.EStage[3][2] - currentShare3.CT[3].Agent[indexAgent])) : 0), 0);
                summaryAssent17.CAgent[indexAgent] = summaryAssent17.JAgent[indexAgent] = decimal.Round((summaryAssent9.JAgent[indexAgent] == 0 ? (item.DStage[0][0] + item.EStage[1][0] - currentShare1.CT[1].Agent[indexAgent]) : 0), 0);


            }

            #endregion

            #region 销售利润 summaryAssent13

            summaryAssent13.B = summaryAssent4.B - summaryAssent5.B - summaryAssent6.B - summaryAssent7.B - summaryAssent11.B;


            for (int i = 0; i < summaryAssent4.CAgent.Count; i++)
            {
                summaryAssent13.CAgent[i] = summaryAssent4.CAgent[i] - summaryAssent5.CAgent[i] - summaryAssent6.CAgent[i] - summaryAssent11.CAgent[i];
                summaryAssent13.JAgent[i] = summaryAssent4.JAgent[i] - summaryAssent5.JAgent[i] - summaryAssent6.JAgent[i] - summaryAssent7.JAgent[i] + summaryAssent10.JAgent[i] - summaryAssent8.JAgent[i];
                summaryAssent13.QAgent[i] = summaryAssent4.QAgent[i] - summaryAssent5.QAgent[i] - summaryAssent6.QAgent[i] - summaryAssent11.QAgent[i];
            }

            summaryAssent13.I = summaryAssent4.I - summaryAssent5.I - summaryAssent6.I - summaryAssent7.I - summaryAssent11.I;
            summaryAssent13.P = summaryAssent4.P - summaryAssent5.P - summaryAssent6.P - summaryAssent7.P - summaryAssent11.P;
            summaryAssent13.W = summaryAssent4.W - summaryAssent5.W - summaryAssent6.W - summaryAssent7.W - summaryAssent11.W;

            for (int i = 0; i < summaryAssent4.XAgent.Count; i++)
            {
                summaryAssent13.XAgent[i] = summaryAssent4.XAgent[i] - summaryAssent5.XAgent[i] - summaryAssent6.XAgent[i] - summaryAssent7.XAgent[i] + summaryAssent10.XAgent[i] - summaryAssent8.XAgent[i];
                summaryAssent13.AEAgent[i] = summaryAssent4.AEAgent[i] - summaryAssent5.AEAgent[i] - summaryAssent6.AEAgent[i] - summaryAssent11.AEAgent[i];
                //=AL7-AL8-AL9-AL10+AL13-AL11 
                summaryAssent13.ALAgent[i] = summaryAssent4.ALAgent[i] - summaryAssent5.ALAgent[i] - summaryAssent6.ALAgent[i] - summaryAssent7.ALAgent[i] + summaryAssent10.ALAgent[i] - summaryAssent8.ALAgent[i];
                summaryAssent16.JAgent[i] = summaryAssent13.JAgent[i] - summaryAssent15.JAgent[i] - summaryAssent14.JAgent[i];//扣除计提跌价损失及银行利息后的利润 summaryAssent16
            }
            summaryAssent13.AD = summaryAssent4.AD - summaryAssent5.AD - summaryAssent6.AD - summaryAssent7.AD - summaryAssent11.AD;
            summaryAssent13.AK = summaryAssent4.AK - summaryAssent5.AK - summaryAssent6.AK - summaryAssent7.AK - summaryAssent11.AK;


            #endregion

            #region 

            for (int i = 0; i < summaryAssent13.XAgent.Count; i++)
            {
                summaryAssent16.XAgent[i] = summaryAssent13.XAgent[i] - summaryAssent15.XAgent[i] - summaryAssent14.XAgent[i];
                summaryAssent16.ALAgent[i] = summaryAssent13.ALAgent[i] - summaryAssent15.ALAgent[i] - summaryAssent14.ALAgent[i];
                summaryAssent18.CAgent[i] = summaryAssent17.CAgent[i] * market1.CM[1].S;//经营中损失的金额  summaryAssent18
                summaryAssent18.JAgent[i] = summaryAssent17.JAgent[i] * market1.EF[1].Agent[i];

            }

            #endregion


            #region 



            foreach (var item in invocicings)
            {
                var indexAgent = agentStages.agents.IndexOf(item.AgentName);
                //=IF(X20=0,0,(进销存报表!$I4+进销存报表!$K4-市场容量及各品牌当年占有率!CT6)*市场价格!EF6+(进销存报表!$M4-市场容量及各品牌当年占有率!CZ6)*市场价格!EL6)
                summaryAssent18.XAgent[indexAgent] = (summaryAssent17.XAgent[indexAgent] == 0 ? 0 :
                                    (item.DStage[1][0] + item.EStage[2][0] - currentShare2.CT[1].Agent[indexAgent]) * market2.EF[0].Agent[indexAgent] +
                                    (item.EStage[2][1] - currentShare2.CT[2].Agent[indexAgent]) * market2.EF[1].Agent[indexAgent]);
                summaryAssent18.ALAgent[indexAgent] = (summaryAssent17.ALAgent[indexAgent] == 0 ? 0 :
                                    (item.DStage[2][0] + item.EStage[3][0] - currentShare3.CT[1].Agent[indexAgent]) *
                                    market3.EF[0].Agent[indexAgent] + (item.DStage[2][1] + item.EStage[3][1] - currentShare3.CT[2].Agent[indexAgent]) *
                                    market3.EF[1].Agent[indexAgent] + (item.EStage[3][2] - currentShare3.CT[3].Agent[indexAgent]) *
                                    market3.EF[2].Agent[indexAgent]);
                //=IF(Q20=0,0,(进销存报表!$I4+进销存报表!$K4-市场容量及各品牌当年占有率!CT6)*市场价格!$CN$6+(进销存报表!$M4-市场容量及各品牌当年占有率!CZ6)*市场价格!$CQ$6)
                summaryAssent18.QAgent[indexAgent] = (summaryAssent17.QAgent[indexAgent] == 0 ? 0 :
                                    (item.DStage[1][0] + item.EStage[2][0] - currentShare2.CT[1].Agent[indexAgent]) *
                                    market2.CM[0].S + (item.EStage[2][1] - currentShare2.CT[2].Agent[indexAgent]) *
                                    market2.CM[0].S);
                summaryAssent18.AEAgent[indexAgent] = (summaryAssent17.AEAgent[indexAgent] == 0 ? 0 :
                                    (item.DStage[2][0] + item.EStage[3][0] - currentShare3.CT[1].Agent[indexAgent]) *
                                    market3.CM[0].S + (item.DStage[2][1] + item.EStage[3][1] - currentShare3.CT[2].Agent[indexAgent]) *
                                    market3.CM[1].S + (item.EStage[3][2] - currentShare3.CT[3].Agent[indexAgent]) *
                                    market3.CM[2].S);

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
        public void  AgentInit()
        {
            for (int i = 0; i < count; i++)
            {
                CAgent.Add(0);
                JAgent.Add(0);
                QAgent.Add(0);
                XAgent.Add(0);
                AEAgent.Add(0);
                ALAgent.Add(0);
            }
            
        }
        public int count { get; set; }
        public int Id { get; set; }

        public string A { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal B { get; set; }
        //[DisplayFormat(DataFormatString = "{0:F0}")]
        public List<decimal> CAgent { get; set; } = new List<decimal>();
 
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal I { get; set; }
        //[DisplayFormat(DataFormatString = "{0:F0}")]
        public List<decimal> JAgent { get; set; } = new List<decimal>();
       
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal P { get; set; }
        //[DisplayFormat(DataFormatString = "{0:F0}")]
        public List<decimal> QAgent { get; set; } = new List<decimal>();
       
        public decimal W { get; set; }
        public List<decimal> XAgent { get; set; } = new List<decimal>();
        
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AD { get; set; }
        // [DisplayFormat(DataFormatString = "{0:F0}")]
        public List<decimal> AEAgent { get; set; } = new List<decimal>();
        
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal AK { get; set; }
        // [DisplayFormat(DataFormatString = "{0:F0}")]
        public List<decimal> ALAgent { get; set; } = new List<decimal>();
        
    }
}