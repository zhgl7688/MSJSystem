using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class ExampleData
    {
        public List<AgentInput> agentInputs { get; set; }
        public List<BrandsInput> brands { get; set; }
        public ExampleData()
        {
            agentInputs = new List<AgentInput>();
            brands = new List<BrandsInput>();
            #region 代理设定



            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第1阶段.ToString(),
                EndImage = 247.5M,
                Salesperson = 247.5M,
                HousePromote = 196,
                demonstrator = 147,
                outdoorActivity = 98,
                promotionTeam = 49,
                servet = 1,
                AgentName = AgentName.代1.ToString(),
                actualSale = 30,
                Inventory = 1,
                BasePurchase = 31,
                retailPriceRC = new List<decimal> { 709.8M, },
                SystemPriceRC = new List<decimal> { 845, },
                Purchase = new List<decimal> { 30,  },


            });
            //第2代1
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第2阶段.ToString(),
                EndImage = 400,
                Salesperson = 450,
                HousePromote = 280,
                demonstrator = 115,
                outdoorActivity = 115,
                promotionTeam = 70,
                servet = 50,
                retailPriceRC = new List<decimal> { 699, 845,   },
                SystemPriceRC = new List<decimal> { 587.16m, 709.8m,  },
                AgentName = AgentName.代1.ToString(),
                Purchase = new List<decimal> {10, 18, },
          
            });
            //第3代1
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第3阶段.ToString(),
                EndImage = 800,
                Salesperson = 1400,
                HousePromote = 800,
                demonstrator = 200,
                outdoorActivity = 120,
                promotionTeam = 80,
                servet = 200,


                AgentName = AgentName.代1.ToString(),

                retailPriceRC = new List<decimal> { 599, 799, 999, },
                SystemPriceRC = new List<decimal> { 503.16m, 671.16m, 839.16m, },
                Purchase = new List<decimal> { 20, 20, 11 }
            });
            //第1代2
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第1阶段.ToString(),
                EndImage = 450,
                Salesperson = 450,
                HousePromote = 392,
                demonstrator = 294,
                outdoorActivity = 196,
                promotionTeam = 98,
                servet = 80,
                retailPriceRC = new List<decimal> { 839},
                SystemPriceRC = new List<decimal> { 746},
                AgentName = AgentName.代2.ToString(),
                Purchase = new List<decimal> { 29 },
                actualSale = 30,
                Inventory = 1,
                BasePurchase = 31,

            });
            //第1代3
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第1阶段.ToString(),
                EndImage = 575,
                Salesperson = 575,
                HousePromote = 460,
                demonstrator = 345,
                outdoorActivity = 230,
                promotionTeam = 115,
                servet = 200,

                AgentName = AgentName.代3.ToString(),
                BasePurchase = 31,
                actualSale = 30,
                Inventory = 1,

                retailPriceRC = new List<decimal> { 839 },
                SystemPriceRC = new List<decimal> { 746.71M },
                Purchase = new List<decimal> { 25 },
            });
            //第1代4
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第1阶段.ToString(),
                EndImage = 230,
                Salesperson = 280,
                HousePromote = 200,
                demonstrator = 150,
                outdoorActivity = 100,
                promotionTeam = 70,
                servet = 100,

                AgentName = AgentName.代4.ToString(),
                BasePurchase = 31,
                actualSale = 30,
                Inventory = 1,
                retailPriceRC = new List<decimal> { 799 },
                SystemPriceRC = new List<decimal> { 623},
                Purchase = new List<decimal> { 26 },
            });

            //第2代2
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第2阶段.ToString(),
                EndImage = 300,
                Salesperson = 430,
                HousePromote = 400,
                demonstrator = 240,
                outdoorActivity = 130,
                promotionTeam = 50,
                servet = 50,
                bankLoan = 7000,
                retailPriceRC = new List<decimal> { 699, 845, },
                SystemPriceRC = new List<decimal> { 622, 752, },
                Purchase = new List<decimal> { 32, 25 },

                AgentName = AgentName.代2.ToString(),


            });
            //第2代3
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第2阶段.ToString(),
                EndImage = 450,
                Salesperson = 450,
                HousePromote = 360,
                demonstrator = 270,
                outdoorActivity = 180,
                promotionTeam = 90,
                servet = 200,

                AgentName = AgentName.代3.ToString(),
                retailPriceRC = new List<decimal> { 699, 999, },
                SystemPriceRC = new List<decimal> { 622.11m, 889.11m, },
                Purchase = new List<decimal> { 25, 15 },


            });
            //第2代4
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第2阶段.ToString(),
                EndImage = 462,
                Salesperson = 392,
                HousePromote = 182,
                demonstrator = 210,
                outdoorActivity = 84,
                promotionTeam = 70,

                retailPriceRC = new List<decimal> { 699, 1099, },
                SystemPriceRC = new List<decimal> { 545, 857, },
                Purchase = new List<decimal> { 10, 6 },


                AgentName = AgentName.代4.ToString(),


            });
           

            //第3代2
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第3阶段.ToString(),
                EndImage = 500,
                Salesperson = 900,
                HousePromote = 860,
                demonstrator = 540,
                outdoorActivity = 400,
                promotionTeam = 200,
                servet = 200,
                bankLoan = 10000,

                AgentName = AgentName.代2.ToString(),

                retailPriceRC = new List<decimal> { 599, 799, 999, },
                SystemPriceRC = new List<decimal> { 533m, 712m, 890, },
                Purchase = new List<decimal> { 35, 30, 22 }
            });

            //第3代3
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第3阶段.ToString(),
                EndImage = 900,
                Salesperson = 900,
                HousePromote = 720,
                demonstrator = 540,
                outdoorActivity = 360,
                promotionTeam = 180,
                servet = 100,
                bankLoan = 11296,
                retailPriceRC = new List<decimal> { 599, 799, 999, },
                SystemPriceRC = new List<decimal> { 533.11m, 711.11m, 889.11m, },

                AgentName = AgentName.代3.ToString(),
                Purchase = new List<decimal> { 45, 25, 15 }

            });

            //第3代4
            agentInputs.Add(new AgentInput
            {
                Stage = Common.Stage.第3阶段.ToString(),
                EndImage = 800,
                Salesperson = 950,
                HousePromote = 770,
                demonstrator = 468,
                outdoorActivity = 360,
                promotionTeam = 144,
                servet = 108,
                retailPriceRC = new List<decimal> { 599, 799, 1099, },
                SystemPriceRC = new List<decimal> { 468, 623, 857, },

                AgentName = AgentName.代4.ToString(),
                Purchase = new List<decimal> { 5, 25, 15 }

            });

            #endregion

            #region 品牌设定
            //第1S
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第1阶段.ToString(),
                Brand = Brand.S品牌.ToString(),
                advertise = 600,
                SurfaceRC = new List<decimal> { 120,0,0 },
                FunctionRC = new List<decimal> { 200, 0, 0 },
                MaterialRC = new List<decimal> { 100, 0, 0 },
                retailPrice = 799
            });
            //第2S
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第2阶段.ToString(),
                Brand = Brand.S品牌.ToString(),
                advertise = 300,
  
                NewDevelopmentCost = 100,
                retailPrice = 699,
                NewCostPrice = 315,
                NewFactoryPrice = 450,
                NewRetailPriceR2 = 845,
                SurfaceRC = new List<decimal> {0, 100,  0 },
                FunctionRC = new List<decimal> {0, 200, 0 },
                MaterialRC = new List<decimal> {0, 100, 0 },
            });
            //第3S
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第3阶段.ToString(),
                Brand = Brand.S品牌.ToString(),
                advertise = 600,
       
                SurfaceRC = new List<decimal> { 50,0, 100 },
                FunctionRC = new List<decimal> { 0,100, 200 },
                MaterialRC = new List<decimal> { 0, 100,50 },
                retailPrice = 599,
                NewRetailPriceR2 = 799,
                NewCostPrice = 320,
                NewFactoryPrice = 490,
                NewRetailPriceR3 = 999,


            });
            //第1M
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第1阶段.ToString(),
                Brand = Brand.M品牌.ToString(),
                advertise = 640,
                
                SurfaceRC = new List<decimal> { 48, 0, 0 },
                FunctionRC = new List<decimal> { 80, 0, 0 },
                MaterialRC = new List<decimal> { 32, 0, 0 },
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
            //第2M
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第2阶段.ToString(),
                Brand = Brand.M品牌.ToString(),
                advertise = 553,
 
                SurfaceRC = new List<decimal> {0, 71, 0 },
                FunctionRC = new List<decimal> {0, 118, 0 },
                MaterialRC = new List<decimal> { 0, 47, 0 },
                EndImage = 369,
                Salesperson = 369,
                HousePromote = 295,
                demonstrator = 221,
                outdoorActivity = 147,
                promotionTeam = 73,
                servet = 369,
                NewDevelopmentCost = 660,

                retailPrice = 759,
                SystemPrice = 609,
                NewCostPrice = 350,
                NewFactoryPrice = 507,
                NewRetailPriceR2 = 949,
                NewSystemPriceR2 = 725
            });
            //第3M
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第3阶段.ToString(),
                Brand = Brand.M品牌.ToString(),
                advertise = 722,
            
 
                SurfaceRC = new List<decimal> { 0,0, 324 },
                FunctionRC = new List<decimal> { 100, 0, 541 },
                MaterialRC = new List<decimal> { 200,200, 216 },

                EndImage = 768,
                Salesperson = 768,
                HousePromote = 614,
                demonstrator = 460,
                outdoorActivity = 307,
                promotionTeam = 153,
                servet = 768,
                NewDevelopmentCost = 1444,

                retailPrice = 659,
                SystemPrice = 516,
                NewCostPrice = 355,
                NewFactoryPrice = 514,

                NewRetailPriceR2 = 869,
                NewSystemPriceR2 = 680,
                NewRetailPriceR3 = 999,
                NewSystemPriceR3 = 775

            });
            //第1J
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第1阶段.ToString(),
                Brand = Brand.J品牌.ToString(),
                advertise = 200,
               

                SurfaceRC = new List<decimal> { 180, 0, 0 },
                FunctionRC = new List<decimal> {300, 0, 0 },
                MaterialRC = new List<decimal> { 120, 0, 0 },
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
            //第2J
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第2阶段.ToString(),
                Brand = Brand.J品牌.ToString(),
                advertise = 600,
            
                SurfaceRC = new List<decimal>  { 0,156, 0 },
                FunctionRC = new List<decimal> { 0,520, 0 },
                MaterialRC = new List<decimal> { 0, 104, 0 },

                EndImage = 235,
                Salesperson = 235,
                HousePromote = 188,
                demonstrator = 141,
                outdoorActivity = 94,
                promotionTeam = 47,
                servet = 280,

                retailPrice = 599,
                SystemPrice = 461.23m,
                NewCostPrice = 382,
                NewFactoryPrice = 545,
                NewRetailPriceR2 = 999,
                NewSystemPriceR2 = 769
            });
            //第3J
            brands.Add(new BrandTable
            {
                Stage = Common.Stage.第3阶段.ToString(),
                Brand = Brand.J品牌.ToString(),

 

                SurfaceRC = new List<decimal> { 0, 0,348},
                FunctionRC = new List<decimal> { 0,0,580 },
                MaterialRC = new List<decimal> { 0,0, 232 },

                EndImage = 625,
                Salesperson = 625,
                HousePromote = 500,
                demonstrator = 375,
                outdoorActivity = 250,
                promotionTeam = 125,
                servet = 500,

                retailPrice = 759,
                SystemPrice = 609,
                NewCostPrice = 269,
                NewFactoryPrice = 359,
                NewRetailPriceR2 = 999,
                NewSystemPriceR2 =769 ,
                NewRetailPriceR3 = 599,
                NewSystemPriceR3 = 461
            });
            #endregion
        }

    }
}