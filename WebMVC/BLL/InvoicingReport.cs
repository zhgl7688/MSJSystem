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

        }
        public List<InvoicingTable> Get()
        {
            return invoicings;
        }
    }
    public class InvoicingTable
    {
        public string Brand { get; internal set; }

        public decimal D { get; internal set; }
        public decimal I { get; internal set; }
        public decimal G { get; internal set; }
        public decimal H { get; internal set; }
    }
}