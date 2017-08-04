using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    /// <summary>
    /// 进销存报表
    /// </summary>
    public class InvoicingReport
    {
        List<InvoicingTable> invoicings = new List<InvoicingTable>();
        List<CurrentShareTable> currentShares;  //市场容量及各品牌当年占有率
        List<MarketTable> markets;    //市场价格
        List<StockReportTable> stockReports; //进货报表


        /// <summary>
        /// 进销存报表
        /// </summary>
        public InvoicingReport()
        {
            currentShares = new CurrentShare().Get();
            markets = new MarketPrice().Get();
            stockReports = new StockReport().Get();
            Init();
        }
        private void Init()
        {
            foreach (var stockReport in stockReports)
            {
                var invoicing = invoicings.FirstOrDefault(s => s.AgentName == stockReport.AgentName);
                if (invoicing == null)
                {
                    invoicing = new InvoicingTable() {
                         B=31,
                    };
                    invoicings.Add(invoicing);
                }
                
            }
        }
        public List<InvoicingTable> Get()
        {
            return invoicings;
        }
    }
    public class InvoicingTable
    {
        public string AgentName { get;   set; }
           public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D { get; set; }
        public decimal E { get; set; }
        public decimal F { get; set; }
        public decimal G { get; set; }
        public decimal H { get; set; }
        public decimal I { get; set; }
        public decimal J { get; set; }
        public decimal K { get; set; }
        public decimal L { get; set; }
        public decimal M { get; set; }
        public decimal N { get; set; }
        public decimal O { get; set; }
        public decimal P { get; set; }
        public decimal Q { get; set; }
        public decimal R { get; set; }
        public decimal S { get; set; }
        public decimal T { get; set; }
        public decimal U { get; set; }
        public decimal V { get; set; }
        public decimal W { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public decimal AA { get; set; }
        public decimal AB { get; set; }
        public decimal AC { get; set; }
        public decimal AD { get; set; }
        public decimal AE { get; set; }
        public decimal AF { get; set; }
        public decimal AG { get; set; }
        public decimal AH { get; set; }
        public decimal AI { get; set; }
        public decimal AJ { get; set; }
        public decimal AK { get; set; }
        public decimal AL { get; set; }
        public decimal AM { get; set; }
        public decimal AN { get; set; }

    }
}