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

    
        /// <summary>
        /// 价格管控表
        /// </summary>
        public PriceControl(InvertmentTable1 invertmentTable1)
        {
  
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
                    for (int i = 0; i < agentItem.retailPriceRC.Count; i++)
                    {
                        priceControl.B.RcM.Add(agentItem.retailPriceRC[i]);
                    }
                }
                else
                if (agentItem.Brand == Common.Brand.J品牌.ToString())
                {
                    priceControl.AG.J = agentItem.NewCostPrice;
                    priceControl.AJ.J = agentItem.NewFactoryPrice;
                    for (int i = 0; i < agentItem.retailPriceRC.Count; i++)
                    {
                        priceControl.B.RcJ.Add(agentItem.retailPriceRC[i]);
                    }
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
                var countStage = AgentStages.stages.IndexOf(agentItem.Stage);
                for (int i = 0; i < countStage; i++)
                {
                    if (priceControl.D.Count <= i) priceControl.D.Add(i, new AgentRC());
                    if (priceControl.K.Count <= i) priceControl.K.Add(i, new AgentRC());
                    if (agentItem.retailPriceRC.Count <= i) agentItem.retailPriceRC.Add(0);
                    if (agentItem.SystemPriceRC.Count <= i) agentItem.SystemPriceRC.Add(0);

                    SetAgents(agentName, priceControl.D[i], priceControl.K[i], agentItem.retailPriceRC[i], agentItem.SystemPriceRC[i]);

                }

            }



        }
        public PriceControlTable GetPriceBy(Stage stageItem)
        {
            PriceControlTable priceControl = new PriceControlTable
            {
                Stage = stageItem.ToString(),
            };
           var brandsInputs = invertmenetTable1.getBrandTable().Where(s=>s.Stage==stageItem.ToString());
            foreach (var agentItem in brandsInputs)
            {
                 if (agentItem.Brand == Common.Brand.M品牌.ToString())
                {
                    priceControl.AG.M = agentItem.NewCostPrice;
                    priceControl.AJ.M = agentItem.NewFactoryPrice;
                    for (int i = 0; i < agentItem.retailPriceRC.Count; i++)
                    {
                        priceControl.B.RcM.Add(agentItem.retailPriceRC[i]);
                    }
                }
                else
                if (agentItem.Brand == Common.Brand.J品牌.ToString())
                {
                    priceControl.AG.J = agentItem.NewCostPrice;
                    priceControl.AJ.J = agentItem.NewFactoryPrice;
                    for (int i = 0; i < agentItem.retailPriceRC.Count; i++)
                    {
                        priceControl.B.RcJ.Add(agentItem.retailPriceRC[i]);
                    }
                }
                else
                if (agentItem.Brand == Common.Brand.S品牌.ToString())
                {
                    priceControl.AG.S = agentItem.NewCostPrice;
                    priceControl.AJ.S = agentItem.NewFactoryPrice;
                }

            }
            var agents = invertmenetTable1.getAgentInputs().Where(s=>s.Stage==stageItem.ToString());
            foreach (var agentItem in agents )
            {
                var countStage = AgentStages.stages.IndexOf(agentItem.Stage);
                for (int i = 0; i < countStage; i++)
                {
                    if (priceControl.D.Count <= i) priceControl.D.Add(i, new AgentRC());
                    if (priceControl.K.Count <= i) priceControl.K.Add(i, new AgentRC());
                    if (agentItem.retailPriceRC.Count <= i) agentItem.retailPriceRC.Add(0);
                    if (agentItem.SystemPriceRC.Count <= i) agentItem.SystemPriceRC.Add(0);

                    SetAgents(agentItem.AgentName, priceControl.D[i], priceControl.K[i], agentItem.retailPriceRC[i], agentItem.SystemPriceRC[i]);

                }

            }
            return priceControl;
        }
        public void SetAgents(string agentName, AgentRC D, AgentRC K, decimal retailPrice, decimal SystemPrice)
        {
          
            var index = AgentStages.agents.FindIndex(s => s == agentName);
            for (int i = D.Agent.Count; i < AgentStages.agents.Count; i++)
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
            var countStage = AgentStages.stages.Count;
            for (int i = 0; i < countStage - 1; i++)
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
 
        public decimal Average
        {
            get { return (this.Agent.Average(s => s)); }
        }
    }

}