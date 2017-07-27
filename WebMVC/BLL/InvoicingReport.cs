using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    /// <summary>
    /// 进销存报表
    /// </summary>
    public class InvoicingReport
    {
        List<Invoicing> invoicings = new List<Invoicing>();
        public List<Invoicing> Get()
        {
            return invoicings;
        }
    }
    public class Invoicing
    {
        public string 代理方 { get; internal set; }
        public decimal D { get; internal set; }
        public decimal I { get; internal set; }
        public decimal G { get; internal set; }
        public decimal H { get; internal set; }
    }
}