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
        public Investment(InvertmentTable1 InvertmentTable1, StockReport StockReport)
        {
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
                    investments.Add(investment);
                }
                var surfaceRC = new SurfaceRC { SurfaceRC1 = item.SurfaceRC1, SurfaceRC2 = item.SurfaceRC2, SurfaceRC3 = item.SurfaceRC3 };
                var functionRC = new FunctionRC { FunctionRC1 = item.FunctionRC1, FunctionRC2 = item.FunctionRC2, FunctionRC3 = item.FunctionRC3 };
                var materialRC = new MaterialRC { materialRC1 = item.MaterialRC1, materialRC2 = item.MaterialRC2, materialRC3 = item.MaterialRC3 };
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
                    investment.CL = agent.B;
                    investment.CT = agent.J;
                    investment.DB = agent.R;
                    investment.DJ = agent.Z;
                    investment.DR = agent.AH;
                    investment.DZ = agent.AP;
                }




            }
            foreach (var item in investments)
            {
                var agentInputList = agentInputs.Where(s => s.Stage == item.Stage);
                foreach (var agentInput in agentInputList)
                {
                    var ss = (int)Enum.Parse(typeof(AgentName), agentInput.AgentName);
                    item.EI.Add(ss, agentInput.bankLoan);
                }
            }
            foreach (var item in stockReports)
            {
                var index = (int)Enum.Parse(typeof(Stage), item.Stage);
                var investment = investments.FirstOrDefault(s => s.Stage == Enum.GetName(typeof(Stage), index + 1));
                if (investment == null)
                {
                    continue;
                }
                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                switch (agentName)
                {
                    case AgentName.代1:
                        investment.AJ_SummaryAssert = item.Sum.Sum;
                        break;
                    case AgentName.代2:
                        investment.AS_SummaryAssert = item.Sum.Sum;
                        break;
                    case AgentName.代3:
                        investment.BB_SummaryAssert = item.Sum.Sum;
                        break;
                    case AgentName.代4:
                        investment.BK_SummaryAssert = item.Sum.Sum;
                        break;
                    case AgentName.代5:
                        investment.BT_SummaryAssert = item.Sum.Sum;
                        break;
                    case AgentName.代6:
                        investment.CC_SummaryAssert = item.Sum.Sum;
                        break;
                    default:
                        break;
                }

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

        [DisplayName("阶段")]
        public string Stage { get; set; }
        //[DisplayName("M投入")]
        //=J11+O11+R11+U11+AN11+AO11+AP11+AQ11+AR11+AS11+AT11+开发费用表!B4
        public decimal B { get { return J + M.SurfaceRCSum + N.FunctionRCSum + O.materialRCSum + V.InputSum + NewDevelopmentCostB; } }
        public decimal NewDevelopmentCostB { get; set; }
        public decimal PQRNew
        {
            get { return P.SurfaceRCSum + Q.FunctionRCSum + R.materialRCSum + NewDevelopmentCostC; }
        }

        //[DisplayName("对代1投入")]
        public decimal C { get { return K + PQRNew + AJ.InputSum; } }
        //[DisplayName("对代2投入")]
        public decimal D { get { return K + PQRNew + AS.InputSum; } }
        //[DisplayName("对代3投入")]
        public decimal E { get { return K + PQRNew + BB.InputSum; } }
        //[DisplayName("对代4投入")]
        public decimal F { get { return K + PQRNew + BK.InputSum; } }
        //[DisplayName("对代5投入")]
        public decimal G { get { return K + PQRNew + BT.InputSum; } }
        //[DisplayName("对代6投入")]
        public decimal H { get { return K + PQRNew + CC.InputSum; } }
        //[DisplayName("J投入")]
        public decimal I { get { return L + S.SurfaceRCSum + T.FunctionRCSum + U.materialRCSum + NewDevelopmentCostD + AC.InputSum; } }
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

        public BrandInput AJ { get; set; } = new BrandInput();

        public BrandInput AS { get; set; } = new BrandInput();
        public BrandInput BB { get; set; } = new BrandInput();
        public BrandInput BK { get; set; } = new BrandInput();
        public BrandInput BT { get; set; } = new BrandInput();
        public BrandInput CC { get; set; } = new BrandInput();
        /// <summary>
        /// 代1
        /// </summary>
        public BrandInput CL { get; set; } = new BrandInput();
        /// <summary>
        /// 代2
        /// </summary>
        public BrandInput CT { get; set; } = new BrandInput();
        /// <summary>
        /// 代3
        /// </summary>
        public BrandInput DB { get; set; } = new BrandInput();
        /// <summary>
        /// 代4
        /// </summary>
        public BrandInput DJ { get; set; } = new BrandInput();
        /// <summary>
        /// 代5
        /// </summary>
        public BrandInput DR { get; set; } = new BrandInput();
        /// <summary>
        /// 代6
        /// </summary>
        public BrandInput DZ { get; set; } = new BrandInput();


        private decimal KPQR(decimal d)
        {


            decimal r;
            if (Stage == Common.Stage.第一阶段.ToString()) d = 2000;
            else d *= 0.2m;
            r = d - K - P.SurfaceRC1 - Q.FunctionRC1 - R.materialRC1;

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

            AJ = getBrandInput(AJ_SummaryAssert, CL);

            AS = getBrandInput(AS_SummaryAssert, CT);

            BB = getBrandInput(BB_SummaryAssert, DB);

            BK = getBrandInput(BK_SummaryAssert, DJ);

            BT = getBrandInput(BT_SummaryAssert, DR);

            CC = getBrandInput(CC_SummaryAssert, DZ);


        }
        public decimal AJ_SummaryAssert { get; set; }
        public decimal AS_SummaryAssert { get; set; }
        public decimal BB_SummaryAssert { get; set; }
        public decimal BK_SummaryAssert { get; set; }
        public decimal BT_SummaryAssert { get; set; }
        public decimal CC_SummaryAssert { get; set; }
        /// <summary>
        /// 银行贷款
        /// </summary>
        public Dictionary<int, decimal> EI { get; set; } = new Dictionary<int, decimal>();
        /// <summary>
        /// 新品开发费用
        /// </summary>
        public decimal NewDevelopmentCostC { get; set; }
    }
    public class SurfaceRC
    {
        public decimal SurfaceRC1 { get; set; }
        public decimal SurfaceRC2 { get; set; }
        public decimal SurfaceRC3 { get; set; }
        public decimal SurfaceRCSum
        {
            get
            {
                return this.SurfaceRC1 + this.SurfaceRC2 + this.SurfaceRC3;
            }
        }
    }
    public class FunctionRC
    {
        public decimal FunctionRC1 { get; set; }
        public decimal FunctionRC2 { get; set; }
        public decimal FunctionRC3 { get; set; }
        public decimal FunctionRCSum
        {
            get
            {
                return this.FunctionRC1 + this.FunctionRC2 + this.FunctionRC3;
            }
        }
    }
    public class MaterialRC
    {
        public decimal materialRC1 { get; set; }
        public decimal materialRC2 { get; set; }
        public decimal materialRC3 { get; set; }
        public decimal materialRCSum
        {
            get
            {
                return this.materialRC1 + this.materialRC2 + this.materialRC3;
            }
        }
    }


}