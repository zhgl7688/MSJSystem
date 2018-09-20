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
            #endregion
            summarys.ForEach(s =>
            {
                s.count = AgentCount;
                s.AgentInit();
            });


            for (int i = 0; i < AgentStages.agents.Count; i++)//代理循环
            {
                var item = invocicing(i);
                if (AgentStages.stages.Count > 1)
                {
                    summaryAssent2.CAgent[i] = 2000;
                    summaryAssent4.CAgent[i] = StockReportbyStageAgent(1, i).E[0].Amount;
                    summaryAssent5.CAgent[i] = item.BStage[1][0] * market(1).CD[0].S;  //=进销存报表!E4  10  *市场价格!CE5  00
                    summaryAssent6.CAgent[i] = investment(1).CAgents[i];
                    summaryAssent11.CAgent[i] = summaryAssent4.CAgent[i] * 0.2m;
                    summaryAssent12.CAgent[i] = summaryAssent2.CAgent[i] + summaryAssent4.CAgent[i] - summaryAssent5.CAgent[i] - summaryAssent6.CAgent[i] - summaryAssent11.CAgent[i];
                    summaryAssent13.CAgent[i] = summaryAssent4.CAgent[i] - summaryAssent5.CAgent[i] - summaryAssent6.CAgent[i] - summaryAssent11.CAgent[i];

                    summaryAssent1.JAgent[i] = item.DStage[0][0];
                    summaryAssent2.JAgent[i] = 15000;
                    summaryAssent3.JAgent[i] = investment(1).EI[i];
                    summaryAssent4.JAgent[i] = item.CStage[1][0] * market(1).EF[0].Agent[i];
                    summaryAssent5.JAgent[i] = item.CStage[1][0] * market(1).CM[0].S;   //=进销存报表!G4   10 *市场价格!$CN$5 00
                    summaryAssent6.JAgent[i] = investment(1).CLAgent[i].InputSum;
                    summaryAssent7.JAgent[i] = (item.CStage[1][0] * market(1).DK[0].Agent[i] * 0.05m + item.CStage[1][0] * market(1).EF[0].Agent[i] * 0.06m + 300);
                    summaryAssent8.JAgent[i] = (item.CStage[1][0] * (market(1).EF[0].Agent[i] > market(1).DK[0].Agent[i] ? (market(1).EF[0].Agent[i] - market(1).DK[0].Agent[i]) : 0));
                    summaryAssent9.JAgent[i] = summaryAssent1.XAgent[i] = item.DStage[1][0];
                    summaryAssent10.JAgent[i] = investment(1).AJAgent[i].InputSum;

                    summaryAssent12.JAgent[i] =
                        summaryAssent2.JAgent[i] + summaryAssent3.JAgent[i] + summaryAssent4.JAgent[i] - summaryAssent5.JAgent[i] - summaryAssent6.JAgent[i] -
                        summaryAssent7.JAgent[i] - summaryAssent8.JAgent[i] - (summaryAssent9.JAgent[i] - summaryAssent1.JAgent[i]) * market(1).CM[0].S + summaryAssent10.JAgent[i];
                    summaryAssent13.JAgent[i] = summaryAssent4.JAgent[i] - summaryAssent5.JAgent[i] - summaryAssent6.JAgent[i] - summaryAssent7.JAgent[i] + summaryAssent10.JAgent[i] - summaryAssent8.JAgent[i];
                    summaryAssent14.JAgent[i] = summaryAssent3.JAgent[i] * 0.08m;
                    summaryAssent15.JAgent[i] = summaryAssent9.JAgent[i] * market(1).CM[0].S * 0.10m;
                    summaryAssent16.JAgent[i] = summaryAssent13.JAgent[i] - summaryAssent15.JAgent[i] - summaryAssent14.JAgent[i];//扣除计提跌价损失及银行利息后的利润 summaryAssent16
                    summaryAssent17.JAgent[i] = decimal.Round((summaryAssent9.JAgent[i] == 0 ? (item.DStage[0][0] + item.BStage[1][0] - currentShare(1).CT[0].Agent[i]) : 0), 0);

                    summaryAssent18.JAgent[i] = summaryAssent17.JAgent[i] * market(1).EF[0].Agent[i];

                    summaryAssent17.CAgent[i] = summaryAssent17.JAgent[i];
                    summaryAssent18.CAgent[i] = summaryAssent17.CAgent[i] * market(1).CM[0].S;//经营中损失的金额  summaryAssent18





                }
                if (AgentStages.stages.Count > 2)
                {
                    summaryAssent2.QAgent[i] = summaryAssent12.CAgent[i];
                    summaryAssent4.QAgent[i] = StockReportbyStageAgent(2, i).Sum.Sum;
                    summaryAssent5.QAgent[i] = StockReportbyStageAgent(2, i).E[0].Stock * market(2).CD[0].S + StockReportbyStageAgent(2, i).E[1].Stock * market(2).CD[1].S;
                    summaryAssent6.QAgent[i] = investment(2).CAgents[i];

                    summaryAssent11.QAgent[i] = summaryAssent4.QAgent[i] * 0.2m;
                    summaryAssent12.QAgent[i] = summaryAssent2.QAgent[i] + summaryAssent4.QAgent[i] - summaryAssent5.QAgent[i] - summaryAssent6.QAgent[i] - summaryAssent7.QAgent[i] - summaryAssent11.QAgent[i];
                    summaryAssent13.QAgent[i] = summaryAssent4.QAgent[i] - summaryAssent5.QAgent[i] - summaryAssent6.QAgent[i] - summaryAssent11.QAgent[i];

                    summaryAssent2.XAgent[i] = summaryAssent12.JAgent[i];
                    summaryAssent3.XAgent[i] = investment(2).EI[i];
                    summaryAssent4.XAgent[i] = item.CStage[2][0] * market(2).EF[0].Agent[i] + item.CStage[2][1] * market(2).EF[1].Agent[i];
                    summaryAssent5.XAgent[i] = item.CStage[2][0] * market(2).CM[0].S + item.CStage[2][1] * market(2).CM[1].S;
                    summaryAssent6.XAgent[i] = investment(2).CLAgent[i].InputSum;
                    summaryAssent7.XAgent[i] = item.HStage[1][0]==0?0:item.CStage[2][0] * market(2).DK[0].Agent[i] * 0.05m + item.CStage[2][0] * market(2).EF[0].Agent[i] *
                                                ((item.HStage[2][0] / item.HStage[1][0] - 1) < 0.15m ? 0.06m : 0.05m) + item.CStage[2][1] * market(2).DK[1].Agent[i] * 0.05m
                                                + item.CStage[2][1] * market(2).EF[1].Agent[i] * 0.06m + 300;
                    summaryAssent8.XAgent[i] = (item.CStage[2][0] * (market(2).EF[1].Agent[i] > market(2).DK[1].Agent[i] ?
                                         (market(2).EF[1].Agent[i] - market(2).DK[1].Agent[i]) : 0) +
                                                item.CStage[2][0] * (market(2).EF[1].Agent[i] > market(2).DK[1].Agent[i] ? (market(2).EF[1].Agent[i] - market(2).DK[1].Agent[i]) : 0));

                    summaryAssent9.XAgent[i] = item.DStage[2][0] + item.DStage[2][1];
                    summaryAssent10.XAgent[i] = investment(2).AJAgent[i].InputSum;
                    summaryAssent12.XAgent[i] = summaryAssent2.XAgent[i] + summaryAssent3.XAgent[i] + summaryAssent4.XAgent[i] - summaryAssent5.XAgent[i] - summaryAssent6.XAgent[i] - summaryAssent7.XAgent[i] - summaryAssent8.XAgent[i];
                       var tt=- ((invocicing(i).DStage[2][0] - invocicing(i).DStage[1][0]) * market(2).CM[0].S + invocicing(i).DStage[2][1] * market(2).CM[1].S) + summaryAssent10.XAgent[i];
                    summaryAssent13.XAgent[i] = summaryAssent4.XAgent[i] - summaryAssent5.XAgent[i] - summaryAssent6.XAgent[i] - summaryAssent7.XAgent[i] + summaryAssent10.XAgent[i] - summaryAssent8.XAgent[i];

                    summaryAssent14.XAgent[i] = summaryAssent3.XAgent[i] * 0.08m;
                    summaryAssent15.XAgent[i] = (item.DStage[2][0] * market(2).CM[0].S + item.DStage[2][1] * market(2).CM[1].S) * 0.10m;//=(进销存报表!S4*市场价格!$CN$6+进销存报表!U4*市场价格!$CQ$6)*10%
                    summaryAssent16.XAgent[i] = summaryAssent13.XAgent[i] - summaryAssent15.XAgent[i] - summaryAssent14.XAgent[i];

                    summaryAssent17.QAgent[i] = summaryAssent17.XAgent[i] =
                    decimal.Round(decimal.Round((summaryAssent9.XAgent[i] == 0 ?
                    ((item.DStage[1][0] + item.EStage[2][0] - currentShare(2).CT[0].Agent[i]) + (item.EStage[2][1] - currentShare(2).CT[1].Agent[i])) : 0), 0), 0);
                    summaryAssent18.XAgent[i] = (summaryAssent17.XAgent[i] == 0 ? 0 :
                                  (item.DStage[1][0] + item.EStage[2][0] - currentShare(2).CT[1].Agent[i]) * market(2).EF[0].Agent[i] +
                                  (item.EStage[2][1] - currentShare(2).CT[1].Agent[i]) * market(2).EF[1].Agent[i]);
                    summaryAssent18.QAgent[i] = (summaryAssent17.QAgent[i] == 0 ? 0 :
                                   (item.DStage[1][0] + item.EStage[2][0] - currentShare(2).CT[0].Agent[i]) *
                                   market(2).CM[0].S + (item.EStage[2][1] - currentShare(2).CT[1].Agent[i]) *
                                   market(2).CM[0].S);


                    //=进销存报表!G4  10*市场价格!DK5 00*5%+进销存报表!G4  10*市场价格!EF5  00*6%+300
                }
                if (AgentStages.stages.Count > 3)
                {
                    summaryAssent2.AEAgent[i] = summaryAssent12.QAgent[i];
                    summaryAssent4.AEAgent[i] = StockReportbyStageAgent(3, i).Sum.Sum;
                    summaryAssent5.AEAgent[i] = (item.EStage[3][0] * market(3).CD[0].S + item.EStage[3][1] * market(3).CD[1].S + item.EStage[3][2] * market(3).CD[2].S);
                    summaryAssent6.AEAgent[i] = investment(3).CAgents[i];

                    summaryAssent11.AEAgent[i] = summaryAssent4.AEAgent[i] * 0.2m;
                    summaryAssent12.AEAgent[i] = summaryAssent2.AEAgent[i] + summaryAssent4.AEAgent[i] - summaryAssent5.AEAgent[i] - summaryAssent6.AEAgent[i] - summaryAssent7.AEAgent[i] - summaryAssent11.AEAgent[i];
                    summaryAssent13.AEAgent[i] = summaryAssent4.AEAgent[i] - summaryAssent5.AEAgent[i] - summaryAssent6.AEAgent[i] - summaryAssent11.AEAgent[i];


                    summaryAssent1.ALAgent[i] = item.DStage[2][0] + item.DStage[2][1];
                    summaryAssent2.ALAgent[i] = summaryAssent12.XAgent[i];
                    summaryAssent3.ALAgent[i] = investment(3).EI[i];
                    summaryAssent4.ALAgent[i] = item.CStage[3][0] * market(3).EF[0].Agent[i] + item.CStage[3][1] * market(3).EF[1].Agent[i] + item.CStage[3][2] * market(3).EF[2].Agent[i];
                    summaryAssent5.ALAgent[i] = (item.CStage[3][0] * market(3).CM[0].S + item.CStage[3][1] * market(3).CM[1].S + item.CStage[3][2] * market(3).CM[2].S);

                    summaryAssent6.ALAgent[i] = investment(3).CLAgent[i].InputSum;
                    GetSummaryAssent7_AL(summaryAssent7, i, item);
                    GetSummaryAssent8_AL(summaryAssent8, i, item);
                    summaryAssent9.ALAgent[i] = item.DStage[3][0] + item.DStage[3][1] + item.DStage[3][2];
                    summaryAssent10.ALAgent[i] = investment(3).AJAgent[i].InputSum;
                    summaryAssent12.ALAgent[i] = summaryAssent2.ALAgent[i] + summaryAssent4.ALAgent[i] - summaryAssent5.ALAgent[i] - summaryAssent6.ALAgent[i] -
                        summaryAssent7.ALAgent[i] - ((item.DStage[3][0] - item.DStage[2][0]) * market(3).CM[0].S + (item.DStage[3][1] - item.DStage[2][1]) * market(3).CM[1].S + item.DStage[3][2] * market(3).CM[2].S) + summaryAssent10.ALAgent[i];
                    summaryAssent13.ALAgent[i] = summaryAssent4.ALAgent[i] - summaryAssent5.ALAgent[i] - summaryAssent6.ALAgent[i] - summaryAssent7.ALAgent[i] + summaryAssent10.ALAgent[i] - summaryAssent8.ALAgent[i];

                    summaryAssent14.ALAgent[i] = summaryAssent3.ALAgent[i] * 0.08m;
                    summaryAssent15.ALAgent[i] = ((item.DStage[3][0] * market(3).CM[0].S + item.DStage[3][1] * market(3).CM[1].S + item.DStage[3][2] * market(3).CM[2].S) * 0.10m);
                    summaryAssent16.ALAgent[i] = summaryAssent13.ALAgent[i] - summaryAssent15.ALAgent[i] - summaryAssent14.ALAgent[i];
                    summaryAssent17.AEAgent[i] = decimal.Round((summaryAssent9.ALAgent[i] == 0 ? ((item.DStage[2][0] + item.EStage[3][0] - currentShare(3).CT[0].Agent[i]) + (item.DStage[2][1] + item.EStage[3][1] - currentShare(3).CT[1].Agent[i]) + (item.EStage[3][2] - currentShare(3).CT[2].Agent[i])) : 0), 0);
                    summaryAssent18.AEAgent[i] = (summaryAssent17.AEAgent[i] == 0 ? 0 :
                                  (item.DStage[2][0] + item.EStage[3][0] - currentShare(3).CT[0].Agent[i]) *
                                  market(3).CM[0].S + (item.DStage[2][1] + item.EStage[3][1] - currentShare(3).CT[1].Agent[i]) *
                                  market(3).CM[1].S + (item.EStage[3][2] - currentShare(3).CT[2].Agent[i]) *
                                  market(3).CM[2].S);
                    summaryAssent17.ALAgent[i] = summaryAssent17.AEAgent[i];
                    summaryAssent18.ALAgent[i] = (summaryAssent17.ALAgent[i] == 0 ? 0 :
                                   (item.DStage[2][0] + item.EStage[3][0] - currentShare(3).CT[0].Agent[i]) *
                                   market(3).EF[0].Agent[i] + (item.DStage[2][1] + item.EStage[3][1] - currentShare(3).CT[1].Agent[i]) *
                                   market(3).EF[1].Agent[i] + (item.EStage[3][2] - currentShare(3).CT[2].Agent[i]) *
                                   market(3).EF[2].Agent[i]);
                }

                //=进销存报表!$G4*IF(市场价格!EF5>市场价格!DK5,(市场价格!EF5-市场价格!DK5),0)

            }

            if (AgentStages.stages.Count > 1)
            {
                summaryAssent2.B = 2000;
                summaryAssent4.B = (Math.Round(bj5_bm5, 2) * market(1).DE[0].M) / (1.10m);
                summaryAssent5.B = bj5_bm5 * market(1).CD[0].M;
                summaryAssent6.B = investment(1).B;
                summaryAssent7.B = 500 + market(1).DE[0].M * bj5_bm5 * 0.05m + market(1).DE[0].M / (1 + 0.10m) * bj5_bm5 * 0.05m;
                summaryAssent11.B = summaryAssent4.B * 0.19m;
                summaryAssent12.B = summaryAssent2.B + summaryAssent4.B - summaryAssent5.B - summaryAssent6.B - summaryAssent7.B - summaryAssent11.B;

                summaryAssent13.B = summaryAssent4.B - summaryAssent5.B - summaryAssent6.B - summaryAssent7.B - summaryAssent11.B;

                summaryAssent2.I = 2000;
                summaryAssent4.I = cb5_ce5 * market(1).DE[0].J / (1 + 0.12m);
                summaryAssent5.I = cb5_ce5 * market(1).CD[0].J;
                summaryAssent6.I = investment(1).I;
                summaryAssent7.I = 200 + market(1).DE[0].J * cb5_ce5 * 0.04m + market(1).DE[0].J / (1 + 0.12m) * cb5_ce5 * 0.07m;


                summaryAssent11.I = summaryAssent4.I * 0.2m;
                summaryAssent12.I = summaryAssent2.I + summaryAssent4.I - summaryAssent5.I - summaryAssent6.I - summaryAssent7.I - summaryAssent11.I;

                summaryAssent13.I = summaryAssent4.I - summaryAssent5.I - summaryAssent6.I - summaryAssent7.I - summaryAssent11.I;



            }
            if (AgentStages.stages.Count > 2)
            {
                summaryAssent2.P = summaryAssent12.B;
                summaryAssent4.P = bj6_bm6 * market(2).DE[0].M / (1 + 0.10m) + bp6_bs6 * market(2).DE[1].M / (1 + 0.10m);
                summaryAssent5.P = bj6_bm6 * market(2).CD[0].M + bp6_bs6 * market(2).CD[1].M;
                summaryAssent6.P = investment(2).B;
                summaryAssent7.P = 500 + (market(2).DE[0].M * bj6_bm6) * 0.05m + market(2).DE[0].M / (1 + 0.10m) * bj6_bm6 * 0.05m
                             + market(2).DE[1].M * bp6_bs6 * 0.05m + market(2).DE[1].M / (1 + 0.10m) * bp6_bs6 * 0.05m;
                summaryAssent11.P = summaryAssent4.P * 0.19m;
                summaryAssent12.P = summaryAssent2.P + summaryAssent4.P - summaryAssent5.P - summaryAssent6.P - summaryAssent7.P - summaryAssent11.P;
                summaryAssent13.P = summaryAssent4.P - summaryAssent5.P - summaryAssent6.P - summaryAssent7.P - summaryAssent11.P;
                summaryAssent2.W = summaryAssent12.I;
                summaryAssent4.W = cb6_ce6 * market(2).DE[0].J / (1 + 0.12m) + ch6_ck6 * market(2).DE[1].J / (1 + 0.12m);
                summaryAssent5.W = cb6_ce6 * market(2).CD[0].J + ch6_ck6 * market(2).CD[1].J;
                summaryAssent6.W = investment(2).I;
                summaryAssent7.W = cb6_ce6==0?0:200 + (df6 * (cb6_ce6) * 0.04m + df6 / (1 + 0.12m) * cb6_ce6 * 0.07m) +
                    dh6 * ch6_ck6 * 0.04m + dh6 / (1 + 0.12m) * ch6_ck6 * 0.07m;
                summaryAssent11.W = summaryAssent4.W * 0.2m;
                summaryAssent12.W = summaryAssent2.W + summaryAssent4.W - summaryAssent5.W - summaryAssent6.W - summaryAssent7.W - summaryAssent11.W;

                summaryAssent13.W = summaryAssent4.W - summaryAssent5.W - summaryAssent6.W - summaryAssent7.W - summaryAssent11.W;
            }



            if (AgentStages.stages.Count > 3)
            {
                summaryAssent2.AD = summaryAssent12.P;
                summaryAssent4.AD = bj7_bm7 * market(3).DE[0].M / (1 + 0.10m) + bp7_bs7 * market(3).DE[1].M / (1 + 0.10m)
                                + bv7_by7 * market(3).DE[2].M / (1 + 0.10m);
                summaryAssent5.AD = bj7_bm7 * market(3).CD[0].M + bp7_bs7 * market(3).CD[1].M + bv7_by7 * market(3).CD[2].M;

                summaryAssent6.AD = investment(3).B;
                summaryAssent7.AD = 500 + market(3).DE[0].M * bj7_bm7 * 0.05m + market(3).DE[0].M / (1 + 0.10m) *
                               bj7_bm7 * 0.05m + market(3).DE[1].M * bp7_bs7 * 0.05m + market(3).DE[1].M / (1 + 0.10m) *
                               bp7_bs7 * 0.05m + market(3).DE[2].M * bv7_by7 * 0.05m + market(3).DE[2].M / (1 + 0.10m) *
                               bv7_by7 * 0.05m;
                summaryAssent11.AD = summaryAssent4.AD * 0.19m;
                summaryAssent12.AD = summaryAssent2.AD + summaryAssent4.AD - summaryAssent5.AD - summaryAssent6.AD - summaryAssent7.AD - summaryAssent11.AD;
                summaryAssent13.AD = summaryAssent4.AD - summaryAssent5.AD - summaryAssent6.AD - summaryAssent7.AD - summaryAssent11.AD;

                summaryAssent2.AK = summaryAssent12.W;
                summaryAssent4.AK = cb7_ce7 * market(3).DE[0].J / (1 + 0.12m) + ch7_ck7 * market(3).DE[1].J / (1 + 0.12m) + cn7_cq7 * market(3).DE[2].J / (1 + 0.12m);
                summaryAssent5.AK = cb7_ce7 * market(3).CD[0].J + ch7_ck7 * market(3).CD[1].J + cn7_cq7 * market(3).CD[2].J;
                summaryAssent6.AK = investment(3).I;

                summaryAssent7.AK = 200 + market(3).DE[0].J * cb7_ce7 * 0.04m + market(3).DE[0].J / (1 + 0.12m) *
                    cb7_ce7 * 0.07m + market(3).DE[1].J * ch7_ck7 * 0.04m + market(3).DE[1].J / (1 + 0.12m) *
                    ch7_ck7 * 0.07m + market(3).DE[2].J * cn7_cq7 * 0.04m + market(3).DE[2].J / (1 + 0.12m) * cn7_cq7 * 0.07m;
                summaryAssent11.AK = summaryAssent4.AK * 0.2m;
                summaryAssent12.AK = summaryAssent2.AK + summaryAssent4.AK - summaryAssent5.AK - summaryAssent6.AK - summaryAssent7.AK - summaryAssent11.AK;
                summaryAssent13.AK = summaryAssent4.AK - summaryAssent5.AK - summaryAssent6.AK - summaryAssent7.AK - summaryAssent11.AK;

            }

           
        }

        private void GetSummaryAssent8_AL(SummaryTable summaryAssent8, int i, InvoicingTable item)
        {
            summaryAssent8.ALAgent[i] = (item.CStage[3][0] * (market(3).EF[0].Agent[i] > market(3).DK[0].Agent[i] ?
                                   (market(3).EF[0].Agent[i] - market(3).DK[0].Agent[i]) : 0) +
                                     item.CStage[3][1] * (market(3).EF[1].Agent[i] > market(3).DK[1].Agent[i] ?
                                     (market(3).EF[1].Agent[i] - market(3).DK[1].Agent[i]) : 0) +
                                                         item.CStage[3][2] * (market(3).EF[2].Agent[i] >
                                                         market(3).DK[2].Agent[i] ? (market(3).EF[2].Agent[i] - market(3).DK[2].Agent[i]) : 0));
        }

        private void GetSummaryAssent7_AL(SummaryTable summaryAssent7, int i, InvoicingTable item)
        {
            summaryAssent7.ALAgent[i] = item.HStage[2][0]==0|| item.HStage[2][1] ==0? 0:
                                       item.CStage[3][0] * market(3).DK[0].Agent[i] * 0.05m +
                                       item.CStage[3][0] * market(3).EF[0].Agent[i] *
                                       ((item.HStage[3][0] / item.HStage[2][0] - 1) < 0.15m ? 0.06m : 0.05m) +
                                      item.CStage[3][1] * market(3).DK[1].Agent[i] * 0.05m + item.CStage[3][1] * market(3).EF[1].Agent[i] *
                                  ((item.HStage[3][1] / item.HStage[2][1] - 1) < 0.15m ? 0.06m : 0.05m) +
                                  item.CStage[3][2] * market(3).DK[2].Agent[i] * 0.05m +
                                  item.CStage[3][2] * market(3).EF[2].Agent[i] * 0.06m + 300;
        }

        public List<SummaryTable> Get()
        {
            return summarys;
        }
        public CurrentShareTable currentShare(int i)
        {
            return currentShares.FirstOrDefault(s => s.Stage == AgentStages.stages[i]);
        }
        // AVERAGE(市场容量及各品牌当年占有率!CB5:CE5)


        public decimal cb5_ce5
        {
            get
            {
                return Cal.GetMJAAverage(currentShare(1).CB[0], AgentCount, MJAType.J);
            }
        }
        public decimal bj5_bm5
        {
            get
            {
                return Cal.GetMJAAverage(currentShare(1).BJ[0], AgentCount, MJAType.M);
            }
        }
        public decimal bj6_bm6
        {
            get
            {
                return Common.Cal.GetMJAAverage(currentShare(2).BJ[0], AgentCount, MJAType.M);
            }
        }
        //AVERAGE(市场容量及各品牌当年占有率!BP6:BS6
        public decimal bp6_bs6
        {
            get
            {
                return Common.Cal.GetMJAAverage(currentShare(2).BJ[1], AgentCount, MJAType.M);
            }
        }
        // AVERAGE(市场容量及各品牌当年占有率!CB6:CE6)
        public decimal cb6_ce6
        {
            get
            {
                return currentShare(2) == null ? 0 : Common.Cal.GetMJAAverage(currentShare(2).CB[0], AgentCount, MJAType.J);
            }
        }
        //AVERAGE(市场容量及各品牌当年占有率!CH6:CK6
        public decimal ch6_ck6
        {
            get
            {
                return currentShare(2) == null ? 0 : Common.Cal.GetMJAAverage(currentShare(2).CB[1], AgentCount, MJAType.J);
            }
        }

        public decimal bj7_bm7
        {
            get
            {
                return currentShare(3) == null ? 0 : Common.Cal.GetMJAAverage(currentShare(3).BJ[0], AgentCount, MJAType.M); ;
            }
        }
        public decimal bp7_bs7
        {
            get
            {
                return currentShare(3) == null ? 0 : Common.Cal.GetMJAAverage(currentShare(3).BJ[1], AgentCount, MJAType.M);
            }
        }
        public decimal bv7_by7
        {
            get
            {
                return currentShare(3) == null ? 0 : Common.Cal.GetMJAAverage(currentShare(3).BJ[2], AgentCount, MJAType.M);
            }
        }
        public decimal cb7_ce7
        {
            get
            {
                return currentShare(3) == null ? 0 : Common.Cal.GetMJAAverage(currentShare(3).CB[0], AgentCount, MJAType.J);
            }
        }
        public decimal ch7_ck7
        {
            get
            {
                return currentShare(3) == null ? 0 : Common.Cal.GetMJAAverage(currentShare(3).CB[1], AgentCount, MJAType.J);
            }
        }
        public decimal cn7_cq7
        {
            get
            {
                return currentShare(3) == null ? 0 : Common.Cal.GetMJAAverage(currentShare(3).CB[2], AgentCount, MJAType.J);
            }
        }
        public MarketTable market(int i)
        {

            return markets.FirstOrDefault(s => s.Stage == AgentStages.stages[i]);

        }
        public InvestmentTable investment(int i) // invocicings
        {

            return investments.FirstOrDefault(s => s.Stage == AgentStages.stages[i]);

        }
        public InvoicingTable invocicing(int i)
        {

            return invocicings.FirstOrDefault(s => s.AgentName == AgentStages.agents[i]);

        }
        public IEnumerable<StockReportTable> StockReportbyStage(int i)
        {
            return stockReports.Where(s => s.Stage == AgentStages.stages[i]);

        }
        public IEnumerable<StockReportTable> StockReportbyAgent(int i)
        {
            return stockReports.Where(s => s.AgentName == AgentStages.agents[i]);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">stages</param>
        /// <param name="j">AgentName</param>
        /// <returns></returns>
        public StockReportTable StockReportbyStageAgent(int i, int j)
        {
            return stockReports.FirstOrDefault(s => s.AgentName == AgentStages.agents[j] && s.Stage == AgentStages.stages[i]);

        }

        public decimal df6
        {
            get
            {
                return market(2) == null ? 0 : market(2).DE[0].J;
            }
        }
        public decimal dh6
        {
            get
            {
                return market(2) == null ? 0 : market(2).DE[1].J;
            }
        }
        public int AgentCount
        {
            get
            {
                return AgentStages.agents.Count;
            }
        }


    }

    public class SummaryTable
    {
        public void AgentInit()
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

//=进销存报表!$AC4*市场价格!$CN$7+进销存报表!$AE4*市场价格!$CQ$7+进销存报表!$AG4*市场价格!$CT$7

//summaryAssent7.ALAgent[i]=进销存报表!$AC4*市场价格!DK7*5%+进销存报表!$AC4*市场价格!EF7*
//IF((进销存报表!$AD4/进销存报表!$P4-1)<15%,6%,5%)+
//进销存报表!$AE4*市场价格!DR7*5%+进销存报表!$AE4*市场价格!EL7
//*IF((进销存报表!$AF4/进销存报表!$R4-1)<15%,6%,5%)+进销存报表!$AG4*市场价格!DY7*5%+进销存报表!$AG4*市场价格!ER7*6%+300

/* summaryAssent8.ALAgent[i] =进销存报表!$AC4 --30
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

//summaryAssent9.ALAgent[i]=进销存报表!$AI4  -30
//+进销存报表!$AK4-- 31
// + 进销存报表!$AM4--32


/*summaryAssent15 .ALAgent[i]      =(进销存报表!$AI4  --30
*市场价格!$CN$7  --00
+进销存报表!$AK4  --31
*市场价格!$CQ$7  --11
+进销存报表!$AM4  --32
*市场价格!$CT$7  --22
)*10%
                */

/*    summaryAssent5.AEAgent[i]=进销存报表!W4  --30
            *市场价格!CE7--00
         + 进销存报表!Y4--31
        * 市场价格!CH7--10
       + 进销存报表!AA4--32
      * 市场价格!CK7--20
      */
// = AVERAGE(市场容量及各品牌当年占有率!CB7:CE7) * 市场价格!DF7 / (1 + 12 %) + 
//AVERAGE(市场容量及各品牌当年占有率!CH7:CK7) * 市场价格!DH7 / (1 + 12 %) +
//AVERAGE(市场容量及各品牌当年占有率!CN7:CQ7) * 市场价格!DJ7 / (1 + 12 %)

//= AVERAGE(市场容量及各品牌当年占有率!BJ5:BM5) * 市场价格!CD5

//=AVERAGE(市场容量及各品牌当年占有率!BJ7:BM7)*市场价格!DE7/(1+10%)+
//AVERAGE(市场容量及各品牌当年占有率!BP7:BS7)*市场价格!DG7/(1+10%)+
//AVERAGE(市场容量及各品牌当年占有率!BV7:BY7)*市场价格!DI7/(1+10%)
//=500+(市场价格!DE6*(AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6))*5%+市场价格!DE6/(1+10%)*(AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6))*5%)
//+市场价格!DG6*(AVERAGE(市场容量及各品牌当年占有率!BP6:BS6))*5%+市场价格!DG6/(1+10%)*(AVERAGE(市场容量及各品牌当年占有率!BP6:BS6)*5%)
//=进货报表!B13*市场价格!$CE$6+进货报表!D13*市场价格!$CH$6 
// summaryAssent4.P=AVERAGE(市场容量及各品牌当年占有率!BJ6:BM6)*市场价格!DE6/(1+10%)+AVERAGE(市场容量及各品牌当年占有率!BP6:BS6)*市场价格!DG6/(1+10%)
//  summaryAssent4.W =AVERAGE(市场容量及各品牌当年占有率!CB6:CE6)*市场价格!DF6/(1+12%)+AVERAGE(市场容量及各品牌当年占有率!CH6:CK6)*市场价格!DH6/(1+12%)
//summaryAssent17.QAgent[indexAgent] = summaryAssent17.XAgent[indexAgent] ==ROUND(ROUND(IF(X12=0,((进销存报表!$I4+进销存报表!$K4-市场容量及各品牌当年占有率!CT6)+(进销存报表!$M4-市场容量及各品牌当年占有率!CZ6)),0),0),0)
//=X5+X6+X7-X8-X9-X10-X11-((进销存报表!S4-进销存报表!I4)*市场价格!$CN$6+进销存报表!U4*市场价格!$CQ$6)+X13
//=AL7-AL8-AL9-AL10+AL13-AL11 
//=IF(X20=0,0,(进销存报表!$I4+进销存报表!$K4-市场容量及各品牌当年占有率!CT6)*市场价格!EF6+(进销存报表!$M4-市场容量及各品牌当年占有率!CZ6)*市场价格!EL6)

//=IF(Q20=0,0,(进销存报表!$I4+进销存报表!$K4-市场容量及各品牌当年占有率!CT6)*市场价格!$CN$6+(进销存报表!$M4-市场容量及各品牌当年占有率!CZ6)*市场价格!$CQ$6)


