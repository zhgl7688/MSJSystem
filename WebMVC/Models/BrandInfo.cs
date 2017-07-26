using System;
using System.Collections.Generic;
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
        public int 出厂价 { get; set; }
        public int 指导零售价 { get; set; }
        public int 品牌广告 { get; set; }
        public int 外观创新 { get; set; }
        public int 功能创新 { get; set; }
        public int 材料创新 { get; set; }
    }
}