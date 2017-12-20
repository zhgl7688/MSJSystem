using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    /// <summary>
    ///各品牌购买意愿指数 
    /// </summary>
    public class IntentionIndex
    {
        //厂家主导的品牌力!$B4+厂家主导的产品创新力!$B6+'市场推广（包含促销投入）'!BP3+渠道服务!AB4+市场价格!AB5)/(厂家主导的品牌力!$P4+厂家主导的产品创新力!$DD6+'市场推广（包含促销投入）'!CI3+渠道服务!AU4+市场价格!EY5
        List<BrandStrengthTable> brandStrengths;//厂家主导的品牌力
        List<ProductInnvoationTable> productInnovations;//厂家主导的产品创新力
        List<MarketPromotionTable> marketPromotions;//市场推广（包含促销投入）
        List<ChannelServiceTable> channelServices;//渠道服务!AB4+市场价格!AB5)
        List<MarketTable> marketPrices;//市场价格!EY5

        AgentStages agentStages;

        List<IntentionIndexTable> intentionIndexs = new List<IntentionIndexTable>();
        /// <summary>
        /// 各品牌购买意愿指数
        /// </summary>
        public IntentionIndex(BrandStrength BrandStrength, ProductInnovation ProductInnovation,
            MarketPromotion MarketPromotion, ChannelService ChannelService, MarketPriceTemp MarketPriceTemp)
        {
            brandStrengths = BrandStrength.Get();
            productInnovations = ProductInnovation.Get();
            marketPromotions = MarketPromotion.Get();
            channelServices = ChannelService.Get();
            marketPrices = MarketPriceTemp.Get();
            agentStages = new AgentStages();
            Init();
        }
        public void Init()
        {
           // Parallel.ForEach(marketPromotions, item =>
            //{
                 foreach (var item in marketPromotions)
                 {
                var intentionIndex = intentionIndexs.FirstOrDefault(s => s.Stage == item.Stage);
                if (intentionIndex == null)
                {
                    intentionIndex = new IntentionIndexTable { Stage = item.Stage };
                    intentionIndexs.Add(intentionIndex);
                }
                var brandStrength = brandStrengths.FirstOrDefault(s => s.Stage == item.Stage);
                var productInnovation = productInnovations.FirstOrDefault(s => s.Stage == item.Stage);
                var channelService = channelServices.FirstOrDefault(s => s.Stage == item.Stage);
                var marketPrice = marketPrices.FirstOrDefault(s => s.Stage == item.Stage);

                //=IF((厂家主导的品牌力!$B4+厂家主导的产品创新力!$B6+'市场推广（包含促销投入）'!BP3+渠道服务!AB4+市场价格!AB5)/
                //(厂家主导的品牌力!$P4+厂家主导的产品创新力!$DD6+'市场推广（包含促销投入）'!CI3+渠道服务!AU4+市场价格!EY5)<0,0,(厂家主导的品牌力!$B4+厂家主导的产品创新力!$B6+'市场推广（包含促销投入）'!BP3+渠道服务!AB4+市场价格!AB5)/(厂家主导的品牌力!$P4+厂家主导的产品创新力!$DD6+'市场推广（包含促销投入）'!CI3+渠道服务!AU4+市场价格!EY5))
                //for (int j = 1; j < agentStages.stages.Count + 1; j++)
                //{

                var IIRC = productInnovation.B.IIRC;

                var csAB = channelService.AB;


                var mpAB = marketPrice.AB;
                var mpAT = marketPrice.AT;
                var mpBL = marketPrice.BL;

                var DDStage = productInnovation.DDStage;
                var AUSum = channelService.AUSum;
                var EY = marketPrice.EY;

                for (int i = 0; i < agentStages.agents.Count; i++)
                {

                    var indexState = agentStages.stages.IndexOf(item.Stage);
                    for (int j = 0; j < indexState; j++)
                    {
                        if (intentionIndex.B.Count <= j) intentionIndex.B.Add(j, new MJA());
                        if (intentionIndex.T.Count <= j) intentionIndex.T.Add(j, new MJA());
                        if (intentionIndex.AL.Count <= j) intentionIndex.AL.Add(j, new MJA());
                        var ss = j;
                        var m1 = brandStrength.B + IIRC[j].M + item.BP.M[i] + csAB.M[i] + mpAB[ss].M[i];
                        var m2 = brandStrength.P + DDStage[j] + item.CIAgent[i] + AUSum[i] + EY[ss].M[i];
                        var m = Common.Cal.GetPositive(m1, m2);
                        intentionIndex.B[ss].M.Add(m);
                        var nj1 = brandStrength.D + IIRC[j].J + item.BP.J[i] + csAB.J[i] + mpAT[ss].J[i];
                        var nj2 = brandStrength.P + DDStage[j] + item.CIAgent[i] + AUSum[i] + EY[ss].M[i];
                        var nj = Common.Cal.GetPositive(nj1, nj2);
                        intentionIndex.T[ss].J.Add(nj);
                        var agent1 = brandStrength.C + IIRC[j].J + item.BP.Agent[i] + csAB.Agent[i] + mpBL[ss].Agent[i];
                        var agent2 = brandStrength.P + DDStage[j] + item.CIAgent[i] + AUSum[i] + EY[ss].M[i];
                        var agent = Common.Cal.GetPositive(agent1, agent2);
                        intentionIndex.AL[ss].Agent.Add(agent);
                    }
                }


            };
        }
        public List<IntentionIndexTable> Get()
        {
            return intentionIndexs;
        }

    }
    public class IntentionIndexTable
    {

        /// <summary>
        /// 阶段
        /// </summary>
        public string Stage { get; set; }
        /// <summary>
        /// RC1
        /// </summary>
        public Dictionary<int, MJA> B { get; set; } = new Dictionary<int, MJA>();

        /// <summary>
        /// RC1
        /// </summary>
        public Dictionary<int, MJA> T { get; set; } = new Dictionary<int, MJA>();

        /// <summary>
        /// RC1
        /// </summary>
        public Dictionary<int, MJA> AL { get; set; } = new Dictionary<int, MJA>();
 /// <summary>
        /// 取平均值 
        /// </summary>
        public List<MJA > BDAvg
        {
            get
            {
                var result = new List<MJA>();
                for (int i = 0; i < B.Count; i++)
                {
                    result.Add(SetAvg(B[i], T[i], AL[i]));
                }
                return result;
            }
        }
       
         
        public MJA SetAvg(MJA m, MJA j, MJA a)
        {
            return new MJA
            {
                M = m.M,
                J = j.J,
                Agent = a.Agent
            };
            //return new MJA()
            //{
            //    M1 = m.M1,
            //    M2 = m.M2,
            //    M3 = m.M3,
            //    M4 = m.M4,
            //    M5 = m.M5,
            //    M6 = m.M6,
            //    J1 = j.J1,
            //    J2 = j.J2,
            //    J3 = j.J3,
            //    J4 = j.J4,
            //    J5 = j.J5,
            //    J6 = j.J6,
            //    Agent1 = a.Agent1,
            //    Agent2 = a.Agent2,
            //    Agent3 = a.Agent3,
            //    Agent4 = a.Agent4,
            //    Agent5 = a.Agent5,
            //    Agent6 = a.Agent6,
            //};
        }


    }




}