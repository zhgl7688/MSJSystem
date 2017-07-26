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
        public int BrandID { get; set; }
        /// <summary>
        /// 品牌商
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 品牌广告投入
        /// </summary>
        public int advertise { get; set; }
        /// <summary>
        /// 外观常规RC1
        /// </summary>
        public int SurfaceRC1 { get; set; }
        /// <summary>
        /// 外观新增RC2
        /// </summary>
        public int SurfaceRC2 { get; set; }
        /// <summary>
        /// 外观新增RC3
        /// </summary>
        public int SurfaceRC3 { get; set; }
        /// <summary>
        /// 功能常规RC1
        /// </summary>
        public int FunctionRC1 { get; set; }
        /// <summary>
        /// 功能新增RC2
        /// </summary>
        public int FunctionRC2 { get; set; }
        /// <summary>
        /// 功能新增RC3
        /// </summary>
        public int FunctionRC3 { get; set; }
        /// <summary>
        /// 材料常规RC1
        /// </summary>
        public int materialRC1 { get; set; }
        /// <summary>
        /// 材料新增RC2
        /// </summary>
        public int materialRC2 { get; set; }
        /// <summary>
        /// 材料新增RC3
        /// </summary>
        public int MaterialRC3 { get; set; }
        /// <summary>
        /// 终端形象
        /// </summary>
        public int EndImage { get; set; }
        /// <summary>
        /// 导购员
        /// </summary>
        public int Salesperson { get; set; }
        /// <summary>
        /// 店内促销
        /// </summary>
        public int HousePromote { get; set; }
        /// <summary>
        /// 演示员
        /// </summary>
        public int demonstrator { get; set; }
        /// <summary>
        /// 户外活动
        /// </summary>
        public int outdoorActivity { get; set; }
        /// <summary>
        /// 推广小分队
        /// </summary>
        public int promotionTeam { get; set; }
        /// <summary>
        /// 服务
        /// </summary>
        public int servet { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public int retailPrice { get; set; }
        /// <summary>
        /// 零售系统供价
        /// </summary>
        public int SystemPrice { get; set; }

    }
}