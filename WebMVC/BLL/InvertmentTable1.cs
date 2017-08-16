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
        MSJDBContext db = new MSJDBContext();
        List<AgentInput> agentInputs;
        List<BrandTable> brands = new List<BrandTable>();
        List<BrandsInput> brandsInputs;
        public InvertmentTable1()
        {
            agentInputs = db.AgentInputs.ToList();
            brandsInputs = db.BrandsInputs.ToList();
            #region 代理设定
            ////第1代1
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第一阶段.ToString(),
            //    EndImage = 247.5M,
            //    Salesperson = 247.5M,
            //    HousePromote = 196,
            //    demonstrator = 147,
            //    outdoorActivity = 98,
            //    promotionTeam = 49,
            //    servet = 1,
            //    retailPriceRC1 = 709.8M,
            //    SystemPriceRC1 = 845,
            //    AgentName = AgentName.代1.ToString(),
            //    purchase = 31,
            //    actualSale = 30,
            //    Inventory = 1,
            //    FirstPurchase = 30

            //});
            ////第1代2
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第一阶段.ToString(),
            //    EndImage = 450,
            //    Salesperson = 450,
            //    HousePromote = 392,
            //    demonstrator = 294,
            //    outdoorActivity = 196,
            //    promotionTeam = 98,
            //    servet = 80,
            //    retailPriceRC1 = 839,
            //    SystemPriceRC1 = 746,
            //    AgentName = AgentName.代2.ToString(),
            //    purchase = 31,
            //    actualSale = 30,
            //    Inventory = 1,
            //    FirstPurchase = 29,


            //});
            ////第1代3
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第一阶段.ToString(),
            //    EndImage = 575,
            //    Salesperson = 575,
            //    HousePromote = 460,
            //    demonstrator = 345,
            //    outdoorActivity = 230,
            //    promotionTeam = 115,
            //    servet = 200,
            //    retailPriceRC1 = 839,
            //    SystemPriceRC1 = 746.71M,
            //    AgentName = AgentName.代3.ToString(),
            //    purchase = 31,
            //    actualSale = 30,
            //    Inventory = 1,
            //    FirstPurchase = 25

            //});
            ////第1代4
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第一阶段.ToString(),
            //    EndImage = 230,
            //    Salesperson = 280,
            //    HousePromote = 200,
            //    demonstrator = 150,
            //    outdoorActivity = 100,
            //    promotionTeam = 70,
            //    servet = 100,
            //    retailPriceRC1 = 799,
            //    SystemPriceRC1 = 623,
            //    AgentName = AgentName.代4.ToString(),
            //    purchase = 31,
            //    actualSale = 30,
            //    Inventory = 1,
            //    FirstPurchase = 26

            //});
            ////第2代1
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第二阶段.ToString(),
            //    EndImage = 400,
            //    Salesperson = 450,
            //    HousePromote = 280,
            //    demonstrator = 115,
            //    outdoorActivity = 115,
            //    promotionTeam = 70,
            //    servet = 50,
            //    retailPriceRC1 = 699,
            //    SystemPriceRC1 = 587.16m,
            //    retailPriceRC2 = 845,
            //    SystemPriceRC2 = 709.8m,
            //    AgentName = AgentName.代1.ToString(),

            //    FirstPurchase = 10,
            //    SecondPurchase = 18

            //});
            ////第2代2
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第二阶段.ToString(),
            //    EndImage = 300,
            //    Salesperson = 430,
            //    HousePromote = 400,
            //    demonstrator = 240,
            //    outdoorActivity = 130,
            //    promotionTeam = 50,
            //    servet = 50,
            //    bankLoan = 7000,
            //    retailPriceRC1 = 699,
            //    SystemPriceRC1 = 622,
            //    retailPriceRC2 = 845,
            //    SystemPriceRC2 = 752,
            //    AgentName = AgentName.代2.ToString(),

            //    FirstPurchase = 32,
            //    SecondPurchase = 25

            //});
            ////第2代3
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第二阶段.ToString(),
            //    EndImage = 450,
            //    Salesperson = 450,
            //    HousePromote = 360,
            //    demonstrator = 270,
            //    outdoorActivity = 180,
            //    promotionTeam = 90,
            //    servet = 200,

            //    retailPriceRC1 = 699,
            //    SystemPriceRC1 = 622.11m,
            //    retailPriceRC2 = 999,
            //    SystemPriceRC2 = 889.11m,
            //    AgentName = AgentName.代3.ToString(),

            //    FirstPurchase = 25,
            //    SecondPurchase = 15

            //});
            ////第2代4
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第二阶段.ToString(),
            //    EndImage = 462,
            //    Salesperson = 392,
            //    HousePromote = 182,
            //    demonstrator = 210,
            //    outdoorActivity = 84,
            //    promotionTeam = 70,


            //    retailPriceRC1 = 699,
            //    SystemPriceRC1 = 545,
            //    retailPriceRC2 = 1099,
            //    SystemPriceRC2 = 857,
            //    AgentName = AgentName.代4.ToString(),

            //    FirstPurchase = 10,
            //    SecondPurchase = 6

            //});
            ////第3代1
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第三阶段.ToString(),
            //    EndImage = 800,
            //    Salesperson = 1400,
            //    HousePromote = 800,
            //    demonstrator = 200,
            //    outdoorActivity = 120,
            //    promotionTeam = 80,
            //    servet = 200,
            //    retailPriceRC1 = 599,
            //    SystemPriceRC1 = 503.16m,
            //    retailPriceRC2 = 799,
            //    SystemPriceRC2 = 671.16m,
            //    retailPriceRC3 = 999,
            //    SystemPriceRC3 = 839.16m,
            //    AgentName = AgentName.代1.ToString(),

            //    FirstPurchase = 20,
            //    SecondPurchase = 20,
            //    ThirdPurchase = 11
            //});

            ////第3代2
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第三阶段.ToString(),
            //    EndImage = 500,
            //    Salesperson = 900,
            //    HousePromote = 860,
            //    demonstrator = 540,
            //    outdoorActivity = 400,
            //    promotionTeam = 200,
            //    servet = 200,
            //    bankLoan = 10000,
            //    retailPriceRC1 = 599,
            //    SystemPriceRC1 = 533,
            //    retailPriceRC2 = 799,
            //    SystemPriceRC2 = 712,
            //    retailPriceRC3 = 999,
            //    SystemPriceRC3 = 890,
            //    AgentName = AgentName.代2.ToString(),

            //    FirstPurchase = 35,
            //    SecondPurchase = 30,
            //    ThirdPurchase = 22
            //});

            ////第3代3
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第三阶段.ToString(),
            //    EndImage = 900,
            //    Salesperson = 900,
            //    HousePromote = 720,
            //    demonstrator = 540,
            //    outdoorActivity = 360,
            //    promotionTeam = 180,
            //    servet = 100,
            //    bankLoan = 11296,
            //    retailPriceRC1 = 599,
            //    SystemPriceRC1 = 533.11m,
            //    retailPriceRC2 = 799,
            //    SystemPriceRC2 = 711.11m,
            //    retailPriceRC3 = 999,
            //    SystemPriceRC3 = 889.11m,
            //    AgentName = AgentName.代3.ToString(),

            //    FirstPurchase = 45,
            //    SecondPurchase = 25,
            //    ThirdPurchase = 15
            //});

            ////第3代4
            //agentInputs.Add(new AgentInput
            //{
            //    Stage = Common.Stage.第三阶段.ToString(),
            //    EndImage = 800,
            //    Salesperson = 950,
            //    HousePromote = 770,
            //    demonstrator = 468,
            //    outdoorActivity = 360,
            //    promotionTeam = 144,
            //    servet = 108,

            //    retailPriceRC1 = 599,
            //    SystemPriceRC1 = 468,
            //    retailPriceRC2 = 799,
            //    SystemPriceRC2 = 623,
            //    retailPriceRC3 = 1099,
            //    SystemPriceRC3 = 857,
            //    AgentName = AgentName.代4.ToString(),

            //    FirstPurchase = 5,
            //    SecondPurchase = 25,
            //    ThirdPurchase = 15
            //});

            #endregion

            #region 品牌设定
            ////第1S
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第一阶段.ToString(),
            //    Brand = Brand.S品牌.ToString(),
            //    advertise = 600,
            //    SurfaceRC1 = 120,
            //    FunctionRC1 = 200,
            //    MaterialRC1 = 100,

            //    retailPrice = 799
            //});
            ////第2S
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
            ////第3S
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第三阶段.ToString(),
            //    Brand = Brand.S品牌.ToString(),
            //    advertise = 600,
            //    SurfaceRC1 = 50,
            //    SurfaceRC3 = 100,
            //    FunctionRC2 = 100,
            //    FunctionRC3 = 200,
            //    MaterialRC2 = 100,
            //    MaterialRC3 = 50,

            //    retailPrice = 599,
            //    NewRetailPriceR2 = 799,
            //    NewCostPrice = 320,
            //    NewFactoryPrice = 490,
            //    NewRetailPriceR3 = 999,


            //});
            ////第1M
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第一阶段.ToString(),
            //    Brand = Brand.M品牌.ToString(),
            //    advertise = 640,
            //    SurfaceRC1 = 48,
            //    FunctionRC1 = 80,
            //    MaterialRC1 = 32,
            //    EndImage = 240,
            //    Salesperson = 240,
            //    HousePromote = 192,
            //    demonstrator = 144,
            //    outdoorActivity = 96,
            //    promotionTeam = 48,
            //    servet = 240,
            //    retailPrice = 799,
            //    SystemPrice = 630

            //});
            ////第2M
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第二阶段.ToString(),
            //    Brand = Brand.M品牌.ToString(),
            //    advertise = 553,
            //    SurfaceRC2 = 71,
            //    FunctionRC2 = 118,
            //    MaterialRC2 = 47,
            //    EndImage = 369,
            //    Salesperson = 369,
            //    HousePromote = 295,
            //    demonstrator = 221,
            //    outdoorActivity = 147,
            //    promotionTeam = 73,
            //    servet = 369,
            //    NewDevelopmentCost = 660,

            //    retailPrice = 759,
            //    SystemPrice = 609,
            //    NewCostPrice = 350,
            //    NewFactoryPrice = 507,
            //    NewRetailPriceR2 = 949,
            //    NewSystemPriceR2 = 725
            //});
            ////第3M
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第三阶段.ToString(),
            //    Brand = Brand.M品牌.ToString(),
            //    advertise = 722,
            //    SurfaceRC3 = 324,
            //    FunctionRC1 = 100,
            //    FunctionRC3 = 541,
            //    MaterialRC1 = 200,
            //    MaterialRC2 = 200,
            //    MaterialRC3 = 216,
            //    EndImage = 768,
            //    Salesperson = 768,
            //    HousePromote = 614,
            //    demonstrator = 460,
            //    outdoorActivity = 307,
            //    promotionTeam = 153,
            //    servet = 768,
            //    NewDevelopmentCost = 1444,

            //    retailPrice = 659,
            //    SystemPrice = 516,
            //    NewCostPrice = 869,
            //    NewFactoryPrice = 680,

            //    NewRetailPriceR2 = 355,
            //    NewSystemPriceR2 = 514,
            //    NewRetailPriceR3 = 999,
            //    NewSystemPriceR3 = 775
            //});
            ////第1J
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第一阶段.ToString(),
            //    Brand = Brand.J品牌.ToString(),
            //    advertise = 200,
            //    SurfaceRC1 = 180,
            //    FunctionRC1 = 300,
            //    MaterialRC1 = 120,
            //    EndImage = 250,
            //    Salesperson = 250,
            //    HousePromote = 200,
            //    demonstrator = 150,
            //    outdoorActivity = 100,
            //    promotionTeam = 50,
            //    servet = 200,

            //    retailPrice = 699,
            //    SystemPrice = 538
            //});
            ////第2J
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第二阶段.ToString(),
            //    Brand = Brand.J品牌.ToString(),
            //    advertise = 600,
            //    SurfaceRC2 = 156,
            //    FunctionRC2 = 520,
            //    MaterialRC2 = 104,
            //    EndImage = 235,
            //    Salesperson = 235,
            //    HousePromote = 188,
            //    demonstrator = 141,
            //    outdoorActivity = 94,
            //    promotionTeam = 47,
            //    servet = 280,

            //    retailPrice = 599,
            //    SystemPrice = 461.23m,
            //    NewCostPrice = 382,
            //    NewFactoryPrice = 545,
            //    NewRetailPriceR2 = 999,
            //    NewSystemPriceR2 = 769
            //});
            ////第3J
            //brands.Add(new BrandTable
            //{
            //    Stage = Common.Stage.第三阶段.ToString(),
            //    Brand = Brand.J品牌.ToString(),

            //    SurfaceRC3 = 348,
            //    FunctionRC3 = 580,
            //    MaterialRC3 = 232,
            //    EndImage = 625,
            //    Salesperson = 625,
            //    HousePromote = 500,
            //    demonstrator = 375,
            //    outdoorActivity = 250,
            //    promotionTeam = 125,
            //    servet = 500,

            //    retailPrice = 759,
            //    SystemPrice = 609,
            //    NewCostPrice = 999,
            //    NewFactoryPrice = 769,
            //    NewRetailPriceR2 = 269,
            //    NewSystemPriceR2 = 359,
            //    NewRetailPriceR3 = 599,
            //    NewSystemPriceR3 = 461
            //});
            #endregion
        }

        public List<AgentInput> getAgentInputs()
        {
            return agentInputs;
        }
        public List<BrandTable> getBrandTable()
        {
            List<BrandTable> brands = new List<BrandTable>();
            foreach (var item in brandsInputs)
            {
               brands.Add( Cal.AutoCopy<BrandsInput, BrandTable>(item));
            }
               return brands;
        }
        
        public List<BrandsInput> getBrandsInputs()
        {  
            return brandsInputs;
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