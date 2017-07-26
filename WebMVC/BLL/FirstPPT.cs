﻿using System;
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
    public class FirstPPT
    {
        List<BrandInfo> brandInfos = new List<BrandInfo>();
        List<SAgentInfo> sAgentInfos = new List<SAgentInfo>();
        List<SAgentResult> sAgentResults = new List<SAgentResult>();
        public BrandProfit BrandProfit { get; set; }

        public void AddBrandInfo(BrandInfo brandInfo)
        {
            brandInfos.Add(brandInfo);
        }
        public void AddsAgentInfos(SAgentInfo sAgentInfo)
        {
            sAgentInfos.Add(sAgentInfo);
        }
        public void AddsAgentResult(SAgentResult sAgentResult)
        {
            sAgentResults.Add(sAgentResult);
        }

    }
    public class FirstPPTOperstion
    {
        MarketPrice marketPrice;
        InvestmentTable inverstmentTable;
        InvertmentTable1 invertmentTable1;
        SummaryAssent summaryAssent;
        LastBrand lastBrand;
        InvoicingReport invoicingReport;
FirstPPT firstPPt = new FirstPPT();
        public FirstPPTOperstion(MarketPrice marketPrice, InvestmentTable inverstmentTable, InvertmentTable1 invertmentTable1)
        {
            this.marketPrice = marketPrice;
            this.inverstmentTable = inverstmentTable;
            this.invertmentTable1 = invertmentTable1;
        }
        #region 品牌商竞争信息表BrandInfo
        /// <summary>
        /// 品牌商竞争信息表BrandInfo
        /// </summary>
        public void BrandInfoadd()
        {
            
            var firstMarketPrice = marketPrice.Get().FirstOrDefault(s => s.阶段 == "第一阶段");
            var firstInverstment = inverstmentTable.get().FirstOrDefault(s => s.阶段 == "第一期");
            var firstinvertmentTable1 = invertmentTable1.getAgentInputs().FirstOrDefault(s => s.Stage == "第一阶段");
            if (firstMarketPrice != null && firstInverstment != null)
            {

                BrandInfo brandInfo = new BrandInfo()
                {
                    品牌方 = Brand.M品牌,
                    出厂价 = firstMarketPrice.CM,
                    指导零售价 = firstMarketPrice.DE,
                    品牌广告 = firstInverstment.J,
                    外观创新 = firstInverstment.M,
                    功能创新 = firstInverstment.N,
                    材料创新 = firstInverstment.O
                };
                firstPPt.AddBrandInfo(brandInfo);


                brandInfo.品牌方 = Brand.S品牌;
                brandInfo.出厂价 = firstMarketPrice.CN;
                brandInfo.指导零售价 = firstinvertmentTable1.retailPrice;
                brandInfo.品牌广告 = firstInverstment.K;
                brandInfo.外观创新 = firstInverstment.P;
                brandInfo.功能创新 = firstInverstment.Q;
                brandInfo.材料创新 = firstInverstment.R;

                firstPPt.AddBrandInfo(brandInfo);
                brandInfo.品牌方 = Brand.J品牌;
                brandInfo.出厂价 = firstMarketPrice.CO;
                brandInfo.指导零售价 = firstMarketPrice.DF;
                brandInfo.品牌广告 = firstInverstment.L;
                brandInfo.外观创新 = firstInverstment.S;
                brandInfo.功能创新 = firstInverstment.T;
                brandInfo.材料创新 = firstInverstment.U;

                firstPPt.AddBrandInfo(brandInfo);
            }


        }
        #endregion

        #region 各品牌商盈利情况BrandProfit
        /// <summary>
        /// 各品牌商盈利情况BrandProfit
        /// </summary>
        public void BrandProfitadd()
        {
            var summary = summaryAssent.GetSummarys().FirstOrDefault(s => s.科目 == "销售利润");

            firstPPt.BrandProfit = new BrandProfit 
            {
                M = summary.B,
                S1 = summary.C,
                S2 = summary.D,
                S3 = summary.E,
                S4 = summary.F,
                J = summary.I,
                SM = GetC("M"),
                SS = GetC("S"),
                SJ = GetC("J")
            };
            
        }
        public int GetC(string brand)
        {
            var shareMark = lastBrand.Get().FirstOrDefault(s => s.品牌方 == brand);
            return shareMark != null ? shareMark.C : 0;
        }
        #endregion

        #region S品牌代理商信息表
         public void sAgentInfosAdd()
        {
            var agentInputs = invertmentTable1.getAgentInputs();
            foreach (var item in agentInputs)
            {
              var sAgentInfo=new SAgentInfo
                {
                    代理方 = item.AgentName,
                    供货价 = item.retailPrice,
                    零售价 = item.SystemPrice,
                     终端形象=item.EndImage,
                      导购员=item.Salesperson,
                       店内促销=item.HousePromote,
                        演示员=item.demonstrator,
                         户外活动=item.outdoorActivity,
                          推广小分队=item.promotionTeam,
                           服务=item.servet,
                  };
                var firstInverstment = inverstmentTable.get().FirstOrDefault(s => s.阶段 == "第一期");
                switch (sAgentInfo.代理方)
                {
                    case "代1":sAgentInfo.S品牌费用补贴支持 = firstInverstment.AR;
                        break;
                    case "代2":
                        sAgentInfo.S品牌费用补贴支持 = firstInverstment.BA;
                        break;
                    case "代3":
                        sAgentInfo.S品牌费用补贴支持 = firstInverstment.BJ;
                        break;
                    case "代4":
                        sAgentInfo.S品牌费用补贴支持 = firstInverstment.BS;
                        break;
                    case "代5":
                        sAgentInfo.S品牌费用补贴支持 = firstInverstment.CB;
                        break;
                    case "代6":
                        sAgentInfo.S品牌费用补贴支持 = firstInverstment.CK;
                        break;
                }
                firstPPt.AddsAgentInfos(sAgentInfo);
            }
          
        }
        #endregion

        #region S品牌代理商经营模拟结果呈现
        public void sAgentResultAdd()
        {
            var agentInputs = invertmentTable1.getAgentInputs();
            var summary20 = summaryAssent.GetSummarys().FirstOrDefault(s => s.科目 == "经营中损失的销售"); 
                 var summary21 = summaryAssent.GetSummarys().FirstOrDefault(s => s.科目 == "经营中损失的金额");
            var summary16 = summaryAssent.GetSummarys().FirstOrDefault(s => s.科目 == "销售利润"); 
            var summary17 = summaryAssent.GetSummarys().FirstOrDefault(s => s.科目 == "应支付银行利息");
            var summary18 = summaryAssent.GetSummarys().FirstOrDefault(s => s.科目 == "库存需按照10%计提跌价损失");
            var summary19 = summaryAssent.GetSummarys().FirstOrDefault(s => s.科目 == "扣除计提跌价损失及银行利息后的利润");
            var summary15 = summaryAssent.GetSummarys().FirstOrDefault(s => s.科目 == "期末现金余额");

            foreach (var item in agentInputs)
            {
                var sAgentResult = new SAgentResult
                {
                    代理方 = item.AgentName,
                   
                };
                var invoicing = invoicingReport.Get().FirstOrDefault(s => s.代理方 == sAgentResult.代理方);
                sAgentResult.期初 = invoicing.D;
                sAgentResult.期末 = invoicing.I;
                sAgentResult.销售量 = invoicing.G;
                sAgentResult.销售金额 = invoicing.H;
                 
                switch (sAgentResult.代理方)
                {
                    case "代1":
                        sAgentResult.数量= summary20.J;
                        sAgentResult.金额 = summary21.J;
                        sAgentResult.销售利润 = summary16.J;
                        sAgentResult.库存跌价损失计提 = summary18.J;
                        sAgentResult.最终经营利润 = summary19.J;
                        sAgentResult.现金流 = summary15.J;
                        break;
                    case "代2":
                        sAgentResult.数量 = summary20.K;
                        sAgentResult.金额 = summary21.K;
                        sAgentResult.销售利润 = summary16.K;
                        sAgentResult.库存跌价损失计提 = summary18.K;
                        sAgentResult.最终经营利润 = summary19.K;
                        sAgentResult.现金流 = summary15.K;
                        break;
                    case "代3":
                        sAgentResult.数量 = summary20.L;
                        sAgentResult.金额 = summary21.L;
                        sAgentResult.销售利润 = summary16.L;
                        sAgentResult.库存跌价损失计提 = summary18.L;
                        sAgentResult.最终经营利润 = summary19.L;
                        sAgentResult.现金流 = summary15.L;
                        break;
                    case "代4":
                        sAgentResult.数量 = summary20.M;
                        sAgentResult.金额 = summary21.M;
                        sAgentResult.销售利润 = summary16.M;
                        sAgentResult.库存跌价损失计提 = summary18.M;
                        sAgentResult.最终经营利润 = summary19.M;
                        sAgentResult.现金流 = summary15.M;
                        break;
                    case "代5":
                        sAgentResult.数量 = summary20.N;
                        sAgentResult.金额 = summary21.N;
                        sAgentResult.销售利润 = summary16.N;
                        sAgentResult.库存跌价损失计提 = summary18.N;
                        sAgentResult.最终经营利润 = summary19.N;
                        sAgentResult.现金流 = summary15.N;
                        break;
                    case "代6":
                        sAgentResult.数量 = summary20.O;
                        sAgentResult.金额 = summary21.O;
                        sAgentResult.销售利润 = summary16.O;
                        sAgentResult.库存跌价损失计提 = summary18.O;
                        sAgentResult.最终经营利润 = summary19.O;
                        sAgentResult.现金流 = summary15.O;
                        break;
                }
                firstPPt.AddsAgentResult(sAgentResult);


            }

        }
        #endregion
    }


}