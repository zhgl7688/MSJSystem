using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;


namespace WebMVC.BLL
{
    public class StockReport
    {
        List<StockReportTable> stockReports = new List<StockReportTable>();
        List<AgentInput> agents;//原表代表商进货表
        List<MarketTable> markets;//市场价格

        /// <summary>
        /// 进货报表
        /// </summary>
        public StockReport()
        {
            agents = new InvertmentTable1().getAgentInputs();
            markets = new MarketPrice().Get();
            Init();
        }
        public void Init()
        {
            int i = 0;
            foreach (var item in agents)
            {
                var stock = stockReports.FirstOrDefault(s => s.Stage == item.Stage && s.AgentName == item.AgentName);
                if (stock == null)
                {
                    stock = new StockReportTable
                    {
                        Id = i++,
                        AgentName = item.AgentName,
                        Stage = item.Stage,

                    };
                    stockReports.Add(stock);
                }
                var prices = markets.FirstOrDefault(s => s.Stage == item.Stage).CM;
                if (item.Stage == Common.Stage.第一阶段.ToString())
                {

                    stock.B = 31; stock.C = 30; stock.E.Add(1, new StockAmount { Stock = item.FirstPurchase, Price = prices[1].S });
                }
                else if (item.Stage == Common.Stage.第二阶段.ToString())
                {
                    stock.E.Add(1, new StockAmount { Stock = item.FirstPurchase, Price = prices[1].S });
                    stock.E.Add(2, new StockAmount { Stock = item.SecondPurchase, Price = prices[2].S });
                }
                else
                {
                    stock.E.Add(1, new StockAmount { Stock = item.FirstPurchase, Price = prices[1].S });
                    stock.E.Add(2, new StockAmount { Stock = item.SecondPurchase, Price = prices[2].S });
                    stock.E.Add(3, new StockAmount { Stock = item.ThirdPurchase, Price = prices[3].S });

                }

            }
        }
        public List<StockReportTable> Get()
        {
            return stockReports;
        }
    }
    public class StockReportTable
    {
       public int Id { get; set; }
        public string Stage { get; set; }
        public string AgentName { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D
        {
            get { return B - C; }
        }
        public Dictionary<int, StockAmount> E { get; set; } = new Dictionary<int, StockAmount>();
        public StockAmount Sum
        {
            get
            {
                var result = new StockAmount();
                result.Stock = E.Sum(s => s.Value.Stock);
                result.Sum = E.Sum(s => s.Value.Amount);
                return result;
            }
        }
    }
    public class StockAmount
    {
        public decimal Stock { get; set; }
        public decimal Price { get; set; }
        public decimal Amount
        {
            get
            { return Stock * Price; }
        }
        public decimal Sum { get; set; }

    }
}