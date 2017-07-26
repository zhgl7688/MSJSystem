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
        List<Summary> summarys = new List<Summary>();
        public List<Summary> GetSummarys()
        {
            return summarys;
        }
    }
    public class Summary
    {
        public string 科目 { get; set; }
        public int B { get; internal set; }
        public int C { get; internal set; }
        public int E { get; internal set; }
        public int D { get; internal set; }
        public int F { get; internal set; }
        public int I { get; internal set; }
        public int J { get; internal set; }
        public int K { get; internal set; }
        public int L { get; internal set; }
        public int M { get; internal set; }
        public int N { get; internal set; }
        public int O { get; internal set; }
    }
}