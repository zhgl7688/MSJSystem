using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class PriceControl
    {
        List<PriceControlTable> priceControlTables = new List<PriceControlTable>();
        InvertmentTable1 invertmenetTable1;
 
        AgentStages agentStages;
        /// <summary>
        /// 价格管控表
        /// </summary>
        public PriceControl(InvertmentTable1 invertmentTable1)
        {
            agentStages = new AgentStages();
            invertmenetTable1 = invertmentTable1;
            init();
         
        }
        public void init()
        {
            var brandsInputs = invertmenetTable1.getBrandTable();
            foreach (var agentItem in brandsInputs)
            {
                var priceControl = priceControlTables.FirstOrDefault(s => s.Stage == agentItem.Stage);
                if (priceControl == null)
                {
                    priceControl = new PriceControlTable { Stage = agentItem.Stage };
                    priceControlTables.Add(priceControl);
                }
                if (agentItem.Brand == Common.Brand.M品牌.ToString())
                {
                    priceControl.AG.M = agentItem.NewCostPrice;
                    priceControl.AJ.M = agentItem.NewFactoryPrice;
                    priceControl.B.RcM.Add(agentItem.retailPrice);
                    priceControl.B.RcM.Add(agentItem.NewRetailPriceR2);
                    priceControl.B.RcM.Add(agentItem.NewRetailPriceR3);
                }
                else
                if (agentItem.Brand == Common.Brand.J品牌.ToString())
                {
                    priceControl.AG.J = agentItem.NewCostPrice;
                    priceControl.AJ.J = agentItem.NewFactoryPrice;
                    priceControl.B.RcJ.Add(agentItem.retailPrice);
                    priceControl.B.RcJ.Add(agentItem.NewRetailPriceR2);
                    priceControl.B.RcJ.Add(agentItem.NewRetailPriceR3);
                }
                else
                if (agentItem.Brand == Common.Brand.S品牌.ToString())
                {
                    priceControl.AG.S = agentItem.NewCostPrice;
                    priceControl.AJ.S = agentItem.NewFactoryPrice;
                }

            }


            var agents = invertmenetTable1.getAgentInputs();
            foreach (var agentItem in agents)
            {
                var priceControl = priceControlTables.FirstOrDefault(s => s.Stage == agentItem.Stage);
                if (priceControl == null)
                {
                    continue;
                }
                string agentName = agentItem.AgentName;
                var countStage = agentStages.stages.IndexOf(agentItem.Stage);
                for (int i = 0; i < countStage; i++)
                {
                    SetAgents(agentName, priceControl.D[i], priceControl.K[i], agentItem.retailPriceRC[i], agentItem.SystemPriceRC[i]);

                }
               
            }



        }
        public void SetAgents(string agentName, AgentRC D, AgentRC K, decimal retailPrice, decimal SystemPrice)
        {
            var agentStages = new AgentStages();
            var index = agentStages.agents.FindIndex(s => s == agentName);
            for (int i = D.Agent.Count; i <agentStages.agents.Count; i++)
            {
                D.Agent.Add(0);
                K.Agent.Add(0);
            }

            D.Agent[index] = retailPrice;
            K.Agent[index] = SystemPrice;

        }
        public List<PriceControlTable> Get()
        {
            return priceControlTables;
        }
    }
    public class PriceControlTable
    {
        public PriceControlTable()
        {
            var countStage = new AgentStages().stages.Count;
            for (int i = 0; i < countStage-1; i++)
            {
                D.Add(i, new AgentRC());
                K.Add(i, new AgentRC());
            }



        }
        public string Stage { get; set; }
        public CompeteRC B { get; set; } = new CompeteRC();
        public Dictionary<int, AgentRC> D { get; set; } = new Dictionary<int, AgentRC>();
        public Dictionary<int, AgentRC> K { get; set; } = new Dictionary<int, AgentRC>();
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
        public List<decimal> Agent { get; set; } = new List<decimal>();
        //public decimal Agent1 { get; set; }
        //public decimal Agent2 { get; set; }
        //public decimal Agent3 { get; set; }
        //public decimal Agent4 { get; set; }
        //public decimal Agent5 { get; set; }
        //public decimal Agent6 { get; set; }
        public decimal Average
        {
            get { return (this.Agent.Average(s => s)); }
        }
    }

}