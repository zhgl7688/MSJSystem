using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class MP
    {
        public decimal M { get; set; }
        public decimal J { get; set; }
        public List<decimal> Agent { get; set; } = new List<decimal>();
        //public decimal Agent1 { get; set; }
        //public decimal Agent2 { get; set; }
        //public decimal Agent3 { get; set; }
        //public decimal Agent4 { get; set; }
        //public decimal Agent5 { get; set; }
        //public decimal Agent6 { get; set; }

    }
}