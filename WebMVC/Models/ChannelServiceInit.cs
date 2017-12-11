using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    // 渠道服务部分：ChannelService	
    public class ChannelServiceInit
    {
        [Key]
        public int id { get; set; }
        //1)         服务投入影响下一年顾客满意度指数。当年顾客满意度指数对下一年有40%的叠加影响；
        public decimal ChannelService_J1 { get; set; } = 0.4m;
        //2)         起始阶段三个品牌商顾客满意度指数均为98%；
        public decimal ChannelService_J2 { get; set; } = 0.98m;


    }
}