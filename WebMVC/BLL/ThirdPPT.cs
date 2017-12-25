using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class ThirdPPTData
    {
        protected ThirdPPTList thirdPPTList;

        public ThirdPPTData()
        {
            thirdPPTList = new ThirdPPTList();

        }
        protected void SetBrandProfit(ThirdBrandProfit brandProfit)
        {
            thirdPPTList.BrandProfit = brandProfit;
        }
        protected void AddBrandInfo(ThirdBrandInfo brandInfo)
        {
            thirdPPTList.brandInfos.Add(brandInfo);
        }
        protected void AddsAgentInfos(ThirdSAgentInfo sAgentInfo)
        {
            thirdPPTList.sAgentInfos.Add(sAgentInfo);
        }
        protected void AddsAgentResult(ThirdSAgentResult sAgentResult)
        {
            thirdPPTList.sAgentResults.Add(sAgentResult);
        }

        protected void AddThirdSummary(ThirdSummary thirdSummary)
        {
            thirdPPTList.thirdSummarys.Add(thirdSummary);
        }
        public ThirdPPTList GetPPTList()
        {
            return thirdPPTList;
        }
    }
    public class ThirdPPT : ThirdPPTData
    {

        List<MarketTable> marketPrices;
        Investment investment;
        InvertmentTable1 invertmentTable1;

        List<SummaryTable> summaryAsserts;
        LastBrand lastBrand;
        List<InvoicingTable> invoicingReports;
        List<PriceControlTable> priceControls;
        List<CurrentShareTable> currentShares;
        SecondPPT secondPPT;
        string stage;
        AgentStages agentStages;
        public ThirdPPT(MarketPrice MarketPrice, Investment Investment, InvertmentTable1 InvertmentTable1, SummaryAssent SummaryAssent,
            LastBrand LastBrand, InvoicingReport InvoicingReport, PriceControl priceControl, CurrentShare currentShare, SecondPPT SecondPPT)
        {
            agentStages = new AgentStages();
            marketPrices = MarketPrice.Get();
            this.investment = Investment;
            this.invertmentTable1 = InvertmentTable1;
            summaryAsserts = SummaryAssent.Get();
            lastBrand = LastBrand;
            invoicingReports = InvoicingReport.Get();
            priceControls = priceControl.Get();
            currentShares = currentShare.Get();
            this.secondPPT = SecondPPT;
            stage = Stage.第3阶段.ToString();
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
            var marketPrice3 = marketPrices.FirstOrDefault(s => s.Stage == stage);
            var inverstment3 = investment.Get().FirstOrDefault(s => s.Stage == stage);
            var invertmentTable3 = invertmentTable1.getAgentInputs().FirstOrDefault(s => s.Stage == stage);
            var brand3 = invertmentTable1.getBrandTable().FirstOrDefault(s => s.Stage == stage && s.Brand == Brand.S品牌.ToString());
            var priceControl3 = priceControls.FirstOrDefault(s => s.Stage == stage);

            if (marketPrice3 != null && inverstment3 != null)
            {

                AddBrandInfo(new ThirdBrandInfo()
                {
                    品牌方 = Brand.M品牌,
                    出厂价 = marketPrice3.CM[0].M,
                    指导零售价 = priceControl3.B.RcM[0],
                    RC2出厂价 = marketPrice3.CM[1].M,
                    RC2指导零售价 = priceControl3.B.RcM[1],
                    RC3出厂价 = marketPrice3.CM[2].M,
                    RC3指导零售价 = priceControl3.B.RcM[2],
                    品牌广告 = inverstment3.J,
                    外观创新 = inverstment3.M.Surfacerc[0],
                    功能创新 = inverstment3.N.Functionrc[0],
                    材料创新 = inverstment3.O.Material[0],
                    RC2外观创新 = inverstment3.M.Surfacerc[1],
                    RC2功能创新 = inverstment3.N.Functionrc[1],
                    RC2材料创新 = inverstment3.O.Material[1],
                    RC3外观创新 = inverstment3.M.Surfacerc[2],
                    RC3功能创新 = inverstment3.N.Functionrc[2],
                    RC3材料创新 = inverstment3.O.Material[2],
                });
                AddBrandInfo(new ThirdBrandInfo()
                {
                    品牌方 = Brand.S品牌,
                    出厂价 = marketPrice3.CM[0].S,
                    指导零售价 = brand3.retailPrice,
                    RC2出厂价 = marketPrice3.CM[1].S,
                    RC2指导零售价 = brand3.NewRetailPriceR2,
                    RC3出厂价 = marketPrice3.CM[2].S,
                    RC3指导零售价 = brand3.NewRetailPriceR3,
                    品牌广告 = inverstment3.K,
                    外观创新 = inverstment3.P.Surfacerc[0],
                    功能创新 = inverstment3.Q.Functionrc[0],
                    材料创新 = inverstment3.R.Material[0],
                    RC2外观创新 = inverstment3.P.Surfacerc[1],
                    RC2功能创新 = inverstment3.Q.Functionrc[1],
                    RC2材料创新 = inverstment3.R.Material[1],
                    RC3外观创新 = inverstment3.P.Surfacerc[2],
                    RC3功能创新 = inverstment3.Q.Functionrc[2],
                    RC3材料创新 = inverstment3.R.Material[2],
                });
                AddBrandInfo(new ThirdBrandInfo
                {
                    品牌方 = Brand.J品牌,
                    出厂价 = marketPrice3.CM[0].J,
                    指导零售价 = priceControl3.B.RcJ[0],
                    RC2出厂价 = marketPrice3.CM[1].J,
                    RC2指导零售价 = priceControl3.B.RcJ[1],
                    RC3出厂价 = marketPrice3.CM[2].J,
                    RC3指导零售价 = priceControl3.B.RcJ[2],
                    品牌广告 = inverstment3.L,
                    外观创新 = inverstment3.S.Surfacerc[0],
                    功能创新 = inverstment3.T.Functionrc[0],
                    材料创新 = inverstment3.U.Material[0],
                    RC2外观创新 = inverstment3.S.Surfacerc[1],
                    RC2功能创新 = inverstment3.T.Functionrc[1],
                    RC2材料创新 = inverstment3.U.Material[1],
                    RC3外观创新 = inverstment3.S.Surfacerc[2],
                    RC3功能创新 = inverstment3.T.Functionrc[2],
                    RC3材料创新 = inverstment3.U.Material[2],
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
            SetBrandProfit(new ThirdBrandProfit
            {
                M = summary.AD,
                S1 = summary.AEAgent[0],
                S2 = summary.AEAgent[1],
                S3 = summary.AEAgent[2],
                S4 = summary.AEAgent[3],
                J = summary.AK,
                SM = getLastBrand(Brand.M品牌.ToString()).F,
                SS = getLastBrand(Brand.S品牌.ToString()).F,
                SJ = getLastBrand(Brand.J品牌.ToString()).F,
                RC2SM = getLastBrand(Brand.M品牌.ToString()).G,
                RC2SS = getLastBrand(Brand.S品牌.ToString()).G,
                RC2SJ = getLastBrand(Brand.J品牌.ToString()).G,
                RC3SM = getLastBrand(Brand.M品牌.ToString()).H,
                RC3SS = getLastBrand(Brand.S品牌.ToString()).H,
                RC3SJ = getLastBrand(Brand.J品牌.ToString()).H,
            });

        }

        #endregion

        #region S品牌代理商信息表 sAgentInfos
        private void sAgentInfos()
        {
            var investment3 = investment.Get().FirstOrDefault(s => s.Stage == stage);
            var priceControl3 = priceControls.FirstOrDefault(s => s.Stage == stage);
            Action<ThirdSAgentInfo, BrandInput> setBrandInput = (sagentInfo, brandInput) =>
             {
                 sagentInfo.终端形象 = brandInput.EndImage;
                 sagentInfo.导购员 = brandInput.Salesperson;
                 sagentInfo.店内促销 = brandInput.HousePromote;
                 sagentInfo.演示员 = brandInput.demonstrator;
                 sagentInfo.户外活动 = brandInput.outdoorActivity;
                 sagentInfo.推广小分队 = brandInput.promotionTeam;
                 sagentInfo.服务 = brandInput.servet;
             };
            foreach (var item in invoicingReports)
            {
                var sAgentInfo = new ThirdSAgentInfo
                {
                    代理方 = item.AgentName,
                };
                var indexAgent = agentStages.agents.IndexOf(item.AgentName);
                sAgentInfo.供货价 = priceControl3.K[1].Agent[indexAgent];
                sAgentInfo.零售价 = priceControl3.D[1].Agent[indexAgent];
                sAgentInfo.RC2供货价 = priceControl3.K[2].Agent[indexAgent];
                sAgentInfo.RC2零售价 = priceControl3.D[2].Agent[indexAgent];
                sAgentInfo.RC3供货价 = priceControl3.K[3].Agent[indexAgent];
                sAgentInfo.RC3零售价 = priceControl3.D[3].Agent[indexAgent];
                setBrandInput(sAgentInfo, investment3.CLAgent[indexAgent]);
                sAgentInfo.S品牌费用补贴支持 = investment3.AJAgent[indexAgent].InputSum;

                AddsAgentInfos(sAgentInfo);
            }

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
            var currentShare3 = currentShares.FirstOrDefault(s => s.Stage == stage);
            var priceControl3 = priceControls.FirstOrDefault(s => s.Stage == stage);

            foreach (var item in invoicingReports)
            {
                var sAgentResult = new ThirdSAgentResult
                {
                    代理方 = item.AgentName,

                };
                sAgentResult.期初 = item.DStage[2][0];
                sAgentResult.期末 = item.DStage[3][0];
                sAgentResult.销售量 = item.CStage[3][0];
                sAgentResult.销售金额 = item.HStage[3][0];
                sAgentResult.RC2期初 = item.DStage[2][1];
                sAgentResult.RC2期末 = item.DStage[3][1];
                sAgentResult.RC2销售量 = item.CStage[3][1];
                sAgentResult.RC2销售金额 = item.HStage[3][1];
                sAgentResult.RC3期初 = 0;
                sAgentResult.RC3期末 = item.DStage[3][2];
                sAgentResult.RC3销售量 = item.CStage[3][2];
                sAgentResult.RC3销售金额 = item.HStage[3][2];

                var indexAgent = agentStages.agents.IndexOf(item.AgentName);
                sAgentResult.数量 = SumRcNumber(sAgentResult.期初, sAgentResult.销售量, currentShare3.CT[1].Agent[indexAgent]);
                sAgentResult.金额 = sAgentResult.数量 * decimal.Round(priceControl3.K[1].Agent[indexAgent], 0);
                sAgentResult.RC2数量 = SumRcNumber(sAgentResult.RC2期初, sAgentResult.RC2销售量, currentShare3.CT[2].Agent[indexAgent]);
                sAgentResult.RC2金额 = sAgentResult.RC2数量 * decimal.Round(priceControl3.K[2].Agent[indexAgent], 0);
                sAgentResult.RC3数量 = SumRcNumber(sAgentResult.RC3期初, sAgentResult.RC3销售量, currentShare3.CT[3].Agent[indexAgent]);
                sAgentResult.RC3金额 = sAgentResult.RC3数量 * decimal.Round(priceControl3.K[3].Agent[indexAgent], 0);
                sAgentResult.销售利润 = summary16.ALAgent[indexAgent];
                sAgentResult.借款利息 = summary17.ALAgent[indexAgent];
                sAgentResult.库存跌价损失计提 = summary18.ALAgent[indexAgent];
                sAgentResult.最终经营利润 = summary19.ALAgent[indexAgent];
                sAgentResult.现金流 = summary15.ALAgent[indexAgent];

                AddsAgentResult(sAgentResult);


            }
        }
        private decimal SumRcNumber(decimal a, decimal b, decimal c)
        {
            var result = decimal.Round(a, 0) + decimal.Round(b, 0) - decimal.Round(c, 0);
            return result > 0 ? 0 : result;
        }
        #endregion
        #region 累计总利润
        public void ThirdSummaryAdd()
        {
            var sAgentResults2 = secondPPT.GetFirstPPTList().sAgentResults;
            var summary = summaryAsserts.FirstOrDefault(s => s.A == "期间销售额");// 13);//

            foreach (var item in sAgentResults2)
            {
                var sAgentResult3 = thirdPPTList.sAgentResults.FirstOrDefault(s => s.代理方 == item.代理方);
                var thirdSummary = new ThirdSummary
                {
                    代理方 = item.代理方,
                    第一期利润 = item.第一期利润,
                    第二期利润 = item.最终经营利润,
                    第三期利润 = sAgentResult3.最终经营利润,
                    库存 = sAgentResult3.期末 + sAgentResult3.RC2期末 + sAgentResult3.RC3期末,
                    现金流 = sAgentResult3.现金流
                };
                var indexAgent = agentStages.agents.IndexOf(item.代理方);
                thirdSummary.销售额 = summary.ALAgent[indexAgent];
                AddThirdSummary(thirdSummary);
            }
        }
        #endregion
    }
    public class ThirdPPTList
    {
        public List<ThirdBrandInfo> brandInfos { get; set; } = new List<ThirdBrandInfo>();
        public List<ThirdSAgentInfo> sAgentInfos { get; set; } = new List<ThirdSAgentInfo>();
        public List<ThirdSAgentResult> sAgentResults { get; set; } = new List<ThirdSAgentResult>();
        public List<ThirdSummary> thirdSummarys { get; set; } = new List<ThirdSummary>();
        public ThirdBrandProfit BrandProfit { get; set; }
    }
    public class ThirdBrandInfo : SecondBrandInfo
    {
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3出厂价 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3指导零售价 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3外观创新 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3功能创新 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3材料创新 { get; set; }


    }
    public class ThirdSAgentInfo : SecondSAgentInfo
    {
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3供货价 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3零售价 { get; set; }

    }
    public class ThirdSAgentResult : SecondSAgentResult
    {
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3期初 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3期末 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3销售量 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3销售金额 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3数量 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal RC3金额 { get; set; }

    }
    public class ThirdBrandProfit : SecondBrandProfit
    {
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal RC3SM { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal RC3SS { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal RC3SJ { get; set; }
    }
    public class ThirdSummary
    {
        public string 代理方 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 第一期利润 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 第二期利润 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 第三期利润 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 累计总利润
        {
            get
            {
                return 第一期利润 + 第二期利润 + 第三期利润;
            }
        }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 库存 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 销售额 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 利润 { get { return 第三期利润; } }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 现金流 { get; set; }

    }
    public class ComprehensiveShare
    {
        public string Brand { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal 第一期 { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal 第二期 { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal 第三期 { get; set; }
    }

}