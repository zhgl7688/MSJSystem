using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        第一阶段,
        第二阶段,
        第三阶段

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
       Default, Primary,Succes,Info,Warning, Dangers,Link
    }
    public enum agentInputStageType
    {
           价格管控表 ,进货表 

    }
}