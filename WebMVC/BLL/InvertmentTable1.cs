using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.BLL
{
    /// <summary>
    /// 投资表1
    /// </summary>
    public class InvertmentTable1
    {
        List<AgentInput> agentInputs = new List<AgentInput>();
        List<Invertment1> invertment1s = new List<Invertment1>();
        public InvertmentTable1()
        {
            #region 代理设定
            agentInputs.Add(new AgentInput
            {
                Stage = "第一阶段",
                EndImage = 247.5M,
                Salesperson = 247.5M,
                HousePromote = 196,
                demonstrator = 147,
                outdoorActivity = 98,
                promotionTeam = 49,
                servet = 1,
                retailPriceRC1 = 709.8M,
                SystemPriceRC1 = 845,
                AgentName = "代1",
                purchase = 31,
                actualSale = 30,
                Inventory = 1,
                FirstPurchase = 30

            });
            agentInputs.Add(new AgentInput
            {
                Stage = "第一阶段",
                EndImage = 450,
                Salesperson = 450,
                HousePromote = 392,
                demonstrator = 294,
                outdoorActivity = 196,
                promotionTeam = 98,
                servet = 80,
                retailPriceRC1 = 839,
                SystemPriceRC1 = 746,
                AgentName = "代2",
                purchase = 31,
                actualSale = 30,
                Inventory = 1,
                FirstPurchase = 29

            });
            agentInputs.Add(new AgentInput
            {
                Stage = "第一阶段",
                EndImage = 575,
                Salesperson = 575,
                HousePromote = 460,
                demonstrator = 345,
                outdoorActivity = 230,
                promotionTeam = 115,
                servet = 200,
                retailPriceRC1 = 839,
                SystemPriceRC1 = 746.71M,
                AgentName = "代3",
                purchase = 31,
                actualSale = 30,
                Inventory = 1,
                FirstPurchase = 25

            });
            agentInputs.Add(new AgentInput
            {
                Stage = "第一阶段",
                EndImage = 230,
                Salesperson = 280,
                HousePromote = 200,
                demonstrator = 150,
                outdoorActivity = 100,
                promotionTeam = 70,
                servet = 100,
                retailPriceRC1 = 799,
                SystemPriceRC1 = 623,
                AgentName = "代4",
                purchase = 31,
                actualSale = 30,
                Inventory = 1,
                FirstPurchase = 26

            });
            #endregion

            #region 品牌设定
            invertment1s.Add(new Invertment1
            {
                Stage = "第一阶段",
                Brand = "S",
                advertise = 600,
                SurfaceRC1 = 120,
                FunctionRC1 = 200,
                materialRC1 = 100,

                retailPrice = 799
            });
            invertment1s.Add(new Invertment1
            {
                Stage = "第一阶段",
                Brand = "M",
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
            invertment1s.Add(new Invertment1
            {
                Stage = "第一阶段",
                Brand = "J",
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
            #endregion
        }
        public List<AgentInput> getAgentInputs()
        {
            return agentInputs;
        }
        public List<Invertment1> getBrandsInputs()
        {
            return invertment1s;
        }
    }
    public class Invertment1 : BrandsInput
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
            get { 
                return this.materialRC1 + this.materialRC2 + this.MaterialRC3;
            }
        }
        public decimal InputSum
        {
            get
            {
                return  this.EndImage + this.Salesperson + this.HousePromote + this.demonstrator
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
}