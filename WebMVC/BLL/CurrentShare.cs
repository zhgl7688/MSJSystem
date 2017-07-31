using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    /// <summary>
    /// 市场容量及各品牌当年占有率
    /// </summary>
    public class CurrentShare
    {

        List<CurrentShareTable> currentShares = new List<CurrentShareTable>();
        List<IntentionIndexTable> intentionIndexs;
        public CurrentShare()
        {
            intentionIndexs = new IntentionIndex().Get();
        }
        public void Init()
        {

            var current0 = new CurrentShareTable { A = "", B = "", C = "", D = 100, E = 100, Stage = Stage.起始阶段.ToString() };
            current0.H.Add(1, new MJA { M1 = 0.45m, M2 = 0.45m, M3 = 0.45m, M4 = 0.45m, M5 = 0.45m, M6 = 0.45m, });
            current0.Z.Add(1, new MJA { J1 = 0.25m, J2 = 0.25m, J3 = 0.25m, J4 = 0.25m, J5 = 0.25m, J6 = 0.25m, });
            current0.AR.Add(1, new MJA { Agent1 = 0.3m, Agent2 = 0.3m, Agent3 = 0.3m, Agent4 = 0.3m, Agent5 = 0.3m, Agent6 = 0.3m, });

            currentShares.Add(current0);
            currentShares.Add(new CurrentShareTable { A = "M≤659", B = "S≤699", C = "J≤599", D = 100, E = 90, Stage = Stage.第一阶段.ToString() });
            currentShares.Add(new CurrentShareTable { A = "659<M≤799", B = "699<S≤845", C = "599<J≤739", D = 80, E = 105, Stage = Stage.第二阶段.ToString() });
            currentShares.Add(new CurrentShareTable { A = "M>799", B = "S>845", C = "J>739", D = 50, E = 98, Stage = Stage.第三阶段.ToString() });
            foreach (var item in intentionIndexs)
            {
                var currentShare = currentShares.FirstOrDefault(s => s.Stage == item.Stage);
                var ss = item.B;
                currentShare.H.Add(1, item.B);
                currentShare.H.Add(2, item.H);
                currentShare.H.Add(3, item.N);
                currentShare.Z.Add(1, item.T);
                currentShare.Z.Add(2, item.Z);
                currentShare.Z.Add(3, item.AF);
                currentShare.AR.Add(1, item.AL);
                currentShare.AR.Add(2, item.AR);
                currentShare.AR.Add(3, item.AX);




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
                    result.Add(2, Cal_MJA_M(H[2], Static_D, F, DE[2].M));
                    result.Add(3, Cal_MJA_M(H[3], Static_D, F, DE[3].M));
                }
                return result;
            }
        }
        public Dictionary<int, RC> DE { get; set; }

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
                    result.Add(2, Cal_MJA_J(Z[2], Static_D, F, DE[2].J));
                    result.Add(3, Cal_MJA_J(Z[3], Static_D, F, DE[3].J));
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
                    result.Add(2, Cal_MJA_Agent(AR[2], Static_D, F, DK[2]));
                    result.Add(3, Cal_MJA_Agent(AR[3], Static_D, F, DK[3]));
                }
                return result;
            }
        }
        public Dictionary<int, MJA> DK { get; set; }

        public MJA Cal_MJA_M(MJA mja, decimal[] ds, decimal f, decimal de)
        {
            decimal d = de <= 659 ? ds[1] : de <= 799 ? ds[2] : ds[3];
            decimal t = d * f;
            mja.M1 *= t;
            mja.M2 *= t;
            mja.M3 *= t;
            mja.M4 *= t;
            mja.M5 *= t;
            mja.M6 *= t;
            return mja;
        }
        public MJA Cal_MJA_J(MJA mja, decimal[] ds, decimal f, decimal de)
        {
            decimal d = de <= 599 ? ds[1] : de <= 739 ? ds[2] : ds[3];
            decimal t = d * f;
            mja.J1 *= t;
            mja.J2 *= t;
            mja.J3 *= t;
            mja.J4 *= t;
            mja.J5 *= t;
            mja.J6 *= t;
            return mja;
        }
        public MJA Cal_MJA_Agent(MJA mja, decimal[] ds, decimal f, MJA de)
        {
            mja.Agent1 *= de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3] * f;
            mja.Agent2 *= de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3] * f;
            mja.Agent3 *= de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3] * f;
            mja.Agent4 *= de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3] * f;
            mja.Agent5 *= de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3] * f;
            mja.Agent6 *= de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3] * f;
            return mja;
        }



    }
}