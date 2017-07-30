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

            }
        }
        public List<CurrentShareTable> Get()
        {

            return currentShares;
        }
    }
    public class CurrentShareTable
    {
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
        public Dictionary<int, MJA> BJ { get; set; } = new Dictionary<int, MJA>();
        public Dictionary<int, MJA> CB
        {
            get
            {
                var result = new Dictionary<int, MJA>();
                if (this.Stage == Common.Stage.起始阶段.ToString())
                {
                    result.Add(1, new MJA { J1 = D * F * Z[1].J1, J2 = D * F * Z[1].J2, J3 = D * F * Z[1].J3, J4 = D * F * Z[1].J4, J5 = D * F * Z[1].J5, J6 = D * F * Z[1].J6, });
                }
                return result;
            }
        }
        public Dictionary<int, MJA> CT { get; set; } = new Dictionary<int, MJA>();






    }
}