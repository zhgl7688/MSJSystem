using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    /// <summary>
    /// 各品牌商盈利情况
    /// </summary>
    public class BrandProfit
    {
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal M { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal S1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal S2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal S3 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal S4 { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal J { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal SM { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal SS { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal SJ { get; set; }

    }
}