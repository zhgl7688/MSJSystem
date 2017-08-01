using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class PriceControl
    {
        List<PriceControlTable> priceControlTables = new List<PriceControlTable>();
        InvertmentTable1 invertmenetTable1;
        /// <summary>
        /// 价格管控表
        /// </summary>
        public PriceControl()
        {
            invertmenetTable1 = new InvertmentTable1();
            init();
        }
        public void init()
        {
            var brandsInputs = invertmenetTable1.getBrandsInputs();
            foreach (var agentItem in brandsInputs)
            {
                var priceControlt = priceControlTables.FirstOrDefault(s => s.Stage == agentItem.Stage);
                if (priceControlt == null)
                {
                    priceControlt = new PriceControlTable { Stage = agentItem.Stage };
                    if (agentItem.Stage == Common.Stage.第一阶段.ToString())
                    {
                        priceControlt.D.Add(1, new AgentRC() { RCName = "RC1" });
                        priceControlt.K.Add(1, new SystemPrice());
                    }
                    if (agentItem.Stage == Common.Stage.第二阶段.ToString())
                    {
                        priceControlt.K.Add(2, new SystemPrice());
                        priceControlt.D.Add(2, new AgentRC() { RCName = "RC2" });
                        if (agentItem.Brand == Common.Brand.M品牌.ToString())
                        {
                            priceControlt.AG.M = agentItem.NewCostPrice;
                            priceControlt.AJ.M = agentItem.NewFactoryPrice;
                        }
                        if (agentItem.Brand == Common.Brand.J品牌.ToString())
                        {
                            priceControlt.AG.J = agentItem.NewCostPrice;
                            priceControlt.AJ.J = agentItem.NewFactoryPrice;
                        }
                        if (agentItem.Brand == Common.Brand.S品牌.ToString())
                        {
                            priceControlt.AG.S = agentItem.NewCostPrice;
                            priceControlt.AJ.S = agentItem.NewFactoryPrice;
                        }
                    }
                    if (agentItem.Stage == Common.Stage.第三阶段.ToString())
                    {
                        priceControlt.K.Add(3, new SystemPrice());
                        priceControlt.D.Add(3, new AgentRC() { RCName = "RC3" });
                    }
                    priceControlTables.Add(priceControlt);
                }
                if (agentItem.Brand == Common.Brand.J品牌.ToString())
                {
                    priceControlt.B.RC1J = agentItem.retailPrice;
                    priceControlt.B.RC2J = agentItem.NewRetailPriceR2;
                    priceControlt.B.RC3J = agentItem.NewRetailPriceR3;
                }
                else if (agentItem.Brand == Common.Brand.M品牌.ToString())
                {
                    priceControlt.B.RC1M = agentItem.retailPrice;
                    priceControlt.B.RC2M = agentItem.NewRetailPriceR2;
                    priceControlt.B.RC3M = agentItem.NewRetailPriceR3;
                }


            }
            var agents = invertmenetTable1.getAgentInputs();
            foreach (var agentItem in agents)
            {
                var priceControlt = priceControlTables.FirstOrDefault(s => s.Stage == agentItem.Stage);
                if (priceControlt == null)
                {
                    priceControlt = new PriceControlTable { Stage = agentItem.Stage };
                    priceControlTables.Add(priceControlt);
                }
                foreach (var item in priceControlt.D.Keys)
                {
                    SetAgents(agentItem, priceControlt, item);
                }

            }
        }
        public void SetAgents(Models.AgentInput agentInput, PriceControlTable priceControlt, int item)
        {
            Dictionary<int, AgentRC> agentDic = priceControlt.D;
            var systemPriceDic = priceControlt.K;
            string agentName = agentInput.AgentName;

            decimal systemPriceRC = agentInput.GetRC(item, Common.RCType.SystemPriceRC);
            decimal retailPriceRC = agentInput.GetRC(item, Common.RCType.retailPriceRC);
            switch (agentName)
            {
                case "代1":
                    agentDic[item].Agent1 = retailPriceRC;
                    systemPriceDic[item].Agent1 = systemPriceRC;
                    break;
                case "代2":
                    agentDic[item].Agent2 = retailPriceRC;
                    systemPriceDic[item].Agent2 = systemPriceRC;
                    break;
                case "代3":
                    agentDic[item].Agent3 = retailPriceRC;
                    systemPriceDic[item].Agent3 = systemPriceRC;
                    break;
                case "代4":
                    agentDic[item].Agent4 = retailPriceRC;
                    systemPriceDic[item].Agent4 = systemPriceRC;
                    break;
                case "代5":
                    agentDic[item].Agent5 = retailPriceRC;
                    systemPriceDic[item].Agent5 = systemPriceRC;
                    break;
                case "代6":
                    agentDic[item].Agent6 = retailPriceRC;
                    systemPriceDic[item].Agent6 = systemPriceRC;
                    break;
                default:
                    break;
            }
        }
        public List<PriceControlTable> Get()
        {
            return priceControlTables;
        }
    }
    public class PriceControlTable
    {
        public string Stage { get; set; }
        public CompeteRC B { get; set; } = new CompeteRC();
        public Dictionary<int, AgentRC> D { get; set; } = new Dictionary<int, AgentRC>();
        public Dictionary<int, SystemPrice> K { get; set; } = new Dictionary<int, SystemPrice>();
        /// <summary>
        /// 成本价
        /// </summary>
        public RC AG { get; set; } = new RC();
        /// <summary>
        /// 出厂价
        /// </summary>
        public RC AJ { get; set; } = new RC();
    }

    public class AgentRC
    {
        public string RCName { get; set; }
        public decimal Agent1 { get; set; }
        public decimal Agent2 { get; set; }
        public decimal Agent3 { get; set; }
        public decimal Agent4 { get; set; }
        public decimal Agent5 { get; set; }

        public decimal Agent6 { get; set; }
        public decimal Average
        {
            get { return (this.Agent1 + this.Agent2 + this.Agent3 + this.Agent4 + this.Agent5 + this.Agent6) / 6; }
        }
    }
    public class SystemPrice
    {
        public decimal Agent1 { get; set; }
        public decimal Agent2 { get; set; }
        public decimal Agent3 { get; set; }
        public decimal Agent4 { get; set; }
        public decimal Agent5 { get; set; }
        public decimal Agent6 { get; set; }
    }
}