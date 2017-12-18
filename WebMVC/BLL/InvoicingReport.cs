using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;

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
            foreach (var stockReport in stockReports)
            {
                var invoicing = invoicings.FirstOrDefault(s => s.AgentName == stockReport.AgentName);
                if (invoicing == null)
                {
                    invoicing = new InvoicingTable()
                    {
                        B = 31,
                        AgentName = stockReport.AgentName,

                    };
                    invoicings.Add(invoicing);
                }
                var indexStage = agentStages.stages.IndexOf(stockReport.Stage);
                var es = new List<decimal>();
                for (int i = 0; i < indexStage; i++)
                {
                    es.Add(stockReport.E[i + 1].Stock);

                }
                invoicing.EStage.Add(indexStage, es);
                //Stage stage = (Stage)Enum.Parse(typeof(Stage), stockReport.Stage);
                //switch (stage)
                //{
                //    case Stage.第一阶段:
                //        invoicing.E = stockReport.E[1].Stock;
                //        break;
                //    case Stage.第二阶段:
                //        invoicing.K = stockReport.E[1].Stock;
                //        invoicing.M = stockReport.E[2].Stock;
                //        break;
                //    case Stage.第三阶段:
                //        invoicing.W = stockReport.E[1].Stock;
                //        invoicing.Y = stockReport.E[2].Stock;
                //        invoicing.AA = stockReport.E[3].Stock;
                //        break;
                //}
            }
 
            var currentShareList = currentShares.OrderBy(s => s.Stage).ToList();
            var marketList = markets.OrderBy(s=>s.Stage).ToList();

            foreach (var invoicing in invoicings)
            {
                var indexAgent = agentStages.agents.IndexOf(invoicing.AgentName);
                invoicing.C = currentShareList[0].CT[1].Agent[indexAgent];
                if (currentShareList.Count>1) invoicing.G = currentShareList[1].CT[1].Agent[indexAgent];
                if (currentShareList.Count >2)
                {
                    invoicing.O = currentShareList[2].CT[1].Agent[indexAgent];
                    invoicing.Q = currentShareList[2].CT[2].Agent[indexAgent];
                }
                if (currentShareList.Count >3)
                {
                    invoicing.AC = currentShareList[3].CT[1].Agent[indexAgent];
                    invoicing.AE = currentShareList[3].CT[2].Agent[indexAgent];
                    invoicing.AG = currentShareList[3].CT[3].Agent[indexAgent];
                }
                if (marketList.Count>0)
                    invoicing.H = marketList[0].EF[1].Agent[indexAgent];
                if (marketList.Count > 1)
                {
                    invoicing.P = marketList[1].EF[1].Agent[indexAgent];
                    invoicing.R = marketList[1].EF[2].Agent[indexAgent];
                }
                if (marketList.Count > 2)
                {
                    invoicing.AD = marketList[2].EF[1].Agent[indexAgent];
                    invoicing.AF = marketList[2].EF[2].Agent[indexAgent];
                    invoicing.AH = marketList[2].EF[3].Agent[indexAgent];
                }
            }

            if (marketList.Count > 0) invoicings.ForEach(s => s.F_MarketPrice_CN5 = marketList[0].CM[1].S);
            if (marketList.Count > 1)
            {
                invoicings.ForEach(s => s.F_MarketPrice_CN6 = marketList[1].CM[1].S);
                invoicings.ForEach(s => s.F_MarketPrice_CQ6 = marketList[1].CM[2].S);

            }
            if (marketList.Count > 1)
            {
                invoicings.ForEach(s => s.F_MarketPrice_CN7 = marketList[2].CM[1].S);
                invoicings.ForEach(s => s.F_MarketPrice_CQ7 = marketList[2].CM[2].S);
                invoicings.ForEach(s => s.F_MarketPrice_CT7 = marketList[2].CM[3].S);

            }

        }

        public List<InvoicingTable> Get()
        {
            return invoicings;
        }
    }
    public class InvoicingTable
    {
        public string AgentName { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D { get { return B - C; } }
        public Dictionary<int, List<decimal>> EStage { get; set; } = new Dictionary<int, List<decimal>>();
        public decimal E { get; set; }
        public decimal F { get { return EStage[1][0] * F_MarketPrice_CN5; } }
        private decimal g;
        public decimal G
        {
            get
            { return g; }
            set
            {
                g = decimal.Round((D + EStage[1][0]) < value ? D + EStage[1][0] : value, 0);
            }
        }
        private decimal h;
        public decimal H { get { return h; } set { h = G * value; } }
        public decimal I { get { return D + EStage[1][0] - G > 0 ? D + EStage[1][0] - G : 0; } }
        public decimal J { get { return I * F_MarketPrice_CN5; } }
        public decimal K { get; set; }
        public decimal L { get { return EStage[2][0] * F_MarketPrice_CN6; } }
        public decimal M { get; set; }
        public decimal N { get { return EStage[2][0] * F_MarketPrice_CQ6; } }
        private decimal o;
        public decimal O
        {
            get
            { return o; }
            set
            {
                o = decimal.Round((I + EStage[2][0]) < value ? I + EStage[2][0] : value, 0);
            }
        }
        private decimal p;
        public decimal P { get { return p; } set { p = O * value; } }
        private decimal q;
        public decimal Q
        {
            get
            { return q; }
            set
            {
                q = decimal.Round(EStage[2][1] < value ? EStage[2][1] : value, 0);
            }
        }
        private decimal r;
        public decimal R { get { return r; } set { r = Q * value; } }
        public decimal S { get { return I + EStage[2][0] - O > 0 ? I + EStage[2][0] - O : 0; } }
        public decimal T { get { return S * F_MarketPrice_CN6; } }
        public decimal U { get { return EStage[2][1] - Q; } }
        public decimal V { get { return U * F_MarketPrice_CQ6; } }
        public decimal W { get; set; }
        public decimal X { get { return EStage[3][0] * F_MarketPrice_CN7; } }
        public decimal Y { get; set; }
        public decimal Z { get { return EStage[3][1] * F_MarketPrice_CQ7; } }
        public decimal AA { get; set; }
        public decimal AB { get { return EStage[3][2] * F_MarketPrice_CT7; } }
        private decimal ac;
        public decimal AC
        {
            get
            { return ac; }
            set
            {
                ac = decimal.Round(S + EStage[3][0] < value ? S + EStage[3][0] : value, 0);
            }
        }
        private decimal ad;
        public decimal AD { get { return ad; } set { ad = ac * value; } }
        private decimal ae;
        public decimal AE
        {
            get
            { return ae; }
            set
            {
                ae = decimal.Round((U + EStage[3][1]) < value ? U + EStage[3][1] : value, 0);
            }
        }
        private decimal af;
        public decimal AF { get { return af; } set { af = AE * value; } }
        private decimal ag;
        public decimal AG
        {
            get
            { return ag; }
            set
            {
                ag = decimal.Round(EStage[3][2] < value ? EStage[3][2] : value, 0);
            }
        }
        private decimal ah;
        public decimal AH { get { return ah; } set { ah = AG * value; } }
        public decimal AI { get { return S + EStage[3][0] - AC > 0 ? S + EStage[3][0] - AC : 0; } }
        public decimal AJ { get { return AI * F_MarketPrice_CN7; } }
        public decimal AK { get { return U + EStage[3][1] - AE > 0 ? U + EStage[3][1] - AE : 0; } }
        public decimal AL { get { return AK * F_MarketPrice_CQ7; } }
        public decimal AM { get { return EStage[3][2] - AG; } }
        public decimal AN { get { return AM * F_MarketPrice_CT7; } }
        public decimal F_MarketPrice_CN5 { get; internal set; }
        public decimal F_MarketPrice_CN6 { get; internal set; }
        public decimal F_MarketPrice_CQ6 { get; internal set; }
        public decimal F_MarketPrice_CN7 { get; internal set; }
        public decimal F_MarketPrice_CQ7 { get; internal set; }
        public decimal F_MarketPrice_CT7 { get; internal set; }
    }
}