using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class BrandsInput
    {
        /// <summary>
        /// 主键 编号
        /// </summary>
        [DisplayName("编号")]
        [Key]
         public int BrandID { get; set; }
        /// <summary>
        /// 阶段
        /// </summary>
        [DisplayName("阶段")]
        public string Stage { get; set; }
        /// <summary>
        /// 品牌商
        /// </summary>
        [DisplayName("品牌商")]
        public string Brand { get; set; }
        /// <summary>
        /// 品牌广告投入
        /// </summary>
        [DisplayName("品牌广告投入")]
        public decimal advertise { get; set; }
        /// <summary>
        /// 外观常规RC1
        /// </summary>
        [DisplayName("外观常规RC1")]
        public decimal SurfaceRC1 { get; set; }
        /// <summary>
        /// 外观新增RC2
        /// </summary>
        [DisplayName("外观新增RC2")]
        public decimal SurfaceRC2 { get; set; }
        /// <summary>
        /// 外观新增RC3
        /// </summary>
        [DisplayName("外观新增RC3")]
        public decimal SurfaceRC3 { get; set; }
        /// <summary>
        /// 功能常规RC1
        /// </summary>
        [DisplayName("功能常规RC1")]
        public decimal FunctionRC1 { get; set; }
        /// <summary>
        /// 功能新增RC2
        /// </summary>
        [DisplayName("功能新增RC2")]
        public decimal FunctionRC2 { get; set; }
        /// <summary>
        /// 功能新增RC3
        /// </summary>
        [DisplayName("功能新增RC3")]
        public decimal FunctionRC3 { get; set; }
        /// <summary>
        /// 材料常规RC1
        /// </summary>
        [DisplayName("材料常规RC1")]
        public decimal MaterialRC1 { get; set; }
        /// <summary>
        /// 材料新增RC2
        /// </summary>
        [DisplayName("材料新增RC2")]
        public decimal MaterialRC2 { get; set; }
        /// <summary>
        /// 材料新增RC3
        /// </summary>
        [DisplayName("材料新增RC3")]
        public decimal MaterialRC3 { get; set; }
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
        /// 新品开发费用
        /// </summary>
        [DisplayName("新品开发费用")]
        public decimal NewDevelopmentCost { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [DisplayName("零售价RC1")]
        public decimal retailPrice { get; set; }
        /// <summary>
        /// 零售系统供价
        /// </summary>
        [DisplayName("零售系统供价RC1")]
        public decimal SystemPrice { get; set; }
        /// <summary>
        /// 新增单品成本价
        /// </summary>
        [DisplayName("新增单品成本价")]
        public decimal NewCostPrice { get; set; }
        /// <summary>
        /// 新增单品出厂价
        /// </summary>
        [DisplayName("新增单品出厂价")]
        public decimal NewFactoryPrice { get; set; }
        /// <summary>
        /// 新增单品零售价R2
        /// </summary>
        [DisplayName("新增单品零售价RC2")]
        public decimal NewRetailPriceR2 { get; set; }
        /// <summary>
        /// 新增单品系统供价R2
        /// </summary>
        [DisplayName("新增单品系统供价RC2")]
        public decimal NewSystemPriceR2 { get; set; }
        /// <summary>
        /// 新增单品系统供价R3
        /// </summary>
        [DisplayName("新增单品系统供价RC3")]
        public decimal NewSystemPriceR3 { get; set; }
        /// <summary>
        /// 新增单品零售价R3
        /// </summary>
        [DisplayName("新增单品零售价RC3")]
        public decimal NewRetailPriceR3 { get; set; }
        public string UserId { get; set; }

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
    public class BrandTable : BrandsInput
    {
        /// <summary>
        /// 外观常规汇总
        /// </summary>
        public decimal SurfaceSum
        {
            get
            {
                return this.SurfaceRC1 + this.SurfaceRC2 + this.SurfaceRC3;
            }
        }
        /// <summary>
        /// 功能常规汇总
        /// </summary>
        public decimal FunctionSum
        {
            get
            {
                return this.FunctionRC1 + this.FunctionRC2 + this.FunctionRC3;
            }
        }
        /// <summary>
        /// 材料常规汇总
        /// </summary>
        public decimal materialSum
        {
            get
            {
                return this.MaterialRC1 + this.MaterialRC2 + this.MaterialRC3;
            }
        }
        public decimal InputSum
        {
            get
            {
                return this.EndImage + this.Salesperson + this.HousePromote + this.demonstrator
                     + this.outdoorActivity + this.promotionTeam + this.servet;
            }
        }
        public decimal Sum
        {
            get
            {
                return this.advertise + this.FunctionSum + this.materialSum + this.SurfaceSum + InputSum;
            }
        }
    }
}