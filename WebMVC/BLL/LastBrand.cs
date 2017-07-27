using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    /// <summary>
    /// 最终三个品牌的市场占有率
    /// </summary>
    public class LastBrand
    {
        List<ShareMarket> shareMarkets = new List<ShareMarket>();
        public List<ShareMarket> Get()
        {
            return shareMarkets;

        }
    }
    public class ShareMarket
    {
        public string 品牌方 { get; internal set; }
        public decimal C { get; internal set; }
    }
}