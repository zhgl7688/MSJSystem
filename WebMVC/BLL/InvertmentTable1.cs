using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    /// <summary>
    /// 投资表1
    /// </summary>
    public class InvertmentTable1
    {
        List<AgentInput> agentInputs = new List<AgentInput>();
        List<BrandTable> brands = new List<BrandTable>();
        public InvertmentTable1()
        {
            #region 代理设定
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第一阶段.ToString(),
                EndImage = 247.5M,
                Salesperson = 247.5M,
                HousePromote = 196,
                demonstrator = 147,
                outdoorActivity = 98,
                promotionTeam = 49,
                servet = 1,
                retailPriceRC1 = 709.8M,
                SystemPriceRC1 = 845,
                AgentName = AgentName.代1.ToString(),
                purchase = 31,
                actualSale = 30,
                Inventory = 1,
                FirstPurchase = 30

            });
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第一阶段.ToString(),
                EndImage = 450,
                Salesperson = 450,
                HousePromote = 392,
                demonstrator = 294,
                outdoorActivity = 196,
                promotionTeam = 98,
                servet = 80,
                retailPriceRC1 = 839,
                SystemPriceRC1 = 746,
                AgentName = AgentName.代2.ToString(),
                purchase = 31,
                actualSale = 30,
                Inventory = 1,
                FirstPurchase = 29

            });
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第一阶段.ToString(),
                EndImage = 575,
                Salesperson = 575,
                HousePromote = 460,
                demonstrator = 345,
                outdoorActivity = 230,
                promotionTeam = 115,
                servet = 200,
                retailPriceRC1 = 839,
                SystemPriceRC1 = 746.71M,
                AgentName = AgentName.代3.ToString(),
                purchase = 31,
                actualSale = 30,
                Inventory = 1,
                FirstPurchase = 25

            });
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第一阶段.ToString(),
                EndImage = 230,
                Salesperson = 280,
                HousePromote = 200,
                demonstrator = 150,
                outdoorActivity = 100,
                promotionTeam = 70,
                servet = 100,
                retailPriceRC1 = 799,
                SystemPriceRC1 = 623,
                AgentName = AgentName.代4.ToString(),
                purchase = 31,
                actualSale = 30,
                Inventory = 1,
                FirstPurchase = 26

            });
            #endregion

            #region 品牌设定
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第一阶段.ToString(),
                Brand = Brand.S品牌.ToString(),
                advertise = 600,
                SurfaceRC1 = 120,
                FunctionRC1 = 200,
                materialRC1 = 100,

                retailPrice = 799
            });
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第二阶段.ToString(),
            //    Brand = Brand.S品牌.ToString(),
            //    advertise = 300,
            //    SurfaceRC2 = 100,
            //    FunctionRC2 = 200,
            //    MaterialRC2 = 100,
            //    NewDevelopmentCost = 100,
            //    retailPrice = 699,
            //    NewCostPrice = 315,
            //    NewFactoryPrice = 450,
            //    NewRetailPriceR2 = 845
            //});
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第三阶段.ToString(),
            //    Brand = Brand.S品牌.ToString(),
            //    advertise = 600,
            //    SurfaceRC1=50,
            //    SurfaceRC3 = 100,
            //    FunctionRC2 = 100,
            //    FunctionRC3=200,
            //    MaterialRC2 = 100,
            //    MaterialRC3=50,
              
            //    retailPrice = 599,
            //    NewRetailPriceR2 = 799,
            //    NewCostPrice = 320,
            //    NewFactoryPrice = 490,
            //    NewRetailPriceR3=999,
     
                
            //});
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第一阶段.ToString(),
                Brand = Brand.M品牌.ToString(),
                advertise = 640,
                SurfaceRC1 = 48,
                FunctionRC1 = 80,
                materialRC1 = 32,
                EndImage = 240,
                Salesperson = 240,
                HousePromote = 192,
                demonstrator = 144,
                outdoorActivity = 96,
                promotionTeam = 48,
                servet = 240,
                retailPrice = 799,
                SystemPrice = 630

            });
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第一阶段.ToString(),
                Brand = Brand.J品牌.ToString(),
                advertise = 200,
                SurfaceRC1 = 180,
                FunctionRC1 = 300,
                materialRC1 = 120,
                EndImage = 250,
                Salesperson = 250,
                HousePromote = 200,
                demonstrator = 150,
                outdoorActivity = 100,
                promotionTeam = 50,
                servet = 200,

                retailPrice = 699,
                SystemPrice = 538
            });
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第二阶段.ToString(),
            //    Brand = Brand.M品牌.ToString(),
            //    advertise = 553,
            //    SurfaceRC2 =71 ,
            //    FunctionRC2 = 118,
            //    materialRC2 = 47,
            //    EndImage = 369,
            //    Salesperson = 369,
            //    HousePromote =295,
            //    demonstrator = 221,
            //    outdoorActivity = 147,
            //    promotionTeam = 73,
            //    servet = 369,
            //   NewDevelopmentCost= 660,

            //    retailPrice = 759,
            //    SystemPrice = 609,
            //     NewCostPrice=350,
            //      NewFactoryPrice=507,
            //     NewRetailPriceR2=949,
            //      NewSystemPriceR2=725
            //});
            #endregion
        }
        public List<AgentInput> getAgentInputs()
        {
            return agentInputs;
        }
        public List<BrandTable> getBrandsInputs()
        {
            return brands;
        }
        public List<AgentTable> getAgents()
        {
            List<AgentTable> agents = new List<AgentTable>();
            foreach (var item in agentInputs)
            {
                var agent = agents.FirstOrDefault(s => s.Stage == item.Stage);
                if (agent == null)
                {
                    agent = new AgentTable { Stage = item.Stage };
                    agents.Add(agent);
                }
                var agentName = (AgentName)Enum.Parse(typeof(AgentName), item.AgentName);
                switch (agentName)
                {
                    case AgentName.代1:
                        agent.B = item.brandInput;
                        break;
                    case AgentName.代2:
                        agent.J = item.brandInput;
                        break;
                    case AgentName.代3:
                        agent.R = item.brandInput;
                        break;
                    case AgentName.代4:
                        agent.Z = item.brandInput;
                        break;
                    case AgentName.代5:
                        agent.AH = item.brandInput;
                        break;
                    case AgentName.代6:
                        agent.AP = item.brandInput;
                        break;
                    default:
                        break;
                }


            }
            return agents;
        }
    }
    public class BrandTable : BrandsInput
    {
        /// <summary>
        /// 外观常规汇总
        /// </summary>
        public decimal SurfaceSum
        {
            get
            {
                return this.SurfaceRC1 + this.SurfaceRC2 + this.SurfaceRC3;
            }
        }
        /// <summary>
        /// 功能常规汇总
        /// </summary>
        public decimal FunctionSum
        {
            get
            {
                return this.FunctionRC1 + this.FunctionRC2 + this.FunctionRC3;
            }
        }
        /// <summary>
        /// 材料常规汇总
        /// </summary>
        public decimal materialSum
        {
            get
            {
                return this.materialRC1 + this.MaterialRC2 + this.MaterialRC3;
            }
        }
        public decimal InputSum
        {
            get
            {
                return this.EndImage + this.Salesperson + this.HousePromote + this.demonstrator
                     + this.outdoorActivity + this.promotionTeam + this.servet;
            }
        }
        public decimal Sum
        {
            get
            {
                return this.advertise + this.FunctionSum + this.materialSum + this.SurfaceSum + InputSum;
            }
        }
    }

    public class AgentTable
    {
        public string Stage { get; set; }
        /// <summary>
        /// 代1
        /// </summary>
        public BrandInput B { get; set; } = new BrandInput();
        /// <summary>
        /// 代2
        /// </summary>
        public BrandInput J { get; set; } = new BrandInput();
        /// <summary>
        /// 代3
        /// </summary>
        public BrandInput R { get; set; } = new BrandInput();
        /// <summary>
        /// 代4
        /// </summary>
        public BrandInput Z { get; set; } = new BrandInput();
        /// <summary>
        /// 代5
        /// </summary>
        public BrandInput AH { get; set; } = new BrandInput();
        /// <summary>
        /// 代6
        /// </summary>
        public BrandInput AP { get; set; } = new BrandInput();

    }
}