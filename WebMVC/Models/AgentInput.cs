using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class AgentInput
    {
        /// <summary>
        /// 主键 编号
        /// </summary>
        public decimal AgentId { get; set; }
        /// <summary>
        /// 代理商
        /// </summary>
        public string AgentName { get; set; }
        /// <summary>
        /// 阶段
        /// </summary>
        public string Stage { get; set; }
        /// <summary>
        /// 终端形象
        /// </summary>
        public decimal EndImage { get; set; }
        /// <summary>
        /// 导购员
        /// </summary>
        public decimal Salesperson { get; set; }
        /// <summary>
        /// 店内促销
        /// </summary>
        public decimal HousePromote { get; set; }
        /// <summary>
        /// 演示员
        /// </summary>
        public decimal demonstrator { get; set; }
        /// <summary>
        /// 户外活动
        /// </summary>
        public decimal outdoorActivity { get; set; }
        /// <summary>
        /// 推广小分队
        /// </summary>
        public decimal promotionTeam { get; set; }
        /// <summary>
        /// 服务
        /// </summary>
        public decimal servet { get; set; }
        /// <summary>
        /// 银行贷款
        /// </summary>
        public decimal bankLoan { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public decimal retailPrice { get; set; }
        /// <summary>
        /// 零售系统供价
        /// </summary>
        public decimal SystemPrice { get; set; }
        /// <summary>
        /// 品牌代理商
        /// </summary>
        public string brandAgent { get; set; }
        /// <summary>
        /// 起始进货
        /// </summary>
        public decimal purchase { get; set; }
        /// <summary>
        /// 起始实际销售
        /// </summary>
        public decimal actualSale { get; set; }
        /// <summary>
        /// 起始库存
        /// </summary>
        public decimal Inventory { get; set; }
        /// <summary>
        /// 第一阶段进货
        /// </summary>
        public decimal FirstPurchase { get; set; }

    }
}