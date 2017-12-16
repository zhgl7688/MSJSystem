using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.BLL
{
    /// <summary>
    /// 投资表1
    /// </summary>
    public class InvertmentTable1
    {  
        List<AgentInput> agentInputs;
        List<BrandTable> brands = new List<BrandTable>();
        List<BrandsInput> brandsInputs;
        private AgentStages agentStages;
        public InvertmentTable1(List<AgentInput> agentInputs, List<BrandsInput> brandsInputs, AgentStages agentStages)
        {
            this.agentInputs = agentInputs;
            this.brandsInputs = brandsInputs;
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
                var index = agentStages.agents .FindIndex(s => s == item.AgentName);
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
        public int GetAgentCount
        {
            get { return agentInputs.Select(s => s.AgentName).Distinct().Count(); }
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