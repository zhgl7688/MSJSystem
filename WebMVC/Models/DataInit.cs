using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class DataInit
    {
        [Key]
        public int id { get; set; }

        #region  品牌力部分：BrandStrength
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
        public decimal currentM { get; set; } = 0.65m;
        #endregion

        #region  渠道服务部分：ChannelService	
        //1)         服务投入影响下一年顾客满意度指数。当年顾客满意度指数对下一年有40%的叠加影响；
        [DisplayName("服务投入影响下一年顾客满意度指数")]
        public decimal ChannelService_J1 { get; set; } = 0.4m;
        //2)         起始阶段三个品牌商顾客满意度指数均为98%；
        [DisplayName("起始阶段三个品牌商顾客满意度指数")]
        public decimal ChannelService_J2 { get; set; } = 0.98m;
        #endregion

        #region //市场价格部分：MarketPrice	

        //1)         M/S/J三大品牌的第一阶段成本价和出厂价假定维持不变，分别为：300、315、285和435、465、395；M和J的零售价由各自品牌确定，不准溢价，S品牌的指导零售价由S品牌发布，但市场实际零售价由代理商确定；
        [DisplayName("M品牌成本价")]
        public decimal CD { get; set; } = 300;
        [DisplayName("S品牌成本价")]
        public decimal CE { get; set; } = 315;
        [DisplayName("J品牌成本价")]
        public decimal CF { get; set; } = 285;
        [DisplayName("M大品牌出厂价")]
        public decimal CM { get; set; } = 435;
        [DisplayName("S品牌出厂价")]
        public decimal CN { get; set; } = 465;
        [DisplayName("J品牌出厂价")]
        public decimal CO { get; set; } = 395;
        //2)         假定卖场对M品牌的政策为：前台毛利率不低于10%（按零售价）、促销费用5%（按零售价）、年度退佣5%（按供价）、固定费用500万/年；
        [DisplayName("前台毛利率")]
        public decimal M_GrossMargin { get; set; } = 0.1m;
        [DisplayName("促销费用")]
        public decimal M_promotional { get; set; } = 0.05m;
        [DisplayName("年度退佣")]
        public decimal M_Year { get; set; } = 0.05m;
        [DisplayName("固定费用")]
        public decimal M_FixedCharges { get; set; } = 500m;
        //3)         假定卖场对S品牌的政策为：前台毛利率不低于11%（按零售价）、促销费用5%（按零售价）、年度退佣6%（按供价）、固定费用300万/年；
        //第二阶段起，如果零售同比增长达到15%及以上，则卖场年度退佣按照5%；
        [DisplayName("前台毛利率")]
        public decimal S_GrossMargin { get; set; } = 0.11m;
        [DisplayName("促销费用")]
        public decimal S_promotional { get; set; } = 0.05m;
        [DisplayName("年度退佣")]
        public decimal S_Year { get; set; } = 0.06m;
        [DisplayName("固定费用")]
        public decimal S_FixedCharges { get; set; } = 300;
        //4)         假定卖场对J品牌的政策为：前台毛利率不低于12%（按零售价）、促销费用4%（按零售价）、年度退佣7%（按供价）、固定费用200万/年；
        [DisplayName("前台毛利率")]
        public decimal J_GrossMargin { get; set; } = 0.12m;
        [DisplayName("促销费用")]
        public decimal J_promotional { get; set; } = 0.04m;
        [DisplayName("年度退佣")]
        public decimal J_Year { get; set; } = 0.07m;
        [DisplayName("固定费用")]
        public decimal J_FixedCharges { get; set; } = 200;
        //5)         如果第一阶段三大品牌的产品价格都定为799，则M价格指数为34、S价格指数为36、J价格指数为31；
        [DisplayName("M品牌产品价格")]
        public decimal price_M { get; set; } = 799;
        [DisplayName("S品牌产品价格")]
        public decimal price_S { get; set; } = 799;
        [DisplayName("J品牌产品价格")]
        public decimal price_J { get; set; } = 799;
        [DisplayName("M品牌价格指数")]
        public decimal priceIndex_M { get; set; } = 34;
        [DisplayName("S品牌价格指数")]
        public decimal priceIndex_S { get; set; } = 36;
        [DisplayName("J品牌价格指数")]
        public decimal priceIndex_J { get; set; } = 31;

        //6)         如果第一阶段三大品牌的产品价格分别定为799、845、739，则M、S、J的价格指数均为33.3；

        //7)         S价格指数的计算公式：（1/3)*((M的零售价/(S的零售价-（相同价格指数下的S售价549-相同价格指数下的M售价529））+J的零售价/(S的零售价-（相同价格指数下的S售价549-相同价格指数下的J售价479））)/2；
        //8)         M价格指数的计算公式：（1/3)*((S的零售价/(M的零售价-（相同价格指数下的M售价529-相同价格指数下的S售价549））+J的零售价/(M的零售价-（相同价格指数下的M售价529-相同价格指数下的J售价479））)/2；
        //9)         J的价格指数计算公式：（1/3)*((M的零售价/(J的零售价-（相同价格指数下的J售价479-相同价格指数下的M售价529））+S的零售价/(J的零售价-（相同价格指数下的J售价479-相同价格指数下的S售价529））)/2；

        #endregion

        #region     市场推广部分：MarketPromotion	
        //1)         市场推广当年投入当年产生影响，同时对第二期、第三期可以构成加强影响，加强影响系数分别为：0.6、0.25；假定起始阶段三大品牌均无形象投入。
        [DisplayName("对第二期")]
        public decimal MarketPromotionInit_AY1 { get; set; } = 0.6m;
        [DisplayName("对第三期")]
        public decimal MarketPromotionInit_AY2 { get; set; } = 0.25m;

        //2)         市场推广和渠道服务投入：M/J均由工厂投入，S由代理商投入，工厂按照1:1的投入原则在年底一次性贴补代理商，但贴补金额不能超过年度费用预算；

        //3)         对市场推广影响指数的权重分别为：终端形象25%、导购派驻25%、店内促销20%、演示开展15%、户外活动10%、推广小分队5%；
        [DisplayName("终端形象")]
        public decimal MarketPromotionInit_AX1 { get; set; } = 0.25m;
        [DisplayName("导购派驻")]
        public decimal MarketPromotionInit_AX2 { get; set; } = 0.25m;
        [DisplayName("店内促销店内促销")]
        public decimal MarketPromotionInit_AX3 { get; set; } = 0.20m;
        [DisplayName("演示开展")]
        public decimal MarketPromotionInit_AX4 { get; set; } = 0.15m;
        [DisplayName("户外活动")]
        public decimal MarketPromotionInit_AX5 { get; set; } = 0.10m;
        [DisplayName("推广小分队")]
        public decimal MarketPromotionInit_AX6 { get; set; } = 0.5m;
        #endregion

        #region 产品创新力部分：ProductInnovation
        //        1)         起始阶段最初三个品牌M/S/J创新指数均分别为35%、45%、20%；
        [DisplayName("品牌M创新指数")]
        public decimal ProductInnovation_M { get; set; } = 0.35m;
        [DisplayName("品牌S创新指数")]
        public decimal ProductInnovation_S { get; set; } = 0.45m;
        [DisplayName("品牌J创新指数")]
        public decimal ProductInnovation_J { get; set; } = 0.2m;

        //2)         起始阶段三个品牌对外观、功能、材料等方面的创新投入占比分别为30%、50%、20%；
        [DisplayName("品牌对外观")]
        public decimal ProductInnovation_T { get; set; } = 0.3m;
        [DisplayName("品牌对功能")]
        public decimal ProductInnovation_AC { get; set; } = 0.5m;
        [DisplayName("品牌对材料")]
        public decimal ProductInnovation_AL { get; set; } = 0.2m;
        //3)外观创新，无成本优势，但更有市场竞争力，当然也面临风险，即你的该项投入低于三大品牌的平均投入时，所遭遇的市场风险。
        //假定最高投入者，产出系数为1.2；
        //中间投入者，若不低于平均投入，产出系数为1.1，
        //等于平均投入，产出系数为1，
        //低于平均投入，产出系数为0.9；
        //最低投入者，产出系数为0.8；
        //外观创新对创新指数的影响为：上一年创新指数+上一年外观创新指数的次级指数=上一年创新指数+（上一年外观创新指数-上一年平均指数）*上一年外观创新产出系数；
        [DisplayName("最高投入者")]
        public decimal ProductInnovation_CB1 { get; set; } = 1.2m;
        [DisplayName("中间投入者")]
        public decimal ProductInnovation_CB2 { get; set; } = 1.1m;
        [DisplayName("等于平均投入")]
        public decimal ProductInnovation_CB3 { get; set; } = 1.0m;
        [DisplayName("低于平均投入")]
        public decimal ProductInnovation_CB4 { get; set; } = 0.9m;
        [DisplayName("最低投入者")]
        public decimal ProductInnovation_CB5 { get; set; } = 0.8m;
        //4) 功能创新，无成本优势，但更有市场竞争力，当然也面临风险，即你的该项投入低于三大品牌的平均投入时，所遭遇的市场风险。
        //假定最高投入者，产出系数为1.3；
        //中间投入者，若不低于平均投入，产出系数为1.15，
        //等于平均投入，产出系数为1，
        //低于平均投入，产出系数为0.85；
        //最低投入者，产出系数为0.7；
        //功能创新对创新指数的影响为：上一年创新指数+上一年功能创新指数的次级指数=上一年创新指数+（上一年功能创新指数-上一年平均指数）*上一年功能创新产出系数；
        [DisplayName("最高投入者")]
        public decimal ProductInnovation_CK1 { get; set; } = 1.3m;
        [DisplayName("中间投入者")]
        public decimal ProductInnovation_CK2 { get; set; } = 1.15m;
        [DisplayName("等于平均投入")]
        public decimal ProductInnovation_CK3 { get; set; } = 1m;
        [DisplayName("低于平均投入")]
        public decimal ProductInnovation_CK4 { get; set; } = 0.85m;
        [DisplayName("最低投入者")]
        public decimal ProductInnovation_CK5 { get; set; } = 0.7m;


        //5) 本年创新指数=上一年创新指数+外观创新指数的次级指数*40%+功能创新指数的次级指数*60%；

        //6)材料创新，有成本优势，每投入100万，可降低2%的成本；

        #endregion
    }
}