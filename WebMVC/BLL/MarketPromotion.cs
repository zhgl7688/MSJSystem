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
        AgentStages agentStages;
        public MarketPromotion(InvertmentTable1 InvertmentTable1)
        {
            agentStages = new AgentStages();
            brands = InvertmentTable1.getBrandTable();
            agents = InvertmentTable1.getAgents();
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
                for (int i = 0; i < agentStages.agents.Count; i++)
                {
                    promotion.B.Agent.Add(itemAgent.Bagent[i].EndImage);//终端形象投入	
                    promotion.J.Agent.Add(itemAgent.Bagent[i].Salesperson);//导购派驻投入
                    promotion.R.Agent.Add(itemAgent.Bagent[i].HousePromote);//店内促销投入	
                    promotion.Z.Agent.Add(itemAgent.Bagent[i].demonstrator);//演示开展投入
                    promotion.AH.Agent.Add(itemAgent.Bagent[i].outdoorActivity);//户外活动投入
                    promotion.AP.Agent.Add(itemAgent.Bagent[i].promotionTeam);//推广小分队投入
                }
            }
  
            marketPromotions.ForEach(s =>
              {
                  var indexStage = agentStages.stages.IndexOf(s.Stage);
                  if (indexStage > 1)
                      s.SecondBP = marketPromotions.FirstOrDefault(ks => ks.Stage == agentStages.stages[indexStage - 1]).BP;
                  if (indexStage>2)
                      s.FirstBP = marketPromotions.FirstOrDefault(ks => ks.Stage == agentStages.stages[indexStage - 2]).BP;
                   
              });
           

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
                //decimal t = 1;
                //decimal t2 = Stage == Common.Stage.第三阶段.ToString() ? 0.6m : 0;
                //if (Stage == Common.Stage.第二阶段.ToString()) t = 0.6m;
                //else if (Stage == Common.Stage.第三阶段.ToString()) t = 0.25m;
                decimal t = 0.25m; 
                decimal t2 = 0.6m;
                var result = new MJA();
                var count = new AgentStages().agents.Count;
                for (int i = 0; i < count; i++)
                {
                    if (FirstBP.M.Count < i + 1)
                    {
                        FirstBP.M.Add(0);
                        FirstBP.J.Add(0);
                        FirstBP.Agent.Add(0);
                    }
                    if (SecondBP.M.Count < i + 1)
                    {
                        SecondBP.M.Add(0);
                        SecondBP.J.Add(0);
                        SecondBP.Agent.Add(0);
                    }
                    result.M.Add(FirstBP.M[i] * t + SecondBP.M[i] * t2 + MarketingIndex(B.M, B.J, B.Agent[i], J.M, J.J, J.Agent[i], R.M, R.J, R.Agent[i], Z.M, Z.J, Z.Agent[i], AH.M, AH.J, AH.Agent[i], AP.M, AP.J, AP.Agent[i]));
                    result.J.Add(FirstBP.J[i] * t + SecondBP.J[i] * t2 + MarketingIndex(B.J, B.M, B.Agent[i], J.J, J.M, J.Agent[i], R.J, R.M, R.Agent[i], Z.J, Z.M, Z.Agent[i], AH.J, AH.M, AH.Agent[i], AP.J, AP.M, AP.Agent[i]));
                    result.Agent.Add(FirstBP.Agent[i] * t + SecondBP.Agent[i] * t2 + MarketingIndex(B.Agent[i], B.J, B.M, J.Agent[i], J.J, J.M, R.Agent[i], R.J, R.M, Z.Agent[i], Z.J, Z.M, AH.Agent[i], AH.J, AH.M, AP.Agent[i], AP.J, AP.M));

                }

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
                var count = new AgentStages().agents.Count;
                for (int i = 0; i < count; i++)
                {
                    result.M.Add(AX.M[i] + AX.J[i] + AX.Agent[i] == 0 ? 0 : AX.M[i] / (AX.M[i] + AX.J[i] + AX.Agent[i]));
                    result.J.Add(AX.M[i] + AX.J[i] + AX.Agent[i] == 0 ? 0 : AX.J[i] / (AX.M[i] + AX.J[i] + AX.Agent[i]));
                    result.Agent.Add(AX.M[i] + AX.J[i] + AX.Agent[i] == 0 ? 0 : AX.Agent[i] / (AX.M[i] + AX.J[i] + AX.Agent[i]));

                }
                return result;

            }
        }
        public List<decimal> CIAgent
        {
            get

            {
                var result = new List<decimal>();
                var count = new AgentStages().agents.Count;
                for (int i = 0; i < count; i++)
                {
                    result.Add(BP.M[i] + BP.J[i] + BP.Agent[i]);
                }
                return result;
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