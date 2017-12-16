using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class MJA
    {

        public List<decimal> M1 { get; set; }
        
        public List<decimal> J1 { get; set; }
         
        public List<decimal> Agent1 { get; set; }
         
        public List<decimal> Average1 { get {
                List<decimal> av = new List<decimal>();
                for (int i = 0; i < M1.Count; i++)
                {
                   av.Add((M1[i] + J1[i] + Agent1[i]) / 3);
                }
                return av; } }
        
        public decimal SumM
        {
            get
            {
                return M1.Sum(s => s); }
        }
        public decimal AverageM
        {
            get { return M1.Average(s => s); }
        }
        public decimal SumJ
        {
            get { return J1.Sum(s => s); }
        }
        public decimal AverageJ
        {
            get { return J1.Average(s => s); }
        }
        public decimal SumAgent
        {
            get { return Agent1.Sum(s => s); }
        }
        public decimal AverageAgent
        {
            get { return Agent1.Average(s => s); }
        }
    }
}