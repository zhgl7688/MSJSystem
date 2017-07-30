using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WebMVC.Models;
using WebMVC.Common;

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
            Init();
        }
        List<MarketTable> markets = new List<MarketTable>();
        public void Init()
        {
            foreach (var item in priceControlTables)
            {
                var market = markets.FirstOrDefault(s => s.Stage == item.Stage);
                if (market == null)
                {
                      market = new MarketTable()
                    {
                        Stage = item.Stage,
                    };
                }
                  var rcDic = new Dictionary<int, RC>();
                Stage stage = (Stage)Enum.Parse(typeof(Stage), item.Stage);
                switch (stage)
                {
                    case Stage.第一阶段:rcDic.Add(1, new RC { M=RC1M, S=RC1S, J=RC1J });
                        break;
                    case Stage.第二阶段:
                        break;
                    case Stage.第三阶段:
                        break;
                    default:
                        break;
                }

                market.CompeteRC = item.Competes;
              

                    markets.Add(market);
                }

            



        }
        public List<MarketTable> Get()
        {
            return markets;
        }
    }
    public class MarketTable
    {

        public string Stage { get; set; }
        /// <summary>
        /// 竞品出货RC1
        /// </summary>
        public RC B { get; set; }
        /// <summary>
        /// 我品市场零售容量
        /// </summary>
        public MJA D { get; set; } = new MJA();
        /// <summary>
        /// RCM
        /// </summary>
        public Dictionary<int, MJA> AB { get; set; }
        
        /// <summary>
        /// RCJ
        /// </summary>
        public Dictionary<int, MJA> AT { get; set; }
   
        public Dictionary<int, MJA> BL { get; set; }
     
        public Dictionary<int, RC> CD { get; set; }
     
        public Dictionary<int, RC> CM { get; set; }
     
        public Dictionary<int, RC> CV { get; set; }
         

        public Dictionary<int,RC> DE { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public Dictionary<int,MJA> DK { get; set; }
        /// <summary>
        /// 供货价
        /// </summary>
        public Dictionary<int, MJA> EF { get; set; }



        
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