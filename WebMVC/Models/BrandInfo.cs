using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebMVC.Common;

namespace WebMVC.Models
{
    /// <summary>
    /// 品牌商竞争信息表
    /// </summary>
    public class BrandInfo
    {

        public Brand 品牌方 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 出厂价 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 指导零售价 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 品牌广告 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 外观创新 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 功能创新 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 材料创新 { get; set; }
    }
}