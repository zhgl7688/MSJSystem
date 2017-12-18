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

        public InvertmentTable1(List<AgentInput> agentInputs, List<BrandsInput> brandsInputs)
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
                brands.Add(Cal.AutoCopy<BrandsInput, BrandTable>(item));
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
            var agentStages = new AgentStages();
            //初始化行列
            for (int i = 1; i < agentStages.stages.Count; i++)
            {
                agents.Add(new AgentTable() { Stage = agentStages.stages[i] });
            }
            agents.ForEach(s =>
            {
                for (int i = 0; i < agentStages.agents.Count; i++)
                {
                    s.Bagent.Add(new BrandInput());
                }
            });

            foreach (var item in agentInputs)
            {
                agents.ForEach(s =>
                {
                    if (s.Stage == item.Stage)
                    {
                        var index = agentStages.agents.FindIndex(j => j == item.AgentName);
                        s.Bagent[index] = item.brandInput;
                    }


                });


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
        public List<BrandInput> Bagent { get; set; } = new List<BrandInput>();
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