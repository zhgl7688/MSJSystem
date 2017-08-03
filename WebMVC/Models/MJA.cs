using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class MJA
    {
        public decimal M1 { get; set; }
        public decimal M2 { get; set; }
        public decimal M3 { get; set; }
        public decimal M4 { get; set; }
        public decimal M5 { get; set; }
        public decimal M6 { get; set; }
        public decimal J1 { get; set; }
        public decimal J2 { get; set; }
        public decimal J3 { get; set; }
        public decimal J4 { get; set; }
        public decimal J5 { get; set; }
        public decimal J6 { get; set; }
        public decimal Agent1 { get; set; }
        public decimal Agent2 { get; set; }
        public decimal Agent3 { get; set; }
        public decimal Agent4 { get; set; }
        public decimal Agent5 { get; set; }
        public decimal Agent6 { get; set; }
        public decimal Average1 { get { return (M1 + J1 + Agent1) / 3; } }
        public decimal Average2 { get { return (M2 + J2 + Agent2) / 3; } }
        public decimal Average3 { get { return (M3 + J3 + Agent3) / 3; } }
        public decimal Average4 { get { return (M4 + J4 + Agent4) / 3; } }
        public decimal Average5 { get { return (M5 + J5 + Agent5) / 3; } }
        public decimal Average6 { get { return (M6 + J6 + Agent6) / 3; } }
        public decimal SumM
        {
            get { return M1 + M2 + M3 + M4 + M5 + M6; }
        }
        public decimal AverageM
        {
            get { return SumM/6m; }
        }
        public decimal SumJ
        {
            get { return J1 + J2 + J3 + J4 + J5 + J6; }
        }
        public decimal AverageJ
        {
            get { return SumJ / 6m; }
        }
        public decimal SumAgent
        {
            get { return Agent1 + Agent2 + Agent3 + Agent4 + Agent5 + Agent6; }
        }
        public decimal AverageAgent
        {
            get { return SumAgent / 6m; }
        }
    }
}