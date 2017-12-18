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
        decimal RC1M = Convert.ToDecimal(ConfigurationManager.AppSettings["RC1M"]);
        decimal RC1S = Convert.ToDecimal(ConfigurationManager.AppSettings["RC1S"]);
        decimal RC1J = Convert.ToDecimal(ConfigurationManager.AppSettings["RC1J"]);
        List<PriceControlTable> priceControlTables;
        List<ProductInnvoationTable> productInnvoations;
        List<CurrentShareTable> currentShares;
        AgentStages agentStages;
        public MarketPrice(PriceControl priceControl, ProductInnovation productInnovation, CurrentShare currentShare)
        {
            agentStages = new AgentStages();
            priceControlTables = priceControl.Get();
            productInnvoations = productInnovation.Get();
            currentShares = currentShare.Get();
            Init();
        }
        List<MarketTable> markets = new List<MarketTable>();
        public void Init()
        {

            #region 第一阶段
            var market1 = new MarketTable() { Stage = agentStages.stages[1], };

            var priceControl1 = priceControlTables.FirstOrDefault(s => s.Stage == agentStages.stages[1]);
            var currentShare1 = currentShares.FirstOrDefault(s => s.Stage == agentStages.stages[1]);
            var productInnvoation1 = productInnvoations.FirstOrDefault(s => s.Stage == agentStages.stages[1]);
            if (priceControl1 == null || currentShare1 == null || productInnvoation1 == null) return;
            market1.B.M = currentShare1.BJ[1].M.Average();
            market1.B.J = currentShare1.CB[1].J.Average();
            market1.D = currentShare1.CT[1];

            market1.CD[1] = new RC { M = 300, S = 315, J = 285 };


            market1.CM[1] = new RC { M = RC1M, S = RC1S, J = RC1J };
            market1.DE[1] = new RC { M = priceControl1.B.RcM[0], J = priceControl1.B.RcJ[0] };
            market1.DK[1] = new MJA { Agent = priceControl1.D[1].Agent };
            for (int i = 0; i < agentStages.agents.Count; i++)
            {
                var agent = GetEF(priceControl1.K[1].Agent[i], priceControl1.D[1].Agent[i]);
                market1.EF[1].Agent.Add(agent);
            }


            //market1.CompeteRC = priceControl1.B;
            markets.Add(market1);
            #endregion

            #region 第二阶段
            var market2 = new MarketTable() { Stage = Stage.第二阶段.ToString(), };
            var priceControl2 = priceControlTables.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());

            var currentShare2 = currentShares.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            var productInnvoation2 = productInnvoations.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            if (priceControl2 == null || currentShare2 == null || productInnvoation2 == null) return;
            market2.B.M = currentShare2.BJ[1].M.Sum();
            market2.B.J = currentShare2.CB[1].J.Sum();
            market2.D = currentShare2.CT[1];

            market2.CD[1] = new RC
            {
                M = market1.CD[1].M - market1.CD[1].M * productInnvoation1.AL.MIRC[0].M / 100 * 0.02m,
                S = market1.CD[1].S - market1.CD[1].S * productInnvoation1.AL.MIRC[0].S / 100 * 0.02m,
                J = market1.CD[1].J - market1.CD[1].J * productInnvoation1.AL.MIRC[0].J / 100 * 0.02m
            };
            market2.CD[2] = priceControl2.AG;

            market2.CM[1] = new RC
            {
                M = market1.CM[1].M - market1.CM[1].M * productInnvoation1.AL.MIRC[1].M / 100 * 0.02m,
                S = market1.CM[1].S - market1.CM[1].S * productInnvoation1.AL.MIRC[1].S / 100 * 0.02m,
                J = market1.CM[1].J - market1.CM[1].J * productInnvoation1.AL.MIRC[1].J / 100 * 0.02m
            };
            market2.CM[2] = priceControl2.AJ;
            market2.DE[1] = new RC { M = priceControl2.B.RcM[0], J = priceControl2.B.RcJ[0] };
            market2.DE[2] = new RC { M = priceControl2.B.RcM[1], J = priceControl2.B.RcJ[1] };

            market2.DK[1] = new MJA { Agent = priceControl2.D[1].Agent };
            market2.DK[2] = new MJA { Agent = priceControl2.D[2].Agent };
            for (int i = 0; i < agentStages.agents.Count; i++)
            {
                var agent = GetEF(priceControl2.K[1].Agent[i], priceControl2.D[1].Agent[i]);
                market2.EF[1].Agent.Add(agent);
                agent = GetEF(priceControl2.K[2].Agent[i], priceControl2.D[2].Agent[i]);
                market2.EF[2].Agent.Add(agent);
            }
            markets.Add(market2);
            #endregion

            #region 第三阶段
            var market3 = new MarketTable() { Stage = Stage.第三阶段.ToString(), };
            var priceControl3 = priceControlTables.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            var currentShare3 = currentShares.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            var productInnvoation3 = productInnvoations.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            if (priceControl3 == null || currentShare3 == null || productInnvoation3 == null) return;
            market3.B.M = currentShare3.BJ[1].M.Sum();
            market3.B.J = currentShare3.CB[1].J.Sum();
            market3.D = currentShare3.CT[1];

            market3.CD[1] = new RC
            {
                M = market2.CD[1].M - market2.CD[1].M * productInnvoation2.AL.MIRC[0].M / 100 * 0.02m,
                S = market2.CD[1].S - market2.CD[1].S * productInnvoation2.AL.MIRC[0].S / 100 * 0.02m,
                J = market2.CD[1].J - market2.CD[1].J * productInnvoation2.AL.MIRC[0].J / 100 * 0.02m
            };
            market3.CD[2] = new RC
            {
                M = market2.CD[2].M - market2.CD[2].M * productInnvoation2.AL.MIRC[1].M / 100 * 0.02m,
                S = market2.CD[2].S - market2.CD[2].S * productInnvoation2.AL.MIRC[1].S / 100 * 0.02m,
                J = market2.CD[2].J - market2.CD[2].J * productInnvoation2.AL.MIRC[1].J / 100 * 0.02m
            };
            market3.CD[3] = priceControl3.AG;

            market3.CM[1] = new RC
            {
                M = market2.CM[1].M - market2.CM[1].M * productInnvoation2.AL.MIRC[0].M / 100 * 0.02m,
                S = market2.CM[1].S - market2.CM[1].S * productInnvoation2.AL.MIRC[0].S / 100 * 0.02m,
                J = market2.CM[1].J - market2.CM[1].J * productInnvoation2.AL.MIRC[0].J / 100 * 0.02m
            };
            market3.CM[2] = new RC
            {
                M = market2.CM[2].M - market2.CM[2].M * productInnvoation2.AL.MIRC[1].M / 100 * 0.02m,
                S = market2.CM[2].S - market2.CM[2].S * productInnvoation2.AL.MIRC[1].S / 100 * 0.02m,
                J = market2.CM[2].J - market2.CM[2].J * productInnvoation2.AL.MIRC[1].J / 100 * 0.02m
            };
            market3.CM[3] = priceControl3.AJ;

            market3.DE[1] = new RC { M = priceControl3.B.RcM[0], J = priceControl3.B.RcJ[0] };
            market3.DE[2] = new RC { M = priceControl3.B.RcM[1], J = priceControl3.B.RcJ[1] };
            market3.DE[3] = new RC { M = priceControl3.B.RcM[2], J = priceControl3.B.RcJ[2] };
            market3.DK[1] = new MJA { Agent = priceControl3.D[1].Agent };
            market3.DK[2] = new MJA { Agent = priceControl3.D[2].Agent };
            market3.DK[3] = new MJA { Agent = priceControl3.D[3].Agent };
            for (int i = 0; i < agentStages.agents.Count; i++)
            {
                var agent = GetEF(priceControl3.K[1].Agent[i], priceControl3.D[1].Agent[i]);
                market3.EF[1].Agent.Add(agent);
                agent = GetEF(priceControl3.K[2].Agent[i], priceControl3.D[2].Agent[i]);
                market3.EF[2].Agent.Add(agent);
                agent = GetEF(priceControl3.K[3].Agent[i], priceControl3.D[3].Agent[i]);
                market3.EF[3].Agent.Add(agent);
            }
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
    public class MarketTable
    {
        public MarketTable()
        {
            var agentStages = new AgentStages();
            for (int i = 0; i < agentStages.stages.Count; i++)
            {
                CD.Add(i, new RC());
                CM.Add(i, new RC());
                DE.Add(i, new RC());
                DK.Add(i, new MJA());
                EF.Add(i, new MJA());
            }
        }
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
                var agentStages = new AgentStages();
                var countAgent = agentStages.agents.Count;
                var indexStage = agentStages.stages.IndexOf(this.Stage);
                var result = new Dictionary<int, MJA>();
                for (int i = 0; i < agentStages.stages.Count; i++)
                {
                    result.Add(i, new MJA());
                }
                for (int i = 0; i < countAgent; i++)
                {
                    for (int j = 1; j < indexStage+1; j++)
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
                var agentStages = new AgentStages();
                var countAgent = agentStages.agents.Count;
                var indexStage = agentStages.stages.IndexOf(this.Stage);
                var result = new Dictionary<int, MJA>();
                for (int i = 0; i < agentStages.stages.Count; i++)
                {
                    result.Add(i, new MJA());
                }
                for (int i = 0; i < countAgent; i++)
                {
                    for (int j = 1; j < indexStage + 1; j++)
                    {
                        var m = GetAT(DK[j].Agent[i], DE[j].M, DE[j].J);
                        result[j].M.Add(m);
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
                var agentStages = new AgentStages();
                var countAgent = agentStages.agents.Count;
                var indexStage = agentStages.stages.IndexOf(this.Stage);
                var result = new Dictionary<int, MJA>();
                for (int i = 0; i < agentStages.stages.Count; i++)
                {
                    result.Add(i, new MJA());
                }
                for (int i = 0; i < countAgent; i++)
                {
                    for (int j = 1; j < indexStage + 1; j++)
                    {
                        var m = GetBL(DK[j].Agent[i], DE[j].M, DE[j].J);
                        result[j].M.Add(m);
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
                result.Add(1, GetVC(CM[1], CD[1]));
                if (Stage == Common.Stage.第二阶段.ToString() || Stage == Common.Stage.第三阶段.ToString())
                    result.Add(2, GetVC(CM[2], CD[2]));
                if (Stage == Common.Stage.第三阶段.ToString())
                    result.Add(3, GetVC(CM[3], CD[3]));

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
                var agentStages = new AgentStages();
                var countAgent = agentStages.agents.Count;
                var indexStage = agentStages.stages.IndexOf(this.Stage);
                var result = new Dictionary<int, MJA>();
                for (int i = 0; i < agentStages.stages.Count; i++)
                {
                    result.Add(i, new MJA());
                }
                for (int i = 0; i < countAgent; i++)
                {
                    for (int j = 1; j < indexStage + 1; j++)
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