using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;
using WebMVC.Common;

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
        public Investment()
        {
            invertMentTable1 = new InvertmentTable1().getBrandsInputs();
            agentInputs = new InvertmentTable1().getAgentInputs();
            agents = new InvertmentTable1().getAgents();
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
                var materialRC = new MaterialRC { materialRC1 = item.materialRC1, materialRC2 = item.FunctionRC2, materialRC3 = item.FunctionRC3 };
                Brand brand = (Brand)Enum.Parse(typeof(Brand), item.Brand);
                switch (brand)
                {
                    case Brand.M品牌:
                        investment.J = item.advertise;
                        investment.M = surfaceRC;
                        investment.N = functionRC;
                        investment.O = materialRC;
                        investment.V = item.brandInput;
                        break;
                    case Brand.S品牌:
                        investment.K = item.advertise;
                        investment.P = surfaceRC;
                        investment.Q = functionRC;
                        investment.R = materialRC;

                        break;
                    case Brand.J品牌:
                        investment.L = item.advertise;
                        investment.S = surfaceRC;
                        investment.T = functionRC;
                        investment.U = materialRC;
                        investment.AC = item.brandInput;
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
                var agentInputList = agentInputs.Where(s => s.Stage == item.Stage);

                foreach (var agentInput in agentInputList)
                {
                   var ss=()
                    switch (switch_on)
                    {
                        default:
                    }
                }
                investment.ItCAL();
            }


        }
        private BrandInput getBrandInput(decimal aj, AgentInput agentInput1)
        {
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
        public List<InvestmentTable> Get()
        {
            return investments;
        }
    }
    public class InvestmentTable
    {


        public string Stage { get; set; }
        /// <summary>
        /// M品牌广告投入 
        /// </summary>
        public decimal J { get; internal set; }
        /// <summary>
        /// S品牌广告投入
        /// </summary>
        public decimal K { get; set; }
        /// <summary>
        /// J品牌广告投入
        /// </summary>
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

        public BrandInput AJ { get; set; }   = new BrandInput();
                                           
        public BrandInput AS { get; set; }   = new BrandInput();
        public BrandInput BB { get; set; }   = new BrandInput();
        public BrandInput BK { get; set; }   = new BrandInput();
        public BrandInput BT { get; set; }   = new BrandInput();
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
        public decimal KPQR
        {
            get
            {
                var r = 2000 - K - P.SurfaceRC1 - Q.FunctionRC1 - R.materialRC1;
                return r < 0 ? 0 : r;
            }
        }
        private BrandInput getBrandInput(decimal aj, BrandInput agentInput1)
        {
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

            AJ = getBrandInput(KPQR, CL);

            AS = getBrandInput(KPQR, CT);

            BB = getBrandInput(KPQR, DB);

            BK = getBrandInput(KPQR, DJ);

            BT = getBrandInput(KPQR, DR);

            CC = getBrandInput(KPQR, DZ);


        }
        /// <summary>
        /// 银行贷款
        /// </summary>
        public MJA EI { get; set; }

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