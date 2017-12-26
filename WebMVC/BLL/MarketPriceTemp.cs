using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class MarketPriceTemp
    {
        List<PriceControlTable> priceControlTables;
   
        public MarketPriceTemp(PriceControl PriceControl)
        {
            priceControlTables = PriceControl.Get();
      
            Init();
        }
        List<MarketTable> markets = new List<MarketTable>();
        public void Init()
        {
            foreach (var item in priceControlTables)
            {
                var market = new MarketTable() { Stage = item.Stage, };
                var indexStage = AgentStages.stages.IndexOf(item.Stage);
                for (int i = 0; i < indexStage; i++)
                {
                    var m = item.B.RcM.Count > i ? item.B.RcM[i] : 0;
                    var je = item.B.RcJ.Count > i ? item.B.RcJ[i] : 0;
                    var d = item.D.Count > i ? item.D[i].Agent : new List<decimal>();

                    market.DE[i] = new RC { M = m, J = je };
                    market.DK[i] = new MJA { Agent = item.D[i].Agent };
                    market.EF[i] = new MJA();
                    for (int j = 0; j < item.K[i].Agent.Count; j++)
                    {
                        market.EF[i].Agent.Add(GetEF(item.K[i].Agent[j], item.D[i].Agent[j]));
                    }
                }


                markets.Add(market);
            }


        }
        private decimal GetEF(decimal a, decimal b)
        {
            return a < (b * 0.89m) ? a : b * 0.89m;
        }
        public List<MarketTable> Get()
        {
            return markets;
        }
    }
}