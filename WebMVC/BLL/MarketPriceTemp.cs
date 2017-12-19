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
        AgentStages agentStages;
        public MarketPriceTemp(PriceControl PriceControl)
        {
            priceControlTables = PriceControl.Get();
            agentStages = new AgentStages();
            Init();
        }
        List<MarketTable> markets = new List<MarketTable>();
        public void Init()
        {
            foreach (var item in priceControlTables)
            {
                var market = new MarketTable() { Stage = item.Stage, };
                var indexStage = agentStages.stages.IndexOf(item.Stage);
                for (int i = 0; i < indexStage; i++)
                {
                    market.DE[i] = new RC { M = item.B.RcM[i], J = item.B.RcJ[i] };
                    market.DK[i] = new MJA { Agent = item.D[i].Agent };
                    market.EF[i] = new MJA();
                    for (int j = 0; j < item.K[1].Agent.Count; j++)
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