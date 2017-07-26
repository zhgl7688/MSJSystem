using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    /// <summary>
    /// 投资表
    /// </summary>
    public class InvestmentTable
    {
        List<Investment> investments = new List<Investment>();
        public void add(Investment investment)
        {
            investments.Add(investment);
        }
        public List<Investment> get()
        {
            return investments;
        }
    }
    public class Investment
    {
       

        public string 阶段 { get; set; }
        public int J { get; internal set; }
        public int M { get; internal set; }
        public int N { get; internal set; }
        public int O { get; internal set; }
        public int Q { get; internal set; }
        public int P { get; internal set; }
        public int R { get; internal set; }
        public int K { get; internal set; }
        public int L { get; internal set; }
        public int S { get; internal set; }
        public int T { get; internal set; }
        public int U { get; internal set; }
        public int AR { get; internal set; }
        public int BA { get; internal set; }
        public int BJ { get; internal set; }
        public int BS { get; internal set; }
        public int CB { get; internal set; }
        public int CK { get; internal set; }
    }
}