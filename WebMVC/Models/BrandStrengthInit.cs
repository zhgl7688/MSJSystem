using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    // 品牌力部分：BrandStrength
    public class BrandStrengthInit
    {
        [Key]
        public int id { get; set; }
        //最初品牌力指数均为33
        [DisplayName("最初品牌力指数")]
        public int BrandStrength_E { get; set; } = 33;
        //起始阶段每个品牌商的启动资金为1000万，投放范围包括：广告（800万）、研发创新（200万）两方面；
        [DisplayName("品牌商启动资金-广告")]
        public int BrandStrength_M1 { get; set; } = 800;
        [DisplayName("品牌商启动资金-研发创新")]
        public int BrandStrength_M2 { get; set; } = 200;
        //   起始阶段每个代理商启动资金为1000万；
        [DisplayName("代理商启动资金")]
        public int BrandStrength_Agent { get; set; } = 1000;

        //上年广告投入影响力指数对品牌力指数的影响占35%，本年广告投入影响力指数对对品牌力指数的影响占65%；
        [DisplayName("上年广告投入影响力指数对品牌力指数的影响占")]
        public decimal lastM { get; set; } = 0.35m;
        [DisplayName("本年广告投入影响力指数对对品牌力指数的影响占")]
        public decimal currentM { get; set; } =0.65m;

    }
}