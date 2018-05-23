using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Infrastructure;

namespace WebMVC.Common
{
    public enum Brand
    {
        M品牌, S品牌, J品牌

    }
    public enum RCType
    {
        retailPriceRC, SystemPriceRC

    }
    public enum Stage
    {
        起始阶段,
        第1阶段,
        第2阶段,
        第3阶段

    }
    public enum AgentName
    {
        代1 = 1,
        代2,
        代3,
        代4,
        代5,
        代6

    }
    public enum MJAType
    {
        M, J, Agent
    }
    public enum ButtonSize
    {
        Large, Normal, Small, ExtraSmall
    }
    public enum ButtonStyle
    {
        Default, Primary, Succes, Info, Warning, Dangers, Link
    }
    public enum agentInputStageType
    {
        价格管控表, 进货表, 投资表, 品价格管控表

    }
    public static class subList
    {
        public static List<string> GetsubList
        {
            get
            {
                using (var db = new AppIdentityDbContext())
                {
                    return db.CodeInit.Where(s => s.Code == "Sub").Select(s => s.Text).ToList();
                }
            }

        }
    }
}