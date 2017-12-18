using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("阶段")]
        [Required]
        public string G { get; set; } = "起始阶段";
        [DisplayName("市场总容量")]
        public int D { get; set; } = 100;
        [DisplayName("社会人口数")]
        public int E { get; set; } = 100;
        [DisplayName("社会购买力")]
        public int F { get; set; } = 1;
      


        //2) 起始阶段M品牌该单品销售了45万台，S品牌销售了30万台，J品牌销售了25万台，三大品牌共销售100万台
        [DisplayName("M品牌销售")]
        public decimal H { get; set; } = 0.45m;
        [DisplayName("S品牌销售")]
        public decimal Z { get; set; } = 0.25m;
        [DisplayName("J品牌销售")]
        public decimal AR { get; set; } = 0.3m;


    }
}