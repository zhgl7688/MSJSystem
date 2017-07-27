using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    public class PriceControl
    {
        List<PriceControlTable> priceControlTables = new List<PriceControlTable>();
        InvertmentTable1 invertmenetTable1 = new InvertmentTable1();
        public void add()
        {
            var brandsInputs = invertmenetTable1.getBrandsInputs();
            foreach (var agentItem in brandsInputs)
            {
                var priceControlt = priceControlTables.FirstOrDefault(s => s.阶段 == agentItem.Stage);
                if (priceControlt == null)
                {
                    priceControlt = new PriceControlTable { 阶段 = agentItem.Stage };
                    if (agentItem.Stage == "第一阶段")
                    {
                        priceControlt.Agents.Add(1, new AgentRC() { RCName = "RC1" });
                    }
                    if (agentItem.Stage == "第二阶段")
                    {
                        priceControlt.Agents.Add(2, new AgentRC() { RCName = "RC2" });
                    }
                    if (agentItem.Stage == "第三阶段")
                    {
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
                var priceControlt = priceControlTables.FirstOrDefault(s => s.阶段 == agentItem.Stage);
                if (priceControlt == null)
                {
                    priceControlt = new PriceControlTable { 阶段 = agentItem.Stage };
                    priceControlTables.Add(priceControlt);
                }
                foreach (var item in priceControlt.Agents.Keys)
                {

                    if (item == 1)
                    {
                        SetAgents(agentItem.AgentName, priceControlt.Agents,item, agentItem.SystemPriceRC1);

                    }

                }

            }
        }
        public void SetAgents(string agentName ,Dictionary<int, AgentRC> agentDic,int item,decimal value)
        {
            switch (agentName)
            {
                case "代1":
                    agentDic[item].Agent1 = value;
                    break;
                case "代2":
                    agentDic[item].Agent2 = value;
                    break;
                case "代3":
                    agentDic[item].Agent3 = value;
                    break;
                case "代4":
                    agentDic[item].Agent4 = value;
                    break;
                case "代5":
                    agentDic[item].Agent5 = value;
                    break;
                case "代6":
                    agentDic[item].Agent6 = value;
                    break;
                default:
                    break;
            }
        }

    }
    public class PriceControlTable
    {
        public string 阶段 { get; set; }
        public CompeteRC Competes { get; set; } = new CompeteRC();
        public Dictionary<int, AgentRC> Agents { get; set; } = new Dictionary<int, AgentRC>();
        public List<SystemPrice> SystemPrices { get; set; } = new List<SystemPrice>();
    }
    public class CompeteRC
    {
        public decimal RC1M { get; set; }
        public decimal RC1J { get; set; }
        public decimal RC2M { get; set; }
        public decimal RC2J { get; set; }
        public decimal RC3M { get; set; }
        public decimal RC3J { get; set; }

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