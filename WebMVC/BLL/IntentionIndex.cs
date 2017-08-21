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



        List<IntentionIndexTable> intentionIndexs = new List<IntentionIndexTable>();
        /// <summary>
        /// 各品牌购买意愿指数
        /// </summary>
        public IntentionIndex(BrandStrength BrandStrength, ProductInnovation ProductInnovation,
            MarketPromotion MarketPromotion, ChannelService ChannelService, MarketPriceTemp MarketPriceTemp) 
        {
            brandStrengths =  BrandStrength.Get();
            productInnovations =  ProductInnovation.Get();
            marketPromotions =  MarketPromotion.Get();
            channelServices =  ChannelService.Get();
            marketPrices =  MarketPriceTemp.Get(); 
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
                intentionIndex.B[1].M1 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC1.M + item.BP.M1 + channelService.AB.M1 + marketPrice.AB[1].M1, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M1);
                intentionIndex.B[1].M2 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC1.M + item.BP.M2 + channelService.AB.M2 + marketPrice.AB[1].M2, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M2);
                intentionIndex.B[1].M3 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC1.M + item.BP.M3 + channelService.AB.M3 + marketPrice.AB[1].M3, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M3);
                intentionIndex.B[1].M4 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC1.M + item.BP.M4 + channelService.AB.M4 + marketPrice.AB[1].M4, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M4);
                intentionIndex.B[1].M5 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC1.M + item.BP.M5 + channelService.AB.M5 + marketPrice.AB[1].M5, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M5);
                intentionIndex.B[1].M6 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC1.M + item.BP.M6 + channelService.AB.M6 + marketPrice.AB[1].M6, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M6);
                if (item.Stage == Stage.第二阶段.ToString() || item.Stage == Stage.第三阶段.ToString())
                {
                    intentionIndex.B[2].M1 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC2.M + item.BP.M1 + channelService.AB.M1 + marketPrice.AB[2].M1, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M1);
                    intentionIndex.B[2].M2 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC2.M + item.BP.M2 + channelService.AB.M2 + marketPrice.AB[2].M2, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M2);
                    intentionIndex.B[2].M3 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC2.M + item.BP.M3 + channelService.AB.M3 + marketPrice.AB[2].M3, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M3);
                    intentionIndex.B[2].M4 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC2.M + item.BP.M4 + channelService.AB.M4 + marketPrice.AB[2].M4, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M4);
                    intentionIndex.B[2].M5 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC2.M + item.BP.M5 + channelService.AB.M5 + marketPrice.AB[2].M5, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M5);
                    intentionIndex.B[2].M6 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC2.M + item.BP.M6 + channelService.AB.M6 + marketPrice.AB[2].M6, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M6);
                }
                if ( item.Stage == Stage.第三阶段.ToString())
                {
                    intentionIndex.B[3].M1 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC3.M + item.BP.M1 + channelService.AB.M1 + marketPrice.AB[3].M1, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M1);
                    intentionIndex.B[3].M2 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC3.M + item.BP.M2 + channelService.AB.M2 + marketPrice.AB[3].M2, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M2);
                    intentionIndex.B[3].M3 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC3.M + item.BP.M3 + channelService.AB.M3 + marketPrice.AB[3].M3, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M3);
                    intentionIndex.B[3].M4 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC3.M + item.BP.M4 + channelService.AB.M4 + marketPrice.AB[3].M4, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M4);
                    intentionIndex.B[3].M5 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC3.M + item.BP.M5 + channelService.AB.M5 + marketPrice.AB[3].M5, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M5);
                    intentionIndex.B[3].M6 = Common.Cal.GetPositive(brandStrength.B + productInnovation.B.RC3.M + item.BP.M6 + channelService.AB.M6 + marketPrice.AB[3].M6, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M6);
                }
             
                intentionIndex.T[1].J1 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC1.J + item.BP.J1 + channelService.AB.J1 + marketPrice.AT[1].J1, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M1);
                intentionIndex.T[1].J2 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC1.J + item.BP.J2 + channelService.AB.J2 + marketPrice.AT[1].J2, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M2);
                intentionIndex.T[1].J3 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC1.J + item.BP.J3 + channelService.AB.J3 + marketPrice.AT[1].J3, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M3);
                intentionIndex.T[1].J4 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC1.J + item.BP.J4 + channelService.AB.J4 + marketPrice.AT[1].J4, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M4);
                intentionIndex.T[1].J5 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC1.J + item.BP.J5 + channelService.AB.J5 + marketPrice.AT[1].J5, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M5);
                intentionIndex.T[1].J6 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC1.J + item.BP.J6 + channelService.AB.J6 + marketPrice.AT[1].J6, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M6);
                if (item.Stage == Stage.第二阶段.ToString() || item.Stage == Stage.第三阶段.ToString())
                {
                   
                    intentionIndex.T[2].J1 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC2.J + item.BP.J1 + channelService.AB.J1 + marketPrice.AT[2].J1, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M1);
                    intentionIndex.T[2].J2 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC2.J + item.BP.J2 + channelService.AB.J2 + marketPrice.AT[2].J2, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M2);
                    intentionIndex.T[2].J3 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC2.J + item.BP.J3 + channelService.AB.J3 + marketPrice.AT[2].J3, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M3);
                    intentionIndex.T[2].J4 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC2.J + item.BP.J4 + channelService.AB.J4 + marketPrice.AT[2].J4, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M4);
                    intentionIndex.T[2].J5 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC2.J + item.BP.J5 + channelService.AB.J5 + marketPrice.AT[2].J5, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M5);
                    intentionIndex.T[2].J6 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC2.J + item.BP.J6 + channelService.AB.J6 + marketPrice.AT[2].J6, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M6);
                }
                if (item.Stage == Stage.第三阶段.ToString())
                {
                  
                    intentionIndex.T[3].J1 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC3.J + item.BP.J1 + channelService.AB.J1 + marketPrice.AT[3].J1, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M1);
                    intentionIndex.T[3].J2 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC3.J + item.BP.J2 + channelService.AB.J2 + marketPrice.AT[3].J2, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M2);
                    intentionIndex.T[3].J3 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC3.J + item.BP.J3 + channelService.AB.J3 + marketPrice.AT[3].J3, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M3);
                    intentionIndex.T[3].J4 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC3.J + item.BP.J4 + channelService.AB.J4 + marketPrice.AT[3].J4, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M4);
                    intentionIndex.T[3].J5 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC3.J + item.BP.J5 + channelService.AB.J5 + marketPrice.AT[3].J5, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M5);
                    intentionIndex.T[3].J6 = Common.Cal.GetPositive(brandStrength.D + productInnovation.B.RC3.J + item.BP.J6 + channelService.AB.J6 + marketPrice.AT[3].J6, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M6);
                }
          
                intentionIndex.AL[1].Agent1 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC1.S + item.BP.Agent1 + channelService.AB.Agent1 + marketPrice.BL[1].Agent1, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M1);
                intentionIndex.AL[1].Agent2 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC1.S + item.BP.Agent2 + channelService.AB.Agent2 + marketPrice.BL[1].Agent2, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M2);
                intentionIndex.AL[1].Agent3 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC1.S + item.BP.Agent3 + channelService.AB.Agent3 + marketPrice.BL[1].Agent3, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M3);
                intentionIndex.AL[1].Agent4 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC1.S + item.BP.Agent4 + channelService.AB.Agent4 + marketPrice.BL[1].Agent4, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M4);
                intentionIndex.AL[1].Agent5 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC1.S + item.BP.Agent5 + channelService.AB.Agent5 + marketPrice.BL[1].Agent5, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M5);
                intentionIndex.AL[1].Agent6 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC1.S + item.BP.Agent6 + channelService.AB.Agent6 + marketPrice.BL[1].Agent6, brandStrength.P + productInnovation.DD + item.CI + channelService.AU + marketPrice.EY[1].M6);
                if (item.Stage == Stage.第二阶段.ToString() || item.Stage == Stage.第三阶段.ToString())
                {
                   
                    intentionIndex.AL[2].Agent1 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC2.S + item.BP.Agent1 + channelService.AB.Agent1 + marketPrice.BL[2].Agent1, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M1);
                    intentionIndex.AL[2].Agent2 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC2.S + item.BP.Agent2 + channelService.AB.Agent2 + marketPrice.BL[2].Agent2, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M2);
                    intentionIndex.AL[2].Agent3 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC2.S + item.BP.Agent3 + channelService.AB.Agent3 + marketPrice.BL[2].Agent3, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M3);
                    intentionIndex.AL[2].Agent4 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC2.S + item.BP.Agent4 + channelService.AB.Agent4 + marketPrice.BL[2].Agent4, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M4);
                    intentionIndex.AL[2].Agent5 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC2.S + item.BP.Agent5 + channelService.AB.Agent5 + marketPrice.BL[2].Agent5, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M5);
                    intentionIndex.AL[2].Agent6 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC2.S + item.BP.Agent6 + channelService.AB.Agent6 + marketPrice.BL[2].Agent6, brandStrength.P + productInnovation.DE + item.CI + channelService.AU + marketPrice.EY[2].M6);
                }
                if (item.Stage == Stage.第三阶段.ToString())
                {
                  
                    intentionIndex.AL[3].Agent1 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC3.S+ item.BP.Agent1 + channelService.AB.Agent1 + marketPrice.BL[3].Agent1, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M1);
                    intentionIndex.AL[3].Agent2 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC3.S+ item.BP.Agent2 + channelService.AB.Agent2 + marketPrice.BL[3].Agent2, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M2);
                    intentionIndex.AL[3].Agent3 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC3.S+ item.BP.Agent3 + channelService.AB.Agent3 + marketPrice.BL[3].Agent3, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M3);
                    intentionIndex.AL[3].Agent4 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC3.S+ item.BP.Agent4 + channelService.AB.Agent4 + marketPrice.BL[3].Agent4, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M4);
                    intentionIndex.AL[3].Agent5 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC3.S+ item.BP.Agent5 + channelService.AB.Agent5 + marketPrice.BL[3].Agent5, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M5);
                    intentionIndex.AL[3].Agent6 = Common.Cal.GetPositive(brandStrength.C + productInnovation.B.RC3.S+ item.BP.Agent6 + channelService.AB.Agent6 + marketPrice.BL[3].Agent6, brandStrength.P + productInnovation.DF + item.CI + channelService.AU + marketPrice.EY[3].M6);
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
                return Stage==Common.Stage.第二阶段.ToString()? SetAvg(B[2], T[2], AL[2]):new MJA();
            }
        }
        /// <summary>
        /// 取平均值
        /// </summary>
        public MJA BP
        {
            get
            {
                return Stage == Common.Stage.第三阶段.ToString() ? SetAvg(B[3], T[3], AL[3]):new MJA();
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
                J1 = j.J1,
                J2 = j.J2,
                J3 = j.J3,
                J4 = j.J4,
                J5 = j.J5,
                J6 = j.J6,
                Agent1 = a.Agent1,
                Agent2 = a.Agent2,
                Agent3 = a.Agent3,
                Agent4 = a.Agent4,
                Agent5 = a.Agent5,
                Agent6 = a.Agent6,
            };
        }


    }

    public class MarketPriceTemp
    {
        List<PriceControlTable> priceControlTables;

        public MarketPriceTemp(PriceControl PriceControl)
        {
            priceControlTables =   PriceControl.Get();

            Init();
        }
        List<MarketTable> markets = new List<MarketTable>();
        public void Init()
        {
            #region 第一阶段
            var market1 = new MarketTable() { Stage = Stage.第一阶段.ToString(), };
            var priceControl1 = priceControlTables.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            if (priceControl1 == null) return;
            market1.DE[1]= new RC { M = priceControl1.B.RC1M, J = priceControl1.B.RC1J };
            market1.DK[1]= new MJA { Agent1 = priceControl1.D[1].Agent1, Agent2 = priceControl1.D[1].Agent2, Agent3 = priceControl1.D[1].Agent3, Agent4 = priceControl1.D[1].Agent4, Agent5 = priceControl1.D[1].Agent5, Agent6 = priceControl1.D[1].Agent6 };
            market1.EF[1]= new MJA
            {
                Agent1 = GetEF(priceControl1.K[1].Agent1, priceControl1.D[1].Agent1),
                Agent2 = GetEF(priceControl1.K[1].Agent2, priceControl1.D[1].Agent2),
                Agent3 = GetEF(priceControl1.K[1].Agent3, priceControl1.D[1].Agent3),
                Agent4 = GetEF(priceControl1.K[1].Agent4, priceControl1.D[1].Agent4),
                Agent5 = GetEF(priceControl1.K[1].Agent5, priceControl1.D[1].Agent5),
                Agent6 = GetEF(priceControl1.K[1].Agent6, priceControl1.D[1].Agent6)
            };
            markets.Add(market1);
            #endregion

            #region 第二阶段
            var market2 = new MarketTable() { Stage = Stage.第二阶段.ToString(), };
            var priceControl2 = priceControlTables.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            if (priceControl2 == null) return;


            market2.DE[1]=new RC { M = priceControl2.B.RC1M, J = priceControl2.B.RC1J };
            market2.DE[2]=new RC { M = priceControl2.B.RC2M, J = priceControl2.B.RC2J };
            market2.DK[1]=new MJA { Agent1 = priceControl2.D[1].Agent1, Agent2 = priceControl2.D[1].Agent2, Agent3 = priceControl2.D[1].Agent3, Agent4 = priceControl2.D[1].Agent4, Agent5 = priceControl2.D[1].Agent5, Agent6 = priceControl2.D[1].Agent6 };
            market2.DK[2]=new MJA { Agent1 = priceControl2.D[2].Agent1, Agent2 = priceControl2.D[2].Agent2, Agent3 = priceControl2.D[2].Agent3, Agent4 = priceControl2.D[2].Agent4, Agent5 = priceControl2.D[2].Agent5, Agent6 = priceControl2.D[2].Agent6 };
            market2.EF[1]=new MJA
            {
                Agent1 = GetEF(priceControl2.K[1].Agent1, priceControl2.D[1].Agent1),
                Agent2 = GetEF(priceControl2.K[1].Agent2, priceControl2.D[1].Agent2),
                Agent3 = GetEF(priceControl2.K[1].Agent3, priceControl2.D[1].Agent3),
                Agent4 = GetEF(priceControl2.K[1].Agent4, priceControl2.D[1].Agent4),
                Agent5 = GetEF(priceControl2.K[1].Agent5, priceControl2.D[1].Agent5),
                Agent6 = GetEF(priceControl2.K[1].Agent6, priceControl2.D[1].Agent6)
            };
            market2.EF[2]= new MJA
            {
                Agent1 = GetEF(priceControl2.K[2].Agent1, priceControl2.D[2].Agent1),
                Agent2 = GetEF(priceControl2.K[2].Agent2, priceControl2.D[2].Agent2),
                Agent3 = GetEF(priceControl2.K[2].Agent3, priceControl2.D[2].Agent3),
                Agent4 = GetEF(priceControl2.K[2].Agent4, priceControl2.D[2].Agent4),
                Agent5 = GetEF(priceControl2.K[2].Agent5, priceControl2.D[2].Agent5),
                Agent6 = GetEF(priceControl2.K[2].Agent6, priceControl2.D[2].Agent6)
            };
            markets.Add(market2);
            #endregion

            #region 第三阶段
            var market3 = new MarketTable() { Stage = Stage.第三阶段.ToString(), };
            var priceControl3 = priceControlTables.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            if (priceControl3 == null) return;


            market3.DE[1]= new RC { M = priceControl3.B.RC1M, J = priceControl3.B.RC1J };
            market3.DE[2]= new RC { M = priceControl3.B.RC2M, J = priceControl3.B.RC2J };
            market3.DE[3]= new RC { M = priceControl3.B.RC3M, J = priceControl3.B.RC3J };
            market3.DK[1]= new MJA { Agent1 = priceControl3.D[1].Agent1, Agent2 = priceControl3.D[1].Agent2, Agent3 = priceControl3.D[1].Agent3, Agent4 = priceControl3.D[1].Agent4, Agent5 = priceControl3.D[1].Agent5, Agent6 = priceControl3.D[1].Agent6 };
            market3.DK[2]= new MJA { Agent1 = priceControl3.D[2].Agent1, Agent2 = priceControl3.D[2].Agent2, Agent3 = priceControl3.D[2].Agent3, Agent4 = priceControl3.D[2].Agent4, Agent5 = priceControl3.D[2].Agent5, Agent6 = priceControl3.D[2].Agent6 };
            market3.DK[3]= new MJA { Agent1 = priceControl3.D[3].Agent1, Agent2 = priceControl3.D[3].Agent2, Agent3 = priceControl3.D[3].Agent3, Agent4 = priceControl3.D[3].Agent4, Agent5 = priceControl3.D[3].Agent5, Agent6 = priceControl3.D[3].Agent6 };
            market3.EF[1]= new MJA
            {
                Agent1 = GetEF(priceControl3.K[1].Agent1, priceControl3.D[1].Agent1),
                Agent2 = GetEF(priceControl3.K[1].Agent2, priceControl3.D[1].Agent2),
                Agent3 = GetEF(priceControl3.K[1].Agent3, priceControl3.D[1].Agent3),
                Agent4 = GetEF(priceControl3.K[1].Agent4, priceControl3.D[1].Agent4),
                Agent5 = GetEF(priceControl3.K[1].Agent5, priceControl3.D[1].Agent5),
                Agent6 = GetEF(priceControl3.K[1].Agent6, priceControl3.D[1].Agent6)
            };
            market3.EF[2]= new MJA
            {
                Agent1 = GetEF(priceControl3.K[2].Agent1, priceControl3.D[2].Agent1),
                Agent2 = GetEF(priceControl3.K[2].Agent2, priceControl3.D[2].Agent2),
                Agent3 = GetEF(priceControl3.K[2].Agent3, priceControl3.D[2].Agent3),
                Agent4 = GetEF(priceControl3.K[2].Agent4, priceControl3.D[2].Agent4),
                Agent5 = GetEF(priceControl3.K[2].Agent5, priceControl3.D[2].Agent5),
                Agent6 = GetEF(priceControl3.K[2].Agent6, priceControl3.D[2].Agent6)
            };
            market3.EF[3]= new MJA
            {
                Agent1 = GetEF(priceControl3.K[3].Agent1, priceControl3.D[3].Agent1),
                Agent2 = GetEF(priceControl3.K[3].Agent2, priceControl3.D[3].Agent2),
                Agent3 = GetEF(priceControl3.K[3].Agent3, priceControl3.D[3].Agent3),
                Agent4 = GetEF(priceControl3.K[3].Agent4, priceControl3.D[3].Agent4),
                Agent5 = GetEF(priceControl3.K[3].Agent5, priceControl3.D[3].Agent5),
                Agent6 = GetEF(priceControl3.K[3].Agent6, priceControl3.D[3].Agent6)
            } ;
            markets.Add(market3);
            #endregion

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