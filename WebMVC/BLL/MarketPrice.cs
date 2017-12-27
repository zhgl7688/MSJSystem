using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WebMVC.Models;
using WebMVC.Common;

namespace WebMVC.BLL
{
    /// <summary>
    /// 市场价格
    /// </summary>
    public class MarketPrice
    {
        decimal RC1M;//= Convert.ToDecimal(ConfigurationManager.AppSettings["RC1M"]);
        decimal RC1S; //= Convert.ToDecimal(ConfigurationManager.AppSettings["RC1S"]);
        decimal RC1J;// Convert.ToDecimal(ConfigurationManager.AppSettings["RC1J

        decimal cd;
        decimal ce;
        decimal cf;

        List<PriceControlTable> priceControlTables;
        List<ProductInnvoationTable> productInnvoations;
        List<CurrentShareTable> currentShares;
   
        public MarketPrice(PriceControl priceControl, ProductInnovation productInnovation, CurrentShare currentShare)
        {
            cd = AgentStages.MP_CD;
            ce = AgentStages.MP_CE;
            cf = AgentStages.MP_CF;
            RC1M = AgentStages.MP_CM;
            RC1S = AgentStages.MP_CN;
            RC1J = AgentStages.MP_CO;
             priceControlTables = priceControl.Get();
            productInnvoations = productInnovation.Get();
            currentShares = currentShare.Get();
            Init();
        }
        List<MarketTable> markets = new List<MarketTable>();
        public void Init()
        {

            for (int i = 0; i < currentShares.Count; i++)
            {
                if (i == AgentStages.stages.Count-1) return;
                var stage = AgentStages.stages[i + 1];
                var market = new MarketTable { Id = i, Stage = stage };
                var priceControl1 = priceControlTables.FirstOrDefault(s => s.Stage == stage);
                var currentShare1 = currentShares.FirstOrDefault(s => s.Stage == stage);
                var productInnvoation1 = productInnvoations.FirstOrDefault(s => s.Stage == stage);
                if (priceControl1 == null || currentShare1 == null || productInnvoation1 == null) break;
                market.B.M = currentShare1.BJ[i].M.Average();
                market.B.J = currentShare1.CB[i].J.Average();
                market.D = currentShare1.CT[i];
                if (i == 0)
                {
                    market.CD[0] = new RC { M = cd, S = ce, J = cf };
                    market.CM[0] = new RC { M = RC1M, S = RC1S, J = RC1J };
                    var m = priceControl1.B.RcM.Count > 0 ? priceControl1.B.RcM[0] : 0;
                    var j = priceControl1.B.RcJ.Count > 0 ? priceControl1.B.RcJ[0] : 0;
                    var agent = priceControl1.D.Count > 0 ? priceControl1.D[0].Agent : new List<decimal>();
                    market.DE[0] = new RC { M =m , J = j };
                    market.DK[0] = new MJA { Agent = agent };
                }
                else
                {

                    var lastMarket = markets.FirstOrDefault(s => s.Id == i - 1);
                    var LastproductInnvoation = productInnvoations.FirstOrDefault(s => s.Stage == AgentStages.stages[i]);

                    for (int s = 0; s < i+1; s++)
                    {
                        if (s == i)
                        {
                            market.CD[i ] = priceControl1.AG;
                            market.CM[i ] = priceControl1.AJ;
                        }
                        else
                        {
                            market.CD[s] = new RC
                            {
                                M = lastMarket.CD[s].M - lastMarket.CD[s].M * LastproductInnvoation.AL.MIRC[s].M / 100 * 0.02m,
                                S = lastMarket.CD[s].S - lastMarket.CD[s].S * LastproductInnvoation.AL.MIRC[s].S / 100 * 0.02m,
                                J = lastMarket.CD[s].J - lastMarket.CD[s].J * LastproductInnvoation.AL.MIRC[s].J / 100 * 0.02m
                            };
                            market.CM[s] = new RC
                            {
                                M = lastMarket.CM[0].M - lastMarket.CM[0].M * LastproductInnvoation.AL.MIRC[0].M / 100 * 0.02m,
                                S = lastMarket.CM[0].S - lastMarket.CM[0].S * LastproductInnvoation.AL.MIRC[0].S / 100 * 0.02m,
                                J = lastMarket.CM[0].J - lastMarket.CM[0].J * LastproductInnvoation.AL.MIRC[0].J / 100 * 0.02m
                            };
                        }
                        var m = priceControl1.B.RcM.Count > s ? priceControl1.B.RcM[s] : 0;
                        var j = priceControl1.B.RcJ.Count > s ? priceControl1.B.RcJ[s] : 0;
                        var agent = priceControl1.D.Count > s ? priceControl1.D[s].Agent : new List<decimal>();
                        market.DE[s] = new RC { M = m, J =j };
                        market.DK[s] = new MJA { Agent = agent };

                    }

                }
                for (int l = 0; l < AgentStages.agents.Count; l++)
                {
                    for (int s = 0; s < i + 1; s++)
                    {
                        var agent = GetEF(priceControl1.K[s].Agent[l], priceControl1.D[s].Agent[l]);
                        market.EF[s].Agent.Add(agent);
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
    public class MarketTable
    {
        public MarketTable()
        {
          
            for (int i = 0; i < AgentStages.stages.Count - 1; i++)
            {
                CD.Add(i, new RC());
                CM.Add(i, new RC());
                DE.Add(i, new RC());
                DK.Add(i, new MJA());
                EF.Add(i, new MJA());
            }
        }
        public int Id { get; set; }
        public string Stage { get; set; }
        /// <summary>
        /// 竞品出货RC1
        /// </summary>
        public RC B { get; set; } = new RC();
        /// <summary>
        /// 我品市场零售容量
        /// </summary>
        public MJA D { get; set; } = new MJA();
        /// <summary>
        /// RCM
        /// </summary>
        public Dictionary<int, MJA> AB
        {
            get
            {
           
                var countAgent = AgentStages.agents.Count;
                var indexStage = AgentStages.stages.IndexOf(this.Stage);
                var result = new Dictionary<int, MJA>();
                for (int i = 0; i < AgentStages.stages.Count - 1; i++)
                {
                    result.Add(i, new MJA());
                }
                for (int i = 0; i < countAgent; i++)
                {
                    for (int j = 0; j < indexStage; j++)
                    {
                        var m = GetAB(DK[j].Agent[i], DE[j].M, DE[j].J);
                        result[j].M.Add(m);
                    }
                }

                return result;
            }
        }
        private decimal GetAB(decimal dk, decimal de, decimal df)
        {
            // = (1 / 3) * ((DK5 / (DE5 - (DE5 - (DE5 * 1.05))) + DF5 / (DE5 - (DE5 - (DE5 * 0.92)))) / 2)
            //* (1 - (IF((DE5 / DE5 - 1) >= 0, (DE5 / DE5 - 1) * 10, (DE5 / DE5 - 1))))
            if (de == 0) return 0;
            var t1 = de - (de - (de * 1.05m)); if (t1 == 0) return 0;
            var t2 = de - (de - (de * 0.92m)); if (t2 == 0) return 0;


            var result = (1 / 3m) * ((dk / t1 + df / t2) / 2) * ((1 - ((de / de - 1) >= 0 ? (de / de - 1) * 10 : (de / de - 1))));
            return result;
        }
        /// <summary>
        /// RCJ
        /// </summary>
        public Dictionary<int, MJA> AT
        {
            get
            {
            
                var countAgent = AgentStages.agents.Count;
                var indexStage = AgentStages.stages.IndexOf(this.Stage);
                var result = new Dictionary<int, MJA>();
                for (int i = 0; i < AgentStages.stages.Count - 1; i++)
                {
                    result.Add(i, new MJA());
                }

                for (int j = 0; j < indexStage; j++)
                {
                    for (int i = 0; i < countAgent; i++)
                    {
                        var m = GetAT(DK[j].Agent[i], DE[j].M, DE[j].J);
                        result[j].J.Add(m);
                    }
                }

                return result;
            }
        }
        private decimal GetAT(decimal dk, decimal de, decimal df)
        {
            //= (1 / 3) * ((DE5 / (DF5 - ((DE5 * 0.92) - DE5)) + DK5 / (DF5 - ((DE5 * 0.92) - (DE5 * 1.05)))) / 2) * (1 - (IF((DF5 / (DE5 * 0.92) - 1) >= 0, (DF5 / (DE5 * 0.92) - 1) * 10, (DF5 / (DE5 * 0.92) - 1))))

            if (de == 0) return 0;
            var t1 = df - ((de * 0.92m) - de); if (t1 == 0) return 0;
            var t2 = df - ((de * 0.92m) - (de * 1.05m)); if (t2 == 0) return 0;
            var result = (1 / 3m) * ((de / (t1) + dk / (t2)) / 2)
                * (1 - (((df / (de * 0.92m) - 1) >= 0 ? (df / (de * 0.92m) - 1) * 10 : (df / (de * 0.92m) - 1))));
            return result;

        }
        public Dictionary<int, MJA> BL
        {
            get
            {
        
                var countAgent = AgentStages.agents.Count;
                var indexStage = AgentStages.stages.IndexOf(this.Stage);
                var result = new Dictionary<int, MJA>();
                for (int i = 0; i < AgentStages.stages.Count - 1; i++)
                {
                    result.Add(i, new MJA());
                }
                for (int i = 0; i < countAgent; i++)
                {
                    for (int j = 0; j < indexStage; j++)
                    {
                        var m = GetBL(DK[j].Agent[i], DE[j].M, DE[j].J);
                        result[j].Agent.Add(m);
                    }
                }

                return result;
            }
        }

        private decimal GetBL(decimal dk, decimal de, decimal df)
        {
            //=IF((1/3)*(($DE5/(DK5-(($DE5*1.05)-$DE5))+$DF5/(DK5-(($DE5*1.05)-($DE5*0.92))))/2)*(1-(IF(DK5/($DE5*1.05)<1.01,(DK5/($DE5*1.05)-1),IF(DK5/($DE5*1.05)<=1.03,(DK5/($DE5*1.05)-1)*3,IF(DK5/($DE5*1.05)<=1.05,(DK5/($DE5*1.05)-1)*6,IF(DK5/($DE5*1.05)<=1.1,(DK5/($DE5*1.05)-1)*12,IF(DK5/($DE5*1.05)<=1.2,(DK5/($DE5*1.05)-1)*18,IF(DK5/($DE5*1.05)<=1.3,(DK5/($DE5*1.05)-1)*24,(DK5/($DE5*1.05)-1)*30))))))))<-320%,-320%,(1/3)*(($DE5/(DK5-(($DE5*1.05)-$DE5))+$DF5/(DK5-(($DE5*1.05)-($DE5*0.92))))/2)*(1-(IF(DK5/($DE5*1.05)<1.01,(DK5/($DE5*1.05)-1),IF(DK5/($DE5*1.05)<=1.03,(DK5/($DE5*1.05)-1)*3,IF(DK5/($DE5*1.05)<=1.05,(DK5/($DE5*1.05)-1)*6,IF(DK5/($DE5*1.05)<=1.1,(DK5/($DE5*1.05)-1)*12,IF(DK5/($DE5*1.05)<=1.2,(DK5/($DE5*1.05)-1)*18,IF(DK5/($DE5*1.05)<=1.3,(DK5/($DE5*1.05)-1)*24,(DK5/($DE5*1.05)-1)*30)))))))))
            if (de == 0) return 0;
            var s1 = (dk - ((de * 1.05m) - de));
            if (s1 == 0) return 0;
            var s2 = (dk - ((de * 1.05m) - (de * 0.92m)));
            if (s2 == 0) return 0;
            var t1 = (1 / 3m) * ((de / s1 + df / s2) / 2m);
            var t2 = dk / (de * 1.05m) <= 1.3m ? (dk / (de * 1.05m) - 1) * 24 : (dk / (de * 1.05m) - 1) * 30;
            var t3 = dk / (de * 1.05m) <= 1.2m ? (dk / (de * 1.05m) - 1) * 18 : t2;
            var t4 = dk / (de * 1.05m) <= 1.1m ? (dk / (de * 1.05m) - 1) * 12 : t3;
            var t5 = dk / (de * 1.05m) <= 1.05m ? (dk / (de * 1.05m) - 1) * 6 : t4;
            var t6 = dk / (de * 1.05m) <= 1.03m ? (dk / (de * 1.05m) - 1) * 3 : t5;
            var t7 = dk / (de * 1.05m) < 1.01m ? (dk / (de * 1.05m) - 1) : t6;
            var result = t1 * (1 - t7) < -3.20m ? -3.20m : t1 * (1 - t7);
            return result;
        }
        public Dictionary<int, RC> CD { get; set; } = new Dictionary<int, RC>();

        public Dictionary<int, RC> CM { get; set; } = new Dictionary<int, RC>();

        public Dictionary<int, RC> CV
        {
            get
            {
                var result = new Dictionary<int, RC>();
                var index = AgentStages.stages.IndexOf(this.Stage);
                for (int i = 0; i < index; i++)
                {
                    result.Add(i, GetVC(CM[i], CD[i]));
                }
                //result.Add(1, GetVC(CM[1], CD[1]));
                //if (Stage == Common.Stage.第二阶段.ToString() || Stage == Common.Stage.第三阶段.ToString())
                //    result.Add(2, GetVC(CM[2], CD[2]));
                //if (Stage == Common.Stage.第三阶段.ToString())
                //    result.Add(3, GetVC(CM[3], CD[3]));

                return result;
            }
        }
        private RC GetVC(RC CM, RC CD)
        {
            return new RC { M = CVCAL(CM.M, CD.M), S = CVCAL(CM.S, CD.S), J = CVCAL(CM.J, CD.J) };

        }
        private decimal CVCAL(decimal a, decimal b)
        {
            if (a == 0) return 0;
            return (a - b) / a;
        }
        public Dictionary<int, RC> DE { get; set; } = new Dictionary<int, RC>();
        /// <summary>
        /// 零售价
        /// </summary>
        public Dictionary<int, MJA> DK { get; set; } = new Dictionary<int, MJA>();
        /// <summary>
        /// 供货价
        /// </summary>
        public Dictionary<int, MJA> EF { get; set; } = new Dictionary<int, MJA>();


        public CompeteRC CompeteRC { get; set; }

        public Dictionary<int, MJA> EY
        {
            get
            {
              
                var countAgent = AgentStages.agents.Count;
                var indexStage = AgentStages.stages.IndexOf(this.Stage);
                var result = new Dictionary<int, MJA>();
                for (int i = 0; i < AgentStages.stages.Count - 1; i++)
                {
                    result.Add(i, new MJA());
                }
                for (int i = 0; i < countAgent; i++)
                {
                    for (int j = 0; j < indexStage; j++)
                    {
                        var m = AB[j].M[i] + AT[j].J[i] + BL[j].Agent[i];
                        result[j].M.Add(m);
                    }
                }

                return result;
            }
        }
    }
}