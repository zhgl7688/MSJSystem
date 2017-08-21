using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{

    /// <summary>
    /// S品牌代理商经营模拟结果呈现
    /// </summary>
    public class SAgentResult
    {


        public string 代理方 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 期初 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 期末 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 销售量 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 销售金额 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 数量 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 金额 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 销售利润 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 借款利息 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 库存跌价损失计提 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 最终经营利润 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal 现金流 { get; set; }


    }
}