using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebMVC.Common;

namespace WebMVC.Models
{
    public class AgentInput
    {
        /// <summary>
        /// 主键 编号
        /// </summary>
        [Key]
        [DisplayName("编号")]
        public int AgentId { get; set; }
        /// <summary>
        /// 代理商
        /// </summary>
        [DisplayName("代理商")]
        public string AgentName { get; set; }
        /// <summary>
        /// 阶段
        /// </summary>
        [DisplayName("阶段")]
        public string Stage { get; set; }
        /// <summary>
        /// 终端形象
        /// </summary>
        [DisplayName("终端形象")]
        public decimal EndImage { get; set; }
        /// <summary>
        /// 导购员
        /// </summary>
        [DisplayName("导购员")]
        public decimal Salesperson { get; set; }
        /// <summary>
        /// 店内促销
        /// </summary>
        [DisplayName("店内促销")]
        public decimal HousePromote { get; set; }
        /// <summary>
        /// 演示员
        /// </summary>
        [DisplayName("演示员")]
        public decimal demonstrator { get; set; }
        /// <summary>
        /// 户外活动
        /// </summary>
        [DisplayName("户外活动")]
        public decimal outdoorActivity { get; set; }
        /// <summary>
        /// 推广小分队
        /// </summary>
        [DisplayName("推广小分队")]
        public decimal promotionTeam { get; set; }
        /// <summary>
        /// 服务
        /// </summary>
        [DisplayName("服务")]
        public decimal servet { get; set; }
        /// <summary>
        /// 银行贷款
        /// </summary>
        [DisplayName("银行贷款")]
        public decimal bankLoan { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [DisplayName("零售价")]
        public decimal retailPriceRC1 { get; set; }
        /// <summary>
        /// 零售系统供价
        /// </summary>
        [DisplayName("零售系统供价")]
        public decimal SystemPriceRC1 { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [DisplayName("零售价")]
        public decimal retailPriceRC2 { get; set; }
        /// <summary>
        /// 零售系统供价
        /// </summary>
        [DisplayName("零售系统供价")]
        public decimal SystemPriceRC2 { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [DisplayName("零售价")]
        public decimal retailPriceRC3 { get; set; }
        /// <summary>
        /// 零售系统供价
        /// </summary>
        [DisplayName("零售系统供价")]
        public decimal SystemPriceRC3 { get; set; }
        /// <summary>
        /// 品牌代理商
        /// </summary>
        [DisplayName("品牌代理商")]
        public string brandAgent { get; set; }
        /// <summary>
        /// 起始进货
        /// </summary>
        [DisplayName("起始进货")]
        public decimal purchase { get; set; }
        /// <summary>
        /// 起始实际销售
        /// </summary>
        [DisplayName("起始实际销售")]
        public decimal actualSale { get; set; }
        /// <summary>
        /// 起始库存
        /// </summary>
        [DisplayName("起始库存")]
        public decimal Inventory { get; set; }
        /// <summary>
        /// RC1进货
        /// </summary>
        [DisplayName("RC1进货")]
        public decimal FirstPurchase { get; set; }
        /// <summary>
        /// RC2进货
        /// </summary>
        [DisplayName("RC2进货")]
        public decimal SecondPurchase { get; set; }
        /// <summary>
        /// RC3进货
        /// </summary>
        [DisplayName("RC3进货")]
        public decimal ThirdPurchase { get; set; }
        public string UserId { get; set; }
        public decimal InputSum
        {
            get
            {
                return this.EndImage + this.Salesperson + this.HousePromote + this.demonstrator
                     + this.outdoorActivity + this.promotionTeam + this.servet;
            }
        }
       
        public BrandInput brandInput
        {
            get
            {
                return new BrandInput
                {
                    EndImage = EndImage,
                    Salesperson = Salesperson,
                    HousePromote = HousePromote,
                    demonstrator = demonstrator,
                    outdoorActivity = outdoorActivity,
                    promotionTeam = promotionTeam,
                    servet = servet,

                };
            }
        }
    }

}