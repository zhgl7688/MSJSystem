using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{ 
    //       市场推广部分：MarketPromotion	
    public class MarketPromotionInit
    {
        [Key]
        public int id { get; set; }
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
    }
}