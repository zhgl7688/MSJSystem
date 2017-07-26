using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
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
        public int D { get; internal set; }
        public int I { get; internal set; }
        public int G { get; internal set; }
        public int H { get; internal set; }
    }
}