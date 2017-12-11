using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    //市场容量：CurrentShare	
    public class CurrentShareInit
    {
        [Key]
        public int id { get; set; }
        //1) 主销价格段、市场总容量、社会人口数、社会购买力等信息需要可以修改填写。
        public int D { get; set; }
        public int E { get; set; }
        public int F { get; set; }
        public int G { get; set; }

        //2) 起始阶段M品牌该单品销售了45万台，S品牌销售了30万台，J品牌销售了25万台，三大品牌共销售100万台
        public decimal H { get; set; } = 0.45m;
        public decimal Z { get; set; } = 0.25m;
        public decimal J { get; set; } = 0.3m;


    }
}