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
                    priceControl.B.RC1M = agentItem.retailPrice;
                    priceControl.B.RC2M = agentItem.NewRetailPriceR2;
                    priceControl.B.RC3M = agentItem.NewRetailPriceR3;
                }
                else
                if (agentItem.Brand == Common.Brand.J品牌.ToString())
                {
                    priceControl.AG.J = agentItem.NewCostPrice;
                    priceControl.AJ.J = agentItem.NewFactoryPrice;
                    priceControl.B.RC1J = agentItem.retailPrice;
                    priceControl.B.RC2J = agentItem.NewRetailPriceR2;
                    priceControl.B.RC3J = agentItem.NewRetailPriceR3;
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
                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), agentItem.AgentName);
               
                if (agentItem.Stage == Stage.第一阶段.ToString())
                {
                    SetAgents(agentName, priceControl.D[1], priceControl.K[1], agentItem.retailPriceRC1, agentItem.SystemPriceRC1);
                }else
                if (agentItem.Stage == Stage.第二阶段.ToString())
                {
                    SetAgents(agentName, priceControl.D[1], priceControl.K[1], agentItem.retailPriceRC1, agentItem.SystemPriceRC1);
                    SetAgents(agentName, priceControl.D[2], priceControl.K[2], agentItem.retailPriceRC2, agentItem.SystemPriceRC2);

                }
                if (agentItem.Stage == Stage.第三阶段.ToString())
                {
                    SetAgents(agentName, priceControl.D[1], priceControl.K[1], agentItem.retailPriceRC1, agentItem.SystemPriceRC1);
                    SetAgents(agentName, priceControl.D[2], priceControl.K[2], agentItem.retailPriceRC2, agentItem.SystemPriceRC2);
                    SetAgents(agentName, priceControl.D[3], priceControl.K[3], agentItem.retailPriceRC3, agentItem.SystemPriceRC3);
                }
            }


        
    }
    public void SetAgents(AgentName agentName, AgentRC D,AgentRC K, decimal retailPrice,decimal SystemPrice)
    {
       
        switch (agentName)
        {
            case AgentName.代1:
                 D .Agent1 = retailPrice;
                 K .Agent1 = SystemPrice;

                break;
            case AgentName.代2:
                D.Agent2 = retailPrice;
                K.Agent2 = SystemPrice;
                break;
            case AgentName.代3:
                D.Agent3 = retailPrice;
                K.Agent3 = SystemPrice;
                break;
            case AgentName.代4:
                D.Agent4 = retailPrice;
                K.Agent4 = SystemPrice;
                break;
            case AgentName.代5:
                D.Agent5 = retailPrice;
                K.Agent5 = SystemPrice;
                break;
            case AgentName.代6:
                D.Agent6 = retailPrice;
                K.Agent6 = SystemPrice;
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
        public PriceControlTable()
        {
            B = new CompeteRC();
            D = new Dictionary<int, AgentRC>();
            K = new Dictionary<int, AgentRC>();
                 D.Add(1, new AgentRC());
                 D.Add(2, new AgentRC());
                 D.Add(3, new AgentRC());
                 K.Add(1, new AgentRC());
                 K.Add(2, new AgentRC());
                 K.Add(3, new AgentRC());
           
        }
    public string Stage { get; set; }
    public   CompeteRC  B { get; set; }  
    public Dictionary<int, AgentRC> D { get; set; }  
    public Dictionary<int, AgentRC> K { get; set; } 
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
  
}