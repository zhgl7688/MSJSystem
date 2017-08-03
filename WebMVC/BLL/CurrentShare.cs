﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{

    public class CurrentShare
    {

        List<CurrentShareTable> currentShares = new List<CurrentShareTable>();
        List<IntentionIndexTable> intentionIndexs;

        List<PriceControlTable> priceControlTables;
        /// <summary>
        /// 市场容量及各品牌当年占有率
        /// </summary>  
        public CurrentShare()
        {
            intentionIndexs = new IntentionIndex().Get();
            priceControlTables = new PriceControl().Get();
            Init();
        }

        public void Init()
        {

            var current0 = new CurrentShareTable { A = "", B = "", C = "", D = 100, E = 100, Stage = Stage.起始阶段.ToString() };
            current0.H.Add(1, new MJA { M1 = 0.45m, M2 = 0.45m, M3 = 0.45m, M4 = 0.45m, M5 = 0.45m, M6 = 0.45m, });
            current0.Z.Add(1, new MJA { J1 = 0.25m, J2 = 0.25m, J3 = 0.25m, J4 = 0.25m, J5 = 0.25m, J6 = 0.25m, });
            current0.AR.Add(1, new MJA { Agent1 = 0.3m, Agent2 = 0.3m, Agent3 = 0.3m, Agent4 = 0.3m, Agent5 = 0.3m, Agent6 = 0.3m, });

            currentShares.Add(current0);
            foreach (var item in intentionIndexs)
            {


                var currentShare = currentShares.FirstOrDefault(s => s.Stage == item.Stage);
                if (currentShare == null)
                {
                    if (item.Stage == Stage.第一阶段.ToString())
                    {
                        currentShare = new CurrentShareTable { A = "M≤659", B = "S≤699", C = "J≤599", D = 100, E = 90, Stage = Stage.第一阶段.ToString() };

                    }
                    else if (item.Stage == Stage.第二阶段.ToString())
                    {

                        currentShare = new CurrentShareTable { A = "659<M≤799", B = "699<S≤845", C = "599<J≤739", D = 80, E = 105, Stage = Stage.第二阶段.ToString() };

                    }
                    else if (item.Stage == Stage.第三阶段.ToString())
                    {

                        currentShare = new CurrentShareTable { A = "M>799", B = "S>845", C = "J>739", D = 50, E = 98, Stage = Stage.第三阶段.ToString() };

                    }

                    currentShares.Add(currentShare);
                }

                var ss = item.B;
                currentShare.H = item.B;
                currentShare.Z = item.T;
                currentShare.AR = item.AL;


                var curretnpriceControl = priceControlTables.FirstOrDefault(s => s.Stage == item.Stage);
                var DE = new Dictionary<int, RC>(); var DK = new Dictionary<int, MJA>();
                DE.Add(1, new RC { M = curretnpriceControl.B.RC1M, J = curretnpriceControl.B.RC1J });
                DK.Add(1, new MJA { Agent1 = curretnpriceControl.D[1].Agent1, Agent2 = curretnpriceControl.D[1].Agent2, Agent3 = curretnpriceControl.D[1].Agent3, Agent4 = curretnpriceControl.D[1].Agent4, Agent5 = curretnpriceControl.D[1].Agent5, Agent6 = curretnpriceControl.D[1].Agent6 });
                if ((item.Stage == Stage.第二阶段.ToString() || item.Stage == Stage.第三阶段.ToString()))
                {
                    DE.Add(2, new RC { M = curretnpriceControl.B.RC2M, J = curretnpriceControl.B.RC2J });
                    DK.Add(2, new MJA { Agent1 = curretnpriceControl.D[2].Agent1, Agent2 = curretnpriceControl.D[2].Agent2, Agent3 = curretnpriceControl.D[2].Agent3, Agent4 = curretnpriceControl.D[2].Agent4, Agent5 = curretnpriceControl.D[2].Agent5, Agent6 = curretnpriceControl.D[2].Agent6 });

                }
                if (item.Stage == Stage.第三阶段.ToString())
                {
                    DE.Add(3, new RC { M = curretnpriceControl.B.RC3M, J = curretnpriceControl.B.RC3J });
                    DK.Add(3, new MJA { Agent1 = curretnpriceControl.D[3].Agent1, Agent2 = curretnpriceControl.D[3].Agent2, Agent3 = curretnpriceControl.D[3].Agent3, Agent4 = curretnpriceControl.D[3].Agent4, Agent5 = curretnpriceControl.D[3].Agent5, Agent6 = curretnpriceControl.D[3].Agent6 });
                }
                currentShare.DE = DE;
                currentShare.DK = DK;



            }
        }
        public List<CurrentShareTable> Get()
        {

            return currentShares;
        }
    }
    public class CurrentShareTable
    {

        decimal[] Static_D = { 100, 100, 80, 50 };
        decimal[] Static_E = { 100, 90, 105, 98 };
        decimal[] Static_F = { 1, 0.9m, 1.05m, 0.98m };
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public decimal D { get; set; }
        public decimal E { get; set; }
        public decimal F
        {
            get
            {
                return E / 100;
            }
        }

        public string Stage { get; set; }
        public Dictionary<int, MJA> H { get; set; } = new Dictionary<int, MJA>();
        public Dictionary<int, MJA> Z { get; set; } = new Dictionary<int, MJA>();
        public Dictionary<int, MJA> AR { get; set; } = new Dictionary<int, MJA>();
        public Dictionary<int, MJA> BJ
        {
            get
            {
                var result = new Dictionary<int, MJA>();
                if (Stage == Common.Stage.起始阶段.ToString())
                {
                    result.Add(1, new MJA { M1 = 45, M2 = 45, M3 = 45, M4 = 45, M5 = 45, M6 = 45 });
                }
                else
                {
                    result.Add(1, Cal_MJA_M(H[1], Static_D, F, DE[1].M));
                    if (Stage == Common.Stage.第二阶段.ToString() || Stage == Common.Stage.第三阶段.ToString())

                        result.Add(2, Cal_MJA_M(H[2], Static_D, F, DE[2].M));
                    else result.Add(2, new MJA());
                    if (Stage == Common.Stage.第三阶段.ToString())

                        result.Add(3, Cal_MJA_M(H[3], Static_D, F, DE[3].M));
                    else result.Add(3, new MJA());
                }
                return result;
            }
        }


        public Dictionary<int, MJA> CB
        {
            get
            {
                var result = new Dictionary<int, MJA>();
                if (this.Stage == Common.Stage.起始阶段.ToString())
                {
                    result.Add(1, new MJA { J1 = D * F * Z[1].J1, J2 = D * F * Z[1].J2, J3 = D * F * Z[1].J3, J4 = D * F * Z[1].J4, J5 = D * F * Z[1].J5, J6 = D * F * Z[1].J6, });
                }
                else
                {
                    result.Add(1, Cal_MJA_J(Z[1], Static_D, F, DE[1].J));
                    if (Stage == Common.Stage.第二阶段.ToString() || Stage == Common.Stage.第三阶段.ToString())
                        result.Add(2, Cal_MJA_J(Z[2], Static_D, F, DE[2].J));
                    else result.Add(2, new MJA());
                    if (Stage == Common.Stage.第三阶段.ToString())
                        result.Add(3, Cal_MJA_J(Z[3], Static_D, F, DE[3].J));
                    else result.Add(3, new MJA());
                }
                return result;
            }
        }
        public Dictionary<int, MJA> CT
        {
            get
            {
                var result = new Dictionary<int, MJA>();
                if (this.Stage == Common.Stage.起始阶段.ToString())
                {
                    result.Add(1, new MJA { Agent1 = D * F * AR[1].Agent1, Agent2 = D * F * Z[1].Agent2, Agent3 = D * F * Z[1].Agent3, Agent4 = D * F * Z[1].Agent4, Agent5 = D * F * Z[1].Agent5, Agent6 = D * F * Z[1].Agent6, });
                }
                else
                {
                    result.Add(1, Cal_MJA_Agent(AR[1], Static_D, F, DK[1]));
                    if (Stage == Common.Stage.第二阶段.ToString() || Stage == Common.Stage.第三阶段.ToString())
                        result.Add(2, Cal_MJA_Agent(AR[2], Static_D, F, DK[2]));
                    else result.Add(2, new MJA());
                    if (Stage == Common.Stage.第三阶段.ToString())
                        result.Add(3, Cal_MJA_Agent(AR[3], Static_D, F, DK[3]));
                    else result.Add(3, new MJA());
                }
                return result;
            }
        }
        public Dictionary<int, RC> DE { get; set; } = new Dictionary<int, RC>();
        public Dictionary<int, MJA> DK { get; set; } = new Dictionary<int, MJA>();

        public MJA Cal_MJA_M(MJA mja, decimal[] ds, decimal f, decimal de)
        {
            var result = new MJA();
            decimal d = de <= 659 ? ds[1] : de <= 799 ? ds[2] : ds[3];
            decimal t = d * f;
           result.M1=mja.M1 *  t;
           result.M2=mja.M2 *  t;
           result.M3=mja.M3 *  t;
           result.M4=mja.M4 *  t;
           result.M5=mja.M5 *  t;
           result.M6=mja.M6 *  t;
            return result;
        }
        public MJA Cal_MJA_J(MJA mja, decimal[] ds, decimal f, decimal de)
        {
            var result = new MJA();
            decimal d = de <= 599 ? ds[1] : de <= 739 ? ds[2] : ds[3];
            decimal t = d * f;
            result.J1 = mja.J1 * t;
            result.J2 = mja.J2 * t;
            result.J3 = mja.J3 * t;
            result.J4 = mja.J4 * t;
            result.J5 = mja.J5 * t;
            result.J6 = mja.J6 * t;
            return result;
        }
        public MJA Cal_MJA_Agent(MJA mja, decimal[] ds, decimal f, MJA de)
        {
            return new MJA
            {
                Agent1 = mja.Agent1 * f * (de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3]),
                Agent2 = mja.Agent1 * f * (de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3]),
                Agent3 = mja.Agent1 * f * (de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3]),
                Agent4 = mja.Agent1 * f * (de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3]),
                Agent5 = mja.Agent1 * f * (de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3]),
                Agent6 = mja.Agent1 * f * (de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3]),
            };


        }



    }
}