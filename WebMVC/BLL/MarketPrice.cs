using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    /// <summary>
    /// 市场价格
    /// </summary>
    public class MarketPrice
    {
        List<MarketCotext> markets = new List<MarketCotext>();
        public void Add(MarketCotext marketContext)
        {
            markets.Add(marketContext);
            
        }
        public List<MarketCotext> Get()
        {
            return markets;
        }
    }
    public class MarketCotext
    {

        public string 阶段 { get; set; }
        public decimal CM { get; set; }
        public decimal DF { get; set; }
        public decimal DE { get; internal set; }
        public decimal CO { get; internal set; }
        public decimal CN { get; internal set; }
    }
}