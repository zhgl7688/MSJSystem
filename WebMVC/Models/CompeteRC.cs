﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class CompeteRC
    {
 
        public List<decimal> RcM { get; set; } = new List<decimal>();
        //public decimal RC1M { get; set; }
        //public decimal RC2M { get; set; }
        //public decimal RC3M { get; set; }
        public List<decimal> RcS { get; set; } = new List<decimal>();

        public decimal RC1S { get; set; }
        public decimal RC2S { get; set; }
        public decimal RC3S { get; set; }
        public List<decimal> RcJ { get; set; } = new List<decimal>();

        //public decimal RC1J { get; set; }
        //public decimal RC2J { get; set; }

        //public decimal RC3J { get; set; }
    }
}