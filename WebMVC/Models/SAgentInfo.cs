using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    /// <summary>
    /// S品牌代理商信息表
    /// </summary>
    public class SAgentInfo
    {

        public string 代理方 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 供货价 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 零售价 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 终端形象 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 导购员 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 店内促销 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 演示员 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 户外活动 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 推广小分队 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 服务 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 投入小计
        {
            get
            {
                return this.终端形象 + this.导购员 + this.店内促销 + this.演示员 + this.户外活动 + this.推广小分队 + this.服务;
            }
        }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal S品牌费用补贴支持 { get; set; }


    }
}