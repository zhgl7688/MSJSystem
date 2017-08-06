using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    /// <summary>
    /// 资产汇总表
    /// </summary>
    public class SummaryAssent
    {
        //=进货报表!F3
        // =进销存报表!E4*
        //市场价格!CE5
        //=投资表!B5

        List<Summary> summarys = new List<Summary>();
        public List<Summary> GetSummarys()
        {
            return summarys;
        }
    }
    public class Summary
    {
        public string 科目 { get; set; }
        public decimal B { get; internal set; }
        public decimal C { get; internal set; }
        public decimal E { get; internal set; }
        public decimal D { get; internal set; }
        public decimal F { get; internal set; }
        public decimal I { get; internal set; }
        public decimal J { get; internal set; }
        public decimal K { get; internal set; }
        public decimal L { get; internal set; }
        public decimal M { get; internal set; }
        public decimal N { get; internal set; }
        public decimal O { get; internal set; }
    }
}