using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class BrandsInput
    {
        /// <summary>
        /// 主键 编号
        /// </summary>
        public decimal BrandID { get; set; }
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
        public decimal SurfaceRC1 { get; set; }
        /// <summary>
        /// 外观新增RC2
        /// </summary>
        public decimal SurfaceRC2 { get; set; }
        /// <summary>
        /// 外观新增RC3
        /// </summary>
        public decimal SurfaceRC3 { get; set; }
        /// <summary>
        /// 功能常规RC1
        /// </summary>
        public decimal FunctionRC1 { get; set; }
        /// <summary>
        /// 功能新增RC2
        /// </summary>
        public decimal FunctionRC2 { get; set; }
        /// <summary>
        /// 功能新增RC3
        /// </summary>
        public decimal FunctionRC3 { get; set; }
        /// <summary>
        /// 材料常规RC1
        /// </summary>
        public decimal MaterialRC1 { get; set; }
        /// <summary>
        /// 材料新增RC2
        /// </summary>
        public decimal MaterialRC2 { get; set; }
        /// <summary>
        /// 材料新增RC3
        /// </summary>
        public decimal MaterialRC3 { get; set; }
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
        /// 新品开发费用
        /// </summary>
        public decimal NewDevelopmentCost { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public decimal retailPrice { get; set; }
        /// <summary>
        /// 零售系统供价
        /// </summary>
        public decimal SystemPrice { get; set; }
        /// <summary>
        /// 新增单品成本价
        /// </summary>
        public decimal NewCostPrice { get; set; }
        /// <summary>
        /// 新增单品出厂价
        /// </summary>
        public decimal NewFactoryPrice { get; set; }
        /// <summary>
        /// 新增单品零售价R2
        /// </summary>
        public decimal NewRetailPriceR2 { get; set; }
        /// <summary>
        /// 新增单品系统供价R2
        /// </summary>
        public decimal NewSystemPriceR2 { get; set; }
        /// <summary>
        /// 新增单品系统供价R3
        /// </summary>
        public decimal NewSystemPriceR3 { get; set; }
        /// <summary>
        /// 新增单品零售价R3
        /// </summary>
        public decimal NewRetailPriceR3 { get; set; }

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