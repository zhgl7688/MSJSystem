using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    //市场价格部分：MarketPrice	
    public class MarketPriceInit
    {
        [Key]
        public int id { get; set; }
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
        public decimal J_FixedCharges { get; set; } =200;
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

    }
}