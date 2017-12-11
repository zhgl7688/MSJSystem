using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    // 产品创新力部分：ProductInnovation
    public class ProductInnovationInit
    {
        [Key]
        public int id { get; set; }
        //        1)         起始阶段最初三个品牌M/S/J创新指数均分别为35%、45%、20%；
        [DisplayName("品牌M创新指数")]
        public decimal ProductInnovation_M { get; set; } = 0.35m;
        [DisplayName("品牌S创新指数")]
        public decimal ProductInnovation_S { get; set; } = 0.45m;
        [DisplayName("品牌J创新指数")]
        public decimal ProductInnovation_J { get; set; } = 0.2m;

        //2)         起始阶段三个品牌对外观、功能、材料等方面的创新投入占比分别为30%、50%、20%；
        [DisplayName("品牌对外观的创新投入占比")]
        public decimal ProductInnovation_T { get; set; } = 0.3m;
        [DisplayName("品牌对功能的创新投入占比")]
        public decimal ProductInnovation_AC { get; set; } = 0.5m;
        [DisplayName("品牌对材料创新投入占比")]
        public decimal ProductInnovation_AL { get; set; } = 0.2m;
        //3)外观创新，无成本优势，但更有市场竞争力，当然也面临风险，即你的该项投入低于三大品牌的平均投入时，所遭遇的市场风险。
        //假定最高投入者，产出系数为1.2；
        //中间投入者，若不低于平均投入，产出系数为1.1，
        //等于平均投入，产出系数为1，
        //低于平均投入，产出系数为0.9；
        //最低投入者，产出系数为0.8；
        //外观创新对创新指数的影响为：上一年创新指数+上一年外观创新指数的次级指数=上一年创新指数+（上一年外观创新指数-上一年平均指数）*上一年外观创新产出系数；
        [DisplayName("最高投入者，产出系数")]
        public decimal ProductInnovation_CB1 { get; set; } = 1.2m;
        [DisplayName("中间投入者，若不低于平均投入，产出系数")]
         public decimal ProductInnovation_CB2 { get; set; } = 1.1m;
        [DisplayName("等于平均投入，产出系数")]
        public decimal ProductInnovation_CB3 { get; set; } = 1.0m;
        [DisplayName("低于平均投入，产出系数")]
        public decimal ProductInnovation_CB4 { get; set; } = 0.9m;
        [DisplayName("最低投入者，产出系数")]
        public decimal ProductInnovation_CB5 { get; set; } = 0.8m;
        //4) 功能创新，无成本优势，但更有市场竞争力，当然也面临风险，即你的该项投入低于三大品牌的平均投入时，所遭遇的市场风险。
        //假定最高投入者，产出系数为1.3；
        //中间投入者，若不低于平均投入，产出系数为1.15，
        //等于平均投入，产出系数为1，
        //低于平均投入，产出系数为0.85；
        //最低投入者，产出系数为0.7；
        //功能创新对创新指数的影响为：上一年创新指数+上一年功能创新指数的次级指数=上一年创新指数+（上一年功能创新指数-上一年平均指数）*上一年功能创新产出系数；
        [DisplayName("最高投入者，产出系数")]
        public decimal ProductInnovation_CK1 { get; set; } = 1.3m;
        public decimal ProductInnovation_CK2 { get; set; } = 1.15m;
        public decimal ProductInnovation_CK3 { get; set; } = 1.1m;
        public decimal ProductInnovation_CK4 { get; set; } = 0.85m;
        public decimal ProductInnovation_CK5 { get; set; } = 0.7m;


        //5) 本年创新指数=上一年创新指数+外观创新指数的次级指数*40%+功能创新指数的次级指数*60%；

        //6)材料创新，有成本优势，每投入100万，可降低2%的成本；

    }
}