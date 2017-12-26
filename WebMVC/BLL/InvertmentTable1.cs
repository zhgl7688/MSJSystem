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

            this.agentInputs.ForEach(s =>
            {
                if (s.PriceMange != null && s.PriceMange.Count > 0)
                {
                    s.retailPriceRC = s.PriceMange.Where(j => j.Name.Contains("零售价")).Select(j => j.Value).ToList();
                    s.SystemPriceRC = s.PriceMange.Where(j => j.Name.Contains("系统供价")).Select(j => j.Value).ToList();
                }
                if (s.PurchaseTable != null && s.PurchaseTable.Count > 0)
                {
                    s.Purchase = s.PurchaseTable.Select(j => j.Value).ToList();
                }

            });
            this.brandsInputs = brandsInputs;
            this.brandsInputs.ForEach(s =>
            {
                if (s.PriceManageSub != null && s.PriceManageSub.Count > 0)
                {
                    s.retailPriceRC = s.PriceManageSub.Where(j => j.Name.Contains("零售价")).Select(j => j.Value).ToList();
                    s.SystemPriceRC = s.PriceManageSub.Where(j => j.Name.Contains("系统供价")).Select(j => j.Value).ToList();
                    var costPrice = s.PriceManageSub.FirstOrDefault(j => j.Name.Contains("成本价"));
                    s.NewCostPrice = costPrice != null ? costPrice.Value : 0;
                    var factoryPrice = s.PriceManageSub.FirstOrDefault(j => j.Name.Contains("出厂价"));
                    s.NewFactoryPrice = factoryPrice != null ? factoryPrice.Value : 0;
                }

                if (s.InvestSub != null && s.InvestSub.Count > 0)
                {
                    s.SurfaceRC = s.InvestSub.Where(j => j.Name.Contains("外观")).Select(j => j.Value).ToList();
                    s.FunctionRC = s.InvestSub.Where(j => j.Name.Contains("功能")).Select(j => j.Value).ToList();
                    s.MaterialRC = s.InvestSub.Where(j => j.Name.Contains("材料")).Select(j => j.Value).ToList();
                }
            });
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
       
            //初始化行列
            for (int i = 1; i < AgentStages.stages.Count; i++)
            {
                agents.Add(new AgentTable() { Stage = AgentStages.stages[i] });
            }
            agents.ForEach(s =>
            {
                for (int i = 0; i < AgentStages.agents.Count; i++)
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
                        var index = AgentStages.agents.FindIndex(j => j == item.AgentName);
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