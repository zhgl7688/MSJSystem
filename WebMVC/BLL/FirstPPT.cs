using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    /// <summary>
    /// 第一期PPT
    /// </summary>
    public class FirstPPTData
    {
        FirstPPTList firstPPTList;

        public FirstPPTData()
        {
            firstPPTList = new FirstPPTList();

        }
        protected void SetBrandProfit(BrandProfit brandProfit)
        {
            firstPPTList.BrandProfit = brandProfit;
        }
        protected void AddBrandInfo(BrandInfo brandInfo)
        {
            firstPPTList.brandInfos.Add(brandInfo);
        }
        protected void AddsAgentInfos(SAgentInfo sAgentInfo)
        {
            firstPPTList.sAgentInfos.Add(sAgentInfo);
        }
        protected void AddsAgentResult(SAgentResult sAgentResult)
        {
            firstPPTList.sAgentResults.Add(sAgentResult);
        }

        public FirstPPTList GetFirstPPTList()
        {
            return firstPPTList;
        }
    }
    public class FirstPPT : FirstPPTData
    {
        MarketPrice marketPrice;
        Investment investment;
        InvertmentTable1 invertmentTable1;
        SummaryAssent summaryAssent;
        LastBrand lastBrand;
        List<InvoicingTable> invoicingReports;
        List<PriceControlTable> priceControls;
        AgentStages agentStages;
        public FirstPPT(MarketPrice MarketPrice, Investment Investment, InvertmentTable1 InvertmentTable1, SummaryAssent SummaryAssent,
            LastBrand LastBrand, InvoicingReport InvoicingReport, PriceControl priceControl)
        {
            agentStages = new AgentStages();
            this.marketPrice = MarketPrice;
            this.investment = Investment;
            this.invertmentTable1 = InvertmentTable1;
            summaryAssent = SummaryAssent;
            lastBrand = LastBrand;
            invoicingReports = InvoicingReport.Get();
            priceControls = priceControl.Get();
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
            var stage = Stage.第1阶段.ToString();
            var firstMarketPrice = marketPrice.Get().FirstOrDefault(s => s.Stage == stage);
            var firstInverstment = investment.Get().FirstOrDefault(s => s.Stage == stage);
            var firstinvertmentTable1 = invertmentTable1.getAgentInputs().FirstOrDefault(s => s.Stage == stage);
            var firstbrand1 = invertmentTable1.getBrandTable().FirstOrDefault(s => s.Stage == stage && s.Brand == Brand.S品牌.ToString());
            if (firstMarketPrice != null && firstInverstment != null)
            {
                AddBrandInfo(new BrandInfo()
                {
                    品牌方 = Brand.M品牌,
                    出厂价 = firstMarketPrice.CM[1].M, 
                    指导零售价 = firstMarketPrice.DE[1].M, 
                    品牌广告 = firstInverstment.J,
                    外观创新 = firstInverstment.M.Surfacerc[0],
                    功能创新 = firstInverstment.N.Functionrc[0],
                    材料创新 = firstInverstment.O.Material[0],
                });
                AddBrandInfo(new BrandInfo()
                {
                    品牌方 = Brand.S品牌,
                    出厂价 = firstMarketPrice.CM[1].S,
                    指导零售价 = firstbrand1.retailPrice,
                    品牌广告 = firstInverstment.K,
                    外观创新 = firstInverstment.P.Surfacerc[0],
                    功能创新 = firstInverstment.Q.Functionrc[0],
                    材料创新 = firstInverstment.R.Material[0],
                });



                AddBrandInfo(new BrandInfo
                {
                    品牌方 = Brand.J品牌,
                    出厂价 = firstMarketPrice.CM[1].J,
                    指导零售价 = firstMarketPrice.DE[1].J,
                    品牌广告 = firstInverstment.L,
                    外观创新 = firstInverstment.S.Surfacerc[0],
                    功能创新 = firstInverstment.T.Functionrc[0],
                    材料创新 = firstInverstment.U.Material[0],
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
            var summary = summaryAssent.Get().FirstOrDefault(s => s.A == "销售利润");// 13);//
            Func<string, decimal> getC = (b) =>
             {
                 var shareMark = lastBrand.Get().FirstOrDefault(s => s.Brand == b);
                 return shareMark != null ? shareMark.C : 0;
             };
            SetBrandProfit(new BrandProfit
            {
                M = summary.B,
                S1 = summary.CAgent[0],
                S2 = summary.CAgent[1],
                S3 = summary.CAgent[2],
                S4 = summary.CAgent[3],
                J = summary.I,
                SM = getC(Brand.M品牌.ToString()),
                SS = getC(Brand.S品牌.ToString()),
                SJ = getC(Brand.J品牌.ToString())
            });

        }

        #endregion

        #region S品牌代理商信息表 sAgentInfos
        private void sAgentInfos()
        {
            var investment1 = investment.Get().FirstOrDefault(s => s.Stage == Stage.第1阶段.ToString());
            var priceControl1 = priceControls.FirstOrDefault(s => s.Stage == Stage.第1阶段.ToString());
            foreach (var item in invoicingReports)
            {
                var sAgentInfo = new SAgentInfo
                {
                    代理方 = item.AgentName,
                };
                var indexAgent = agentStages.agents.IndexOf(item.AgentName);
                sAgentInfo.供货价 = priceControl1.K[1].Agent[indexAgent];
                sAgentInfo.零售价 = priceControl1.D[1].Agent[indexAgent];
                setBrandInput(sAgentInfo, investment1.CLAgent[indexAgent]);
                sAgentInfo.S品牌费用补贴支持 = investment1.AJAgent[indexAgent].InputSum;

                AddsAgentInfos(sAgentInfo);
            }

        }
        #endregion
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
        #region S品牌代理商经营模拟结果呈现 sAgentResult
        private void sAgentResult()
        {
            var agentInputs = invertmentTable1.getAgentInputs();
            var summary20 = summaryAssent.Get().FirstOrDefault(s => s.A == "经营中损失的销售");
            var summary21 = summaryAssent.Get().FirstOrDefault(s => s.A == "经营中损失的金额");
            var summary16 = summaryAssent.Get().FirstOrDefault(s => s.A == "销售利润");
            var summary17 = summaryAssent.Get().FirstOrDefault(s => s.A == "应支付银行利息");
            var summary18 = summaryAssent.Get().FirstOrDefault(s => s.A == "库存需按照10%计提跌价损失");
            var summary19 = summaryAssent.Get().FirstOrDefault(s => s.A == "扣除计提跌价损失及银行利息后的利润");
            var summary15 = summaryAssent.Get().FirstOrDefault(s => s.A == "期末现金余额");

            foreach (var item in invoicingReports)
            {
                var sAgentResult = new SAgentResult
                {
                    代理方 = item.AgentName,

                };
                sAgentResult.期初 = item.DStage[0][0];
                sAgentResult.期末 = item.DStage[1][0];
                sAgentResult.销售量 = item.CStage[1][0];
                sAgentResult.销售金额 = item.HStage[1][0];
                var indexAgent = agentStages.agents.IndexOf(item.AgentName);
                sAgentResult.数量 = summary20.JAgent[indexAgent];
                sAgentResult.金额 = summary21.JAgent[indexAgent];
                sAgentResult.销售利润 = summary16.JAgent[indexAgent];
                sAgentResult.借款利息 = summary17.JAgent[indexAgent];
                sAgentResult.库存跌价损失计提 = summary18.JAgent[indexAgent];
                sAgentResult.最终经营利润 = summary19.JAgent[indexAgent];
                sAgentResult.现金流 = summary15.JAgent[indexAgent];
 
                AddsAgentResult(sAgentResult);


            }

        }
        #endregion

    }
    public class FirstPPTList
    {
        public List<BrandInfo> brandInfos { get; set; } = new List<BrandInfo>();
        public List<SAgentInfo> sAgentInfos { get; set; } = new List<SAgentInfo>();
        public List<SAgentResult> sAgentResults { get; set; } = new List<SAgentResult>();
        public BrandProfit BrandProfit { get; set; }
    }

}