using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
      List<MarketPromotionTable>marketPromotions;//市场推广（包含促销投入）
      List<ChannelServiceTable> channelServices;//渠道服务!AB4+市场价格!AB5)
     List<MarketTable>  marketPrices;//市场价格!EY5



        List<IntentionIndexTable> intentionIndexs = new List<IntentionIndexTable>();
        public IntentionIndex()
        {
             brandStrengths = new BrandStrength().Get();
             productInnovations = new ProductInnovation().Get();
             marketPromotions = new MarketPromotion().Get();
             channelServices = new ChannelService().Get();
             marketPrices = new MarketPrice().Get();
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
                }
                var brandStrength = brandStrengths.FirstOrDefault(s => s.Stage == item.Stage);
                var productInnovation = productInnovations.FirstOrDefault(s => s.Stage == item.Stage);
                var channelService = channelServices.FirstOrDefault(s => s.Stage == item.Stage);
                var marketPrice = marketPrices.FirstOrDefault(s => s.Stage == item.Stage);

                //=IF((厂家主导的品牌力!$B4+厂家主导的产品创新力!$B6+'市场推广（包含促销投入）'!BP3+渠道服务!AB4+市场价格!AB5)/
                //(厂家主导的品牌力!$P4+厂家主导的产品创新力!$DD6+'市场推广（包含促销投入）'!CI3+渠道服务!AU4+市场价格!EY5)<0,0,(厂家主导的品牌力!$B4+厂家主导的产品创新力!$B6+'市场推广（包含促销投入）'!BP3+渠道服务!AB4+市场价格!AB5)/(厂家主导的品牌力!$P4+厂家主导的产品创新力!$DD6+'市场推广（包含促销投入）'!CI3+渠道服务!AU4+市场价格!EY5))
               
                intentionIndex.B.M1 = (brandStrength.B + productInnovation.B.RC1.M + item.BP.M1 + channelService.AB.M1 + marketPrice.AB[1].M1) 
                    / (brandStrength.P+productInnovation.DD+item.CI+channelService.;
            }
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
        public MJA B { get; set; }
        /// <summary>
        /// RC2
        /// </summary>
        public MJA H { get; set; }
        /// <summary>
        /// RC3
        /// </summary>
        public MJA N { get; set; }
        /// <summary>
        /// RC1
        /// </summary>
        public MJA T { get; set; }
        /// <summary>
        /// RC2
        /// </summary>
        public MJA Z { get; set; }
        /// <summary>
        /// RC3
        /// </summary>
        public MJA AF { get; set; }
        /// <summary>
        /// RC1
        /// </summary>
        public MJA AL { get; set; }
        /// <summary>
        /// RC2
        /// </summary>
        public MJA AR { get; set; }
        /// <summary>
        /// RC3
        /// </summary>
        public MJA AX { get; set; }
        /// <summary>
        /// RC1
        /// </summary>
        public MJA BD
        {
            get
            {
                return SetAvg(B, T, AL);
            }
        }
        /// <summary>
        /// RC2
        /// </summary>
        public MJA BK {
            get
            {
                return SetAvg(H, Z, AR);
            }
        }
        /// <summary>
        /// RC3
        /// </summary>
        public MJA BP {
            get
            {
                return SetAvg(N, AF, AX);
            }
        }
        public MJA SetAvg(MJA m, MJA j, MJA a)
        {
            return new MJA()
            {
                M1 = m.M1,
                M2 = m.M2,
                M3 = m.M3,
                M4 = m.M4,
                M5 = m.M5,
                M6 = m.M6,
                J1 = j.M1,
                J2 = j.M2,
                J3 = j.M3,
                J4 = j.M4,
                J5 = j.M5,
                J6 = j.M6,
                Agent1 = a.Agent1,
                Agent2 = a.Agent2,
                Agent3 = a.Agent3,
                Agent4 = a.Agent4,
                Agent5 = a.Agent5,
                Agent6 = a.Agent6,
            };
        }


    }


   
}