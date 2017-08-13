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


        /// <summary>
        /// 进销存报表
        /// </summary>
        public InvoicingReport(CurrentShare CurrentShare, MarketPrice MarketPrice, StockReport StockReport)
        {
            currentShares =  CurrentShare.Get();
            markets =  MarketPrice.Get();
            stockReports =  StockReport.Get();
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
                Stage stage = (Stage)Enum.Parse(typeof(Stage), stockReport.Stage);
                switch (stage)
                {
                    case Stage.第一阶段:
                        invoicing.E = stockReport.E[1].Stock;
                        break;
                    case Stage.第二阶段:
                        invoicing.K = stockReport.E[1].Stock;
                        invoicing.M = stockReport.E[2].Stock;
                        break;
                    case Stage.第三阶段:
                        invoicing.W = stockReport.E[1].Stock;
                        invoicing.Y = stockReport.E[2].Stock;
                        invoicing.AA = stockReport.E[3].Stock;
                        break;
                }




            }
            var currentShare0 = currentShares.FirstOrDefault(s => s.Stage == Common.Stage.起始阶段.ToString());
            var currentShare1 = currentShares.FirstOrDefault(s => s.Stage == Common.Stage.第一阶段.ToString());
            var currentShare2 = currentShares.FirstOrDefault(s => s.Stage == Common.Stage.第二阶段.ToString());
            var currentShare3 = currentShares.FirstOrDefault(s => s.Stage == Common.Stage.第三阶段.ToString());

            var market1 = markets.FirstOrDefault(s => s.Stage == Common.Stage.第一阶段.ToString());
            var market2 = markets.FirstOrDefault(s => s.Stage == Common.Stage.第二阶段.ToString());
            var market3 = markets.FirstOrDefault(s => s.Stage == Common.Stage.第三阶段.ToString());

            foreach (var invoicing in invoicings)
            {

                AgentName agentName = (AgentName)Enum.Parse(typeof(AgentName), invoicing.AgentName);

                switch (agentName)
                {
                    case AgentName.代1:
                        invoicing.C = currentShare0.CT[1].Agent1;
                        if (currentShare1 != null)
                            invoicing.G = currentShare1.CT[1].Agent1;
                        if (currentShare2 != null)
                        {
                            invoicing.O = currentShare2.CT[1].Agent1;
                            invoicing.Q = currentShare2.CT[2].Agent1;
                        }
                        if (currentShare3 != null)
                        {
                            invoicing.AC = currentShare3.CT[1].Agent1;
                            invoicing.AE = currentShare3.CT[2].Agent1;
                            invoicing.AG = currentShare3.CT[3].Agent1;
                        }
                        if (market1 != null)
                            invoicing.H = market1.EF[1].Agent1;
                        if (market2 != null)
                        {
                            invoicing.P = market2.EF[1].Agent1;
                            invoicing.R = market2.EF[2].Agent1;
                        }
                        if (market3 != null)
                        {
                            invoicing.AD = market3.EF[1].Agent1;
                            invoicing.AF = market3.EF[2].Agent1;
                            invoicing.AH = market3.EF[3].Agent1;
                        }


                        break;
                    case AgentName.代2:
                        invoicing.C = currentShare0.CT[1].Agent2;
                        if (currentShare1 != null)
                            invoicing.G = currentShare1.CT[1].Agent2;
                        if (currentShare2 != null)
                        {
                            invoicing.O = currentShare2.CT[1].Agent2;
                            invoicing.Q = currentShare2.CT[2].Agent2;
                        }
                        if (currentShare3 != null)
                        {
                            invoicing.AC = currentShare3.CT[1].Agent2;
                            invoicing.AE = currentShare3.CT[2].Agent2;
                            invoicing.AG = currentShare3.CT[3].Agent2;
                        }
                        if (market1 != null)
                            invoicing.H = market1.EF[1].Agent2;
                        if (market2 != null)
                        {
                            invoicing.P = market2.EF[1].Agent2;
                            invoicing.R = market2.EF[2].Agent2;
                        }
                        if (market3 != null)
                        {
                            invoicing.AD = market3.EF[1].Agent2;
                            invoicing.AF = market3.EF[2].Agent2;
                            invoicing.AH = market3.EF[3].Agent2;
                        }
                        break;
                    case AgentName.代3:
                        invoicing.C = currentShare0.CT[1].Agent3;
                        if (currentShare1 != null)
                            invoicing.G = currentShare1.CT[1].Agent3;
                        if (currentShare2 != null)
                        {
                            invoicing.O = currentShare2.CT[1].Agent3;
                            invoicing.Q = currentShare2.CT[2].Agent3;
                        }
                        if (currentShare3 != null)
                        {
                            invoicing.AC = currentShare3.CT[1].Agent3;
                            invoicing.AE = currentShare3.CT[2].Agent3;
                            invoicing.AG = currentShare3.CT[3].Agent3;
                        }
                        if (market1 != null)
                            invoicing.H = market1.EF[1].Agent3;
                        if (market2 != null)
                        {
                            invoicing.P = market2.EF[1].Agent3;
                            invoicing.R = market2.EF[2].Agent3;
                        }
                        if (market3 != null)
                        {
                            invoicing.AD = market3.EF[1].Agent3;
                            invoicing.AF = market3.EF[2].Agent3;
                            invoicing.AH = market3.EF[3].Agent3;
                        }

                        break;
                    case AgentName.代4:
                        invoicing.C = currentShare0.CT[1].Agent4;
                        if (currentShare1 != null)
                            invoicing.G = currentShare1.CT[1].Agent4;
                        if (currentShare2 != null)
                        {
                            invoicing.O = currentShare2.CT[1].Agent4;
                            invoicing.Q = currentShare2.CT[2].Agent4;
                        }
                        if (currentShare3 != null)
                        {
                            invoicing.AC = currentShare3.CT[1].Agent4;
                            invoicing.AE = currentShare3.CT[2].Agent4;
                            invoicing.AG = currentShare3.CT[3].Agent4;
                        }
                        if (market1 != null)
                            invoicing.H = market1.EF[1].Agent4;
                        if (market2 != null)
                        {
                            invoicing.P = market2.EF[1].Agent4;
                            invoicing.R = market2.EF[2].Agent4;
                        }
                        if (market3 != null)
                        {
                            invoicing.AD = market3.EF[1].Agent4;
                            invoicing.AF = market3.EF[2].Agent4;
                            invoicing.AH = market3.EF[3].Agent4;
                        }
                        break;
                    case AgentName.代5:
                        invoicing.C = currentShare0.CT[1].Agent5;
                        if (currentShare1 != null)
                            invoicing.G = currentShare1.CT[1].Agent5;
                        if (currentShare2 != null)
                        {
                            invoicing.O = currentShare2.CT[1].Agent5;
                            invoicing.Q = currentShare2.CT[2].Agent5;
                        }
                        if (currentShare3 != null)
                        {
                            invoicing.AC = currentShare3.CT[1].Agent5;
                            invoicing.AE = currentShare3.CT[2].Agent5;
                            invoicing.AG = currentShare3.CT[3].Agent5;
                        }
                        if (market1 != null)
                            invoicing.H = market1.EF[1].Agent5;
                        if (market2 != null)
                        {
                            invoicing.P = market2.EF[1].Agent5;
                            invoicing.R = market2.EF[2].Agent5;
                        }
                        if (market3 != null)
                        {
                            invoicing.AD = market3.EF[1].Agent5;
                            invoicing.AF = market3.EF[2].Agent5;
                            invoicing.AH = market3.EF[3].Agent5;
                        }
                        break;
                    case AgentName.代6:
                        invoicing.C = currentShare0.CT[1].Agent6;
                        if (currentShare1 != null)
                            invoicing.G = currentShare1.CT[1].Agent6;
                        if (currentShare2 != null)
                        {
                            invoicing.O = currentShare2.CT[1].Agent6;
                            invoicing.Q = currentShare2.CT[2].Agent6;
                        }
                        if (currentShare3 != null)
                        {
                            invoicing.AC = currentShare3.CT[1].Agent6;
                            invoicing.AE = currentShare3.CT[2].Agent6;
                            invoicing.AG = currentShare3.CT[3].Agent6;
                        }
                        if (market1 != null)
                            invoicing.H = market1.EF[1].Agent6;
                        if (market2 != null)
                        {
                            invoicing.P = market2.EF[1].Agent6;
                            invoicing.R = market2.EF[2].Agent6;
                        }
                        if (market3 != null)
                        {
                            invoicing.AD = market3.EF[1].Agent6;
                            invoicing.AF = market3.EF[2].Agent6;
                            invoicing.AH = market3.EF[3].Agent6;
                        }

                        break;
                    default:
                        break;
                }
            }

            if (market1 != null) invoicings.ForEach(s => s.F_MarketPrice_CN5 = market1.CM[1].S);
            if (market2 != null)
            {
                invoicings.ForEach(s => s.F_MarketPrice_CN6 = market2.CM[1].S);
                invoicings.ForEach(s => s.F_MarketPrice_CQ6 = market2.CM[2].S);

            }
            if (market3 != null)
            {
                invoicings.ForEach(s => s.F_MarketPrice_CN7 = market3.CM[1].S);
                invoicings.ForEach(s => s.F_MarketPrice_CQ7 = market3.CM[2].S);
                invoicings.ForEach(s => s.F_MarketPrice_CT7 = market3.CM[3].S);

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
        public decimal E { get; set; }
        public decimal F { get { return E * F_MarketPrice_CN5; } }
        private decimal g;
        public decimal G
        {
            get
            { return g; }
            set
            {
                g = decimal.Round((D + E) < value ? D + E : value, 0);
            }
        }
        private decimal h;
        public decimal H { get { return h; } set { h = G * value; } }
        public decimal I { get { return D + E - G > 0 ? D + E - G : 0; } }
        public decimal J { get { return I * F_MarketPrice_CN5; } }
        public decimal K { get; set; }
        public decimal L { get { return K * F_MarketPrice_CN6; } }
        public decimal M { get; set; }
        public decimal N { get { return K * F_MarketPrice_CQ6; } }
        private decimal o;
        public decimal O
        {
            get
            { return o; }
            set
            {
                o = decimal.Round((I + K) < value ? I + K : value, 0);
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
                q = decimal.Round(M < value ? M : value, 0);
            }
        }
        private decimal r;
        public decimal R { get { return r; } set { r = Q * value; } }
        public decimal S { get { return I + K - O > 0 ? I + K - O : 0; } }
        public decimal T { get { return S * F_MarketPrice_CN6; } }
        public decimal U { get { return M - Q; } }
        public decimal V { get { return U * F_MarketPrice_CQ6; } }
        public decimal W { get; set; }
        public decimal X { get { return W * F_MarketPrice_CN7; } }
        public decimal Y { get; set; }
        public decimal Z { get { return Y * F_MarketPrice_CQ7; } }
        public decimal AA { get; set; }
        public decimal AB { get { return AA * F_MarketPrice_CT7; } }
        private decimal ac;
        public decimal AC
        {
            get
            { return ac; }
            set
            {
                ac = decimal.Round(S + W < value ? S + W : value, 0);
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
                ae = decimal.Round((U + Y) < value ? U + Y : value, 0);
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
                ag = decimal.Round(AA < value ? AA : value, 0);
            }
        }
        private decimal ah;
        public decimal AH { get { return ah; } set { ah = AG * value; } }
        public decimal AI { get { return S + W - AC > 0 ? S + W - AC : 0; } }
        public decimal AJ { get { return AI * F_MarketPrice_CN7; } }
        public decimal AK { get { return U + Y - AE > 0 ? U + Y - AE : 0; } }
        public decimal AL { get { return AK * F_MarketPrice_CQ7; } }
        public decimal AM { get { return AA - AG; } }
        public decimal AN { get { return AM * F_MarketPrice_CT7; } }
        public decimal F_MarketPrice_CN5 { get; internal set; }
        public decimal F_MarketPrice_CN6 { get; internal set; }
        public decimal F_MarketPrice_CQ6 { get; internal set; }
        public decimal F_MarketPrice_CN7 { get; internal set; }
        public decimal F_MarketPrice_CQ7 { get; internal set; }
        public decimal F_MarketPrice_CT7 { get; internal set; }
    }
}