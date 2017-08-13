using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class BrandInput
    {
        /// <summary>
        /// S品牌对代1最高可投入
        /// </summary>
        [DisplayName("")]
        public decimal AJ { get; set; }
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
        /// 实际投入小计
        /// </summary>
        public decimal InputSum
        {
            get
            {
                return EndImage + Salesperson + HousePromote + demonstrator + outdoorActivity + promotionTeam + servet;
            }
        }
       
    }
}