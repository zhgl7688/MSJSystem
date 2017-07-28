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
    public class InvestmentTable
    {
        List<Invertment1> invertMentTable1;
        List<AgentInput> agentInputs;
        public InvestmentTable()
        {
            invertMentTable1 = new InvertmentTable1().getBrandsInputs();
            agentInputs   = new InvertmentTable1().getAgentInputs();
            Init();
        }

        List<Investment> investments = new List<Investment>();
        private void Init()
        {
            foreach (var item in invertMentTable1)
            {
                var investment = investments.FirstOrDefault(s => s.Stage == item.Stage);
                if (investment == null)
                {
                    investment = new Investment { Stage = item.Stage };
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
                        break;
                    default:
                        break;
                }
               
               
                var agentInput1 = agentInputs.Where(s => s.Stage == item.Stage );
               
                foreach (var agentInput in agentInput1)
                {
                    var brandinput=getBrandInput(investment.KPQR, agentInput);
                    switch (agentInput.AgentName)
                    {
                        case "代1":
                            investment.AJ = brandinput;
                            break;
                        case "代2":
                            investment.AS = brandinput;
                            break;
                        case "代3":
                            investment.BB = brandinput;
                            break;
                        case "代4":
                            investment.BK = brandinput;
                            break;
                        case "代5":
                            investment.BT = brandinput;
                            break;
                        case "代6":
                            investment.CC = brandinput;
                            break;
 
                    }
                }

                
            }


        }
        private BrandInput getBrandInput(decimal aj, AgentInput agentInput1)
        {
            var brandInput = new BrandInput() { AJ = aj };
                brandInput.AK = Cal.EndImage(brandInput.AJ, agentInput1.InputSum, agentInput1.EndImage);
                brandInput.AL = Cal.Salesperson(brandInput.AJ, agentInput1.InputSum, agentInput1.Salesperson,brandInput.AK);
                brandInput.AQ = Cal.Servet(brandInput.AJ, agentInput1.InputSum, agentInput1.servet, brandInput.AK,brandInput.AL);
                brandInput.AM= Cal.HousePromote(brandInput.AJ, agentInput1.InputSum, agentInput1.HousePromote, brandInput.AK,brandInput.AL,brandInput.AQ);
                brandInput.AN = Cal.Demonstrator(brandInput.AJ, agentInput1.InputSum, agentInput1.demonstrator, brandInput.AK, brandInput.AL, brandInput.AQ,brandInput.AM);
                brandInput.AO = Cal.OutdoorActivity(brandInput.AJ, agentInput1.InputSum, agentInput1.outdoorActivity, brandInput.AK, brandInput.AL, brandInput.AQ, brandInput.AM,brandInput.AN);
                brandInput.AP = Cal.PromotionTeam(brandInput.AJ, agentInput1.InputSum, agentInput1.promotionTeam, brandInput.AK, brandInput.AL, brandInput.AQ, brandInput.AM, brandInput.AN,brandInput.AO);

            return brandInput;
        }
        public List<Investment> Get()
        {
            return investments;
        }
    }
    public class Investment
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
        public BrandInput V { get; set; }
        public BrandInput AC { get; set; }

        public BrandInput AJ { get; set; }
        
        public BrandInput AS { get; set; }
        public BrandInput BB { get; set; }
        public BrandInput BK { get; set; }
        public BrandInput BT { get; set; }
        public BrandInput CC { get; set; }
    
        public decimal KPQR
        {
            get
            {
                var r = 2000 - K - P.SurfaceRC1 - Q.FunctionRC1 - R.materialRC1;
                return r < 0 ? 0 : r;
            }
        }

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

    public class BrandInput
    {

        /// <summary>
        /// S品牌对代1最高可投入
        /// </summary>
        public decimal AJ { get; set; }
        /// <summary>
        /// 终端形象
        /// </summary>
        public decimal AK { get; set; }
        /// <summary>
        /// 导购员
        /// </summary>
        public decimal AL { get; set; }
        /// <summary>
        /// 店内促销
        /// </summary>
        public decimal AM { get; set; }
        /// <summary>
        /// 演示员
        /// </summary>
        public decimal AN { get; set; }
        /// <summary>
        /// 户外活动
        /// </summary>
        public decimal AO { get; set; }
        /// <summary>
        /// 推广小分队
        /// </summary>
        public decimal AP { get; set; }
        /// <summary>
        /// 服务
        /// </summary>
        public decimal AQ { get; set; }
        /// <summary>
        /// 实际投入小计
        /// </summary>
        public decimal AR
        {
            get
            {
                return AK + AL + AM + AN + AO + AP + AQ;
            }
        }

    }
}