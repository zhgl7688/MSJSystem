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
        List<BrandsInput> brandsInputs = new List<BrandsInput>();
        public List<AgentInput> getAgentInputs()
        {
            return agentInputs;
        }
        public List<BrandsInput> getBrandsInputs()
        {
            return brandsInputs;
        }
    }
}