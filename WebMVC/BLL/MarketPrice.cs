using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WebMVC.Models;

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
        List<PriceControlTable> priceControlTables;

        public MarketPrice()
        {
            priceControlTables = new PriceControl().Get();
            Add();
        }
        List<MarketCotext> markets = new List<MarketCotext>();
        public void Add()
        {
            foreach (var item in priceControlTables)
            {
                var markett = markets.FirstOrDefault(s => s.阶段 == item.阶段);
                if (markett == null)
                {
                    MarketCotext marketContext = new MarketCotext()
                    {
                        阶段 = item.阶段,
                        CM = RC1M,
                        CN = RC1S,
                        CO = RC1J,
                        CompeteRC = item.Competes
                    };

                    markets.Add(marketContext);
                }

            }



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
        public decimal DE
        {
            get
            {
                return CompeteRC.RC1M;
            }
        }

        public decimal DF
        {
            get
            {
                return CompeteRC.RC1J;
            }
        }
        public decimal DG
        {
            get
            {
                return CompeteRC.RC2M;
            }
        }
        public decimal DH
        {
            get
            {
                return CompeteRC.RC2J;
            }
        }
        public decimal DI
        {
            get
            {
                return CompeteRC.RC3M;
            }
        }
        public decimal DJ
        {
            get
            {
                return CompeteRC.RC3J;
            }
        }
        public CompeteRC CompeteRC { get; set; }


    }
}