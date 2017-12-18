using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;
using WebMVC.Common;
using System.ComponentModel;

namespace WebMVC.BLL
{
    /// <summary>
    /// 投资表
    /// </summary>
    public class Investment
    {
        List<BrandTable> invertMentTable1;
        List<AgentInput> agentInputs;
        List<AgentTable> agents;
        List<StockReportTable> stockReports;
        AgentStages agentStage;
        public Investment(InvertmentTable1 InvertmentTable1, StockReport StockReport)
        {
            agentStage = new AgentStages();
            invertMentTable1 = InvertmentTable1.getBrandTable();
            agentInputs = InvertmentTable1.getAgentInputs();
            agents = InvertmentTable1.getAgents();
            stockReports = StockReport.Get();

            Init();
        }

        List<InvestmentTable> investments = new List<InvestmentTable>();
        private void Init()
        {
            foreach (var item in invertMentTable1)
            {
                var investment = investments.FirstOrDefault(s => s.Stage == item.Stage);
                if (investment == null)
                {
                    investment = new InvestmentTable { Stage = item.Stage };
                    agentStage.agents.ForEach(s =>
                    {
                        investment.AJ_SummaryAsserts.Add(0);
                    });
                    investments.Add(investment);

                }
                var indexStage = agentStage.stages.IndexOf(item.Stage);
                var surfaceRC = new SurfaceRC();
                var functionRC = new FunctionRC();
                var materialRC = new MaterialRC();
                for (int i = 0; i < indexStage; i++)
                {
                    surfaceRC.Surfacerc.Add(item.SurfaceRC[i]);
                    functionRC.Functionrc.Add(item.FunctionRC[i]);
                    materialRC.Material.Add(item.MaterialRC[i]);
                }

                Brand brand = (Brand)Enum.Parse(typeof(Brand), item.Brand);
                switch (brand)
                {
                    case Brand.M品牌:
                        investment.J = item.advertise;
                        investment.M = surfaceRC;
                        investment.N = functionRC;
                        investment.O = materialRC;
                        investment.V = item.brandInput;
                        investment.NewDevelopmentCostB = item.NewDevelopmentCost;
                        break;
                    case Brand.S品牌:
                        investment.K = item.advertise;
                        investment.P = surfaceRC;
                        investment.Q = functionRC;
                        investment.R = materialRC;
                        investment.NewDevelopmentCostC = item.NewDevelopmentCost;
                        break;
                    case Brand.J品牌:
                        investment.L = item.advertise;
                        investment.S = surfaceRC;
                        investment.T = functionRC;
                        investment.U = materialRC;
                        investment.AC = item.brandInput;
                        investment.NewDevelopmentCostD = item.NewDevelopmentCost;
                        break;
                    default:
                        break;
                }
                var agent = agents.FirstOrDefault(s => s.Stage == item.Stage);
                if (agent != null)
                {
                    investment.CLAgent = agent.Bagent;
                    //investment.CL = agent.B;
                    //investment.CT = agent.J;
                    //investment.DB = agent.R;
                    //investment.DJ = agent.Z;
                    //investment.DR = agent.AH;
                    //investment.DZ = agent.AP;
                }

            }

            foreach (var item in investments)
            {
                var agentInputList = agentInputs.Where(s => s.Stage == item.Stage).ToList();
                agentInputList.ForEach(s =>
                {
                    var ss = agentStage.agents.IndexOf(s.AgentName);
                    item.EI[ss] = s.bankLoan;
                });

            }
            foreach (var item in stockReports)
            {
                var index = agentStage.stages.FindIndex(s => s == item.Stage);//(int)Enum.Parse(typeof(Stage), item.Stage);
                if (index == agentStage.stages.Count - 1) continue;
                var investment = investments.FirstOrDefault(s => s.Stage == agentStage.stages[index + 1]);// Enum.GetName(typeof(Stage), index + 1));
                if (investment == null)
                {
                    continue;
                }
                index = agentStage.agents.IndexOf(item.AgentName);
                investment.AJ_SummaryAsserts[index] = item.Sum.Sum;
                //var index = (int)Enum.Parse(typeof(Stage), item.Stage);
                //var investment = investments.FirstOrDefault(s => s.Stage == Enum.GetName(typeof(Stage), index + 1));

                //AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                //switch (agentName)
                //{
                //    case AgentName.代1:
                //        investment.AJ_SummaryAssert = item.Sum.Sum;
                //        break;
                //    case AgentName.代2:
                //        investment.AS_SummaryAssert = item.Sum.Sum;
                //        break;
                //    case AgentName.代3:
                //        investment.BB_SummaryAssert = item.Sum.Sum;
                //        break;
                //    case AgentName.代4:
                //        investment.BK_SummaryAssert = item.Sum.Sum;
                //        break;
                //    case AgentName.代5:
                //        investment.BT_SummaryAssert = item.Sum.Sum;
                //        break;
                //    case AgentName.代6:
                //        investment.CC_SummaryAssert = item.Sum.Sum;
                //        break;
                //    default:
                //        break;
                //}

            }
            investments.ForEach(s => s.ItCAL());
        }


        public List<InvestmentTable> Get()
        {
            return investments;
        }
    }

    public class InvestmentTable
    {
        public InvestmentTable()
        {
            EI = new Dictionary<int, decimal>();
            var agentStages = new AgentStages();
            for (int i = 0; i < agentStages.agents.Count; i++)
            {
                EI.Add(i + 1, 0);
            }
            //EI.Add(1, 0);
            //EI.Add(2, 0);
            //EI.Add(3, 0);
            //EI.Add(4, 0);
            //EI.Add(5, 0);
            //EI.Add(6, 0);

        }
        [DisplayName("阶段")]
        public string Stage { get; set; }
        //[DisplayName("M投入")]
        //=J11+O11+R11+U11+AN11+AO11+AP11+AQ11+AR11+AS11+AT11+开发费用表!B4
        public decimal B { get { return J + M.SurfaceRCSum + N.FunctionRCSum + O.MaterialRCSum + V.InputSum + NewDevelopmentCostB; } }
        public decimal NewDevelopmentCostB { get; set; }
        public decimal PQRNew
        {
            get { return P.SurfaceRCSum + Q.FunctionRCSum + R.MaterialRCSum + NewDevelopmentCostC; }
        }
        //[DisplayName("对代1投入")]
        public List<decimal> CAgents
        {
            get
            {
                var result = new List<decimal>();
                for (int i = 0; i < AJAgent.Count; i++)
                {
                    result.Add(K + PQRNew + AJAgent[i].InputSum);
                }
                return result;
            }

        }


        //public decimal C { get { return K + PQRNew + AJ.InputSum; } }
        ////[DisplayName("对代2投入")]
        //public decimal D { get { return K + PQRNew + AS.InputSum; } }
        ////[DisplayName("对代3投入")]
        //public decimal E { get { return K + PQRNew + BB.InputSum; } }
        ////[DisplayName("对代4投入")]
        //public decimal F { get { return K + PQRNew + BK.InputSum; } }
        ////[DisplayName("对代5投入")]
        //public decimal G { get { return K + PQRNew + BT.InputSum; } }
        ////[DisplayName("对代6投入")]
        //public decimal H { get { return K + PQRNew + CC.InputSum; } }
        //[DisplayName("J投入")]
        public decimal I { get { return L + S.SurfaceRCSum + T.FunctionRCSum + U.MaterialRCSum + NewDevelopmentCostD + AC.InputSum; } }
        public decimal NewDevelopmentCostD { get; set; }
        /// <summary>
        /// M品牌广告投入 
        /// </summary>
        //[DisplayName("M品牌广告投入")]
        public decimal J { get; internal set; }
        /// <summary>
        /// S品牌广告投入
        /// </summary>
        //[DisplayName("S品牌广告投入")]
        public decimal K { get; set; }
        /// <summary>
        /// J品牌广告投入
        /// </summary>
        //[DisplayName("J品牌广告投入")]
        public decimal L { get; internal set; }

        public SurfaceRC M { get; internal set; } = new SurfaceRC();
        public FunctionRC N { get; internal set; } = new FunctionRC();
        public MaterialRC O { get; internal set; } = new MaterialRC();

        public SurfaceRC P { get; set; } = new SurfaceRC();

        public FunctionRC Q { get; set; } = new FunctionRC();
        public MaterialRC R { get; set; } = new MaterialRC();

        public SurfaceRC S { get; internal set; } = new SurfaceRC();
        public FunctionRC T { get; internal set; } = new FunctionRC();
        public MaterialRC U { get; internal set; } = new MaterialRC();
        /// <summary>
        /// M品牌市场推广
        /// </summary>
        public BrandInput V { get; set; }
        /// <summary>
        /// J品牌市场推广
        /// </summary>
        public BrandInput AC { get; set; } = new BrandInput();
        public List<BrandInput> AJAgent { get; set; } = new List<BrandInput>();
        //public BrandInput AJ { get; set; } = new BrandInput();

        //public BrandInput AS { get; set; } = new BrandInput();
        //public BrandInput BB { get; set; } = new BrandInput();
        //public BrandInput BK { get; set; } = new BrandInput();
        //public BrandInput BT { get; set; } = new BrandInput();
        //public BrandInput CC { get; set; } = new BrandInput();
        public List<BrandInput> CLAgent { get; set; } = new List<BrandInput>();
        /// <summary>
        /// 代1
        /// </summary>
        //public BrandInput CL { get; set; } = new BrandInput();
        ///// <summary>
        ///// 代2
        ///// </summary>
        //public BrandInput CT { get; set; } = new BrandInput();
        ///// <summary>
        ///// 代3
        ///// </summary>
        //public BrandInput DB { get; set; } = new BrandInput();
        ///// <summary>
        ///// 代4
        ///// </summary>
        //public BrandInput DJ { get; set; } = new BrandInput();
        ///// <summary>
        ///// 代5
        ///// </summary>
        //public BrandInput DR { get; set; } = new BrandInput();
        ///// <summary>
        ///// 代6
        ///// </summary>
        //public BrandInput DZ { get; set; } = new BrandInput();


        private decimal KPQR(decimal d)
        {


            decimal r;
            if (Stage == Common.Stage.第一阶段.ToString()) d = 2000;
            else d *= 0.2m;
            r = d - K - P.Surfacerc[0] - Q.Functionrc[0] - R.Material[0];

            return r < 0 ? 0 : r;

        }
        private BrandInput getBrandInput(decimal aj, BrandInput agentInput1)
        {
            aj = KPQR(aj);
            var brandInput = new BrandInput() { AJ = aj };
            brandInput.EndImage = Cal.EndImage(brandInput.AJ, agentInput1.InputSum, agentInput1.EndImage);
            brandInput.Salesperson = Cal.Salesperson(brandInput.AJ, agentInput1.InputSum, agentInput1.Salesperson, brandInput.EndImage);
            brandInput.servet = Cal.Servet(brandInput.AJ, agentInput1.InputSum, agentInput1.servet, brandInput.EndImage, brandInput.Salesperson);
            brandInput.HousePromote = Cal.HousePromote(brandInput.AJ, agentInput1.InputSum, agentInput1.HousePromote, brandInput.EndImage, brandInput.Salesperson, brandInput.servet);
            brandInput.demonstrator = Cal.Demonstrator(brandInput.AJ, agentInput1.InputSum, agentInput1.demonstrator, brandInput.EndImage, brandInput.Salesperson, brandInput.servet, brandInput.HousePromote);
            brandInput.outdoorActivity = Cal.OutdoorActivity(brandInput.AJ, agentInput1.InputSum, agentInput1.outdoorActivity, brandInput.EndImage, brandInput.Salesperson, brandInput.servet, brandInput.HousePromote, brandInput.demonstrator);
            brandInput.promotionTeam = Cal.PromotionTeam(brandInput.AJ, agentInput1.InputSum, agentInput1.promotionTeam, brandInput.EndImage, brandInput.Salesperson, brandInput.servet, brandInput.HousePromote, brandInput.demonstrator, brandInput.outdoorActivity);

            return brandInput;
        }
        public void ItCAL()
        {
            AJAgent.ForEach(s =>
            {
                var index = AJAgent.IndexOf(s);
                s = getBrandInput(AJ_SummaryAsserts[index], CLAgent[index]);
            });

            //AJ = getBrandInput(AJ_SummaryAssert, CL);

            //AS = getBrandInput(AS_SummaryAssert, CT);

            //BB = getBrandInput(BB_SummaryAssert, DB);

            //BK = getBrandInput(BK_SummaryAssert, DJ);

            //BT = getBrandInput(BT_SummaryAssert, DR);

            //CC = getBrandInput(CC_SummaryAssert, DZ);


        }
        public List<decimal> AJ_SummaryAsserts { get; set; } = new List<decimal>();
        //public decimal AJ_SummaryAssert { get; set; }
        //public decimal AS_SummaryAssert { get; set; }
        //public decimal BB_SummaryAssert { get; set; }
        //public decimal BK_SummaryAssert { get; set; }
        //public decimal BT_SummaryAssert { get; set; }
        //public decimal CC_SummaryAssert { get; set; }
        /// <summary>
        /// 银行贷款
        /// </summary>
        public Dictionary<int, decimal> EI { get; set; }
        /// <summary>
        /// 新品开发费用
        /// </summary>
        public decimal NewDevelopmentCostC { get; set; }
    }
    public class SurfaceRC
    {
        public List<decimal> Surfacerc { get; set; } = new List<decimal>();
        public decimal SurfaceRCSum
        {
            get
            {
                return this.Surfacerc.Sum();
            }
        }
    }
    public class FunctionRC
    {
        public List<decimal> Functionrc { get; set; } = new List<decimal>();
        //public decimal FunctionRC1 { get; set; }
        //public decimal FunctionRC2 { get; set; }
        //public decimal FunctionRC3 { get; set; }
        public decimal FunctionRCSum
        {
            get
            {
                return this.Functionrc.Sum();
            }
        }
    }
    public class MaterialRC
    {
        public List<decimal> Material { get; set; } = new List<decimal>();
        //public decimal MaterialRC1 { get; set; }
        //public decimal MaterialRC2 { get; set; }
        //public decimal MaterialRC3 { get; set; }
        public decimal MaterialRCSum
        {
            get
            {
                return Material.Sum();
            }
        }
    }


}