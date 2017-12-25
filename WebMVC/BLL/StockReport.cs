using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Infrastructure;
using WebMVC.Models;


namespace WebMVC.BLL
{
    public class StockReport
    {
        List<StockReportTable> stockReports = new List<StockReportTable>();
        List<AgentInput> agents;//原表代表商进货表
        List<MarketTable> markets;//市场价格
        AgentStages agentStages;
        /// <summary>
        /// 进货报表
        /// </summary>
        public StockReport(InvertmentTable1 InvertmentTable1, MarketPrice MarketPrice)
        {
            agents = InvertmentTable1.getAgentInputs();
            markets = MarketPrice.Get();
            agentStages = new AgentStages();
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
                var indexStage = agentStages.stages.IndexOf(item.Stage);
                if (indexStage == 1)
                {
                    stock.B = item.BasePurchase; stock.C = item.actualSale;
                }
                for (int j = 0; j < indexStage; j++)
                {
                    stock.E.Add(j, new StockAmount { Stock = item.Purchase[j], Price = prices[j].S });

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