using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    /// <summary>
    ///市场推广（包含促销投入） 
    /// </summary>
    public class MarketPromotion
    {
        List<MarketPromotionTable> marketPromotions = new List<MarketPromotionTable>();
        List<BrandTable> brands;
        List<AgentTable> agents;
        public MarketPromotion(InvertmentTable1 InvertmentTable1)
        {
            brands =   InvertmentTable1.getBrandTable();
            agents =   InvertmentTable1.getAgents();
            init();
        }
        public void init()
        {
            foreach (var brand in brands)
            {
                var promotion = marketPromotions.FirstOrDefault(s => s.Stage == brand.Stage);
                if (promotion == null)
                {
                    promotion = new MarketPromotionTable { Stage = brand.Stage };
                    marketPromotions.Add(promotion);

                }
                if (brand.Brand == Brand.M品牌.ToString())
                {
                    promotion.B.M = brand.EndImage;
                    promotion.J.M = brand.Salesperson;
                    promotion.R.M = brand.HousePromote;
                    promotion.Z.M = brand.demonstrator;
                    promotion.AH.M = brand.outdoorActivity;
                    promotion.AP.M = brand.promotionTeam;

                }
                else if (brand.Brand == Brand.J品牌.ToString())
                {
                    promotion.B.J = brand.EndImage;
                    promotion.J.J = brand.Salesperson;
                    promotion.R.J = brand.HousePromote;
                    promotion.Z.J = brand.demonstrator;
                    promotion.AH.J = brand.outdoorActivity;
                    promotion.AP.J = brand.promotionTeam;

                }
            }
            foreach (var itemAgent in agents)
            {
                var promotion = marketPromotions.FirstOrDefault(s => s.Stage == itemAgent.Stage);
                if (promotion == null)
                {
                    promotion = new MarketPromotionTable { Stage = itemAgent.Stage };
                    marketPromotions.Add(promotion);

                }

                #region 终端形象投入							
                promotion.B.Agent1 = itemAgent.B.EndImage;
                promotion.B.Agent2 = itemAgent.J.EndImage;
                promotion.B.Agent3 = itemAgent.R.EndImage;
                promotion.B.Agent4 = itemAgent.Z.EndImage;
                promotion.B.Agent5 = itemAgent.AH.EndImage;
                promotion.B.Agent6 = itemAgent.AP.EndImage;
                #endregion

                #region 导购派驻投入							


                promotion.J.Agent1 = itemAgent.B.Salesperson;
                promotion.J.Agent2 = itemAgent.J.Salesperson;
                promotion.J.Agent3 = itemAgent.R.Salesperson;
                promotion.J.Agent4 = itemAgent.Z.Salesperson;
                promotion.J.Agent5 = itemAgent.AH.Salesperson;
                promotion.J.Agent6 = itemAgent.AP.Salesperson;
                #endregion

                #region 店内促销投入							


                promotion.R.Agent1 = itemAgent.B.HousePromote;
                promotion.R.Agent2 = itemAgent.J.HousePromote;
                promotion.R.Agent3 = itemAgent.R.HousePromote;
                promotion.R.Agent4 = itemAgent.Z.HousePromote;
                promotion.R.Agent5 = itemAgent.AH.HousePromote;
                promotion.R.Agent6 = itemAgent.AP.HousePromote;
                #endregion

                #region 演示开展投入							
                promotion.Z.Agent1 = itemAgent.B.demonstrator;
                promotion.Z.Agent2 = itemAgent.J.demonstrator;
                promotion.Z.Agent3 = itemAgent.R.demonstrator;
                promotion.Z.Agent4 = itemAgent.Z.demonstrator;
                promotion.Z.Agent5 = itemAgent.AH.demonstrator;
                promotion.Z.Agent6 = itemAgent.AP.demonstrator;
                #endregion

                #region 户外活动投入							
                promotion.AH.Agent1 = itemAgent.B.outdoorActivity;
                promotion.AH.Agent2 = itemAgent.J.outdoorActivity;
                promotion.AH.Agent3 = itemAgent.R.outdoorActivity;
                promotion.AH.Agent4 = itemAgent.Z.outdoorActivity;
                promotion.AH.Agent5 = itemAgent.AH.outdoorActivity;
                promotion.AH.Agent6 = itemAgent.AP.outdoorActivity;
                #endregion

                #region 推广小分队投入							

                promotion.AP.Agent1 = itemAgent.B.promotionTeam;
                promotion.AP.Agent2 = itemAgent.J.promotionTeam;
                promotion.AP.Agent3 = itemAgent.R.promotionTeam;
                promotion.AP.Agent4 = itemAgent.Z.promotionTeam;
                promotion.AP.Agent5 = itemAgent.AH.promotionTeam;
                promotion.AP.Agent6 = itemAgent.AP.promotionTeam;
                #endregion


            }

            var s1 = marketPromotions.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());

            marketPromotions.ForEach(s =>
              {
                  if (s.Stage != Stage.第一阶段.ToString())
                  {
                      s.FirstBP = s1.BP;
                  }
              });
            var s3 = marketPromotions.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            if (s3 != null)
                s3.SecondBP = marketPromotions.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString()).BP;

        }

        public List<MarketPromotionTable> Get()
        {
            return marketPromotions;
        }
    }
    public class MarketPromotionTable
    {
        public int ID { get; set; }
        public string Stage { get; set; }
        public MP B { get; set; } = new MP();
        public MP J { get; set; } = new MP();
        public MP R { get; set; } = new MP();
        public MP Z { get; set; } = new MP();
        public MP AH { get; set; } = new MP();
        public MP AP { get; set; } = new MP();
        /// <summary>
        /// 市场推广指数
        /// </summary>
        public MJA AX
        {
            get
            {
                decimal t = 1;
                decimal t2 = Stage == Common.Stage.第三阶段.ToString()? 0.6m:0;
                if (Stage == Common.Stage.第二阶段.ToString()) t = 0.6m;
                else if (Stage == Common.Stage.第三阶段.ToString()) t = 0.25m;

                var result = new MJA();

                result.M1 = FirstBP.M1 * t+SecondBP.M1*t2 + MarketingIndex(B.M, B.J, B.Agent1, J.M, J.J, J.Agent1, R.M, R.J, R.Agent1, Z.M, Z.J, Z.Agent1, AH.M, AH.J, AH.Agent1, AP.M, AP.J, AP.Agent1);
                result.M2 = FirstBP.M2 * t+SecondBP.M2*t2 + MarketingIndex(B.M, B.J, B.Agent2, J.M, J.J, J.Agent2, R.M, R.J, R.Agent2, Z.M, Z.J, Z.Agent2, AH.M, AH.J, AH.Agent2, AP.M, AP.J, AP.Agent2);
                result.M3 = FirstBP.M3 * t+SecondBP.M3*t2 + MarketingIndex(B.M, B.J, B.Agent3, J.M, J.J, J.Agent3, R.M, R.J, R.Agent3, Z.M, Z.J, Z.Agent3, AH.M, AH.J, AH.Agent3, AP.M, AP.J, AP.Agent3);
                result.M4 = FirstBP.M4 * t+SecondBP.M4*t2 + MarketingIndex(B.M, B.J, B.Agent4, J.M, J.J, J.Agent4, R.M, R.J, R.Agent4, Z.M, Z.J, Z.Agent4, AH.M, AH.J, AH.Agent4, AP.M, AP.J, AP.Agent4);
                result.M5 = FirstBP.M5 * t+SecondBP.M5*t2 + MarketingIndex(B.M, B.J, B.Agent5, J.M, J.J, J.Agent5, R.M, R.J, R.Agent5, Z.M, Z.J, Z.Agent5, AH.M, AH.J, AH.Agent5, AP.M, AP.J, AP.Agent5);
                result.M6 = FirstBP.M6 * t+SecondBP.M6*t2 + MarketingIndex(B.M, B.J, B.Agent6, J.M, J.J, J.Agent6, R.M, R.J, R.Agent6, Z.M, Z.J, Z.Agent6, AH.M, AH.J, AH.Agent6, AP.M, AP.J, AP.Agent6);
                result.J1 = FirstBP.J1 * t+SecondBP.J1*t2 + MarketingIndex(B.J, B.M, B.Agent1, J.J, J.M, J.Agent1, R.J, R.M, R.Agent1, Z.J, Z.M, Z.Agent1, AH.J, AH.M, AH.Agent1, AP.J, AP.M, AP.Agent1);
                result.J2 = FirstBP.J2 * t+SecondBP.J2*t2 + MarketingIndex(B.J, B.M, B.Agent2, J.J, J.M, J.Agent2, R.J, R.M, R.Agent2, Z.J, Z.M, Z.Agent2, AH.J, AH.M, AH.Agent2, AP.J, AP.M, AP.Agent2);
                result.J3 = FirstBP.J3 * t+SecondBP.J3*t2 + MarketingIndex(B.J, B.M, B.Agent3, J.J, J.M, J.Agent3, R.J, R.M, R.Agent3, Z.J, Z.M, Z.Agent3, AH.J, AH.M, AH.Agent3, AP.J, AP.M, AP.Agent3);
                result.J4 = FirstBP.J4 * t+SecondBP.J4*t2 + MarketingIndex(B.J, B.M, B.Agent4, J.J, J.M, J.Agent4, R.J, R.M, R.Agent4, Z.J, Z.M, Z.Agent4, AH.J, AH.M, AH.Agent4, AP.J, AP.M, AP.Agent4);
                result.J5 = FirstBP.J5 * t+SecondBP.J5*t2 + MarketingIndex(B.J, B.M, B.Agent5, J.J, J.M, J.Agent5, R.J, R.M, R.Agent5, Z.J, Z.M, Z.Agent5, AH.J, AH.M, AH.Agent5, AP.J, AP.M, AP.Agent5);
                result.J6 = FirstBP.J6 * t + SecondBP.J6 * t2 + MarketingIndex(B.J, B.M, B.Agent6, J.J, J.M, J.Agent6, R.J, R.M, R.Agent6, Z.J, Z.M, Z.Agent6, AH.J, AH.M, AH.Agent6, AP.J, AP.M, AP.Agent6);
                result.Agent1 = FirstBP.Agent1 * t +SecondBP.Agent1*t2 + MarketingIndex(B.Agent1, B.J, B.M, J.Agent1, J.J, J.M, R.Agent1, R.J, R.M, Z.Agent1, Z.J, Z.M, AH.Agent1, AH.J, AH.M, AP.Agent1, AP.J, AP.M);
                result.Agent2 = FirstBP.Agent2 * t +SecondBP.Agent2*t2 + MarketingIndex(B.Agent2, B.J, B.M, J.Agent2, J.J, J.M, R.Agent2, R.J, R.M, Z.Agent2, Z.J, Z.M, AH.Agent2, AH.J, AH.M, AP.Agent2, AP.J, AP.M);
                result.Agent3 = FirstBP.Agent3 * t +SecondBP.Agent3*t2 + MarketingIndex(B.Agent3, B.J, B.M, J.Agent3, J.J, J.M, R.Agent3, R.J, R.M, Z.Agent3, Z.J, Z.M, AH.Agent3, AH.J, AH.M, AP.Agent3, AP.J, AP.M);
                result.Agent4 = FirstBP.Agent4 * t +SecondBP.Agent4*t2 + MarketingIndex(B.Agent4, B.J, B.M, J.Agent4, J.J, J.M, R.Agent4, R.J, R.M, Z.Agent4, Z.J, Z.M, AH.Agent4, AH.J, AH.M, AP.Agent4, AP.J, AP.M);
                result.Agent5 = FirstBP.Agent5 * t +SecondBP.Agent5*t2 + MarketingIndex(B.Agent5, B.J, B.M, J.Agent5, J.J, J.M, R.Agent5, R.J, R.M, Z.Agent5, Z.J, Z.M, AH.Agent5, AH.J, AH.M, AP.Agent5, AP.J, AP.M);
                result.Agent6 = FirstBP.Agent6 * t + SecondBP.Agent6*t2 + MarketingIndex(B.Agent6, B.J, B.M, J.Agent6, J.J, J.M, R.Agent6, R.J, R.M, Z.Agent6, Z.J, Z.M, AH.Agent6, AH.J, AH.M, AP.Agent6, AP.J, AP.M);

                return result;
            }
        }
        public MJA FirstBP { get; set; } = new MJA();
        public MJA SecondBP { get; set; } = new MJA();
        /// <summary>
        /// 市场推广影响力
        /// </summary>
        public MJA BP
        {
            get
            {
                var result = new MJA();
                result.M1 = AX.M1 + AX.J1 + AX.Agent1 == 0 ? 0 : AX.M1 / (AX.M1 + AX.J1 + AX.Agent1);
                result.M2 = AX.M2 + AX.J2 + AX.Agent2 == 0 ? 0 : AX.M2 / (AX.M2 + AX.J2 + AX.Agent2);
                result.M3 = AX.M3 + AX.J3 + AX.Agent3 == 0 ? 0 : AX.M3 / (AX.M3 + AX.J3 + AX.Agent3);
                result.M4 = AX.M4 + AX.J4 + AX.Agent4 == 0 ? 0 : AX.M4 / (AX.M4 + AX.J4 + AX.Agent4);
                result.M5 = AX.M5 + AX.J5 + AX.Agent5 == 0 ? 0 : AX.M5 / (AX.M5 + AX.J5 + AX.Agent5);
                result.M6 = AX.M6 + AX.J6 + AX.Agent6 == 0 ? 0 : AX.M6 / (AX.M6 + AX.J6 + AX.Agent6);
                result.J1 = AX.M1 + AX.J1 + AX.Agent1 == 0 ? 0 : AX.J1 / (AX.M1 + AX.J1 + AX.Agent1);
                result.J2 = AX.M2 + AX.J2 + AX.Agent2 == 0 ? 0 : AX.J2 / (AX.M2 + AX.J2 + AX.Agent2);
                result.J3 = AX.M3 + AX.J3 + AX.Agent3 == 0 ? 0 : AX.J3 / (AX.M3 + AX.J3 + AX.Agent3);
                result.J4 = AX.M4 + AX.J4 + AX.Agent4 == 0 ? 0 : AX.J4 / (AX.M4 + AX.J4 + AX.Agent4);
                result.J5 = AX.M5 + AX.J5 + AX.Agent5 == 0 ? 0 : AX.J5 / (AX.M5 + AX.J5 + AX.Agent5);
                result.J6 = AX.M6 + AX.J6 + AX.Agent6 == 0 ? 0 : AX.J6 / (AX.M6 + AX.J6 + AX.Agent6);
                result.Agent1 = AX.M1 + AX.J1 + AX.Agent1 == 0 ? 0 : AX.Agent1 / (AX.M1 + AX.J1 + AX.Agent1);
                result.Agent2 = AX.M2 + AX.J2 + AX.Agent2 == 0 ? 0 : AX.Agent2 / (AX.M2 + AX.J2 + AX.Agent2);
                result.Agent3 = AX.M3 + AX.J3 + AX.Agent3 == 0 ? 0 : AX.Agent3 / (AX.M3 + AX.J3 + AX.Agent3);
                result.Agent4 = AX.M4 + AX.J4 + AX.Agent4 == 0 ? 0 : AX.Agent4 / (AX.M4 + AX.J4 + AX.Agent4);
                result.Agent5 = AX.M5 + AX.J5 + AX.Agent5 == 0 ? 0 : AX.Agent5 / (AX.M5 + AX.J5 + AX.Agent5);
                result.Agent6 = AX.M6 + AX.J6 + AX.Agent6 == 0 ? 0 : AX.Agent6 / (AX.M6 + AX.J6 + AX.Agent6);
                return result;

            }
        }

        public decimal CI
        {
            get
            {
                return BP.M1 + BP.J1 + BP.Agent1;
            }
        }
        public decimal CJ
        {
            get
            {
                return BP.M2 + BP.J2 + BP.Agent2;
            }
        }
        public decimal CK
        {
            get
            {
                return BP.M3 + BP.J3 + BP.Agent3;
            }
        }
        public decimal CL
        {
            get
            {
                return BP.M4 + BP.J4 + BP.Agent4;
            }
        }
        public decimal CM
        {
            get
            {
                return BP.M5 + BP.J5 + BP.Agent5;
            }
        }
        public decimal CN
        {
            get
            {
                return BP.M6 + BP.J6 + BP.Agent6;
            }
        }
        public decimal MarketingIndex(decimal b, decimal c, decimal d, decimal j, decimal k, decimal l, decimal r, decimal s,
           decimal t, decimal z, decimal aa, decimal ab, decimal ah, decimal ai, decimal aj, decimal ap, decimal aq, decimal ar)
        {
            var t1 = b + c + d;
            var t2 = j + k + l;
            var t3 = r + s + t;
            var t4 = z + aa + ab;
            var t5 = ah + ai + aj;
            var t6 = ap + aq + ar;
            if (t1 == 0 || t2 == 0 || t3 == 0 || t4 == 0 || t5 == 0 || t6 == 0) return 0;
            //=25%*B3/(B3+C3+D3)+25%*J3/(J3+K3+L3)+20%*R3/(R3+S3+T3)+15%*Z3/(Z3+AA3+AB3)+10%*AH3/(AH3+AI3+AJ3)+5%*AP3/(AP3+AQ3+AR3)
            return 0.25m * b / t1 + 0.25m * j / t2 + 0.20m * r / t3 + 0.15m * z / t4 + 0.10m * ah / t5 + 0.05m * ap / t6;
        }
    }


}