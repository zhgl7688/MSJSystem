using System;
using System.Collections.Generic;
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
        public decimal 供货价 { get; set; }
        public decimal 零售价 { get; set; }
        public decimal 终端形象 { get; set; }
        public decimal 导购员 { get; set; }
        public decimal 店内促销 { get; set; }
        public decimal 演示员 { get; set; }
        public decimal 户外活动 { get; set; }
        public decimal 推广小分队 { get; set; }
        public decimal 服务 { get; set; }

        public decimal 投入小计
        {
            get
            {
                return this.终端形象 + this.导购员 + this.店内促销 + this.演示员 + this.户外活动 + this.推广小分队 + this.服务;
            }
        }
        public decimal S品牌费用补贴支持 { get; set; }


    }
}