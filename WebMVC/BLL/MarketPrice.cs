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
        public MarketPrice()
        {
            priceControlTables = new PriceControl().Get();
            productInnvoations = new ProductInnovation().Get();
            currentShares = new CurrentShare().Get();
            Init();
        }
        List<MarketTable> markets = new List<MarketTable>();
        public void Init()
        {
            #region 第一阶段
            var market1 = new MarketTable() { Stage = Stage.第一阶段.ToString(), };
            var priceControl1 = priceControlTables.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            var currentShare1 = currentShares.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            var productInnvoation1 = productInnvoations.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            market1.B.M = currentShare1.BJ[1].AverageM;
            market1.B.J = currentShare1.CB[1].AverageJ;
            market1.D = currentShare1.CT[1];

            market1.CD.Add(1, new RC { M = 300, S = 315, J = 285 });
            market1.CM.Add(1, new RC { M = RC1M, S = RC1S, J = RC1J });
            market1.DE.Add(1, new RC { M = priceControl1.B.RC1M, J = priceControl1.B.RC1J });
            market1.DK.Add(1, new MJA { Agent1 = priceControl1.D[1].Agent1, Agent2 = priceControl1.D[1].Agent2, Agent3 = priceControl1.D[1].Agent3, Agent4 = priceControl1.D[1].Agent4, Agent5 = priceControl1.D[1].Agent5, Agent6 = priceControl1.D[1].Agent6 });
            market1.EF.Add(1, new MJA
            {
                Agent1 = GetEF(priceControl1.K[1].Agent1, priceControl1.D[1].Agent1),
                Agent2 = GetEF(priceControl1.K[1].Agent2, priceControl1.D[1].Agent2),
                Agent3 = GetEF(priceControl1.K[1].Agent3, priceControl1.D[1].Agent3),
                Agent4 = GetEF(priceControl1.K[1].Agent4, priceControl1.D[1].Agent4),
                Agent5 = GetEF(priceControl1.K[1].Agent5, priceControl1.D[1].Agent5),
                Agent6 = GetEF(priceControl1.K[1].Agent6, priceControl1.D[1].Agent6)
            });

            //market1.CompeteRC = priceControl1.B;
            markets.Add(market1);
            #endregion

            #region 第二阶段
            var market2 = new MarketTable() { Stage = Stage.第二阶段.ToString(), };
            var priceControl2 = priceControlTables.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            if (priceControl2 == null) return;
            var currentShare2 = currentShares.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());
            var productInnvoation2 = productInnvoations.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString());

            market2.B.M = currentShare2.BJ[1].SumM;
            market2.B.J = currentShare2.CB[1].SumJ;
            market2.D = currentShare2.CT[1];

            market2.CD.Add(1, new RC
            {
                M = market1.CD[1].M - market1.CD[1].M * productInnvoation1.AL.RC1.M / 100 * 0.02m,
                S = market1.CD[1].S - market1.CD[1].S * productInnvoation1.AL.RC1.S / 100 * 0.02m,
                J = market1.CD[1].J - market1.CD[1].J * productInnvoation1.AL.RC1.J / 100 * 0.02m
            });
            market2.CD.Add(2, priceControl2.AG);

            market2.CM.Add(1, new RC
            {
                M = market1.CM[1].M - market1.CM[1].M * productInnvoation1.AL.RC1.M / 100 * 0.02m,
                S = market1.CM[1].S - market1.CM[1].S * productInnvoation1.AL.RC1.S / 100 * 0.02m,
                J = market1.CM[1].J - market1.CM[1].J * productInnvoation1.AL.RC1.J / 100 * 0.02m
            });
            market2.CM.Add(2, priceControl2.AJ);
            market2.DE.Add(1, new RC { M = priceControl2.B.RC1M, J = priceControl2.B.RC1J });
            market2.DE.Add(2, new RC { M = priceControl2.B.RC2M, J = priceControl2.B.RC2J });

            market2.DK.Add(1, new MJA { Agent1 = priceControl2.D[1].Agent1, Agent2 = priceControl2.D[1].Agent2, Agent3 = priceControl2.D[1].Agent3, Agent4 = priceControl2.D[1].Agent4, Agent5 = priceControl2.D[1].Agent5, Agent6 = priceControl2.D[1].Agent6 });
            market2.DK.Add(2, new MJA { Agent1 = priceControl2.D[2].Agent1, Agent2 = priceControl2.D[2].Agent2, Agent3 = priceControl2.D[2].Agent3, Agent4 = priceControl2.D[2].Agent4, Agent5 = priceControl2.D[2].Agent5, Agent6 = priceControl2.D[2].Agent6 });

            market2.EF.Add(1, new MJA
            {
                Agent1 = GetEF(priceControl2.K[1].Agent1, priceControl2.D[1].Agent1),
                Agent2 = GetEF(priceControl2.K[1].Agent2, priceControl2.D[1].Agent2),
                Agent3 = GetEF(priceControl2.K[1].Agent3, priceControl2.D[1].Agent3),
                Agent4 = GetEF(priceControl2.K[1].Agent4, priceControl2.D[1].Agent4),
                Agent5 = GetEF(priceControl2.K[1].Agent5, priceControl2.D[1].Agent5),
                Agent6 = GetEF(priceControl2.K[1].Agent6, priceControl2.D[1].Agent6)
            });
            market2.EF.Add(2, new MJA
            {
                Agent1 = GetEF(priceControl2.K[2].Agent1, priceControl2.D[2].Agent1),
                Agent2 = GetEF(priceControl2.K[2].Agent2, priceControl2.D[2].Agent2),
                Agent3 = GetEF(priceControl2.K[2].Agent3, priceControl2.D[2].Agent3),
                Agent4 = GetEF(priceControl2.K[2].Agent4, priceControl2.D[2].Agent4),
                Agent5 = GetEF(priceControl2.K[2].Agent5, priceControl2.D[2].Agent5),
                Agent6 = GetEF(priceControl2.K[2].Agent6, priceControl2.D[2].Agent6)
            });
            markets.Add(market2);
            #endregion

            #region 第三阶段
            var market3 = new MarketTable() { Stage = Stage.第三阶段.ToString(), };
            var priceControl3 = priceControlTables.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            if (priceControl3 == null) return;
            var currentShare3 = currentShares.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());
            var productInnvoation3 = productInnvoations.FirstOrDefault(s => s.Stage == Stage.第三阶段.ToString());

            market3.B.M = currentShare3.BJ[1].SumM;
            market3.B.J = currentShare3.CB[1].SumJ;
            market3.D = currentShare3.CT[1];

            market3.CD.Add(1, new RC
            {
                M = market2.CD[1].M - market2.CD[1].M * productInnvoation2.AL.RC1.M / 100 * 0.02m,
                S = market2.CD[1].S - market2.CD[1].S * productInnvoation2.AL.RC1.S / 100 * 0.02m,
                J = market2.CD[1].J - market2.CD[1].J * productInnvoation2.AL.RC1.J / 100 * 0.02m
            });
            market3.CD.Add(2, new RC
            {
                M = market2.CD[2].M - market2.CD[2].M * productInnvoation2.AL.RC2.M / 100 * 0.02m,
                S = market2.CD[2].S - market2.CD[2].S * productInnvoation2.AL.RC2.S / 100 * 0.02m,
                J = market2.CD[2].J - market2.CD[2].J * productInnvoation2.AL.RC2.J / 100 * 0.02m
            });
            market3.CD.Add(3, priceControl3.AG);

            market3.CM.Add(1, new RC
            {
                M = market2.CM[1].M - market2.CM[1].M * productInnvoation2.AL.RC1.M / 100 * 0.02m,
                S = market2.CM[1].S - market2.CM[1].S * productInnvoation2.AL.RC1.S / 100 * 0.02m,
                J = market2.CM[1].J - market2.CM[1].J * productInnvoation2.AL.RC1.J / 100 * 0.02m
            });
            market3.CM.Add(2, new RC
            {
                M = market2.CM[2].M - market2.CM[2].M * productInnvoation2.AL.RC2.M / 100 * 0.02m,
                S = market2.CM[2].S - market2.CM[2].S * productInnvoation2.AL.RC2.S / 100 * 0.02m,
                J = market2.CM[2].J - market2.CM[2].J * productInnvoation2.AL.RC2.J / 100 * 0.02m
            });
            market3.CM.Add(3, priceControl3.AJ);

            market3.DE.Add(1, new RC { M = priceControl3.B.RC1M, J = priceControl3.B.RC1J });
            market3.DE.Add(2, new RC { M = priceControl3.B.RC2M, J = priceControl3.B.RC2J });
            market3.DE.Add(3, new RC { M = priceControl3.B.RC3M, J = priceControl3.B.RC3J });
            market3.DK.Add(1, new MJA { Agent1 = priceControl3.D[1].Agent1, Agent2 = priceControl3.D[1].Agent2, Agent3 = priceControl3.D[1].Agent3, Agent4 = priceControl3.D[1].Agent4, Agent5 = priceControl3.D[1].Agent5, Agent6 = priceControl3.D[1].Agent6 });
            market3.DK.Add(2, new MJA { Agent1 = priceControl3.D[2].Agent1, Agent2 = priceControl3.D[2].Agent2, Agent3 = priceControl3.D[2].Agent3, Agent4 = priceControl3.D[2].Agent4, Agent5 = priceControl3.D[2].Agent5, Agent6 = priceControl3.D[2].Agent6 });
            market3.DK.Add(3, new MJA { Agent1 = priceControl3.D[3].Agent1, Agent2 = priceControl3.D[3].Agent2, Agent3 = priceControl3.D[3].Agent3, Agent4 = priceControl3.D[3].Agent4, Agent5 = priceControl3.D[3].Agent5, Agent6 = priceControl3.D[3].Agent6 });

            market3.EF.Add(1, new MJA
            {
                Agent1 = GetEF(priceControl3.K[1].Agent1, priceControl3.D[1].Agent1),
                Agent2 = GetEF(priceControl3.K[1].Agent2, priceControl3.D[1].Agent2),
                Agent3 = GetEF(priceControl3.K[1].Agent3, priceControl3.D[1].Agent3),
                Agent4 = GetEF(priceControl3.K[1].Agent4, priceControl3.D[1].Agent4),
                Agent5 = GetEF(priceControl3.K[1].Agent5, priceControl3.D[1].Agent5),
                Agent6 = GetEF(priceControl3.K[1].Agent6, priceControl3.D[1].Agent6)
            });
            market3.EF.Add(2, new MJA
            {
                Agent1 = GetEF(priceControl3.K[2].Agent1, priceControl3.D[2].Agent1),
                Agent2 = GetEF(priceControl3.K[2].Agent2, priceControl3.D[2].Agent2),
                Agent3 = GetEF(priceControl3.K[2].Agent3, priceControl3.D[2].Agent3),
                Agent4 = GetEF(priceControl3.K[2].Agent4, priceControl3.D[2].Agent4),
                Agent5 = GetEF(priceControl3.K[2].Agent5, priceControl3.D[2].Agent5),
                Agent6 = GetEF(priceControl3.K[2].Agent6, priceControl3.D[2].Agent6)
            });
            market3.EF.Add(3, new MJA
            {
                Agent1 = GetEF(priceControl3.K[3].Agent1, priceControl3.D[3].Agent1),
                Agent2 = GetEF(priceControl3.K[3].Agent2, priceControl3.D[3].Agent2),
                Agent3 = GetEF(priceControl3.K[3].Agent3, priceControl3.D[3].Agent3),
                Agent4 = GetEF(priceControl3.K[3].Agent4, priceControl3.D[3].Agent4),
                Agent5 = GetEF(priceControl3.K[3].Agent5, priceControl3.D[3].Agent5),
                Agent6 = GetEF(priceControl3.K[3].Agent6, priceControl3.D[3].Agent6)
            });
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
                var result = new Dictionary<int, MJA>();
                result.Add(1, new MJA
                {
                    M1 = GetAB(DK[1].Agent1, DE[1].M, DE[1].J),
                    M2 = GetAB(DK[1].Agent2, DE[1].M, DE[1].J),
                    M3 = GetAB(DK[1].Agent3, DE[1].M, DE[1].J),
                    M4 = GetAB(DK[1].Agent4, DE[1].M, DE[1].J),
                    M5 = GetAB(DK[1].Agent5, DE[1].M, DE[1].J),
                    M6 = GetAB(DK[1].Agent6, DE[1].M, DE[1].J),
                });
                if (Stage == Common.Stage.第二阶段.ToString()||Stage == Common.Stage.第三阶段.ToString())
                    result.Add(2, new MJA
                    {
                        M1 = GetAB(DK[2].Agent1, DE[2].M, DE[2].J),
                        M2 = GetAB(DK[2].Agent2, DE[2].M, DE[2].J),
                        M3 = GetAB(DK[2].Agent3, DE[2].M, DE[2].J),
                        M4 = GetAB(DK[2].Agent4, DE[2].M, DE[2].J),
                        M5 = GetAB(DK[2].Agent5, DE[2].M, DE[2].J),
                        M6 = GetAB(DK[2].Agent6, DE[2].M, DE[2].J),
                    });
                if (Stage == Common.Stage.第三阶段.ToString())
                    result.Add(3, new MJA
                    {
                        M1 = GetAB(DK[3].Agent1, DE[3].M, DE[3].J),
                        M2 = GetAB(DK[3].Agent2, DE[3].M, DE[3].J),
                        M3 = GetAB(DK[3].Agent3, DE[3].M, DE[3].J),
                        M4 = GetAB(DK[3].Agent4, DE[3].M, DE[3].J),
                        M5 = GetAB(DK[3].Agent5, DE[3].M, DE[3].J),
                        M6 = GetAB(DK[3].Agent6, DE[3].M, DE[3].J),
                    });
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
                var result = new Dictionary<int, MJA>();
                result.Add(1, new MJA
                {
                    J1 = GetAT(DK[1].Agent1, DE[1].M, DE[1].J),
                    J2 = GetAT(DK[1].Agent2, DE[1].M, DE[1].J),
                    J3 = GetAT(DK[1].Agent3, DE[1].M, DE[1].J),
                    J4 = GetAT(DK[1].Agent4, DE[1].M, DE[1].J),
                    J5 = GetAT(DK[1].Agent5, DE[1].M, DE[1].J),
                    J6 = GetAT(DK[1].Agent6, DE[1].M, DE[1].J),
                });
                if (Stage == Common.Stage.第二阶段.ToString() || Stage == Common.Stage.第三阶段.ToString())
                    result.Add(2, new MJA
                    {
                        J1 = GetAT(DK[2].Agent1, DE[2].M, DE[2].J),
                        J2 = GetAT(DK[2].Agent2, DE[2].M, DE[2].J),
                        J3 = GetAT(DK[2].Agent3, DE[2].M, DE[2].J),
                        J4 = GetAT(DK[2].Agent4, DE[2].M, DE[2].J),
                        J5 = GetAT(DK[2].Agent5, DE[2].M, DE[2].J),
                        J6 = GetAT(DK[2].Agent6, DE[2].M, DE[2].J),
                    });
                if (Stage == Common.Stage.第三阶段.ToString())
                    result.Add(3, new MJA
                    {
                        J1 = GetAT(DK[3].Agent1, DE[3].M, DE[3].J),
                        J2 = GetAT(DK[3].Agent2, DE[3].M, DE[3].J),
                        J3 = GetAT(DK[3].Agent3, DE[3].M, DE[3].J),
                        J4 = GetAT(DK[3].Agent4, DE[3].M, DE[3].J),
                        J5 = GetAT(DK[3].Agent5, DE[3].M, DE[3].J),
                        J6 = GetAT(DK[3].Agent6, DE[3].M, DE[3].J),
                    });
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
                var result = new Dictionary<int, MJA>();
                result.Add(1, new MJA
                {
                    Agent1 = GetBL(DK[1].Agent1, DE[1].M, DE[1].J),
                    Agent2 = GetBL(DK[1].Agent2, DE[1].M, DE[1].J),
                    Agent3 = GetBL(DK[1].Agent3, DE[1].M, DE[1].J),
                    Agent4 = GetBL(DK[1].Agent4, DE[1].M, DE[1].J),
                    Agent5 = GetBL(DK[1].Agent5, DE[1].M, DE[1].J),
                    Agent6 = GetBL(DK[1].Agent6, DE[1].M, DE[1].J),
                });
                if (Stage == Common.Stage.第二阶段.ToString() || Stage == Common.Stage.第三阶段.ToString())

                    result.Add(2, new MJA
                    {
                        Agent1 = GetBL(DK[2].Agent1, DE[2].M, DE[2].J),
                        Agent2 = GetBL(DK[2].Agent2, DE[2].M, DE[2].J),
                        Agent3 = GetBL(DK[2].Agent3, DE[2].M, DE[2].J),
                        Agent4 = GetBL(DK[2].Agent4, DE[2].M, DE[2].J),
                        Agent5 = GetBL(DK[2].Agent5, DE[2].M, DE[2].J),
                        Agent6 = GetBL(DK[2].Agent6, DE[2].M, DE[2].J),
                    });
                if (Stage == Common.Stage.第三阶段.ToString())
                    result.Add(3, new MJA
                    {
                        Agent1 = GetBL(DK[3].Agent1, DE[3].M, DE[3].J),
                        Agent2 = GetBL(DK[3].Agent2, DE[3].M, DE[3].J),
                        Agent3 = GetBL(DK[3].Agent3, DE[3].M, DE[3].J),
                        Agent4 = GetBL(DK[3].Agent4, DE[3].M, DE[3].J),
                        Agent5 = GetBL(DK[3].Agent5, DE[3].M, DE[3].J),
                        Agent6 = GetBL(DK[3].Agent6, DE[3].M, DE[3].J),
                    });
                return result;
            }
        }

        private decimal GetBL(decimal dk, decimal de, decimal df)
        {
            //=IF((1/3)*(($DE5/(DK5-(($DE5*1.05)-$DE5))+$DF5/(DK5-(($DE5*1.05)-($DE5*0.92))))/2)*(1-(IF(DK5/($DE5*1.05)<1.01,(DK5/($DE5*1.05)-1),IF(DK5/($DE5*1.05)<=1.03,(DK5/($DE5*1.05)-1)*3,IF(DK5/($DE5*1.05)<=1.05,(DK5/($DE5*1.05)-1)*6,IF(DK5/($DE5*1.05)<=1.1,(DK5/($DE5*1.05)-1)*12,IF(DK5/($DE5*1.05)<=1.2,(DK5/($DE5*1.05)-1)*18,IF(DK5/($DE5*1.05)<=1.3,(DK5/($DE5*1.05)-1)*24,(DK5/($DE5*1.05)-1)*30))))))))<-320%,-320%,(1/3)*(($DE5/(DK5-(($DE5*1.05)-$DE5))+$DF5/(DK5-(($DE5*1.05)-($DE5*0.92))))/2)*(1-(IF(DK5/($DE5*1.05)<1.01,(DK5/($DE5*1.05)-1),IF(DK5/($DE5*1.05)<=1.03,(DK5/($DE5*1.05)-1)*3,IF(DK5/($DE5*1.05)<=1.05,(DK5/($DE5*1.05)-1)*6,IF(DK5/($DE5*1.05)<=1.1,(DK5/($DE5*1.05)-1)*12,IF(DK5/($DE5*1.05)<=1.2,(DK5/($DE5*1.05)-1)*18,IF(DK5/($DE5*1.05)<=1.3,(DK5/($DE5*1.05)-1)*24,(DK5/($DE5*1.05)-1)*30)))))))))

            var t1 = (1 / 3m) * ((de / (dk - ((de * 1.05m) - de)) + df / (dk - ((de * 1.05m) - (de * 0.92m)))) / 2m);
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
                if (Stage == Common.Stage.第二阶段.ToString()||Stage==Common.Stage.第三阶段.ToString())
                    result.Add(2, GetVC(CM[2], CD[2]));
                if (Stage == Common.Stage.第三阶段.ToString())
                    result.Add(3, GetVC(CM[3], CD[3]));

                return result;
            }
        }
        private RC GetVC(RC CM,RC CD)
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

                var result = new Dictionary<int, MJA>();
                result.Add(1, new MJA
                {
                    M1 = AB[1].M1 + AT[1].J1 + BL[1].Agent1,
                    M2 = AB[1].M2 + AT[1].J2 + BL[1].Agent2,
                    M3 = AB[1].M3 + AT[1].J3 + BL[1].Agent3,
                    M4 = AB[1].M4 + AT[1].J4 + BL[1].Agent4,
                    M5 = AB[1].M5 + AT[1].J5 + BL[1].Agent5,
                    M6 = AB[1].M6 + AT[1].J6 + BL[1].Agent6,

                });
                if (Stage == Common.Stage.第二阶段.ToString() || Stage == Common.Stage.第三阶段.ToString())
                {
                    result.Add(2, new MJA
                    {
                        M1 = AB[2].M1 + AT[2].J1 + BL[2].Agent1,
                        M2 = AB[2].M2 + AT[2].J2 + BL[2].Agent2,
                        M3 = AB[2].M3 + AT[2].J3 + BL[2].Agent3,
                        M4 = AB[2].M4 + AT[2].J4 + BL[2].Agent4,
                        M5 = AB[2].M5 + AT[2].J5 + BL[2].Agent5,
                        M6 = AB[2].M6 + AT[2].J6 + BL[2].Agent6,

                    });
                }
                if (Stage == Common.Stage.第三阶段.ToString())
                {
                    result.Add(3, new MJA
                    {
                        M1 = AB[3].M1 + AT[3].J1 + BL[3].Agent1,
                        M2 = AB[3].M2 + AT[3].J2 + BL[3].Agent2,
                        M3 = AB[3].M3 + AT[3].J3 + BL[3].Agent3,
                        M4 = AB[3].M4 + AT[3].J4 + BL[3].Agent4,
                        M5 = AB[3].M5 + AT[3].J5 + BL[3].Agent5,
                        M6 = AB[3].M6 + AT[3].J6 + BL[3].Agent6,

                    });

                   
                }
                return result;
            }
        }
    }
}