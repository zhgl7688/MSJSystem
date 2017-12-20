﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.BLL
{

    public class CurrentShare
    {

        List<CurrentShareTable> currentShares = new List<CurrentShareTable>();
        List<IntentionIndexTable> intentionIndexs;

        List<PriceControlTable> priceControlTables;
        AgentStages agentStage;
        /// <summary>
        /// 市场容量及各品牌当年占有率
        /// </summary>  
        public CurrentShare(IntentionIndex intentionIndex, PriceControl priceControl)
        {
            agentStage = new AgentStages();
            intentionIndexs = intentionIndex.Get();
            priceControlTables = priceControl.Get();
            Init();
        }

        public void Init()
        {
            List<CurrentShareInit> currentShareInits;
            using (var db = new AppIdentityDbContext())
            {
                currentShareInits = db.CurrentShareInit.ToList();
            }
            var firstInit = currentShareInits.FirstOrDefault(s => s.G == agentStage.stages[0]);
            var current0 = new CurrentShareTable { A = "", B = "", C = "", D = firstInit.D, E = firstInit.E, Stage = agentStage.stages[0] };
            //  current0.H[1] = new MJA { M1 = 0.45m, M2 = 0.45m, M3 = 0.45m, M4 = 0.45m, M5 = 0.45m, M6 = 0.45m, };
            // current0.Z[1] = new MJA { J1 = 0.25m, J2 = 0.25m, J3 = 0.25m, J4 = 0.25m, J5 = 0.25m, J6 = 0.25m, };
            // current0.AR[1] = new MJA { Agent1 = 0.3m, Agent2 = 0.3m, Agent3 = 0.3m, Agent4 = 0.3m, Agent5 = 0.3m, Agent6 = 0.3m, };

            current0.H.Add(0,new MJA());
            current0.Z.Add(0, new MJA());
            current0.AR.Add(0, new MJA());

            for (int i = 0; i < agentStage.agents.Count; i++)
            {
                current0.H[0].M.Add(firstInit.H);
                current0.Z[0].M.Add(firstInit.Z);
                current0.AR[0].M.Add(firstInit.AR);
            }

            currentShares.Add(current0);
            foreach (var item in intentionIndexs)
            {
                var currentShare = currentShares.FirstOrDefault(s => s.Stage == item.Stage);
                if (currentShare == null)
                {
                    var result = currentShareInits.FirstOrDefault(s => s.G == item.Stage);
                    currentShare = new CurrentShareTable { D = result.D, E = result.E, Stage = item.Stage };

                    //if (item.Stage ==agentStage.stages[1])
                    //{
                    //    currentShare = new CurrentShareTable { A = "M≤659", B = "S≤699", C = "J≤599", D = 100, E = 90, Stage = Stage.第一阶段.ToString() };

                    //}
                    //else if (item.Stage == agentStage.stages[2])
                    //{

                    //    currentShare = new CurrentShareTable { A = "659<M≤799", B = "699<S≤845", C = "599<J≤739", D = 80, E = 105, Stage = Stage.第二阶段.ToString() };

                    //}
                    //else if (item.Stage == agentStage.stages[3])
                    //{

                    //    currentShare = new CurrentShareTable { A = "M>799", B = "S>845", C = "J>739", D = 50, E = 98, Stage = Stage.第三阶段.ToString() };

                    //}

                    currentShares.Add(currentShare);
                }

                var ss = item.B;
                currentShare.H = item.B;
                currentShare.Z = item.T;
                currentShare.AR = item.AL;


                var curretnpriceControl = priceControlTables.FirstOrDefault(s => s.Stage == item.Stage);
                var DE = new Dictionary<int, RC>(); var DK = new Dictionary<int, MJA>();
                var index = agentStage.stages.IndexOf(item.Stage);
                if (index > 0)
                {
                    DE.Add(index, new RC { M = curretnpriceControl.B.RcM[index - 1], J = curretnpriceControl.B.RcJ[index - 1] });

                    //DK.Add(1, new MJA { Agent1 = curretnpriceControl.D[1].Agent1, Agent2 = curretnpriceControl.D[1].Agent2, Agent3 = curretnpriceControl.D[1].Agent3, Agent4 = curretnpriceControl.D[1].Agent4, Agent5 = curretnpriceControl.D[1].Agent5, Agent6 = curretnpriceControl.D[1].Agent6 });
                    DK.Add(index, new MJA { Agent = curretnpriceControl.D[index].Agent });
                }
                //DE.Add(1, new RC { M = curretnpriceControl.B.RcM[0], J = curretnpriceControl.B.RcJ[0] });

                ////DK.Add(1, new MJA { Agent1 = curretnpriceControl.D[1].Agent1, Agent2 = curretnpriceControl.D[1].Agent2, Agent3 = curretnpriceControl.D[1].Agent3, Agent4 = curretnpriceControl.D[1].Agent4, Agent5 = curretnpriceControl.D[1].Agent5, Agent6 = curretnpriceControl.D[1].Agent6 });
                //DK.Add(1,new MJA { Agent = curretnpriceControl.D[1].Agent });


                //if ((item.Stage == Stage.第二阶段.ToString() || item.Stage == Stage.第三阶段.ToString()))
                //{
                //    DE.Add(2, new RC { M = curretnpriceControl.B.RcM[1], J = curretnpriceControl.B.RcJ[1] });
                //   // DK.Add(2, new MJA { Agent1 = curretnpriceControl.D[2].Agent1, Agent2 = curretnpriceControl.D[2].Agent2, Agent3 = curretnpriceControl.D[2].Agent3, Agent4 = curretnpriceControl.D[2].Agent4, Agent5 = curretnpriceControl.D[2].Agent5, Agent6 = curretnpriceControl.D[2].Agent6 });
                //    DK.Add(2, new MJA { Agent = curretnpriceControl.D[2].Agent});

                //}
                //if (item.Stage == Stage.第三阶段.ToString())
                //{
                //    DE.Add(3, new RC { M = curretnpriceControl.B.RcM[2], J = curretnpriceControl.B.RcJ[2] });
                //    //DK.Add(3, new MJA { Agent1 = curretnpriceControl.D[3].Agent1, Agent2 = curretnpriceControl.D[3].Agent2, Agent3 = curretnpriceControl.D[3].Agent3, Agent4 = curretnpriceControl.D[3].Agent4, Agent5 = curretnpriceControl.D[3].Agent5, Agent6 = curretnpriceControl.D[3].Agent6 });
                //    DK.Add(3, new MJA { Agent = curretnpriceControl.D[3].Agent });
                //}
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
        public Dictionary<int, MJA> H { get; set; }=new Dictionary<int, MJA>();
  
        public Dictionary<int, MJA> Z { get; set; }= new Dictionary<int, MJA>();
        public Dictionary<int, MJA> AR { get; set; }= new Dictionary<int, MJA>();
        public Dictionary<int, MJA> BJ
        {
            get
            {
                var result = new Dictionary<int, MJA>();
                var index = new AgentStages().stages.IndexOf(this.Stage);
                if (index == 0)
                {
                    var m = new List<decimal>();
                    for (int i = 0; i < H[1].M.Count; i++)
                    {
                        m.Add(D * F * H[1].M[i]);
                    }
                    result[1] = new MJA { M = m };
                    //result[1] = new MJA()
                    //{
                    //    M1 = D * F * H[1].M1,
                    //    M2 = D * F * H[1].M2,
                    //    M3 = D * F * H[1].M3,
                    //    M4 = D * F * H[1].M4,
                    //    M5 = D * F * H[1].M5,
                    //    M6 = D * F * H[1].M6
                    //};
                }
                else
                {
                    for (int i = 1; i < index + 1; i++)
                    {
                        result[i] = Cal_MJA_M(H[i], Static_D, F, DE[i].M);
                    }

                }
                //result.Add(1, new MJA { });
                //result.Add(2, new MJA { });
                //result.Add(3, new MJA { });
                //Stage stage;
                //if (Enum.TryParse<Stage>(this.Stage, out stage))
                //{
                //    switch (stage)
                //    {
                //        case Common.Stage.起始阶段:
                //            result[1] = new MJA()
                //            {
                //                M1 = D * F * H[1].M1,
                //                M2 = D * F * H[1].M2,
                //                M3 = D * F * H[1].M3,
                //                M4 = D * F * H[1].M4,
                //                M5 = D * F * H[1].M5,
                //                M6 = D * F * H[1].M6
                //            };
                //            break;
                //        case Common.Stage.第一阶段:
                //            result[1] = Cal_MJA_M(H[1], Static_D, F, DE[1].M);
                //            break;
                //        case Common.Stage.第二阶段:
                //            result[1] = Cal_MJA_M(H[1], Static_D, F, DE[1].M);
                //            result[2] = Cal_MJA_M(H[2], Static_D, F, DE[2].M);
                //            break;
                //        case Common.Stage.第三阶段:
                //            result[1] = Cal_MJA_M(H[1], Static_D, F, DE[1].M);
                //            result[2] = Cal_MJA_M(H[2], Static_D, F, DE[2].M);
                //            result[3] = Cal_MJA_M(H[3], Static_D, F, DE[3].M);
                //            break;
                //    }
                //}


                return result;
            }
        }


        public Dictionary<int, MJA> CB
        {
            get
            {
                var result = new Dictionary<int, MJA>();
                //result.Add(1, new MJA { });
                //result.Add(2, new MJA { });
                //result.Add(3, new MJA { });
                var index = new AgentStages().stages.IndexOf(this.Stage);
                if (index == 0)//起始阶段
                {
                    var j = new List<decimal>();
                    for (int i = 0; i < Z[1].J.Count; i++)
                    {
                        j.Add(D * F * Z[1].J[i]);
                    }
                    result[1] = new MJA { J = j };
                    //result[1] = new MJA {
                    //    J1 = D * F * Z[1].J1,
                    //    J2 = D * F * Z[1].J2,
                    //    J3 = D * F * Z[1].J3,
                    //    J4 = D * F * Z[1].J4,
                    //    J5 = D * F * Z[1].J5,
                    //    J6 = D * F * Z[1].J6, };

                }
                else
                {
                    for (int i = 1; i < index+1; i++)
                    {
                        result[i] = Cal_MJA_J(Z[i], Static_D, F, DE[i].J);
                     }
                }
                //Stage stage;
                //if (Enum.TryParse<Stage>(this.Stage, out stage))
                //{
                //    switch (stage)
                //    {
                //        case Common.Stage.起始阶段:
                //            result[1] = new MJA { J1 = D * F * Z[1].J1, J2 = D * F * Z[1].J2, J3 = D * F * Z[1].J3, J4 = D * F * Z[1].J4, J5 = D * F * Z[1].J5, J6 = D * F * Z[1].J6, };
                //            break;
                //        case Common.Stage.第一阶段:
                //            result[1] = Cal_MJA_J(Z[1], Static_D, F, DE[1].J);
                //            break;
                //        case Common.Stage.第二阶段:
                //            result[1] = Cal_MJA_J(Z[1], Static_D, F, DE[1].J);
                //            result[2] = Cal_MJA_J(Z[2], Static_D, F, DE[2].J);
                //            break;
                //        case Common.Stage.第三阶段:
                //            result[1] = Cal_MJA_J(Z[1], Static_D, F, DE[1].J);
                //            result[2] = Cal_MJA_J(Z[2], Static_D, F, DE[2].J);
                //            result[3] = Cal_MJA_J(Z[3], Static_D, F, DE[3].J);
                //            break;
                //    }
                //}

                return result;
            }
        }
        public Dictionary<int, MJA> CT
        {
            get
            {
                var result = new Dictionary<int, MJA>();
                //result.Add(1, new MJA { });
                //result.Add(2, new MJA { });
                //result.Add(3, new MJA { });
                var index = new AgentStages().stages.IndexOf(this.Stage);
                if (index == 0)//起始阶段
                {
                    var agent = new List<decimal>();
                    for (int i = 0; i < Z[1].J.Count; i++)
                    {
                        agent.Add(D * F * AR[1].Agent[i]);
                    }
                    result[1] = new MJA { Agent = agent };
                    //result[1] = new MJA {
                    //    J1 = D * F * Z[1].J1,
                    //    J2 = D * F * Z[1].J2,
                    //    J3 = D * F * Z[1].J3,
                    //    J4 = D * F * Z[1].J4,
                    //    J5 = D * F * Z[1].J5,
                    //    J6 = D * F * Z[1].J6, };

                }
                else
                {
                    for (int i = 1; i < index + 1; i++)
                    {
                        result[i] = Cal_MJA_Agent(AR[i], Static_D, F, DK[i]);
                    }
                }
                //var stage = (Stage)Enum.Parse(typeof(Stage), this.Stage);
                //switch (stage)
                //{
                //    case Common.Stage.起始阶段:
                //        result[1] = new MJA { Agent1 = D * F * AR[1].Agent1, Agent2 = D * F * AR[1].Agent2, Agent3 = D * F * AR[1].Agent3, Agent4 = D * F * AR[1].Agent4, Agent5 = D * F * AR[1].Agent5, Agent6 = D * F * AR[1].Agent6, };
                //        break;
                //    case Common.Stage.第一阶段:
                //        result[1] = Cal_MJA_Agent(AR[1], Static_D, F, DK[1]);
                //        break;
                //    case Common.Stage.第二阶段:
                //        result[1] = Cal_MJA_Agent(AR[1], Static_D, F, DK[1]);
                //        result[2] = Cal_MJA_Agent(AR[2], Static_D, F, DK[2]);
                //        break;
                //    case Common.Stage.第三阶段:
                //        result[1] = Cal_MJA_Agent(AR[1], Static_D, F, DK[1]);
                //        result[2] = Cal_MJA_Agent(AR[2], Static_D, F, DK[2]);
                //        result[3] = Cal_MJA_Agent(AR[3], Static_D, F, DK[3]);
                //        break;
                //}
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
            var m = new List<decimal>();
            for (int i = 0; i < mja.M.Count; i++)
            {
                m.Add(mja.M[i] * t);
            }
            result.M = m;
            //result.M1 = mja.M1 * t;
            //result.M2 = mja.M2 * t;
            //result.M3 = mja.M3 * t;
            //result.M4 = mja.M4 * t;
            //result.M5 = mja.M5 * t;
            //result.M6 = mja.M6 * t;
            return result;
        }
        public MJA Cal_MJA_J(MJA mja, decimal[] ds, decimal f, decimal de)
        {
            var result = new MJA();

            decimal d = de <= 599 ? ds[1] : de <= 739 ? ds[2] : ds[3];
            decimal t = d * f;
            var j = new List<decimal>();
            for (int i = 0; i < mja.J.Count; i++)
            {
                j.Add(mja.J[i] * t);
            }
            result.J = j;
            //result.J1 = mja.J1 * t;
            //result.J2 = mja.J2 * t;
            //result.J3 = mja.J3 * t;
            //result.J4 = mja.J4 * t;
            //result.J5 = mja.J5 * t;
            //result.J6 = mja.J6 * t;
            return result;
        }
        public MJA Cal_MJA_Agent(MJA mja, decimal[] ds, decimal f, MJA de)
        {
            var result = new MJA();
            for (int i = 0; i < mja.Agent.Count; i++)
            {
                result.Agent.Add(mja.Agent[i] * f * (de.Agent[i] <= 699 ? ds[1] : de.Agent[i] <= 845 ? ds[2] : ds[3]));
            }
            //return new MJA
            //{
            //    Agent1 = mja.Agent1 * f * (de.Agent1 <= 699 ? ds[1] : de.Agent1 <= 845 ? ds[2] : ds[3]),
            //    Agent2 = mja.Agent2 * f * (de.Agent2 <= 699 ? ds[1] : de.Agent2 <= 845 ? ds[2] : ds[3]),
            //    Agent3 = mja.Agent3 * f * (de.Agent3 <= 699 ? ds[1] : de.Agent3 <= 845 ? ds[2] : ds[3]),
            //    Agent4 = mja.Agent4 * f * (de.Agent4 <= 699 ? ds[1] : de.Agent4 <= 845 ? ds[2] : ds[3]),
            //    Agent5 = mja.Agent5 * f * (de.Agent5 <= 699 ? ds[1] : de.Agent5 <= 845 ? ds[2] : ds[3]),
            //    Agent6 = mja.Agent6 * f * (de.Agent6 <= 699 ? ds[1] : de.Agent6 <= 845 ? ds[2] : ds[3]),
            //};
            return result;

        }



    }
}