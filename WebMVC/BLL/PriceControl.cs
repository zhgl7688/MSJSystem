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
                    if (agentItem.Stage == "第一阶段")
                    {
                        priceControlt.Agents.Add(1, new AgentRC() { RCName = "RC1" });
                        priceControlt.SystemPrices.Add(1, new SystemPrice());
                    }
                    if (agentItem.Stage == "第二阶段")
                    {
                        priceControlt.SystemPrices.Add(2, new SystemPrice());
                        priceControlt.Agents.Add(2, new AgentRC() { RCName = "RC2" });
                    }
                    if (agentItem.Stage == "第三阶段")
                    {
                        priceControlt.SystemPrices.Add(3, new SystemPrice());
                        priceControlt.Agents.Add(3, new AgentRC() { RCName = "RC3" });
                    }
                    priceControlTables.Add(priceControlt);
                }
                if (agentItem.Brand == "J")
                {
                    priceControlt.Competes.RC1J = agentItem.retailPrice;
                    priceControlt.Competes.RC2J = agentItem.NewRetailPriceR2;
                    priceControlt.Competes.RC3J = agentItem.NewRetailPriceR3;
                }
                else if (agentItem.Brand == "M")
                {
                    priceControlt.Competes.RC1M = agentItem.retailPrice;
                    priceControlt.Competes.RC2M = agentItem.NewRetailPriceR2;
                    priceControlt.Competes.RC3M = agentItem.NewRetailPriceR3;
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
                foreach (var item in priceControlt.Agents.Keys)
                {
                             SetAgents(agentItem, priceControlt, item);
                 }

            }
        }
        public void SetAgents(Models.AgentInput agentInput,PriceControlTable priceControlt, int item)
        {
            Dictionary<int, AgentRC> agentDic = priceControlt.Agents;
            var systemPriceDic = priceControlt.SystemPrices;
            string agentName = agentInput.AgentName;

            decimal systemPriceRC = agentInput.GetRC(item, Common.RCType.SystemPriceRC);
            decimal retailPriceRC = agentInput.GetRC(item, Common.RCType.retailPriceRC);
            switch (agentName)
            {
                case "代1":
                    agentDic[item].Agent1 = retailPriceRC;
                    systemPriceDic[item].Price1 = systemPriceRC;
                    break;
                case "代2":
                    agentDic[item].Agent2 = retailPriceRC;
                    systemPriceDic[item].Price2 = systemPriceRC;
                    break;
                case "代3":
                    agentDic[item].Agent3 = retailPriceRC;
                    systemPriceDic[item].Price3 = systemPriceRC;
                    break;
                case "代4":
                    agentDic[item].Agent4 = retailPriceRC;
                    systemPriceDic[item].Price4 = systemPriceRC;
                    break;
                case "代5":
                    agentDic[item].Agent5 = retailPriceRC;
                    systemPriceDic[item].Price5 = systemPriceRC;
                    break;
                case "代6":
                    agentDic[item].Agent6 = retailPriceRC;
                    systemPriceDic[item].Price6 = systemPriceRC;
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
        public CompeteRC Competes { get; set; } = new CompeteRC();
        public Dictionary<int, AgentRC> Agents { get; set; } = new Dictionary<int, AgentRC>();
        public Dictionary<int, SystemPrice> SystemPrices { get; set; } = new Dictionary<int, SystemPrice>();
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
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
        public decimal Price4 { get; set; }
        public decimal Price5 { get; set; }
        public decimal Price6 { get; set; }
    }
}