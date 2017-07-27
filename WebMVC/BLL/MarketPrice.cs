using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace WebMVC.BLL
{
    /// <summary>
    /// 市场价格
    /// </summary>
    public class MarketPrice
    {
        decimal RC1M = Convert.ToDecimal(ConfigurationManager.AppSettings["RC1M"]);
        decimal RC1S = Convert.ToDecimal(ConfigurationManager.AppSettings["RC1S"]);
        decimal RC1J = Convert.ToDecimal(ConfigurationManager.AppSettings["RC1J"]);
        public MarketPrice()
        {

        }
        List<MarketCotext> markets = new List<MarketCotext>();
        public void Add()
        {
            MarketCotext marketContext = new MarketCotext()
            {
                CM=RC1M,
                CN=RC1S,
                CO=RC1J
            };
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
        /// <summary>
        ///品牌方决定"出厂价（元）" 常规单品（RC1）	 M
        /// </summary>
        public decimal CM { get; set; }
        /// <summary>
        /// 品牌方决定"出厂价（元）" 常规单品（RC1）	 S
        /// </summary>
        public decimal CN { get; internal set; }
        /// <summary>
        /// 品牌方决定"出厂价（元）" 常规单品（RC1）	J
        /// </summary>
        public decimal CO { get; internal set; }
        public decimal DF { get; set; }
        public decimal DE { get; internal set; }


    }
}