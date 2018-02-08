﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class PPT
    {

        List<MarketTable> marketPrices;
        Investment investment;
        InvertmentTable1 invertmentTable1;
        PPTList pptList;
        List<SummaryTable> summaryAsserts;
        LastBrand lastBrand;
        List<InvoicingTable> invoicingReports;
        List<PriceControlTable> priceControls;
        List<CurrentShareTable> currentShares;
        FirstPPT firstPPT;
        string stage;
        int indexStage;
        public PPT(string stage, MarketPrice MarketPrice, Investment Investment, InvertmentTable1 InvertmentTable1, SummaryAssent SummaryAssent,
            LastBrand LastBrand, InvoicingReport InvoicingReport, PriceControl priceControl, CurrentShare currentShare, FirstPPT firstPPT)
        {
            this.stage = stage;
            this.indexStage = AgentStages.stages.IndexOf(stage);
            marketPrices = MarketPrice.Get();
            this.investment = Investment;
            this.invertmentTable1 = InvertmentTable1;
            summaryAsserts = SummaryAssent.Get();
            lastBrand = LastBrand;
            invoicingReports = InvoicingReport.Get();
            priceControls = priceControl.Get();
            currentShares = currentShare.Get();
  
            Init();
        }
        public void Init()
        {
            BrandInfo();
            BrandProfitAdd();
            sAgentInfos();
            sAgentResult();
        }
        #region 品牌商竞争信息表BrandInfo
        /// <summary>
        /// 品牌商竞争信息表BrandInfo
        /// </summary>
        private void BrandInfo()
        {
            var marketPrice = marketPrices.FirstOrDefault(s => s.Stage == stage);
            var inverstment= investment.Get().FirstOrDefault(s => s.Stage == stage);
            var invertmentTable = invertmentTable1.getAgentInputs().FirstOrDefault(s => s.Stage == stage);
            var brand = invertmentTable1.getBrandTable().FirstOrDefault(s => s.Stage == stage && s.Brand == Brand.S品牌.ToString());
            var priceControl = priceControls.FirstOrDefault(s => s.Stage == stage);
            if (marketPrice != null && inverstment != null)
            {

                var sbm = new SecondBrandInfo()
                {
                    品牌方 = Brand.M品牌,
                    出厂价 = marketPrice.CM[0].M,
                    指导零售价 = priceControl.B.RcM[0],
                    RC2出厂价 = marketPrice.CM[1].M,
                    RC2指导零售价 = priceControl.B.RcM[1],
                    品牌广告 = inverstment.J,
                    外观创新 = inverstment.M.Surfacerc[0],
                    功能创新 = inverstment.N.Functionrc[0],
                    材料创新 = inverstment.O.Material[0],
                    RC2外观创新 = inverstment.M.Surfacerc[1],
                    RC2功能创新 = inverstment.N.Functionrc[1],
                    RC2材料创新 = inverstment.O.Material[1],
                };
                for (int i = 0; i < indexStage; i++)
                {

                }
                AddBrandInfo(new SecondBrandInfo()
                {
                    品牌方 = Brand.M品牌,
                    出厂价 = marketPrice.CM[0].M,
                    指导零售价 = priceControl.B.RcM[0],
                    RC2出厂价 = marketPrice.CM[1].M,
                    RC2指导零售价 = priceControl.B.RcM[1],
                    品牌广告 = inverstment.J,
                    外观创新 = inverstment.M.Surfacerc[0],
                    功能创新 = inverstment.N.Functionrc[0],
                    材料创新 = inverstment.O.Material[0],
                    RC2外观创新 = inverstment.M.Surfacerc[1],
                    RC2功能创新 = inverstment.N.Functionrc[1],
                    RC2材料创新 = inverstment.O.Material[1],
                });

                AddBrandInfo(new SecondBrandInfo()
                {
                    品牌方 = Brand.S品牌,
                    出厂价 = marketPrice.CM[0].S,
                    指导零售价 = brand.retailPriceRC[0],
                    RC2出厂价 = marketPrice.CM[1].S,
                    RC2指导零售价 = brand.retailPriceRC[1],
                    品牌广告 = inverstment.K,
                    外观创新 = inverstment.P.Surfacerc[0],
                    功能创新 = inverstment.Q.Functionrc[0],
                    材料创新 = inverstment.R.Material[0],
                    RC2外观创新 = inverstment.P.Surfacerc[1],
                    RC2功能创新 = inverstment.Q.Functionrc[1],
                    RC2材料创新 = inverstment.R.Material[1],
                });



                AddBrandInfo(new SecondBrandInfo
                {
                    品牌方 = Brand.J品牌,
                    出厂价 = marketPrice.CM[0].J,
                    指导零售价 = priceControl.B.RcJ[0],
                    RC2出厂价 = marketPrice.CM[1].J,
                    RC2指导零售价 = priceControl.B.RcJ[1],
                    品牌广告 = inverstment.L,
                    外观创新 = inverstment.S.Surfacerc[0],
                    功能创新 = inverstment.T.Functionrc[0],
                    材料创新 = inverstment.U.Material[0],
                    RC2外观创新 = inverstment.S.Surfacerc[1],
                    RC2功能创新 = inverstment.T.Functionrc[1],
                    RC2材料创新 = inverstment.U.Material[1],
                });

            }


        }
        #endregion

        #region 各品牌商盈利情况BrandProfit
        /// <summary>
        /// 各品牌商盈利情况BrandProfit
        /// </summary>
        private void BrandProfitAdd()
        {
            var summary = summaryAsserts.FirstOrDefault(s => s.A == "销售利润");// 13);//
            Func<string, LastBrandTable> getLastBrand = (b) =>
            {
                return lastBrand.Get().FirstOrDefault(s => s.Brand == b);
            };
            var sbp = new SecondBrandProfit
            {
                M = summary.P,

                J = summary.W,
                SM = getLastBrand(Brand.M品牌.ToString()).D,
                SS = getLastBrand(Brand.S品牌.ToString()).D,
                SJ = getLastBrand(Brand.J品牌.ToString()).D,
                RC2SM = getLastBrand(Brand.M品牌.ToString()).E,
                RC2SS = getLastBrand(Brand.S品牌.ToString()).E,
                RC2SJ = getLastBrand(Brand.J品牌.ToString()).E,
            };
            for (int i = 0; i < summary.QAgent.Count; i++)
            {
                sbp.SAgent.Add(summary.QAgent[i]);
                //S1 = summary.QAgent[0],
                //S2 = summary.QAgent[1],
                //S3 = summary.QAgent[2],
                // S4 = summary.QAgent[3],
            }
            SetBrandProfit(sbp);

        }

        #endregion

        #region S品牌代理商信息表 sAgentInfos
        private void sAgentInfos()
        {
            var investment2 = investment.Get().FirstOrDefault(s => s.Stage == Stage.第2阶段.ToString());
            var priceControl2 = priceControls.FirstOrDefault(s => s.Stage == Stage.第2阶段.ToString());
            foreach (var item in invoicingReports)
            {
                var sAgentInfo = new SecondSAgentInfo
                {
                    代理方 = item.AgentName,
                };
                var indexAgent = AgentStages.agents.IndexOf(item.AgentName);
                sAgentInfo.供货价 = priceControl2.K[0].Agent[indexAgent];
                sAgentInfo.零售价 = priceControl2.D[0].Agent[indexAgent];
                sAgentInfo.RC2供货价 = priceControl2.K[1].Agent[indexAgent];
                sAgentInfo.RC2零售价 = priceControl2.D[1].Agent[indexAgent];
                setBrandInput(sAgentInfo, investment2.CLAgent[indexAgent]);
                sAgentInfo.S品牌费用补贴支持 = investment2.AJAgent[indexAgent].InputSum;

                AddsAgentInfos(sAgentInfo);
            }

        }

        public void setBrandInput(SAgentInfo sagentInfo, BrandInput brandInput)
        {
            sagentInfo.终端形象 = brandInput.EndImage;
            sagentInfo.导购员 = brandInput.Salesperson;
            sagentInfo.店内促销 = brandInput.HousePromote;
            sagentInfo.演示员 = brandInput.demonstrator;
            sagentInfo.户外活动 = brandInput.outdoorActivity;
            sagentInfo.推广小分队 = brandInput.promotionTeam;
            sagentInfo.服务 = brandInput.servet;
        }
        #endregion

        #region S品牌代理商经营模拟结果呈现 sAgentResult
        private void sAgentResult()
        {
            var agentInputs = invertmentTable1.getAgentInputs();
            var summary20 = summaryAsserts.FirstOrDefault(s => s.A == "经营中损失的销售");
            var summary21 = summaryAsserts.FirstOrDefault(s => s.A == "经营中损失的金额");
            var summary16 = summaryAsserts.FirstOrDefault(s => s.A == "销售利润");
            var summary17 = summaryAsserts.FirstOrDefault(s => s.A == "应支付银行利息");
            var summary18 = summaryAsserts.FirstOrDefault(s => s.A == "库存需按照10%计提跌价损失");
            var summary19 = summaryAsserts.FirstOrDefault(s => s.A == "扣除计提跌价损失及银行利息后的利润");
            var summary15 = summaryAsserts.FirstOrDefault(s => s.A == "期末现金余额");
            var currentShare2 = currentShares.FirstOrDefault(s => s.Stage == Stage.第2阶段.ToString());
            var marketPrice2 = marketPrices.FirstOrDefault(s => s.Stage == Stage.第2阶段.ToString());

            foreach (var item in invoicingReports)
            {
                var sAgentResult = new SecondSAgentResult
                {
                    代理方 = item.AgentName,

                };
                sAgentResult.期初 = item.DStage[1][0];
                sAgentResult.期末 = item.DStage[2][0];
                sAgentResult.销售量 = item.CStage[2][0];
                sAgentResult.销售金额 = item.HStage[2][0];
                sAgentResult.RC2期初 = 0;
                sAgentResult.RC2期末 = item.DStage[2][1];
                sAgentResult.RC2销售量 = item.CStage[2][1];
                sAgentResult.RC2销售金额 = item.HStage[2][1];
                var indexAgent = AgentStages.agents.IndexOf(sAgentResult.代理方);
                sAgentResult.数量 = ((sAgentResult.期初 + sAgentResult.销售量 - currentShare2.CT[0].Agent[indexAgent]) > 0 ?
                    0 : (sAgentResult.期初 + sAgentResult.销售量 - currentShare2.CT[0].Agent[indexAgent]));
                sAgentResult.金额 = sAgentResult.数量 * marketPrice2.EF[1].Agent[indexAgent];
                sAgentResult.RC2数量 = ((sAgentResult.RC2期初 + sAgentResult.RC2销售量 - currentShare2.CT[1].Agent[indexAgent]) > 0 ?
                    0 : (sAgentResult.RC2期初 + sAgentResult.RC2销售量 - currentShare2.CT[1].Agent[indexAgent])); ;
                sAgentResult.RC2金额 = sAgentResult.RC2数量 * marketPrice2.EF[1].Agent[indexAgent];
                sAgentResult.销售利润 = summary16.XAgent[indexAgent];
                sAgentResult.借款利息 = summary17.XAgent[indexAgent];
                sAgentResult.库存跌价损失计提 = summary18.XAgent[indexAgent];
                sAgentResult.最终经营利润 = summary19.XAgent[indexAgent];
                sAgentResult.现金流 = summary15.XAgent[indexAgent];

                AddsAgentResult(sAgentResult);


            }
            var ppt1 = firstPPT.GetFirstPPTList().sAgentResults;
            foreach (var item in pptList.sAgentResults)
            {
                //item.第一期利润 = ppt1.FirstOrDefault(s => s.代理方 == item.代理方).最终经营利润;
            }
        }
        #endregion
        protected void SetBrandProfit(BrandProfit brandProfit)
        {
            pptList.BrandProfit = brandProfit;
        }
        protected void AddBrandInfo(BrandInfo brandInfo)
        {
            pptList.brandInfos.Add(brandInfo);
        }
        protected void AddsAgentInfos(SAgentInfo sAgentInfo)
        {
            pptList.sAgentInfos.Add(sAgentInfo);
        }
        protected void AddsAgentResult(SAgentResult sAgentResult)
        {
            pptList.sAgentResults.Add(sAgentResult);
        }

    }
    public class PPTData
    {
        PPTList PPTList;

        public PPTData()
        {
            PPTList = new PPTList();

        }
        protected void SetBrandProfit(BrandProfit brandProfit)
        {
            PPTList.BrandProfit = brandProfit;
        }
        protected void AddBrandInfo(BrandInfo brandInfo)
        {
            PPTList.brandInfos.Add(brandInfo);
        }
        protected void AddsAgentInfos(SAgentInfo sAgentInfo)
        {
            PPTList.sAgentInfos.Add(sAgentInfo);
        }
        protected void AddsAgentResult(SAgentResult sAgentResult)
        {
            PPTList.sAgentResults.Add(sAgentResult);
        }

        public PPTList GetFirstPPTList()
        {
            return PPTList;
        }
    }
    public class PPTList
    {
        public List<BrandInfo> brandInfos { get; set; } = new List<BrandInfo>();
        public List<SAgentInfo> sAgentInfos { get; set; } = new List<SAgentInfo>();
        public List<SAgentResult> sAgentResults { get; set; } = new List<SAgentResult>();
        public BrandProfit BrandProfit { get; set; }
    }
}