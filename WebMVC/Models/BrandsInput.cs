using System;
using System.Collections.Generic;
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
        public string Stage { get; set; }
        /// <summary>
        /// 品牌商
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 品牌广告投入
        /// </summary>
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
        public decimal materialRC1 { get; set; }
        /// <summary>
        /// 材料新增RC2
        /// </summary>
        public decimal materialRC2 { get; set; }
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
        /// 零售价
        /// </summary>
        public decimal retailPrice { get; set; }
        /// <summary>
        /// 零售系统供价
        /// </summary>
        public decimal SystemPrice { get; set; }

    }
}