using System;
using System.Collections.Generic;
using System.Linq;
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
                for (int i = 0; i < agentStages.agents.Count; i++)
                {
                    var indexState = agentStages.stages.IndexOf(item.Stage);
                    for (int j = 0; j <indexState; j++)
                    {
                        var ss = j + 1;
                        var m = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.IIRC[j].M + item.BP.M[i] + channelService.AB.M[i] + marketPrice.AB[ss].M[i], brandStrength.P + productInnovation.DDStage[i] + item.CIAgent[i] + channelService.AUSum[i] + marketPrice.EY[ss].M[i]);
                        intentionIndex.B[ss].M.Add(m);
                        var n = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.IIRC[j].J + item.BP.J[i] + channelService.AB.J[i] + marketPrice.AT[ss].J[i], brandStrength.P + productInnovation.DDStage[i] + item.CIAgent[i] + channelService.AUSum[i] + marketPrice.EY[ss].M[i]);
                        intentionIndex.T[ss].J.Add(n);
                        var agent = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.IIRC[j].J + item.BP.Agent[i] + channelService.AB.Agent[i] + marketPrice.BL[ss].Agent[i], brandStrength.P + productInnovation.DDStage[i] + item.CIAgent[i] + channelService.AUSum[i] + marketPrice.EY[ss].M[i]);
                        intentionIndex.T[ss].Agent.Add(agent);
                    }
                }


            }
        }
        public List<IntentionIndexTable> Get()
        {
            return intentionIndexs;
        }

    }
    public class IntentionIndexTable
    {
        public IntentionIndexTable()
        {
            B = new Dictionary<int, MJA>();
            B.Add(1, new MJA());
            B.Add(2, new MJA());
            B.Add(3, new MJA());
            T = new Dictionary<int, MJA>();
            T.Add(1, new MJA());
            T.Add(2, new MJA());
            T.Add(3, new MJA());
            AL = new Dictionary<int, MJA>();
            AL.Add(1, new MJA());
            AL.Add(2, new MJA());
            AL.Add(3, new MJA());
        }
        /// <summary>
        /// 阶段
        /// </summary>
        public string Stage { get; set; }
        /// <summary>
        /// RC1
        /// </summary>
        public Dictionary<int, MJA> B { get; set; }

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
        public MJA BD
        {
            get
            {

                return SetAvg(B[1], T[1], AL[1]);
            }
        }
        /// <summary>
        ///  取平均值
        /// </summary>
        public MJA BJ
        {
            get
            {
                return Stage == Common.Stage.第二阶段.ToString() ? SetAvg(B[2], T[2], AL[2]) : new MJA();
            }
        }
        /// <summary>
        /// 取平均值
        /// </summary>
        public MJA BP
        {
            get
            {
                return Stage == Common.Stage.第三阶段.ToString() ? SetAvg(B[3], T[3], AL[3]) : new MJA();
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

    public class MarketPriceTemp
    {
        List<PriceControlTable> priceControlTables;
        AgentStages agentStages;
        public MarketPriceTemp(PriceControl PriceControl)
        {
            priceControlTables = PriceControl.Get();
            agentStages = new AgentStages();
            Init();
        }
        List<MarketTable> markets = new List<MarketTable>();
        public void Init()
        {
            foreach (var item in priceControlTables)
            {
                var market = new MarketTable() { Stage = item.Stage, };
                var indexStage = agentStages.stages.IndexOf(item.Stage);
                for (int i = 0; i < indexStage; i++)
                {
                    market.DE[i] = new RC { M = item.B.RcM[i], J = item.B.RcJ[i] };
                    market.DK[i] = new MJA { Agent = item.D[i].Agent };
                    market.EF[i] = new MJA();
                    for (int j = 0; j < item.K[1].Agent.Count; j++)
                    {
                        market.EF[i].Agent.Add(GetEF(item.K[i].Agent[j], item.D[i].Agent[j]));
                    }
                }


                markets.Add(market);
            }


        }
        private decimal GetEF(decimal a, decimal b)
        {
            return a < (b * 0.89m) ? a : b * 0.89m;
        }
        public List<MarketTable> Get()
        {
            return markets;
        }
    }


}