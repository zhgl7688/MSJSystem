using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

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

        AgentStages agentStages;
        /// <summary>
        /// 进销存报表
        /// </summary>
        public InvoicingReport(CurrentShare CurrentShare, MarketPrice MarketPrice, StockReport StockReport)
        {
            agentStages = new AgentStages();
            currentShares = CurrentShare.Get();
            markets = MarketPrice.Get();
            stockReports = StockReport.Get();
            Init();
        }
        private void Init()
        {

            //进货报表
            foreach (var stockReport in stockReports)//12个代理循环
            {
                var invoicing = invoicings.FirstOrDefault(s => s.AgentName == stockReport.AgentName);
                if (invoicing == null)
                {
                    invoicing = new InvoicingTable()
                    {
                        // B = 31,
                        AgentName = stockReport.AgentName,

                    };
                    invoicing.BStage.Add(0, new List<decimal> { 31 });
                    invoicings.Add(invoicing);
                }
                var indexStage = agentStages.stages.IndexOf(stockReport.Stage);
                var es = new List<decimal>();
                for (int i = 0; i < indexStage; i++)
                {
                    es.Add(stockReport.E[i].Stock);

                }
                invoicing.BStage.Add(indexStage, es);

            }
            for (int i = 0; i < invoicings.Count; i++)
            {
                var cts0 = currentShares.FirstOrDefault(s => s.Stage == agentStages.stages[0]);
                invoicings[i].CStage.Add(0, new List<decimal> { cts0.CT[0].Agent[i] });
            }
            var ctStage = new Dictionary<int, Dictionary<int, MJA>>();
            //市场容量及各品牌当年占有率
            for (int i = 0; i < currentShares.Count; i++)//阶段循环
            {
                ctStage.Add(i, currentShares[i].CT);

            }
            invoicings.ForEach(s =>
            {
                var indexAgent = new AgentStages().agents.IndexOf(s.AgentName);
                var dStage = new Dictionary<int, List<decimal>>();
                s.CStage = Common.Cal.ActualSale(indexAgent, ctStage, out dStage, s.BStage);
                s.DStage = dStage;
            });
            
            invoicings.ForEach(s =>
            {
                var cmList = markets.Select(sz => sz.CM).ToList();
                for (int i = 1; i < s.BStage.Count; i++)
                {
                    var cmt = cmList[i - 1];
                    s.FStage.Add(i, new List<decimal>());
                    s.HStage.Add(i, new List<decimal>());
                    s.JStage.Add(i, new List<decimal>());
                    for (int j = 0; j < i; j++)
                    {
                        s.FStage[i].Add( s.BStage[i][j]*cmt[j].S); //市场价格
                        s.HStage[i].Add( s.CStage[i][j]*cmt[j].S);
                        s.JStage[i].Add( s.DStage[i][j]*cmt[j].S);
                    }

                }

            });
           
        }

        public List<InvoicingTable> Get()
        {
            return invoicings;
        }
    }
    public class InvoicingTable
    {
        public string AgentName { get; set; }
        public Dictionary<int, List<decimal>> BStage { get; set; } = new Dictionary<int, List<decimal>>();
        public decimal B { get; set; }
        public Dictionary<int, List<decimal>> CStage { get; set; } = new Dictionary<int, List<decimal>>();


        public Dictionary<int, List<decimal>> DStage { get; set; } = new Dictionary<int, List<decimal>>();

        public Dictionary<int, List<decimal>> EStage
        {
            get
            {
                return CStage;
            }
        }
        public Dictionary<int, List<decimal>> FStage { get; set; } = new Dictionary<int, List<decimal>>();


        public Dictionary<int, List<decimal>> HStage { get; set; } = new Dictionary<int, List<decimal>>();

 
        public Dictionary<int, List<decimal>> JStage { get; set; } = new Dictionary<int, List<decimal>>();

     

    }
}