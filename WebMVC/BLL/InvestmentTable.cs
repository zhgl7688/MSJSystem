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
        public decimal J { get; internal set; }
        public decimal M { get; internal set; }
        public decimal N { get; internal set; }
        public decimal O { get; internal set; }
        public decimal Q { get; internal set; }
        public decimal P { get; internal set; }
        public decimal R { get; internal set; }
        public decimal K { get; internal set; }
        public decimal L { get; internal set; }
        public decimal S { get; internal set; }
        public decimal T { get; internal set; }
        public decimal U { get; internal set; }
        public decimal AR { get; internal set; }
        public decimal BA { get; internal set; }
        public decimal BJ { get; internal set; }
        public decimal BS { get; internal set; }
        public decimal CB { get; internal set; }
        public decimal CK { get; internal set; }
    }
}